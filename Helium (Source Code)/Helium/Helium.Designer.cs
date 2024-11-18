
namespace Helium
{
    partial class HeliumForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeliumForm));
            this.metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
            this.HeliumWorker = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.CameraTweaks = new System.Windows.Forms.TabPage();
            this.metroSetLabel4 = new MetroSet_UI.Controls.MetroSetLabel();
            this.metroSetTrackBar4 = new MetroSet_UI.Controls.MetroSetTrackBar();
            this.metroSetLabel6 = new MetroSet_UI.Controls.MetroSetLabel();
            this.metroSetTrackBar5 = new MetroSet_UI.Controls.MetroSetTrackBar();
            this.metroSetLabel7 = new MetroSet_UI.Controls.MetroSetLabel();
            this.metroSetTrackBar6 = new MetroSet_UI.Controls.MetroSetTrackBar();
            this.metroSetLabel8 = new MetroSet_UI.Controls.MetroSetLabel();
            this.metroSetSwitch2 = new MetroSet_UI.Controls.MetroSetSwitch();
            this.Information = new System.Windows.Forms.TabPage();
            this.HotKeysInfo = new MetroSet_UI.Controls.MetroSetLabel();
            this.Status = new MetroSet_UI.Controls.MetroSetLabel();
            this.getStatus = new MetroSet_UI.Controls.MetroSetLabel();
            this.Hispano = new MetroSet_UI.Controls.MetroSetLabel();
            this.proID = new MetroSet_UI.Controls.MetroSetLabel();
            this.procIDLabel = new MetroSet_UI.Controls.MetroSetLabel();
            this.Utility = new System.Windows.Forms.TabPage();
            this.cameraInfoLabel = new MetroSet_UI.Controls.MetroSetLabel();
            this.PlayAnimationButton = new MetroSet_UI.Controls.MetroSetButton();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.CameraHeightSlider = new MetroSet_UI.Controls.MetroSetTrackBar();
            this.TabControl = new Sunny.UI.UITabControl();
            this.FreecamSwitch = new MetroSet_UI.Controls.MetroSetSwitch();
            this.AddAnimationFrameButton = new MetroSet_UI.Controls.MetroSetButton();
            this.metroSetLabel1 = new MetroSet_UI.Controls.MetroSetLabel();
            this.metroSetLabel2 = new MetroSet_UI.Controls.MetroSetLabel();
            this.CameraTweaks.SuspendLayout();
            this.Information.SuspendLayout();
            this.Utility.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.TabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroSetControlBox1
            // 
            this.metroSetControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroSetControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.metroSetControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.metroSetControlBox1.CloseNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.DisabledForeColor = System.Drawing.Color.Silver;
            this.metroSetControlBox1.IsDerivedStyle = true;
            this.metroSetControlBox1.Location = new System.Drawing.Point(397, 11);
            this.metroSetControlBox1.MaximizeBox = false;
            this.metroSetControlBox1.MaximizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetControlBox1.MaximizeHoverForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MaximizeNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MinimizeBox = true;
            this.metroSetControlBox1.MinimizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetControlBox1.MinimizeHoverForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MinimizeNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.Name = "metroSetControlBox1";
            this.metroSetControlBox1.Size = new System.Drawing.Size(100, 25);
            this.metroSetControlBox1.Style = MetroSet_UI.Enums.Style.Dark;
            this.metroSetControlBox1.StyleManager = null;
            this.metroSetControlBox1.TabIndex = 0;
            this.metroSetControlBox1.Text = "metroSetControlBox1";
            this.metroSetControlBox1.ThemeAuthor = "Narwin";
            this.metroSetControlBox1.ThemeName = "MetroDark";
            // 
            // HeliumWorker
            // 
            this.HeliumWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.HeliumWorker_DoWork);
            // 
            // CameraTweaks
            // 
            this.CameraTweaks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.CameraTweaks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CameraTweaks.Controls.Add(this.metroSetLabel4);
            this.CameraTweaks.Controls.Add(this.metroSetTrackBar4);
            this.CameraTweaks.Controls.Add(this.metroSetLabel6);
            this.CameraTweaks.Controls.Add(this.metroSetTrackBar5);
            this.CameraTweaks.Controls.Add(this.metroSetLabel7);
            this.CameraTweaks.Controls.Add(this.metroSetTrackBar6);
            this.CameraTweaks.Controls.Add(this.metroSetLabel8);
            this.CameraTweaks.Controls.Add(this.metroSetSwitch2);
            this.CameraTweaks.ForeColor = System.Drawing.Color.White;
            this.CameraTweaks.Location = new System.Drawing.Point(0, 30);
            this.CameraTweaks.Name = "CameraTweaks";
            this.CameraTweaks.Size = new System.Drawing.Size(482, 215);
            this.CameraTweaks.TabIndex = 3;
            this.CameraTweaks.Text = "Camera Tweaks";
            // 
            // metroSetLabel4
            // 
            this.metroSetLabel4.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroSetLabel4.IsDerivedStyle = true;
            this.metroSetLabel4.Location = new System.Drawing.Point(14, 66);
            this.metroSetLabel4.Name = "metroSetLabel4";
            this.metroSetLabel4.Size = new System.Drawing.Size(227, 23);
            this.metroSetLabel4.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetLabel4.StyleManager = null;
            this.metroSetLabel4.TabIndex = 18;
            this.metroSetLabel4.Text = "Field of View";
            this.metroSetLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroSetLabel4.ThemeAuthor = "Narwin";
            this.metroSetLabel4.ThemeName = "MetroLite";
            // 
            // metroSetTrackBar4
            // 
            this.metroSetTrackBar4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.metroSetTrackBar4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroSetTrackBar4.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.metroSetTrackBar4.DisabledBorderColor = System.Drawing.Color.Empty;
            this.metroSetTrackBar4.DisabledHandlerColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.metroSetTrackBar4.DisabledValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.metroSetTrackBar4.HandlerColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.metroSetTrackBar4.IsDerivedStyle = true;
            this.metroSetTrackBar4.Location = new System.Drawing.Point(14, 92);
            this.metroSetTrackBar4.Maximum = 100;
            this.metroSetTrackBar4.Minimum = 0;
            this.metroSetTrackBar4.Name = "metroSetTrackBar4";
            this.metroSetTrackBar4.Size = new System.Drawing.Size(227, 16);
            this.metroSetTrackBar4.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetTrackBar4.StyleManager = null;
            this.metroSetTrackBar4.TabIndex = 17;
            this.metroSetTrackBar4.Text = "metroSetTrackBar4";
            this.metroSetTrackBar4.ThemeAuthor = "Narwin";
            this.metroSetTrackBar4.ThemeName = "MetroLite";
            this.metroSetTrackBar4.Value = 0;
            this.metroSetTrackBar4.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            // 
            // metroSetLabel6
            // 
            this.metroSetLabel6.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroSetLabel6.IsDerivedStyle = true;
            this.metroSetLabel6.Location = new System.Drawing.Point(14, 158);
            this.metroSetLabel6.Name = "metroSetLabel6";
            this.metroSetLabel6.Size = new System.Drawing.Size(227, 23);
            this.metroSetLabel6.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetLabel6.StyleManager = null;
            this.metroSetLabel6.TabIndex = 16;
            this.metroSetLabel6.Text = "Camera Height";
            this.metroSetLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroSetLabel6.ThemeAuthor = "Narwin";
            this.metroSetLabel6.ThemeName = "MetroLite";
            // 
            // metroSetTrackBar5
            // 
            this.metroSetTrackBar5.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.metroSetTrackBar5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroSetTrackBar5.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.metroSetTrackBar5.DisabledBorderColor = System.Drawing.Color.Empty;
            this.metroSetTrackBar5.DisabledHandlerColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.metroSetTrackBar5.DisabledValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.metroSetTrackBar5.HandlerColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.metroSetTrackBar5.IsDerivedStyle = true;
            this.metroSetTrackBar5.Location = new System.Drawing.Point(14, 184);
            this.metroSetTrackBar5.Maximum = 100;
            this.metroSetTrackBar5.Minimum = 0;
            this.metroSetTrackBar5.Name = "metroSetTrackBar5";
            this.metroSetTrackBar5.Size = new System.Drawing.Size(227, 16);
            this.metroSetTrackBar5.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetTrackBar5.StyleManager = null;
            this.metroSetTrackBar5.TabIndex = 15;
            this.metroSetTrackBar5.Text = "metroSetTrackBar5";
            this.metroSetTrackBar5.ThemeAuthor = "Narwin";
            this.metroSetTrackBar5.ThemeName = "MetroLite";
            this.metroSetTrackBar5.Value = 0;
            this.metroSetTrackBar5.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            // 
            // metroSetLabel7
            // 
            this.metroSetLabel7.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroSetLabel7.IsDerivedStyle = true;
            this.metroSetLabel7.Location = new System.Drawing.Point(14, 112);
            this.metroSetLabel7.Name = "metroSetLabel7";
            this.metroSetLabel7.Size = new System.Drawing.Size(227, 23);
            this.metroSetLabel7.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetLabel7.StyleManager = null;
            this.metroSetLabel7.TabIndex = 14;
            this.metroSetLabel7.Text = "Camera Distance";
            this.metroSetLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroSetLabel7.ThemeAuthor = "Narwin";
            this.metroSetLabel7.ThemeName = "MetroLite";
            // 
            // metroSetTrackBar6
            // 
            this.metroSetTrackBar6.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.metroSetTrackBar6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroSetTrackBar6.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.metroSetTrackBar6.DisabledBorderColor = System.Drawing.Color.Empty;
            this.metroSetTrackBar6.DisabledHandlerColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.metroSetTrackBar6.DisabledValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.metroSetTrackBar6.HandlerColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.metroSetTrackBar6.IsDerivedStyle = true;
            this.metroSetTrackBar6.Location = new System.Drawing.Point(14, 138);
            this.metroSetTrackBar6.Maximum = 100;
            this.metroSetTrackBar6.Minimum = 0;
            this.metroSetTrackBar6.Name = "metroSetTrackBar6";
            this.metroSetTrackBar6.Size = new System.Drawing.Size(227, 16);
            this.metroSetTrackBar6.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetTrackBar6.StyleManager = null;
            this.metroSetTrackBar6.TabIndex = 13;
            this.metroSetTrackBar6.Text = "metroSetTrackBar6";
            this.metroSetTrackBar6.ThemeAuthor = "Narwin";
            this.metroSetTrackBar6.ThemeName = "MetroLite";
            this.metroSetTrackBar6.Value = 0;
            this.metroSetTrackBar6.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            // 
            // metroSetLabel8
            // 
            this.metroSetLabel8.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroSetLabel8.IsDerivedStyle = true;
            this.metroSetLabel8.Location = new System.Drawing.Point(81, 13);
            this.metroSetLabel8.Name = "metroSetLabel8";
            this.metroSetLabel8.Size = new System.Drawing.Size(182, 23);
            this.metroSetLabel8.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetLabel8.StyleManager = null;
            this.metroSetLabel8.TabIndex = 12;
            this.metroSetLabel8.Text = "First Person Perspective";
            this.metroSetLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroSetLabel8.ThemeAuthor = "Narwin";
            this.metroSetLabel8.ThemeName = "MetroLite";
            // 
            // metroSetSwitch2
            // 
            this.metroSetSwitch2.BackColor = System.Drawing.Color.Transparent;
            this.metroSetSwitch2.BackgroundColor = System.Drawing.Color.Empty;
            this.metroSetSwitch2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(147)))));
            this.metroSetSwitch2.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetSwitch2.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.metroSetSwitch2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroSetSwitch2.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.metroSetSwitch2.DisabledCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetSwitch2.DisabledUnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.metroSetSwitch2.IsDerivedStyle = true;
            this.metroSetSwitch2.Location = new System.Drawing.Point(14, 13);
            this.metroSetSwitch2.Name = "metroSetSwitch2";
            this.metroSetSwitch2.Size = new System.Drawing.Size(58, 22);
            this.metroSetSwitch2.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetSwitch2.StyleManager = null;
            this.metroSetSwitch2.Switched = false;
            this.metroSetSwitch2.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.metroSetSwitch2.TabIndex = 11;
            this.metroSetSwitch2.Text = "metroSetSwitch2";
            this.metroSetSwitch2.ThemeAuthor = "Narwin";
            this.metroSetSwitch2.ThemeName = "MetroLite";
            this.metroSetSwitch2.UnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            // 
            // Information
            // 
            this.Information.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Information.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Information.Controls.Add(this.HotKeysInfo);
            this.Information.Controls.Add(this.Status);
            this.Information.Controls.Add(this.getStatus);
            this.Information.Controls.Add(this.Hispano);
            this.Information.Controls.Add(this.proID);
            this.Information.Controls.Add(this.procIDLabel);
            this.Information.ForeColor = System.Drawing.Color.White;
            this.Information.Location = new System.Drawing.Point(0, 40);
            this.Information.Name = "Information";
            this.Information.Size = new System.Drawing.Size(200, 60);
            this.Information.TabIndex = 1;
            this.Information.Text = "Information";
            // 
            // HotKeysInfo
            // 
            this.HotKeysInfo.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HotKeysInfo.IsDerivedStyle = true;
            this.HotKeysInfo.Location = new System.Drawing.Point(268, 14);
            this.HotKeysInfo.Name = "HotKeysInfo";
            this.HotKeysInfo.Size = new System.Drawing.Size(200, 158);
            this.HotKeysInfo.Style = MetroSet_UI.Enums.Style.Light;
            this.HotKeysInfo.StyleManager = null;
            this.HotKeysInfo.TabIndex = 6;
            this.HotKeysInfo.Text = "HotKeys to toggle the utilities:\r\nF1 -> NO DROP ANIMATION\r\nF2 -> NO ITEMS RENDER\r" +
    "\nF3 -> NO BOBBING ANIMATION\r\nF4 -> HIDE ALL NAMES\r\nF5 -> ENABLE ALL\r\n";
            this.HotKeysInfo.ThemeAuthor = "Narwin";
            this.HotKeysInfo.ThemeName = "MetroLite";
            // 
            // Status
            // 
            this.Status.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.IsDerivedStyle = true;
            this.Status.Location = new System.Drawing.Point(12, 37);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(77, 23);
            this.Status.Style = MetroSet_UI.Enums.Style.Light;
            this.Status.StyleManager = null;
            this.Status.TabIndex = 5;
            this.Status.Text = "STATUS:";
            this.Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Status.ThemeAuthor = "Narwin";
            this.Status.ThemeName = "MetroLite";
            // 
            // getStatus
            // 
            this.getStatus.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getStatus.IsDerivedStyle = true;
            this.getStatus.Location = new System.Drawing.Point(85, 37);
            this.getStatus.Name = "getStatus";
            this.getStatus.Size = new System.Drawing.Size(108, 23);
            this.getStatus.Style = MetroSet_UI.Enums.Style.Light;
            this.getStatus.StyleManager = null;
            this.getStatus.TabIndex = 4;
            this.getStatus.Text = "DISCONNECTED";
            this.getStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.getStatus.ThemeAuthor = "Narwin";
            this.getStatus.ThemeName = "MetroLite";
            // 
            // Hispano
            // 
            this.Hispano.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hispano.IsDerivedStyle = true;
            this.Hispano.Location = new System.Drawing.Point(94, 191);
            this.Hispano.Name = "Hispano";
            this.Hispano.Size = new System.Drawing.Size(293, 23);
            this.Hispano.Style = MetroSet_UI.Enums.Style.Light;
            this.Hispano.StyleManager = null;
            this.Hispano.TabIndex = 3;
            this.Hispano.Text = "Helium has been scripted and compiled by Hispano";
            this.Hispano.ThemeAuthor = "Narwin";
            this.Hispano.ThemeName = "MetroLite";
            // 
            // proID
            // 
            this.proID.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proID.IsDerivedStyle = true;
            this.proID.Location = new System.Drawing.Point(12, 14);
            this.proID.Name = "proID";
            this.proID.Size = new System.Drawing.Size(77, 23);
            this.proID.Style = MetroSet_UI.Enums.Style.Light;
            this.proID.StyleManager = null;
            this.proID.TabIndex = 2;
            this.proID.Text = "PROCESS:";
            this.proID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.proID.ThemeAuthor = "Narwin";
            this.proID.ThemeName = "MetroLite";
            // 
            // procIDLabel
            // 
            this.procIDLabel.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.procIDLabel.IsDerivedStyle = true;
            this.procIDLabel.Location = new System.Drawing.Point(85, 14);
            this.procIDLabel.Name = "procIDLabel";
            this.procIDLabel.Size = new System.Drawing.Size(108, 23);
            this.procIDLabel.Style = MetroSet_UI.Enums.Style.Light;
            this.procIDLabel.StyleManager = null;
            this.procIDLabel.TabIndex = 1;
            this.procIDLabel.Text = "DISCONNECTED";
            this.procIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.procIDLabel.ThemeAuthor = "Narwin";
            this.procIDLabel.ThemeName = "MetroLite";
            // 
            // Utility
            // 
            this.Utility.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Utility.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Utility.Controls.Add(this.metroSetLabel2);
            this.Utility.Controls.Add(this.metroSetLabel1);
            this.Utility.Controls.Add(this.AddAnimationFrameButton);
            this.Utility.Controls.Add(this.FreecamSwitch);
            this.Utility.Controls.Add(this.cameraInfoLabel);
            this.Utility.Controls.Add(this.PlayAnimationButton);
            this.Utility.Controls.Add(this.pictureBox);
            this.Utility.Controls.Add(this.CameraHeightSlider);
            this.Utility.ForeColor = System.Drawing.Color.White;
            this.Utility.Location = new System.Drawing.Point(0, 30);
            this.Utility.Name = "Utility";
            this.Utility.Size = new System.Drawing.Size(482, 215);
            this.Utility.TabIndex = 0;
            this.Utility.Text = "Utility";
            // 
            // cameraInfoLabel
            // 
            this.cameraInfoLabel.Font = new System.Drawing.Font("Impact", 11.25F);
            this.cameraInfoLabel.IsDerivedStyle = true;
            this.cameraInfoLabel.Location = new System.Drawing.Point(303, 27);
            this.cameraInfoLabel.Name = "cameraInfoLabel";
            this.cameraInfoLabel.Size = new System.Drawing.Size(143, 102);
            this.cameraInfoLabel.Style = MetroSet_UI.Enums.Style.Light;
            this.cameraInfoLabel.StyleManager = null;
            this.cameraInfoLabel.TabIndex = 6;
            this.cameraInfoLabel.Text = "PositionX: PositionY: PositionZ: CameraYaw: CameraPitch:";
            this.cameraInfoLabel.ThemeAuthor = "Narwin";
            this.cameraInfoLabel.ThemeName = "MetroLite";
            // 
            // PlayAnimationButton
            // 
            this.PlayAnimationButton.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.PlayAnimationButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.PlayAnimationButton.DisabledForeColor = System.Drawing.Color.Gray;
            this.PlayAnimationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.PlayAnimationButton.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.PlayAnimationButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.PlayAnimationButton.HoverTextColor = System.Drawing.Color.White;
            this.PlayAnimationButton.IsDerivedStyle = true;
            this.PlayAnimationButton.Location = new System.Drawing.Point(356, 140);
            this.PlayAnimationButton.Name = "PlayAnimationButton";
            this.PlayAnimationButton.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.PlayAnimationButton.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.PlayAnimationButton.NormalTextColor = System.Drawing.Color.White;
            this.PlayAnimationButton.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.PlayAnimationButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.PlayAnimationButton.PressTextColor = System.Drawing.Color.White;
            this.PlayAnimationButton.Size = new System.Drawing.Size(75, 23);
            this.PlayAnimationButton.Style = MetroSet_UI.Enums.Style.Light;
            this.PlayAnimationButton.StyleManager = null;
            this.PlayAnimationButton.TabIndex = 5;
            this.PlayAnimationButton.ThemeAuthor = "Narwin";
            this.PlayAnimationButton.ThemeName = "MetroLite";
            this.PlayAnimationButton.Click += new System.EventHandler(this.PlayAnimationButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Silver;
            this.pictureBox.Location = new System.Drawing.Point(5, 5);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(180, 180);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // CameraHeightSlider
            // 
            this.CameraHeightSlider.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.CameraHeightSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CameraHeightSlider.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.CameraHeightSlider.DisabledBorderColor = System.Drawing.Color.Empty;
            this.CameraHeightSlider.DisabledHandlerColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.CameraHeightSlider.DisabledValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.CameraHeightSlider.HandlerColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.CameraHeightSlider.IsDerivedStyle = true;
            this.CameraHeightSlider.Location = new System.Drawing.Point(5, 191);
            this.CameraHeightSlider.Maximum = 100;
            this.CameraHeightSlider.Minimum = 0;
            this.CameraHeightSlider.Name = "CameraHeightSlider";
            this.CameraHeightSlider.Size = new System.Drawing.Size(180, 16);
            this.CameraHeightSlider.Style = MetroSet_UI.Enums.Style.Light;
            this.CameraHeightSlider.StyleManager = null;
            this.CameraHeightSlider.TabIndex = 1;
            this.CameraHeightSlider.Text = "metroSetTrackBar1";
            this.CameraHeightSlider.ThemeAuthor = "Narwin";
            this.CameraHeightSlider.ThemeName = "MetroLite";
            this.CameraHeightSlider.Value = 0;
            this.CameraHeightSlider.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.CameraHeightSlider.Scroll += new MetroSet_UI.Controls.MetroSetTrackBar.ScrollEventHandler(this.CameraHeightSlider_Scroll);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.Utility);
            this.TabControl.Controls.Add(this.Information);
            this.TabControl.Controls.Add(this.CameraTweaks);
            this.TabControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.TabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.TabControl.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TabControl.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl.ItemSize = new System.Drawing.Size(120, 30);
            this.TabControl.Location = new System.Drawing.Point(15, 93);
            this.TabControl.MainPage = "";
            this.TabControl.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(482, 245);
            this.TabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TabControl.TabIndex = 1;
            this.TabControl.TabSelectedColor = System.Drawing.Color.Red;
            this.TabControl.TabSelectedForeColor = System.Drawing.Color.White;
            this.TabControl.TabSelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TabControl.TabSelectedHighColorSize = 2;
            this.TabControl.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // FreecamSwitch
            // 
            this.FreecamSwitch.BackColor = System.Drawing.Color.Transparent;
            this.FreecamSwitch.BackgroundColor = System.Drawing.Color.Empty;
            this.FreecamSwitch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(147)))));
            this.FreecamSwitch.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.FreecamSwitch.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.FreecamSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FreecamSwitch.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.FreecamSwitch.DisabledCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.FreecamSwitch.DisabledUnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.FreecamSwitch.IsDerivedStyle = true;
            this.FreecamSwitch.Location = new System.Drawing.Point(211, 27);
            this.FreecamSwitch.Name = "FreecamSwitch";
            this.FreecamSwitch.Size = new System.Drawing.Size(58, 22);
            this.FreecamSwitch.Style = MetroSet_UI.Enums.Style.Light;
            this.FreecamSwitch.StyleManager = null;
            this.FreecamSwitch.Switched = false;
            this.FreecamSwitch.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.FreecamSwitch.TabIndex = 7;
            this.FreecamSwitch.ThemeAuthor = "Narwin";
            this.FreecamSwitch.ThemeName = "MetroLite";
            this.FreecamSwitch.UnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            // 
            // AddAnimationFrameButton
            // 
            this.AddAnimationFrameButton.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.AddAnimationFrameButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.AddAnimationFrameButton.DisabledForeColor = System.Drawing.Color.Gray;
            this.AddAnimationFrameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AddAnimationFrameButton.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.AddAnimationFrameButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.AddAnimationFrameButton.HoverTextColor = System.Drawing.Color.White;
            this.AddAnimationFrameButton.IsDerivedStyle = true;
            this.AddAnimationFrameButton.Location = new System.Drawing.Point(211, 140);
            this.AddAnimationFrameButton.Name = "AddAnimationFrameButton";
            this.AddAnimationFrameButton.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.AddAnimationFrameButton.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.AddAnimationFrameButton.NormalTextColor = System.Drawing.Color.White;
            this.AddAnimationFrameButton.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.AddAnimationFrameButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.AddAnimationFrameButton.PressTextColor = System.Drawing.Color.White;
            this.AddAnimationFrameButton.Size = new System.Drawing.Size(75, 23);
            this.AddAnimationFrameButton.Style = MetroSet_UI.Enums.Style.Light;
            this.AddAnimationFrameButton.StyleManager = null;
            this.AddAnimationFrameButton.TabIndex = 8;
            this.AddAnimationFrameButton.ThemeAuthor = "Narwin";
            this.AddAnimationFrameButton.ThemeName = "MetroLite";
            this.AddAnimationFrameButton.Click += new System.EventHandler(this.AddAnimationFrameButton_Click);
            // 
            // metroSetLabel1
            // 
            this.metroSetLabel1.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroSetLabel1.IsDerivedStyle = true;
            this.metroSetLabel1.Location = new System.Drawing.Point(211, 166);
            this.metroSetLabel1.Name = "metroSetLabel1";
            this.metroSetLabel1.Size = new System.Drawing.Size(85, 23);
            this.metroSetLabel1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetLabel1.StyleManager = null;
            this.metroSetLabel1.TabIndex = 19;
            this.metroSetLabel1.Text = "Add Frame";
            this.metroSetLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroSetLabel1.ThemeAuthor = "Narwin";
            this.metroSetLabel1.ThemeName = "MetroLite";
            // 
            // metroSetLabel2
            // 
            this.metroSetLabel2.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroSetLabel2.IsDerivedStyle = true;
            this.metroSetLabel2.Location = new System.Drawing.Point(356, 166);
            this.metroSetLabel2.Name = "metroSetLabel2";
            this.metroSetLabel2.Size = new System.Drawing.Size(121, 23);
            this.metroSetLabel2.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetLabel2.StyleManager = null;
            this.metroSetLabel2.TabIndex = 20;
            this.metroSetLabel2.Text = "Play Animation";
            this.metroSetLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroSetLabel2.ThemeAuthor = "Narwin";
            this.metroSetLabel2.ThemeName = "MetroLite";
            // 
            // HeliumForm
            // 
            this.AllowResize = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BackgroundImageTransparency = 0.1F;
            this.ClientSize = new System.Drawing.Size(512, 353);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.metroSetControlBox1);
            this.Font = new System.Drawing.Font("Impact", 13.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(512, 353);
            this.MinimumSize = new System.Drawing.Size(512, 353);
            this.Name = "HeliumForm";
            this.Opacity = 0.95D;
            this.Padding = new System.Windows.Forms.Padding(12, 90, 12, 12);
            this.ShowTitle = false;
            this.SmallLineColor1 = System.Drawing.Color.Red;
            this.SmallLineColor2 = System.Drawing.Color.Red;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style = MetroSet_UI.Enums.Style.Custom;
            this.Text = "Silicon";
            this.TextColor = System.Drawing.Color.White;
            this.ThemeAuthor = "Hispano";
            this.ThemeName = "Helium-Red";
            this.UseSlideAnimation = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.CameraTweaks.ResumeLayout(false);
            this.Information.ResumeLayout(false);
            this.Utility.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroSet_UI.Controls.MetroSetControlBox metroSetControlBox1;
        private System.ComponentModel.BackgroundWorker HeliumWorker;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage CameraTweaks;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel4;
        private MetroSet_UI.Controls.MetroSetTrackBar metroSetTrackBar4;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel6;
        private MetroSet_UI.Controls.MetroSetTrackBar metroSetTrackBar5;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel7;
        private MetroSet_UI.Controls.MetroSetTrackBar metroSetTrackBar6;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel8;
        private MetroSet_UI.Controls.MetroSetSwitch metroSetSwitch2;
        private System.Windows.Forms.TabPage Information;
        private MetroSet_UI.Controls.MetroSetLabel HotKeysInfo;
        private MetroSet_UI.Controls.MetroSetLabel Status;
        private MetroSet_UI.Controls.MetroSetLabel getStatus;
        private MetroSet_UI.Controls.MetroSetLabel Hispano;
        private MetroSet_UI.Controls.MetroSetLabel proID;
        private MetroSet_UI.Controls.MetroSetLabel procIDLabel;
        private System.Windows.Forms.TabPage Utility;
        private MetroSet_UI.Controls.MetroSetLabel cameraInfoLabel;
        private MetroSet_UI.Controls.MetroSetButton PlayAnimationButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private MetroSet_UI.Controls.MetroSetTrackBar CameraHeightSlider;
        private Sunny.UI.UITabControl TabControl;
        private MetroSet_UI.Controls.MetroSetSwitch FreecamSwitch;
        private MetroSet_UI.Controls.MetroSetButton AddAnimationFrameButton;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel1;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel2;
    }
}

