using SampAutobind.Enums;
using SampAutobind.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampAutobind.Logic
{
    public static class GunbindManager
    {
        public static Timer GunCheckerTimer = new Timer();
        private static IntPtr GunHoldingAddress = new IntPtr(0xBAA410);
        private static Weapons CurrentGun { get; set; }
        private static Weapons OldGun { get; set; }
        private static bool GunBindsEnabled = false;
        private static Label CurrentGunLabel, GunBindsEnabledLbl;
        private static Button AttachBtn, GunBindsToggleBtn;

        public static void Initialize(Label currentGunLabel, Label gunBindsEnabledLbl, Button attachBtn, Button gunBindsToggleBtn)
        {
            CurrentGunLabel = currentGunLabel;
            GunBindsEnabledLbl = gunBindsEnabledLbl;
            AttachBtn = attachBtn;
            GunBindsToggleBtn = gunBindsToggleBtn;
        }

        public static void ChangeGuns()
        {
            if (GunBindsEnabled)
            {
                string oldGunTextIn = GunbindManager.GetGunInText(OldGun.GetHashCode());
                string currentGunTextOut = GunbindManager.GetGunOutText(CurrentGun.GetHashCode());
                MemoryManager.SendKeysToProcess(oldGunTextIn);
                MemoryManager.SendKeysToProcess(currentGunTextOut);
            }
            OldGun = CurrentGun;
        }

        public static string GetGunInText(int gunId)
        {
            return SettingsManager.Settings.Find(x => x.WeaponID == gunId)?.GunInAction;
        }

        public static string GetGunOutText(int gunId)
        {
            return SettingsManager.Settings.Find(x => x.WeaponID == gunId)?.GunOutAction;
        }

        public static void StartMemoryChecker()
        {
            GunCheckerTimer.Interval = 100;
            GunCheckerTimer.Tick += GunCheckerTimer_Tick;
            GunCheckerTimer.Start();
        }
        
        private static void GunCheckerTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (MemoryManager.IsProcessAlive())
                {
                    CurrentGun = (Weapons)MemoryManager.ReadInt(GunHoldingAddress);
                    CurrentGunLabel.Text = CurrentGun.ToString();

                    if (CurrentGun != OldGun)
                    {
                        ChangeGuns();
                    }
                }
                else
                {
                    GunCheckerTimer.Stop();
                    AttachBtn.BackColor = Color.Red;
                    AttachBtn.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ToggleGunbind()
        {
            if (GunBindsEnabled)
            {
                GunBindsEnabled = false;
                GunBindsToggleBtn.BackColor = Color.Red;
                GunBindsEnabledLbl.Text = "OFF";
            }
            else
            {
                GunBindsEnabled = true;
                GunBindsToggleBtn.BackColor = Color.Green;
                GunBindsEnabledLbl.Text = "ON";
            }
        }

    }
}
