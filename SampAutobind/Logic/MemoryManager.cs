using Binarysharp.MemoryManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampAutobind.Logic
{
    public static class MemoryManager
    {
        private static MemorySharp Mem { get; set; }
        private static Process Proc { get; set; }

        const int PROCESS_WM_READ = 0x0010;
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        public static bool AttachToProcess()
        {
            try
            {
                Proc = Process.GetProcessesByName("gta_sa")[0];
                Mem = new MemorySharp(Process.GetProcessesByName("gta_sa")[0]);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsProcessAlive()
        {
            return Mem.IsRunning;
        }

        public static bool IsProcessNull()
        {
            return Mem == null;
        }

        public static int ReadInt(IntPtr Addres)
        {
            IntPtr processHandle = OpenProcess(PROCESS_WM_READ, false, Proc.Id);
            int bytesRead = 0;
            byte[] buffer = new byte[4]; //To read a 24 byte unicode string

            ReadProcessMemory((int)processHandle, new IntPtr(0xBAA410), buffer, buffer.Length, ref bytesRead);
            
            return BitConverter.ToInt32(buffer, 0);
        }

        public static void SendKeysToProcess(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Mem.Windows.MainWindow.Keyboard.Press(Binarysharp.MemoryManagement.Native.Keys.Enter, TimeSpan.FromMilliseconds(20));
                Mem.Windows.MainWindow.Keyboard.Write(string.Format("t{0}", message));
                Mem.Windows.MainWindow.Keyboard.Release(Binarysharp.MemoryManagement.Native.Keys.Enter);
            }
        }
    }
}
