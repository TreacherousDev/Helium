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
            metroSetLabel8.ForeColor = Color.White;
            metroSetLabel4.ForeColor = Color.White;
            metroSetLabel7.ForeColor = Color.White;

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

        private double interpolationSpeed = 0.1f; // Adjust for faster or slower interpolation
        private double rotationSpeed = 1f; // Adjust for faster or slower interpolation

        // Persistent Functions (Required for the engine to function)
        readonly string cameraCoordinatesFunction = "90 90 90 90 90 90 90 90 90 90 90 90";
        readonly string cameraHeightInjection = "53 E8 00 00 00 00 5B F3 0F 5C 43 1B F3 0F 11 40 08 5B F3 0F 5C CB 8D 85 FC FE FF FF E9 72 34 39 FF 66 66 A6 3F";
        readonly string cameraHeightFunctionEntry = "E9 72 CB C6 00 0F 1F 44 00 00";

        readonly string unlockCameraArrowsInjection = "50 E8 00 00 00 00 58 F3 0F 10 58 1F 0F 2F D8 58 0F 86 AA F7 38 FF C7 86 EC 09 00 00 00 00 B2 C2 E9 9B F7 38 FF 00 00 B2 C2 86 92 F7 38 FF E9 86 F7 38 FF 00 00 B2 C2";
        readonly string unlockCameraArrowsFunctionEntry = "E9 47 08 C7 00";

        readonly string unlockCameraRMBInjection = "50 E8 00 00 00 00 58 F3 0F 10 70 1F 0F 2F F1 58 0F 86 55 0E 3A FF C7 80 EC 09 00 00 00 00 B2 C2 E9 46 0E 3A FF 00 00 B2 C2 FF 00 00 B2 C2";
        readonly string unlockCameraRMBFunctionEntry = "E9 9C F1 C5 00";

        readonly string unlockCameraFOVInjection = "50 E8 00 00 00 00 58 F3 0F 10 40 12 58 8D 85 D8 FE FF FF E9 D7 33 39 FF 00 00 70 42";
        readonly string unlockCameraFOVFunctionEntry = "E9 12 CC C6 00 90";

        readonly string getPlayerCoordinatesInjection = "50 E8 00 00 00 00 58 F3 0F 11 58 1F F3 0F 11 48 23 F3 0F 11 40 27 58 F3 0F 11 1E F3 0F 11 4E 04 E9 F3 FB 38 FF 22 8D 5B 42 52 D6 5B 42 F6 FF C1 42";
        readonly string getPlayerCoordinatesFunctionEntry = "E9 EC 03 C7 00 0F 1F 40 00";

        readonly string adjustCameraDistanceInjection = "50 E8 00 00 00 00 58 F3 0F 59 40 24 F3 0F 59 58 24 F3 0F 59 60 24 58 E9 00 00 00 00 F3 0F 5C D0 F3 0F 10 40 08 E9 0E 32 39 FF 00 00 B4 41 FF FF FF FF";
        readonly string adjustCameraDistanceFunctionEntry = "E9 CC CD C6 00 0F 1F 40 00";

        // Revertable functions (Optional switch states available)
        readonly string cameraLookAtEditorInjection = "50 E8 00 00 00 00 58 F3 0F 10 58 2F F3 0F 10 48 33 F3 0F 10 40 37 58 50 E8 00 00 00 00 58 53 8D 5E 10 89 58 24 5B 58 F3 0F 11 1E F3 0F 11 4E 04 E9 75 FA 38 FF 00 00 00 00 00 00 00 00 00 00 8C 42 00 00 00 00";
        readonly string cameraLookAtEditorFunctionEntry = "E9 5A 05 C7 00 0F 1F 40 00";
        readonly string cameraLookAtEditorFunctionOriginal = "E9 71 05 C7 00 0F 1F 40 00";

        readonly string hidePlayerAvatarInjection = "53 E8 00 00 00 00 5B F3 0F 10 7D 08 F3 0F 5C 7B B9 50 F3 0F 11 7B 65 8B 43 65 23 43 5D 66 0F 6E F8 58 0F 2E 7B 61 0F 83 2C 00 00 00 F3 0F 10 7D 0C F3 0F 5C 7B BD 50 F3 0F 11 7B 65 8B 43 65 23 43 5D 66 0F 6E F8 58 0F 2E 7B 61 0F 83 07 00 00 00 C7 45 10 00 00 C8 C2 5B F3 0F 10 45 10 E9 C3 64 37 FF FF FF FF 7F 9A 99 99 3E 18 7A 91 C0";
        readonly string hidePlayerAvatarFunctionEntry = "E9 DA 9A C8 00";
        readonly string hidePlayerAvatarFunctionOriginal = "F3 0F 10 45 10";

        

        private bool isFreecamEnabled = false;
        private bool isHidePlayerModelEnabled = false;
        private int cameraFOVSliderValue = 0;
        private int cameraDistanceSliderValue = 0;
        private void CheckAndUpdateMemory()
        {
            uint intRotationAddress = m.ReadUInt("Cubic.exe+E29020");
            string pitchAddress = (intRotationAddress + 4).ToString("X");
            string yawAddress = (intRotationAddress).ToString("X");

            //initial injection script that lays the foundation for the UI to access the camera settings addresses
            if (scriptInjected == false && getStatus.Text == "CONNECTED")
            {
                scriptInjected = true;
                m.WriteMemory("Cubic.exe+1BC1A5", "bytes", cameraCoordinatesFunction);

                // Special case for cameraLookAtEditor
                // Always inject, but skip assignment if deactivated (inject to the adress after assignment)
                m.WriteMemory("Cubic.exe+E28FDF", "bytes", cameraLookAtEditorInjection);
                m.WriteMemory("Cubic.exe+1B8A80", "bytes", cameraLookAtEditorFunctionOriginal);
                
                m.WriteMemory("Cubic.exe+E28D31", "bytes", cameraHeightInjection);
                m.WriteMemory("Cubic.exe+1BC1BA", "bytes", cameraHeightFunctionEntry);
                m.WriteMemory("Cubic.exe+E28D7A", "bytes", unlockCameraArrowsInjection);
                m.WriteMemory("Cubic.exe+1B852E", "bytes", unlockCameraArrowsFunctionEntry);
                m.WriteMemory("Cubic.exe+E28DC8", "bytes", unlockCameraRMBInjection);
                m.WriteMemory("Cubic.exe+1C9C27", "bytes", unlockCameraRMBFunctionEntry);
                m.WriteMemory("Cubic.exe+E28E05", "bytes", unlockCameraFOVInjection);
                m.WriteMemory("Cubic.exe+1BC1EE", "bytes", unlockCameraFOVFunctionEntry);
                m.WriteMemory("Cubic.exe+E28E71", "bytes", getPlayerCoordinatesInjection);
                m.WriteMemory("Cubic.exe+1B8A80", "bytes", getPlayerCoordinatesFunctionEntry);
                m.WriteMemory("Cubic.exe+E28F82", "bytes", adjustCameraDistanceInjection);
                m.WriteMemory("Cubic.exe+1BC1B1", "bytes", adjustCameraDistanceFunctionEntry);

                //Revertable, injections only as set to false by default
                m.WriteMemory("Cubic.exe+E28ED7", "bytes", hidePlayerAvatarInjection);
            }

            if (FreecamSwitch.Switched != isFreecamEnabled)
            {
                isFreecamEnabled = FreecamSwitch.Switched;
                if (isFreecamEnabled == true)
                {
                    m.WriteMemory("Cubic.exe+1B8A80", "bytes", cameraLookAtEditorFunctionEntry);
                }
                else
                {
                    m.WriteMemory("Cubic.exe+1B8A80", "bytes", cameraLookAtEditorFunctionOriginal);
                }
            }

            if (HidePlayerModelSwitch.Switched != isHidePlayerModelEnabled) 
            {
                isHidePlayerModelEnabled = HidePlayerModelSwitch.Switched;
                if (isHidePlayerModelEnabled == true)
                {
                    m.WriteMemory("Cubic.exe+19F3F8", "bytes", hidePlayerAvatarFunctionEntry);
                }
                else
                {
                    m.WriteMemory("Cubic.exe+19F3F8", "bytes", hidePlayerAvatarFunctionOriginal);
                }
            }

            if (CameraFOVSlider.Value != cameraFOVSliderValue)
            {
                cameraFOVSliderValue = CameraFOVSlider.Value;
                m.WriteMemory("Cubic.exe+E28E1D", "float", CameraFOVSlider.Value.ToString());
            }

            if (CameraDistanceSlider.Value != cameraDistanceSliderValue)
            {
                cameraDistanceSliderValue = CameraDistanceSlider.Value;
                m.WriteMemory("Cubic.exe+E28FAC", "float", CameraDistanceSlider.Value.ToString());
            }


            

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


            if (FreecamSwitch.Switched == true)
            {
                if (isAnimationPlaying == true)
                {
                    m.WriteMemory(pitchAddress, "float", currentCameraPitch.ToString());
                    m.WriteMemory(yawAddress, "float", currentCameraYaw.ToString());
                }
                m.WriteMemory("Cubic.exe+E29014", "float", currentCameraLookAtX.ToString());
                m.WriteMemory("Cubic.exe+E29018", "float", currentCameraLookAtY.ToString());
                m.WriteMemory("Cubic.exe+E2901C", "float", currentCameraLookAtZ.ToString());
            }
                




            //Console.WriteLine(currentCameraLookAtX + " " + currentCameraLookAtY + " " + currentCameraLookAtZ);
            UpdateLabel(cameraInfoLabel, $"PositionX: {currentCameraLookAtX:F2} PositionY: {currentCameraLookAtY:F2} PositionZ: {currentCameraLookAtZ:F2} Camera Pitch: {currentCameraPitch:F2} Camera Yaw: {currentCameraYaw:F2} ", Color.Red);

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

                // Calculate rotation speed dynamically based on distance
                // This allows us to haave smoother transitions as rotations will end on hte exact keyframe
                // that the camera arrives to its destination

                // Distance to target formula for 3D vector
                double moveDistance = Math.Sqrt(
                    Math.Pow(targetCameraLookAtX - currentCameraLookAtX, 2) +
                    Math.Pow(targetCameraLookAtY - currentCameraLookAtY, 2) +
                    Math.Pow(targetCameraLookAtZ - currentCameraLookAtZ, 2)
                );

                // Distance to target formula for 2D vector
                double rotateDistance = Math.Sqrt(
                    Math.Pow(targetCameraPitch - currentCameraPitch, 2) +
                    Math.Pow(targetCameraYaw - currentCameraYaw, 2)
                );

                // Calculate new rotation speed
                double timeToTarget = moveDistance / interpolationSpeed;
                rotationSpeed = rotateDistance / timeToTarget;

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