namespace XBOX_One_Drive_Converter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DetectedXBOXDrivesGridView = new System.Windows.Forms.DataGridView();
            this.ScanButton = new System.Windows.Forms.Button();
            this.DevicesGroupBox = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enableXBOXModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enablePCModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFormatLogicalDrive = new System.Windows.Forms.Button();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DetectedXBOXDrivesGridView)).BeginInit();
            this.DevicesGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.RightClickMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // DetectedXBOXDrivesGridView
            // 
            this.DetectedXBOXDrivesGridView.AllowUserToAddRows = false;
            this.DetectedXBOXDrivesGridView.AllowUserToDeleteRows = false;
            this.DetectedXBOXDrivesGridView.AllowUserToResizeRows = false;
            this.DetectedXBOXDrivesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DetectedXBOXDrivesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DetectedXBOXDrivesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeviceName,
            this.DeviceCaption,
            this.DeviceMode});
            this.DetectedXBOXDrivesGridView.Location = new System.Drawing.Point(3, 16);
            this.DetectedXBOXDrivesGridView.MultiSelect = false;
            this.DetectedXBOXDrivesGridView.Name = "DetectedXBOXDrivesGridView";
            this.DetectedXBOXDrivesGridView.RowHeadersVisible = false;
            this.DetectedXBOXDrivesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DetectedXBOXDrivesGridView.Size = new System.Drawing.Size(604, 241);
            this.DetectedXBOXDrivesGridView.TabIndex = 2;
            this.DetectedXBOXDrivesGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DetectedXBOXDrivesGridView_MouseClick);
            // 
            // ScanButton
            // 
            this.ScanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ScanButton.Location = new System.Drawing.Point(15, 315);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(86, 27);
            this.ScanButton.TabIndex = 3;
            this.ScanButton.Text = "Scan";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // DevicesGroupBox
            // 
            this.DevicesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DevicesGroupBox.Controls.Add(this.DetectedXBOXDrivesGridView);
            this.DevicesGroupBox.Location = new System.Drawing.Point(12, 36);
            this.DevicesGroupBox.Name = "DevicesGroupBox";
            this.DevicesGroupBox.Size = new System.Drawing.Size(610, 273);
            this.DevicesGroupBox.TabIndex = 4;
            this.DevicesGroupBox.TabStop = false;
            this.DevicesGroupBox.Text = "Detected XBOX One Storage Devices:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(638, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // scanToolStripMenuItem
            // 
            this.scanToolStripMenuItem.Name = "scanToolStripMenuItem";
            this.scanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.scanToolStripMenuItem.Text = "Scan";
            this.scanToolStripMenuItem.Click += new System.EventHandler(this.scanToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // RightClickMenuStrip
            // 
            this.RightClickMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableXBOXModeToolStripMenuItem,
            this.enablePCModeToolStripMenuItem});
            this.RightClickMenuStrip.Name = "RightClickMenuStrip";
            this.RightClickMenuStrip.Size = new System.Drawing.Size(177, 48);
            // 
            // enableXBOXModeToolStripMenuItem
            // 
            this.enableXBOXModeToolStripMenuItem.Name = "enableXBOXModeToolStripMenuItem";
            this.enableXBOXModeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.enableXBOXModeToolStripMenuItem.Text = "Enable XBOX Mode";
            this.enableXBOXModeToolStripMenuItem.Click += new System.EventHandler(this.enableXBOXModeToolStripMenuItem_Click);
            // 
            // enablePCModeToolStripMenuItem
            // 
            this.enablePCModeToolStripMenuItem.Name = "enablePCModeToolStripMenuItem";
            this.enablePCModeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.enablePCModeToolStripMenuItem.Text = "Enable PC Mode";
            this.enablePCModeToolStripMenuItem.Click += new System.EventHandler(this.enablePCModeToolStripMenuItem_Click);
            // 
            // btnFormatLogicalDrive
            // 
            this.btnFormatLogicalDrive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFormatLogicalDrive.Location = new System.Drawing.Point(510, 315);
            this.btnFormatLogicalDrive.Name = "btnFormatLogicalDrive";
            this.btnFormatLogicalDrive.Size = new System.Drawing.Size(112, 27);
            this.btnFormatLogicalDrive.TabIndex = 6;
            this.btnFormatLogicalDrive.Text = "Create XBOX Drive";
            this.btnFormatLogicalDrive.UseVisualStyleBackColor = true;
            this.btnFormatLogicalDrive.Click += new System.EventHandler(this.btnFormatLogicalDrive_Click);
            // 
            // DeviceName
            // 
            this.DeviceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DeviceName.HeaderText = "Device";
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.Width = 66;
            // 
            // DeviceCaption
            // 
            this.DeviceCaption.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DeviceCaption.HeaderText = "Caption";
            this.DeviceCaption.Name = "DeviceCaption";
            // 
            // DeviceMode
            // 
            this.DeviceMode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DeviceMode.HeaderText = "Mode";
            this.DeviceMode.Name = "DeviceMode";
            this.DeviceMode.Width = 59;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 350);
            this.Controls.Add(this.btnFormatLogicalDrive);
            this.Controls.Add(this.DevicesGroupBox);
            this.Controls.Add(this.ScanButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "XBOX One External Storage Device Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DetectedXBOXDrivesGridView)).EndInit();
            this.DevicesGroupBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.RightClickMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DetectedXBOXDrivesGridView;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.GroupBox DevicesGroupBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip RightClickMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem enableXBOXModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enablePCModeToolStripMenuItem;
        private System.Windows.Forms.Button btnFormatLogicalDrive;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceCaption;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceMode;
    }
}

