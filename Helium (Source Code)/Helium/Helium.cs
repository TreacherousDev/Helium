using Memory;
using MetroSet_UI.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Timers;
using Sunny.UI;
using Timer = System.Timers.Timer;
using NHotkey;
using NHotkey.WindowsForms;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace Helium
{


    public partial class HeliumForm : MetroSetForm
    {
        public Mem m = new Mem();
        private System.Timers.Timer processCheckTimer;
        private readonly Dictionary<String, int> _hotkeyMap;
        private readonly Dictionary<int, ToggleAction> _scriptActions;
        public delegate void ToggleAction();
        private bool isDragging = false;
        private Point joystickCenter;
        private float maxPitch = (float)Math.PI / 2; // Define max pitch range

        public HeliumForm()
        {
            InitializeComponent();
            pictureBox.Paint += PictureBox_Paint;
            pictureBox.MouseClick += PictureBox_MouseClick;
            pictureBox.MouseMove += PictureBox_MouseMove;
            cameraLookJoystick.MouseDown += Joystick_MouseDown;
            cameraLookJoystick.MouseMove += Joystick_MouseMove;
            cameraLookJoystick.MouseUp += Joystick_MouseUp;
            //HeliumForm.MouseLeave += Joystick_MouseLeave;



            // Set center point of joystick panel
            joystickCenter = new Point(cameraLookJoystick.Width / 2, cameraLookJoystick.Height / 2);


            _hotkeyMap = new Dictionary<string, int>
            {
                { "F1", 1 },
                { "F2", 2 },
                { "F3", 3 },
                { "F4", 4 },
                { "F5", 5 },
            };


            foreach (var kvp in _hotkeyMap)
            {
                HotkeyManager.Current.AddOrReplace(kvp.Key, (Keys)Enum.Parse(typeof(Keys), kvp.Key), HotKeyshandler);
            }

            // Some color overrides since the TabControl seems to be bugged and sets by default the ForeColor to Black even when the default color has been changed.
            Hispano.ForeColor = Color.Gray;
            proID.ForeColor = Color.White;
            Status.ForeColor = Color.White;
            HotKeysInfo.ForeColor = Color.White;

        }

        private void HotKeyshandler(object sender, HotkeyEventArgs e)
        {
            if (_hotkeyMap.TryGetValue(e.Name, out int scriptNumber))
            {
                ScriptHandler(scriptNumber);
            }
            e.Handled = true;
        }

        private void ScriptHandler(int scriptNumber)
        {
            if (_scriptActions.TryGetValue(scriptNumber, out ToggleAction action))
            {
                action();
            }
        }

        private void InfoClick(object sender, EventArgs e)
        {
            MessageBox.Show(
                "This option will reset itself/be bugged when changing between realms/rooms/overworlds. Please uncheck and check it again to reapply the effect.",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning

            );
        }

        private void InfoSlider(object sender, EventArgs e)
        {
            MessageBox.Show(
                 "This option will reset itself/be bugged when changing between realms/rooms/overworlds. Please slide the slider again to your desired view distance to reapply the effect.",
                 "Information",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning

            );
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartProcessCheckTimer();

            if (!HeliumWorker.IsBusy)
                HeliumWorker.RunWorkerAsync();
        }

        private void StartProcessCheckTimer()
        {
            processCheckTimer = new System.Timers.Timer(1000);
            processCheckTimer.Elapsed += ProcessCheckTimer_Elapsed;
            processCheckTimer.AutoReset = true;
            processCheckTimer.Enabled = true;
        }

        private bool hasReadMemory = false;
        private bool wasConnected = false;

        // This reads and tells you if the program can find the game process (Cubic.exe)
        private void ProcessCheckTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            processCheckTimer.Enabled = false;

            int pID = m.GetProcIdFromName("Cubic");
            bool openProc = pID > 0 && m.OpenProcess(pID);

            if (openProc)
            {
                this.Invoke(new Action(() =>
                {
                    UpdateLabel(procIDLabel, pID.ToString(), Color.Green);
                    UpdateLabel(getStatus, "CONNECTED", Color.Green);
                }));

                if (!wasConnected)
                {
                    wasConnected = true;
                    hasReadMemory = false;
                }

            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    UpdateLabel(procIDLabel, "DISCONNECTED", Color.Red);
                    UpdateLabel(getStatus, "DISCONNECTED", Color.Red);
                }));

                if (wasConnected)
                {
                    wasConnected = false;
                    hasReadMemory = false;  // Allow reading again in the future if the process gets disconnected.
                }
            }
            processCheckTimer.Enabled = true;
        }


        private void UpdateLabel(Label label, string text, Color color)
        {

            if (label.InvokeRequired)
            {
                label.Invoke((MethodInvoker)delegate
                {
                    label.Text = text;
                    label.ForeColor = color;
                });
            }
            else
            {
                label.Text = text;
                label.ForeColor = color;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (processCheckTimer != null)
            {
                processCheckTimer.Stop();
                processCheckTimer.Dispose();
            }

            HotkeyManager.Current.Remove("F1");
            HotkeyManager.Current.Remove("F2");
            HotkeyManager.Current.Remove("F3");
            HotkeyManager.Current.Remove("F4");
            HotkeyManager.Current.Remove("F5");
            base.OnFormClosing(e);
        }


        // From this point to the bottom is the main mod menu code

        private int viewDistanceSlider = 50;
        private float cameraMapX = 0;
        private float cameraMapY = 0;
        private float mappedX = 0;
        private float mappedY = 0;
        private float mappedZ = 0;

        private float lookAtX = 0;
        private float lookAtY = 0;
        private float lookAtZ = 0;

        private float cameraPositionX = 0;
        private float cameraPositionY = 0;
        private float cameraPositionZ = 0;

        private float yaw = 0; // Yaw angle (rotation around z-axis)
        private float pitch = 0; // Pitch angle (rotation around x-axis)
        private float yawJoystick = 0; // Yaw angle (rotation around z-axis)
        private float pitchJoystick = 0; // Yaw angle (rotation around z-axis)
        private float rotationSpeed = 0.05f; // Speed of rotation per iteration
        private float radius = 5; // Distance from the center point to rotating point

        private Timer _updateTimer;

        private void HeliumWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _updateTimer = new Timer(10);
            _updateTimer.Elapsed += UpdateMemoryOnTimerTick;
            _updateTimer.AutoReset = true;
            _updateTimer.Start();
        }

        private void UpdateMemoryOnTimerTick(object sender, ElapsedEventArgs e)
        {
            CheckAndUpdateMemory();
        }

        private float interpolationSpeed = 0.01f; // Adjust for faster or slower interpolation
        private float rotationInterpolationSpeed = 0.01f; // Adjust for faster or slower interpolation

        private void CheckAndUpdateMemory()
        {
            // Interpolate cameraMapX and cameraMapY towards mappedX and mappedY
            cameraMapX += (mappedX - cameraMapX) * interpolationSpeed;
            cameraMapY += (mappedY - cameraMapY) * interpolationSpeed;

            // Only write to memory if values are close enough to the target
            if (Math.Abs(cameraMapX - mappedX) > 0.2f || Math.Abs(cameraMapY - mappedY) > 0.2f)
            {
                m.WriteMemory("Cubic.exe+27DB05", "float", cameraMapX.ToString());
                m.WriteMemory("Cubic.exe+27DB09", "float", cameraMapY.ToString());
            }


            float targetZ = 100 - CameraHeightSlider.Value;
            // Interpolate mappedZ towards targetZ
            mappedZ += (targetZ - mappedZ) * interpolationSpeed;
            // Only write to memory if mappedZ is close enough to the target value
            if (Math.Abs(mappedZ - targetZ) > 0.1f)
            {
                m.WriteMemory("Cubic.exe+27DB0D", "float", mappedZ.ToString());
            }

            lookAtX = m.ReadFloat("Cubic.exe+27DB05");
            lookAtY = m.ReadFloat("Cubic.exe+27DB09");
            lookAtZ = m.ReadFloat("Cubic.exe+27DB0D");

            cameraPositionX = lookAtX + (float)(radius * (Math.Cos(yaw) * Math.Cos(pitch)));
            cameraPositionY = lookAtY + (float)(radius * (Math.Sin(yaw) * Math.Cos(pitch)));
            cameraPositionZ = lookAtZ + (float)(radius * (Math.Sin(pitch)));


            yaw += (yawJoystick - yaw) * rotationInterpolationSpeed;
            pitch += (pitchJoystick - pitch) * rotationInterpolationSpeed;

            if (pitch * (180 / (float)Math.PI) >= 90)
            {
                pitch = 89 / (float)(180 / Math.PI);
            }
            if (pitch * (180 / (float)Math.PI) <= -90)
            {
                pitch = -89 / (float)(180 / Math.PI);
            }


            m.WriteMemory("Cubic.exe+27DB63", "float", cameraPositionX.ToString());
            m.WriteMemory("Cubic.exe+27DB67", "float", cameraPositionY.ToString());
            m.WriteMemory("Cubic.exe+27DB6B", "float", cameraPositionZ.ToString());

            radius = (float)(RadiusSlider.Value);
            Console.WriteLine(pitchJoystick + " " + pitch);

        }

        private int dotSize = 5;  // Size of the dot
        private Point lastClickedPoint = Point.Empty;  // Stores the last clicked position

        // Draw the grid and the dot where last clicked
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            // Draw the dot at the last clicked position
            if (lastClickedPoint != Point.Empty)
            {
                var dotRect = new Rectangle(lastClickedPoint.X - dotSize / 2,
                                            lastClickedPoint.Y - dotSize / 2,
                                            dotSize, dotSize);
                e.Graphics.FillEllipse(Brushes.Red, dotRect);
            }
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            SetDotPosition(e.Location);
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SetDotPosition(e.Location);
            }
        }

        private void SetDotPosition(Point mouseLocation)
        {
            // Clamp the position to keep the dot within the PictureBox boundaries
            int x = Math.Max(dotSize / 2, Math.Min(mouseLocation.X, (pictureBox.Width - (dotSize + 1) / 2 - 1)));
            int y = Math.Max(dotSize / 2, Math.Min(mouseLocation.Y, (pictureBox.Height - (dotSize + 1) / 2 - 1)));

            // Map x and y to a range of 0 to 100 based on the PictureBox dimensions
            mappedX = ((x - dotSize / 2) / (float)(pictureBox.Width - dotSize) * 100);
            mappedY = ((y - dotSize / 2) / (float)(pictureBox.Height - dotSize) * 100);

            // Update the last clicked position and refresh the PictureBox
            lastClickedPoint = new Point(x, y);
            pictureBox.Invalidate();
        }

        private void Joystick_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
        }

        private void Joystick_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging)
            {
                //yawJoystick = 0;
                //pitchJoystick = 0;
                return;
            }

            // Calculate offset from center
            float offsetX = e.X - joystickCenter.X;
            float offsetY = joystickCenter.Y - e.Y;

            // Map offset to yaw and pitch
            yawJoystick = yaw + (offsetX / (cameraLookJoystick.Width / 2) / 4);
            pitchJoystick = pitch + (offsetY / (cameraLookJoystick.Height / 2) / 4);


            // Optionally redraw joystick position
            cameraLookJoystick.Invalidate();
            //Console.WriteLine(yawJoystick  + " " + pitchJoystick);
        }

        private void Joystick_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void Joystick_MouseLeave(object sender, EventArgs e)
        {
            isDragging = false;
        }

        private async void PlayAnimationButton_Click(object sender, EventArgs e)
        {
            mappedX = 49;
            mappedY = 81;
            CameraHeightSlider.Value = 30;
            interpolationSpeed = 0.1f;
            rotationInterpolationSpeed = 0.1f;
            yawJoystick = 0 * (float)(Math.PI / 180);
            pitchJoystick = -88 * (float)(Math.PI / 180);
            RadiusSlider.Value = 12;

            await Task.Delay(2000);

            CameraHeightSlider.Value = 10;
            interpolationSpeed = 0.01f;
            rotationInterpolationSpeed = 0.03f;
            yawJoystick = 0 * (float)(Math.PI / 180);
            pitchJoystick = -88 * (float)(Math.PI / 180);

            await Task.Delay(3000);

            CameraHeightSlider.Value = 2;
            //interpolationSpeed = 0.02f;
            mappedX = 36;
            interpolationSpeed = 0.006f;
            rotationInterpolationSpeed = 0.008f;
            yawJoystick = 0 * (float)(Math.PI / 180);
            pitchJoystick = -10 * (float)(Math.PI / 180);

            await Task.Delay(6000);


            mappedX = 5;
            mappedY = 81;
            interpolationSpeed = 0.002f;
        }
    }
}