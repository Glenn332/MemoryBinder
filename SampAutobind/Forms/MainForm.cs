using System;
using System.Collections.Generic;
using Binarysharp.MemoryManagement;
using System.Windows.Forms;
using SampAutobind.Enums;
using SampAutobind.Models;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace SampAutobind.Forms
{
    public partial class MainForm : Form
    {
        private IntPtr GunHoldingAddress = new IntPtr(0xBAA410);
        private MemorySharp Mem;
        private Timer GunCheckerTimer = new Timer();
        private Weapons CurrentGun { get; set; }
        private Weapons OldGun { get; set; }
        private List<WeaponKeybindModel> WeaponKeybinds { get; set; }
        private bool GunBindsEnabled = false;

        public MainForm()
        {
            InitializeComponent();
            gunBindsToggleBtn.BackColor = Color.Red;
            WeaponKeybinds = new List<WeaponKeybindModel>();
            if (File.Exists("Keybinds.json"))
            {
                using (StreamReader sr = new StreamReader("Keybinds.json"))
                {
                    string text = sr.ReadToEnd();
                    WeaponKeybinds = JsonConvert.DeserializeObject<List<WeaponKeybindModel>>(text);
                    sr.Close();
                }
            } else
            {
                using(StreamWriter sw = new StreamWriter("Keybinds.json"))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(WeaponKeybinds));
                    sw.Close();
                }
            }
        }

        private void attachBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Mem = new MemorySharp(Process.GetProcessesByName("gta_sa")[0]);

                attachBtn.BackColor = Color.Green; //User Feedback
                attachBtn.Enabled = false;

                GunCheckerTimer.Interval = 100;
                GunCheckerTimer.Tick += GunCheckerTimer_Tick;
                GunCheckerTimer.Start();
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Game not found!");
                //throw ex;
            }
        }

        private void GunCheckerTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Mem.IsRunning)
                {
                    CurrentGun = (Weapons)Mem.Read<int>(GunHoldingAddress, false);
                    currentGunLabel.Text = CurrentGun.ToString();

                    if (CurrentGun != OldGun)
                    {
                        ChangeGuns();
                    }
                }
                else
                {
                    GunCheckerTimer.Stop();
                    attachBtn.BackColor = Color.Red;
                    attachBtn.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ChangeGuns()
        {
            if (GunBindsEnabled)
            {
                string oldGunTextIn = WeaponKeybinds.Find(x => x.WeaponID == (int)OldGun)?.GunInAction;
                string currentGunTextOut = WeaponKeybinds.Find(x => x.WeaponID == (int)CurrentGun)?.GunOutAction;
                TypeGunLineInWindow(oldGunTextIn);
                TypeGunLineInWindow(currentGunTextOut);
            }
            OldGun = CurrentGun;
        }

        private void TypeGunLineInWindow(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                Mem.Windows.MainWindow.Keyboard.Press(Binarysharp.MemoryManagement.Native.Keys.Enter, TimeSpan.FromMilliseconds(20));
                Mem.Windows.MainWindow.Keyboard.Write(string.Format("t{0}", text));
                Mem.Windows.MainWindow.Keyboard.Release(Binarysharp.MemoryManagement.Native.Keys.Enter);
            }
        }

        private void gunBindsToggleBtn_Click(object sender, EventArgs e)
        {
            if (Mem != null && Mem.IsRunning)
            {
                if (GunBindsEnabled)
                {
                    GunBindsEnabled = false;
                    gunBindsToggleBtn.BackColor = Color.Red;
                }
                else
                {
                    GunBindsEnabled = true;
                    gunBindsToggleBtn.BackColor = Color.Green;
                }
            }
        }
    }
}
