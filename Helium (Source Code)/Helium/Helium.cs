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
using System.Linq;
using System.Data.SqlTypes;


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
            //HeliumForm.MouseLeave += Joystick_MouseLeave;






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
            metroSetLabel1.ForeColor = Color.White;
            metroSetLabel2.ForeColor = Color.White;

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
                    scriptInjected = false;
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

        private double currentCameraLookAtX = 30;
        private double currentCameraLookAtY = 30;
        private double currentCameraLookAtZ = 70;
        private double targetCameraLookAtX = 20;
        private double targetCameraLookAtY = 20;
        private double targetCameraLookAtZ = 70;
        private double cameraMoveDirectionX;
        private double cameraMoveDirectionY;
        private double cameraMoveDirectionZ;
        private double cameraMoveDistance;

        double currentCameraPitch = 30;
        double currentCameraYaw = 30;
        double targetCameraPitch = 20;
        double targetCameraYaw = 20;
        private double cameraRotateDirectionPitch;
        private double cameraRotateDirectionYaw;
        private double cameraRotateDistance;

        bool scriptInjected = false;
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

        private double interpolationSpeed = 0.25f; // Adjust for faster or slower interpolation
        private double rotationSpeed = 0.05f; // Adjust for faster or slower interpolation
        string freecamFunctionEntry = "E9 5A 05 C7 00 0F 1F 40 00";
        string freecamFunctionOriginal = "F3 0F 11 1E F3 0F 11 4E 04";
        string freecamInjection = "F3 0F 10 1D 0F 90 6C 01 F3 0F 10 0D 1F 90 6C 01 F3 0F 10 05 2F 90 6C 01 50 8D 46 10 A3 3F 90 6C 01 58 F3 0F 11 1E F3 0F 11 4E 04 E9 7A FA 38 FF";
        
        
        private void CheckAndUpdateMemory()
        {
            if (FreecamSwitch.Switched == true)
            {
                m.WriteMemory("Cubic.exe+1B8A80", "bytes", freecamFunctionEntry);
                m.WriteMemory("Cubic.exe+E28FDF", "bytes", freecamInjection);  
            }
            else
            {
                m.WriteMemory("Cubic.exe+1B8A80", "bytes", freecamFunctionOriginal);
            }
            
            if (scriptInjected == false && getStatus.Text == "CONNECTED") 
            {
                scriptInjected = true;
                string cameraCoordinatesFunction = "90 90 90 90 90 90 90 90 90 90 90 90";
                string cameraLookAtEditorInjection = "50 E8 00 00 00 00 58 F3 0F 10 58 29 F3 0F 10 48 2D F3 0F 10 40 31 58 50 8D 46 10 A3 1A 90 6C 01 58 F3 0F 11 1E F3 0F 11 4E 04 E9 7B FA 38 FF 00 00 00 00 00 00 00 00 00 00 8C 42 00 00 00 00";
                string cameraLookAtEditorFunctionEntry = "E9 71 05 C7 00 0F 1F 40 00";
                string cameraHeightInjection = "53 E8 00 00 00 00 5B F3 0F 5C 43 1B F3 0F 11 40 08 5B F3 0F 5C CB 8D 85 FC FE FF FF E9 72 34 39 FF 66 66 A6 3F";
                string cameraHeightFunctionEntry = "E9 72 CB C6 00 0F 1F 44 00 00";
                string unlockCameraArrowsInjection = "50 E8 00 00 00 00 58 F3 0F 10 58 2D 0F 2F D8 58 0F 86 AA F7 38 FF C7 86 EC 09 00 00 00 00 B2 C2 E9 9B F7 38 FF 0F 2F D8 0F 86 92 F7 38 FF E9 86 F7 38 FF 00 00 B2 C2";
                string unlockCameraArrowsFunctionEntry = "E9 47 08 C7 00";
                string unlockCameraRMBInjection = "50 E8 00 00 00 00 58 F3 0F 10 70 1F 0F 2F F1 58 0F 86 55 0E 3A FF C7 80 EC 09 00 00 00 00 B2 C2";
                string unlockCameraRMBFunctionEntry = "E9 9C F1 C5 00";
                string unlockCameraFOVInjection = "50 E8 00 00 00 00 58 0F 2F 48 2D F3 0F 11 48 31 F3 0F 10 48 31 58 F3 0F 11 8E E8 07 00 00 0F 86 EC 03 39 FF C7 86 E8 07 00 00 00 00 F0 42 E9 DD 03 39 FF 00 00 F0 42 00 00 70 42";
                string unlockCameraFOVFunctionEntry = "E9 FE FB C6 00 66 90";
                string getPlayerCoordinatesInjection = "50 E8 00 00 00 00 58 F3 0F 11 58 1F F3 0F 11 48 23 F3 0F 11 40 27 58 F3 0F 11 1E F3 0F 11 4E 04 E9 F3 FB 38 FF 22 8D 5B 42 52 D6 5B 42 F6 FF C1 42";
                string getPlayerCoordinatesFunctionEntry = "E9 EC 03 C7 00 0F 1F 40 00";
                string adjustCameraDistanceInjection = "50 E8 00 00 00 00 58 F3 0F 59 40 16 F3 0F 59 58 16 F3 0F 59 60 16 58 E9 08 00 00 00 00 00 B4 41";
                string adjustCameraDistanceFunctionEntry = "E9 CC CD C6 00 0F 1F 40 00";
                //string hidePlayerAvatar

                m.WriteMemory("Cubic.exe+1BC1A5", "bytes", cameraCoordinatesFunction);
                m.WriteMemory("Cubic.exe+E28FDF", "bytes", cameraLookAtEditorInjection);
                m.WriteMemory("Cubic.exe+1B8A80", "bytes", cameraLookAtEditorFunctionEntry);
                m.WriteMemory("Cubic.exe+E28D31", "bytes", cameraHeightInjection);
                m.WriteMemory("Cubic.exe+1BC1BA", "bytes", cameraHeightFunctionEntry);
                m.WriteMemory("Cubic.exe+E28D7A", "bytes", unlockCameraArrowsInjection);
                m.WriteMemory("Cubic.exe+1B852E", "bytes", unlockCameraArrowsFunctionEntry);
                m.WriteMemory("Cubic.exe+E28DC8", "bytes", unlockCameraRMBInjection);
                m.WriteMemory("Cubic.exe+1C9C27", "bytes", unlockCameraRMBFunctionEntry);
                m.WriteMemory("Cubic.exe+E28E05", "bytes", unlockCameraFOVInjection);
                m.WriteMemory("Cubic.exe+1B9202", "bytes", unlockCameraFOVFunctionEntry);
                m.WriteMemory("Cubic.exe+E28E71", "bytes", getPlayerCoordinatesInjection);
                m.WriteMemory("Cubic.exe+1B8A80", "bytes", getPlayerCoordinatesFunctionEntry);
                m.WriteMemory("Cubic.exe+E28F82", "bytes", adjustCameraDistanceInjection);
                m.WriteMemory("Cubic.exe+1BC1B1", "bytes", adjustCameraDistanceFunctionEntry);
            }

            uint intRotationAddress = m.ReadUInt("Cubic.exe+E2903F");
            string pitchAddress = (intRotationAddress+4).ToString("X");
            string yawAddress = (intRotationAddress).ToString("X");
            //Console.WriteLine(rotationAddress);

            // Calculate the direction vector towards the target
            cameraMoveDirectionX = targetCameraLookAtX - currentCameraLookAtX;
            cameraMoveDirectionY = targetCameraLookAtY - currentCameraLookAtY;
            cameraMoveDirectionZ = targetCameraLookAtZ - currentCameraLookAtZ;
            //Normalize distance
            cameraMoveDistance = Math.Sqrt(cameraMoveDirectionX * cameraMoveDirectionX + cameraMoveDirectionY * cameraMoveDirectionY + cameraMoveDirectionZ * cameraMoveDirectionZ);
            
            //Interpolate and move to target location
            //Snap to target if close enough
            if (cameraMoveDistance < interpolationSpeed) 
            {
                currentCameraLookAtX = targetCameraLookAtX;
                currentCameraLookAtY = targetCameraLookAtY;
                currentCameraLookAtZ = targetCameraLookAtZ;
            }
            else {
                // Normalize the direction vector and move towards the target
                currentCameraLookAtX += cameraMoveDirectionX / cameraMoveDistance * interpolationSpeed;
                currentCameraLookAtY += cameraMoveDirectionY / cameraMoveDistance * interpolationSpeed;
                currentCameraLookAtZ += cameraMoveDirectionZ / cameraMoveDistance * interpolationSpeed;
            }


            currentCameraPitch = m.ReadFloat(pitchAddress);
            currentCameraYaw = m.ReadFloat(yawAddress);

            // Calculate the direction vector towards the target
            cameraRotateDirectionPitch = targetCameraPitch - currentCameraPitch;
            cameraRotateDirectionYaw = targetCameraYaw - currentCameraYaw;
            //Normalize distance
            cameraRotateDistance = Math.Sqrt(cameraRotateDirectionPitch * cameraRotateDirectionPitch + cameraRotateDirectionYaw * cameraRotateDirectionYaw);

            //Interpolate and move to target location
            //Snap to target if close enough
            if (cameraRotateDistance < rotationSpeed)
            {
                currentCameraPitch = targetCameraPitch;
                currentCameraYaw = targetCameraYaw;
            }
            else
            {
                // Normalize the direction vector and move towards the target
                currentCameraPitch += cameraRotateDirectionPitch / cameraRotateDistance * rotationSpeed;
                currentCameraYaw += cameraRotateDirectionYaw / cameraRotateDistance * rotationSpeed;
            }

            //Console.WriteLine(currentCameraPitch + " " + targetCameraPitch);
            //currentCameraYaw += (targetCameraYaw - currentCameraYaw) * rotationSpeed;
            //currentCameraPitch += (targetCameraPitch - currentCameraPitch) * rotationSpeed;
            



            m.WriteMemory("Cubic.exe+E2900F", "float", currentCameraLookAtX.ToString());
            m.WriteMemory("Cubic.exe+E2901F", "float", currentCameraLookAtY.ToString());
            m.WriteMemory("Cubic.exe+E2902F", "float", currentCameraLookAtZ.ToString());

            if (FreecamSwitch.Switched == true && isAnimationPlaying == true)
            {
                m.WriteMemory(pitchAddress, "float", currentCameraPitch.ToString());
                m.WriteMemory(yawAddress, "float", currentCameraYaw.ToString());
            }
                




            //Console.WriteLine(currentCameraLookAtX + " " + currentCameraLookAtY + " " + currentCameraLookAtZ);
            UpdateLabel(cameraInfoLabel, $"PositionX: {currentCameraLookAtX:F2} PositionY: {currentCameraLookAtY:F2} PositionZ: {currentCameraLookAtZ:F2} Pitch: {currentCameraPitch:F2} Yaw: {currentCameraYaw:F2} ", Color.Red);

        }

        private int dotSize = 5;
        private Point lastClickedPoint = Point.Empty;
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
            targetCameraLookAtX = ((x - dotSize / 2) / (float)(pictureBox.Width - dotSize) * 100);
            targetCameraLookAtY = ((y - dotSize / 2) / (float)(pictureBox.Height - dotSize) * 100);

            // Update the last clicked position and refresh the PictureBox
            lastClickedPoint = new Point(x, y);
            pictureBox.Invalidate();
        }

        private void Joystick_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;


        }
       
        List<List<double>> animationFrames = new List<List<double>>();
        bool isAnimationPlaying = false;
        private async void PlayAnimationButton_Click(object sender, EventArgs e)
        {
            isAnimationPlaying = true;
            foreach (List<double> frame in animationFrames)
            {
                Console.WriteLine("a");
                targetCameraLookAtX = frame[0];
                targetCameraLookAtY = frame[1];
                targetCameraLookAtZ = frame[2];
                targetCameraPitch = frame[3];
                targetCameraYaw = frame[4];
                interpolationSpeed = frame[5]; 
                rotationSpeed = frame[6];

                await Task.Delay(100);
                while (cameraMoveDistance > 0.5)
                {
                    await Task.Delay(100);
                }
            }
            isAnimationPlaying = false;
        }

        private void CameraHeightSlider_Scroll(object sender)
        {
            targetCameraLookAtZ = 100 - CameraHeightSlider.Value;
        }

        private void CameraUp_Click(object sender, EventArgs e)
        {

        }

        
        private void AddAnimationFrameButton_Click(object sender, EventArgs e)
        {
            List<double> frame = new List<double>();
            frame.Add(currentCameraLookAtX);
            frame.Add(currentCameraLookAtY);
            frame.Add(currentCameraLookAtZ);
            frame.Add(currentCameraPitch);
            frame.Add(currentCameraYaw);
            frame.Add(interpolationSpeed);
            frame.Add(rotationSpeed);
            animationFrames.Add(frame);
        }
    }
}