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
using SampAutobind.Constants;
using System.Reflection;
using SampAutobind.Properties;

namespace SampAutobind.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            gunBindsToggleBtn.BackColor = Color.Red;
            if (!SettingsManager.LoadSettingsFile())
                SettingsManager.CreateNewSettingsFile();
            GunbindManager.Initialize(currentGunLabel, gunBindsEnabledLbl, attachBtn, gunBindsToggleBtn);
        }

        private void attachBtn_Click(object sender, EventArgs e)
        {
            if (MemoryManager.AttachToProcess())
            {
                attachBtn.BackColor = Color.Green;
                attachBtn.Enabled = false;

                GunbindManager.StartMemoryChecker();
            }
        }

        private void gunBindsToggleBtn_Click(object sender, EventArgs e)
        {
            if (MemoryManager.IsProcessNull() == false && MemoryManager.IsProcessAlive())
            {
                GunbindManager.ToggleGunbind();
            }
        }

        private void gunbindsEditBtn_Click(object sender, EventArgs e)
        {
            GunbindsEditForm form = new GunbindsEditForm();
            form.Show();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            mToolTip.Show(string.Format(MainConstants.INFO_TOOLTIP_FORMAT, Resources.Creator, Environment.NewLine, Assembly.GetExecutingAssembly().GetName().Version), mInfoBtn);
        }
    }
}
