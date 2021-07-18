using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace XBOX_One_Drive_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        //private void initialize
        private void refreshDrives()
        {
            Cursor.Current = Cursors.WaitCursor;

            var drives = System.IO.DriveInfo.GetDrives();

            var devices = DeviceManager.ParsePhysicalDrives();
            DetectedXBOXDrivesGridView.Rows.Clear();

            foreach (var device in devices)
            {
                DetectedXBOXDrivesGridView.Rows.Add(device.DeviceName, device.DeviceCaption, device.DeviceMode);
            }

            drives = System.IO.DriveInfo.GetDrives();

            Cursor.Current = Cursors.Default;

            if (devices.Count == 0)
                MessageBox.Show("No Xbox One external storage devices found.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refreshDrives();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void scanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshDrives();
        }

        private void DetectedXBOXDrivesGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (DetectedXBOXDrivesGridView.SelectedRows.Count > 0)
                {
                    string Mode = DetectedXBOXDrivesGridView.SelectedRows[0].Cells["DeviceMode"].Value.ToString();
                    if (Mode == "XBOX Mode")
                    {
                        RightClickMenuStrip.Items[0].Enabled = false;
                        RightClickMenuStrip.Items[1].Enabled = true;
                    }
                    else if (Mode == "PC Mode")
                    {
                        RightClickMenuStrip.Items[0].Enabled = true;
                        RightClickMenuStrip.Items[1].Enabled = false;
                    }

                    RightClickMenuStrip.Show(DetectedXBOXDrivesGridView, e.Location);
                }
            }
        }

        private void changeDeviceMode(DeviceManager.DeviceMode mode)
        {
            Cursor.Current = Cursors.WaitCursor;
            DeviceManager.ChangeDeviceMode(DetectedXBOXDrivesGridView.SelectedRows[0].Cells["DeviceName"].Value.ToString(), mode);
            refreshDrives();
            Cursor.Current = Cursors.Default;
        }


        private void enableXBOXModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeDeviceMode(DeviceManager.DeviceMode.Xbox);
        }

        private void enablePCMode()
        {
            changeDeviceMode(DeviceManager.DeviceMode.PC);
        }

        private void enablePCModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enablePCMode();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm About = new AboutForm();
            About.ShowDialog();
        }

        private void btnFormatLogicalDrive_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            string logicalDrive = fbd.SelectedPath.Remove(1);
            if (fbd.SelectedPath.Length > 3)
            {
                if (MessageBox.Show(String.Format("You selected a folder. Would you like to continue and use the logicial drive this folder is under ({0})?", logicalDrive),
                    "Invalid Path", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            System.IO.DriveInfo drive = System.IO.DriveInfo.GetDrives().Single(d => d.Name.Remove(1) == logicalDrive);

            // people are dumb
            if (drive.DriveFormat != "NTFS" && MessageBox.Show("This will clear the data on the partition you chose! Would you like to continue?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                MessageBox.Show("Please wait while your drive is prepared. Your drive will show up in the list when it is finished being built. Click OK to Continue.", "INFORMATION");
                DeviceManager.FormatLogicalDrive(drive);
                refreshDrives();
            }
            catch (DeviceManager.BootDriveFormatException ex)
            {
                MessageBox.Show("Attempted to write to MBR of boot disk! This is a bad idea, and has been prevented.", "Boot Disk MBR Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
