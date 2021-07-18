using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.IO;
using System.Management;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows;

namespace XBOX_One_Drive_Converter
{
    class DeviceManager
    {
        const short FILE_ATTRIBUTE_NORMAL = 0x80;
        const short INVALID_HANDLE_VALUE = -1;
        const uint GENERIC_READ = 0x80000000;
        const uint GENERIC_WRITE = 0x40000000;
        const uint CREATE_NEW = 1;
        const uint CREATE_ALWAYS = 2;
        const uint OPEN_EXISTING = 3;

        [Flags]
        public enum EFileShare : uint
        {
            /// <summary>
            /// 
            /// </summary>
            None = 0x00000000,
            /// <summary>
            /// Enables subsequent open operations on an object to request read access. 
            /// Otherwise, other processes cannot open the object if they request read access. 
            /// If this flag is not specified, but the object has been opened for read access, the function fails.
            /// </summary>
            Read = 0x00000001,
            /// <summary>
            /// Enables subsequent open operations on an object to request write access. 
            /// Otherwise, other processes cannot open the object if they request write access. 
            /// If this flag is not specified, but the object has been opened for write access, the function fails.
            /// </summary>
            Write = 0x00000002,
            /// <summary>
            /// Enables subsequent open operations on an object to request delete access. 
            /// Otherwise, other processes cannot open the object if they request delete access.
            /// If this flag is not specified, but the object has been opened for delete access, the function fails.
            /// </summary>
            Delete = 0x00000004
        }

        const int MBR_SIGNATURE_SIZE = 2;
        const int MBR_SIGNATURE_OFFSET = 0x1FE;
        const int MBR_SIZE = 0x200;

        static readonly byte[] XBOX_Signature = { 0x99, 0xCC };
        static readonly byte[] PC_Signature = { 0x55, 0xAA };

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint SetFilePointer(
            [In] SafeFileHandle hFile,
            [In] int lDistanceToMove,
            IntPtr high,
            [In] EMoveMethod dwMoveMethod);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern SafeFileHandle CreateFile(string lpFileName, uint dwDesiredAccess,
          uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition,
          uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32", SetLastError = true)]
        internal extern static int ReadFile(SafeFileHandle handle, byte[] bytes,
           int numBytesToRead, out int numBytesRead, IntPtr overlapped_MustBeZero);

        [DllImport("kernel32", SetLastError = true)]
        internal extern static int WriteFile(SafeFileHandle handle, byte[] bytes,
           int numBytesToWrite, out int numBytesWritten, IntPtr overlapped_MustBeZero);



        private enum EMoveMethod : uint
        {
            Begin = 0,
            Current = 1,
            End = 2
        }

        public enum DeviceMode
        {
            Xbox,
            PC,
        }

        public class XBOX_External_Storage_Device
        {
            public string DeviceName;
            public string DeviceCaption;
            public string DeviceMode;
            public int DeviceNumber;
        }

        public class UnsupportedDriveTypeException : Exception { }
        private class DeviceNotFoundException : Exception { }
        public class BootDriveFormatException : Exception { }

        public static List<XBOX_External_Storage_Device> ParsePhysicalDrives()
        {
            int BytesRead = 0;
            var detectedXboxDevices = new List<XBOX_External_Storage_Device>();

            byte[] MBR_Buffer = new byte[MBR_SIZE];
            using (var diskSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"))
            {
                foreach (var device in diskSearcher.Get())
                {
                    string DevicePath = (string)device["DeviceID"];
                    SafeFileHandle handleValue = CreateFile(
                        DevicePath,
                        GENERIC_READ,
                        (uint)EFileShare.Read,
                        IntPtr.Zero,
                        OPEN_EXISTING,
                        0,
                        IntPtr.Zero
                    );
                    if (handleValue.IsInvalid)
                    {
                        handleValue.Close();
                        continue;
                    }

                    ReadFile(handleValue, MBR_Buffer, MBR_SIZE, out BytesRead, IntPtr.Zero);

                    // Read the signature value and see if it is an XBOX or PC Device.
                    byte[] MBR_Signature = new byte[MBR_SIGNATURE_SIZE];
                    MBR_Signature[0] = MBR_Buffer[MBR_SIGNATURE_OFFSET];
                    MBR_Signature[1] = MBR_Buffer[MBR_SIGNATURE_OFFSET + 1];

                    XBOX_External_Storage_Device CurrentDrive = new XBOX_External_Storage_Device();
                    CurrentDrive.DeviceName = DevicePath;
                    CurrentDrive.DeviceCaption = (string)device["Caption"];
                    CurrentDrive.DeviceNumber = Convert.ToInt32((UInt32)device["Index"]);

                    if (MBR_Signature.SequenceEqual(XBOX_Signature))
                    {
                        CurrentDrive.DeviceMode = "XBOX Mode";
                        detectedXboxDevices.Add(CurrentDrive);
                    }
                    // SHOWING PC SIGNATURE - VERIFY REST OF MBR IS ZEROD (XBOX DRIVE IN PC MODE)
                    else if (MBR_Signature.SequenceEqual(PC_Signature))
                    {
                        bool bIsXBOXDrive = true;
                        for (int j = 0; j < 0x1B8; j++)
                        {
                            if (MBR_Buffer[j] != 0x00)
                            {
                                bIsXBOXDrive = false;
                                break;
                            }
                        }

                        if (bIsXBOXDrive)
                        {
                            CurrentDrive.DeviceMode = "PC Mode";
                            detectedXboxDevices.Add(CurrentDrive);
                        }
                    }

                    handleValue.Close();
                }
            }

            return detectedXboxDevices;
        }

        public static void ChangeDeviceMode(string deviceName, DeviceMode mode)
        {
            byte[] MBR_Buffer = new byte[MBR_SIZE];
            int bytesRead = 0, bytesWritten = 0;

            SafeFileHandle handleValue = CreateFile(deviceName, GENERIC_READ | GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
            if (handleValue.IsInvalid)
            {
                handleValue.Close();
            }

            ReadFile(handleValue, MBR_Buffer, MBR_SIZE, out bytesRead, IntPtr.Zero);

            // Read the signature value and see if it is an XBOX or PC Device.
            byte[] MBR_Signature = new byte[MBR_SIGNATURE_SIZE];
            MBR_Signature[0] = MBR_Buffer[MBR_SIGNATURE_OFFSET];
            MBR_Signature[1] = MBR_Buffer[MBR_SIGNATURE_OFFSET + 1];

            if (mode == DeviceMode.Xbox && MBR_Signature.SequenceEqual(PC_Signature))
            {
                MBR_Buffer[MBR_SIGNATURE_OFFSET] = XBOX_Signature[0];
                MBR_Buffer[MBR_SIGNATURE_OFFSET + 1] = XBOX_Signature[1];
            }
            else if (mode == DeviceMode.PC && MBR_Signature.SequenceEqual(XBOX_Signature))
            {
                MBR_Buffer[MBR_SIGNATURE_OFFSET] = PC_Signature[0];
                MBR_Buffer[MBR_SIGNATURE_OFFSET + 1] = PC_Signature[1];
            }
            else
            {
                // Don't make any changes to the disk -- it's already in the proper mode.
                handleValue.Close();
                return;
            }

            SetFilePointer(handleValue, 0x00, IntPtr.Zero, EMoveMethod.Begin);
            WriteFile(handleValue, MBR_Buffer, MBR_SIZE, out bytesWritten, IntPtr.Zero);

            handleValue.Close();
        }

        public static void FormatLogicalDrive(DriveInfo drive)
        {
            if (drive.DriveType != DriveType.Removable && drive.DriveType != DriveType.Fixed)
            {
                throw new UnsupportedDriveTypeException();
            }

            string logicalDriveId = drive.Name.Remove(2);
            // skip this stuff if the drive is already formatted to NTFS
            if (drive.DriveFormat != "NTFS")
            {
                // should check if drive is ready here... but that should just be assumed. Who cares about race conditions?
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "format.com";
                startInfo.Arguments = logicalDriveId + " /Y /fs:NTFS /V:XBOX_EXTERNAL /Q";
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardInput = true;

                Process p = Process.Start(startInfo);

                p.WaitForExit();
                if (p.ExitCode != 0)
                {
                    throw new Exception(p.StandardError.ReadToEnd());
                }
            }

            string deviceName = getDeviceNameFromLogicalPath(logicalDriveId);
            ChangeDeviceMode(deviceName, DeviceMode.Xbox);
        }

        private static string getDeviceNameFromLogicalPath(string logicalId)
        {
            // man, this looks awful but it's cool as hell
            using (var diskSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"))
            {
                foreach (var disk in diskSearcher.Get())
                {
                    var query = string.Format("ASSOCIATORS OF {{Win32_DiskDrive.DeviceID='{0}'}} WHERE AssocClass = Win32_DiskDriveToDiskPartition", (string)disk["DeviceID"]);
                    using (var diskDriveSearcher = new ManagementObjectSearcher(query))
                    {
                        foreach (var diskPartition in diskDriveSearcher.Get())
                        {
                            query = string.Format("ASSOCIATORS OF {{Win32_DiskPartition.DeviceID='{0}'}} WHERE AssocClass = Win32_LogicalDiskToPartition", (string)diskPartition["DeviceID"]);

                            using (var partitionSearcher = new ManagementObjectSearcher(query))
                            {
                                foreach (var logicalDisk in partitionSearcher.Get())
                                {

                                    string letter = (string)logicalDisk["Caption"];
                                    if (letter == logicalId)
                                    {
                                        string devicePath = (string)disk["DeviceID"];
                                        if ((uint)disk["Index"] == 0)
                                        {
                                            throw new BootDriveFormatException();
                                        }
                                        return (string)disk["DeviceID"];
                                    }
                                }
                            }
                        }
                    }
                }
            }

            throw new DeviceNotFoundException();
        }
    }
}
