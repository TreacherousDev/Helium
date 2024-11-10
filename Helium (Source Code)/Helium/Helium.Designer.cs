
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
            this.TabControl = new Sunny.UI.UITabControl();
            this.Utility = new System.Windows.Forms.TabPage();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.cameraLookJoystick = new MetroSet_UI.Controls.MetroSetPanel();
            this.RadiusSlider = new MetroSet_UI.Controls.MetroSetTrackBar();
            this.CameraHeightSlider = new MetroSet_UI.Controls.MetroSetTrackBar();
            this.Information = new System.Windows.Forms.TabPage();
            this.HotKeysInfo = new MetroSet_UI.Controls.MetroSetLabel();
            this.Status = new MetroSet_UI.Controls.MetroSetLabel();
            this.getStatus = new MetroSet_UI.Controls.MetroSetLabel();
            this.Hispano = new MetroSet_UI.Controls.MetroSetLabel();
            this.proID = new MetroSet_UI.Controls.MetroSetLabel();
            this.procIDLabel = new MetroSet_UI.Controls.MetroSetLabel();
            this.HeliumWorker = new System.ComponentModel.BackgroundWorker();
            this.PlayAnimationButton = new MetroSet_UI.Controls.MetroSetButton();
            this.TabControl.SuspendLayout();
            this.Utility.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.Information.SuspendLayout();
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
            // TabControl
            // 
            this.TabControl.Controls.Add(this.Utility);
            this.TabControl.Controls.Add(this.Information);
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
            // Utility
            // 
            this.Utility.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Utility.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Utility.Controls.Add(this.PlayAnimationButton);
            this.Utility.Controls.Add(this.pictureBox);
            this.Utility.Controls.Add(this.cameraLookJoystick);
            this.Utility.Controls.Add(this.RadiusSlider);
            this.Utility.Controls.Add(this.CameraHeightSlider);
            this.Utility.ForeColor = System.Drawing.Color.White;
            this.Utility.Location = new System.Drawing.Point(0, 30);
            this.Utility.Name = "Utility";
            this.Utility.Size = new System.Drawing.Size(482, 215);
            this.Utility.TabIndex = 0;
            this.Utility.Text = "Utility";
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
            // cameraLookJoystick
            // 
            this.cameraLookJoystick.BackgroundColor = System.Drawing.Color.White;
            this.cameraLookJoystick.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cameraLookJoystick.BorderThickness = 1;
            this.cameraLookJoystick.IsDerivedStyle = true;
            this.cameraLookJoystick.Location = new System.Drawing.Point(204, 38);
            this.cameraLookJoystick.Name = "cameraLookJoystick";
            this.cameraLookJoystick.Size = new System.Drawing.Size(100, 100);
            this.cameraLookJoystick.Style = MetroSet_UI.Enums.Style.Light;
            this.cameraLookJoystick.StyleManager = null;
            this.cameraLookJoystick.TabIndex = 3;
            this.cameraLookJoystick.ThemeAuthor = "Narwin";
            this.cameraLookJoystick.ThemeName = "MetroLite";
            // 
            // RadiusSlider
            // 
            this.RadiusSlider.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.RadiusSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RadiusSlider.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.RadiusSlider.DisabledBorderColor = System.Drawing.Color.Empty;
            this.RadiusSlider.DisabledHandlerColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.RadiusSlider.DisabledValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.RadiusSlider.HandlerColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.RadiusSlider.IsDerivedStyle = true;
            this.RadiusSlider.Location = new System.Drawing.Point(204, 16);
            this.RadiusSlider.Maximum = 100;
            this.RadiusSlider.Minimum = 5;
            this.RadiusSlider.Name = "RadiusSlider";
            this.RadiusSlider.Size = new System.Drawing.Size(100, 16);
            this.RadiusSlider.Style = MetroSet_UI.Enums.Style.Light;
            this.RadiusSlider.StyleManager = null;
            this.RadiusSlider.TabIndex = 2;
            this.RadiusSlider.Text = "metroSetTrackBar1";
            this.RadiusSlider.ThemeAuthor = "Narwin";
            this.RadiusSlider.ThemeName = "MetroLite";
            this.RadiusSlider.Value = 5;
            this.RadiusSlider.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
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
            // HeliumWorker
            // 
            this.HeliumWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.HeliumWorker_DoWork);
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
            this.PlayAnimationButton.Location = new System.Drawing.Point(217, 153);
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
            this.Text = "Helium";
            this.TextColor = System.Drawing.Color.White;
            this.ThemeAuthor = "Hispano";
            this.ThemeName = "Helium-Red";
            this.UseSlideAnimation = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TabControl.ResumeLayout(false);
            this.Utility.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.Information.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroSet_UI.Controls.MetroSetControlBox metroSetControlBox1;
        private Sunny.UI.UITabControl TabControl;
        private System.Windows.Forms.TabPage Information;
        private MetroSet_UI.Controls.MetroSetLabel procIDLabel;
        private MetroSet_UI.Controls.MetroSetLabel getStatus;
        private MetroSet_UI.Controls.MetroSetLabel Hispano;
        private MetroSet_UI.Controls.MetroSetLabel proID;
        private MetroSet_UI.Controls.MetroSetLabel Status;
        private System.ComponentModel.BackgroundWorker HeliumWorker;
        private MetroSet_UI.Controls.MetroSetLabel HotKeysInfo;
        private System.Windows.Forms.TabPage Utility;
        private MetroSet_UI.Controls.MetroSetPanel cameraLookJoystick;
        private MetroSet_UI.Controls.MetroSetTrackBar RadiusSlider;
        private MetroSet_UI.Controls.MetroSetTrackBar CameraHeightSlider;
        private System.Windows.Forms.PictureBox pictureBox;
        private MetroSet_UI.Controls.MetroSetButton PlayAnimationButton;
    }
}

