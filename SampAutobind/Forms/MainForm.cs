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
using SampAutobind.Logic;

namespace SampAutobind.Forms
{
    public partial class MainForm : Form
    {
        private IntPtr GunHoldingAddress = new IntPtr(0xBAA410);
        private Timer GunCheckerTimer = new Timer();
        private Weapons CurrentGun { get; set; }
        private Weapons OldGun { get; set; }
        private List<WeaponKeybindModel> WeaponKeybinds { get; set; }
        private bool GunBindsEnabled = false;
        private string settingsFile = "settings.json";

        public MainForm()
        {
            InitializeComponent();
            gunBindsToggleBtn.BackColor = Color.Red;
            WeaponKeybinds = new List<WeaponKeybindModel>();
            if (File.Exists(settingsFile))
            {
                using (StreamReader sr = new StreamReader(settingsFile))
                {
                    string text = sr.ReadToEnd();
                    WeaponKeybinds = JsonConvert.DeserializeObject<List<WeaponKeybindModel>>(text);
                    sr.Close();
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(settingsFile))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(WeaponKeybinds));
                    sw.Close();
                }
            }
        }

        private void attachBtn_Click(object sender, EventArgs e)
        {
            if (MemoryManager.AttachToProcess())
            {
                attachBtn.BackColor = Color.Green;
                attachBtn.Enabled = false;

                GunCheckerTimer.Interval = 100;
                GunCheckerTimer.Tick += GunCheckerTimer_Tick;
                GunCheckerTimer.Start();
            }
        }

        private void GunCheckerTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (MemoryManager.IsProcessAlive())
                {
                    CurrentGun = (Weapons)MemoryManager.ReadInt(GunHoldingAddress);
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
                MemoryManager.SendKeysToProcess(oldGunTextIn);
                MemoryManager.SendKeysToProcess(currentGunTextOut);
            }
            OldGun = CurrentGun;
        }

        private void gunBindsToggleBtn_Click(object sender, EventArgs e)
        {
            if (MemoryManager.IsProcessNull() == false && MemoryManager.IsProcessAlive())
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
