using Binarysharp.MemoryManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampAutobind.Logic
{
    public static class MemoryManager
    {
        private static MemorySharp Mem { get; set; }
        
        public static bool AttachToProcess()
        {
            try
            {
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
            return Mem.Read<int>(Addres, false);
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
