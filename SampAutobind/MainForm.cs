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

namespace SampAutobind
{
    public partial class MainForm : Form
    {
        private IntPtr gunHoldingAddress = new IntPtr(0xBAA410);
        private MemorySharp mem;
        private Timer gunCheckerTimer = new Timer();
        private Weapons currentGun { get; set; }
        private Weapons oldGun { get; set; }
        private List<WeaponKeybindModel> WeaponKeybinds { get; set; }
        private bool gunBindsEnabled = false;

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
                mem = new MemorySharp(Process.GetProcessesByName("gta_sa")[0]);

                attachBtn.BackColor = Color.Green; //User Feedback
                attachBtn.Enabled = false;

                string test = Newtonsoft.Json.JsonConvert.SerializeObject(WeaponKeybinds);

                gunCheckerTimer.Interval = 100;
                gunCheckerTimer.Tick += GunCheckerTimer_Tick;
                gunCheckerTimer.Start();
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
                if (mem.IsRunning)
                {
                    currentGun = (Weapons)mem.Read<int>(gunHoldingAddress, false);
                    currentGunLabel.Text = currentGun.ToString();

                    if (currentGun != oldGun)
                    {
                        ChangeGuns();
                    }
                }
                else
                {
                    gunCheckerTimer.Stop();
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
            if (gunBindsEnabled)
            {
                string oldGunTextIn = WeaponKeybinds.Find(x => x.WeaponID == (int)oldGun)?.GunInAction;
                string currentGunTextOut = WeaponKeybinds.Find(x => x.WeaponID == (int)currentGun)?.GunOutAction;
                TypeGunLineInWindow(oldGunTextIn);
                TypeGunLineInWindow(currentGunTextOut);
            }
            oldGun = currentGun;
        }

        private void TypeGunLineInWindow(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                mem.Windows.MainWindow.Keyboard.Press(Binarysharp.MemoryManagement.Native.Keys.Enter, TimeSpan.FromMilliseconds(20));
                mem.Windows.MainWindow.Keyboard.Write(string.Format("t{0}", text));
                mem.Windows.MainWindow.Keyboard.Release(Binarysharp.MemoryManagement.Native.Keys.Enter);
            }
        }

        private void gunBindsToggleBtn_Click(object sender, EventArgs e)
        {
            if (mem != null && mem.IsRunning)
            {
                if (gunBindsEnabled)
                {
                    gunBindsEnabled = false;
                    gunBindsToggleBtn.BackColor = Color.Red;
                }
                else
                {
                    gunBindsEnabled = true;
                    gunBindsToggleBtn.BackColor = Color.Green;
                }
            }
        }
    }
}
