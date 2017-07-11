using SampAutobind.Enums;
using SampAutobind.Logic;
using SampAutobind.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampAutobind.Forms
{
    public partial class GunbindsEditForm : Form
    {
        private int _selectedWeaponId { get; set; }
        public GunbindsEditForm()
        {
            InitializeComponent();
            CreateWeaponSelectionList();
        }

        private void CreateWeaponSelectionList()
        {
            List<Weapons> allWeapons = Enum.GetValues(typeof(Weapons)).Cast<Weapons>().ToList();
            foreach (Weapons item in allWeapons)
            {
                weaponSelectBox.Items.Add(item.ToString());
            }
        }

        private void weaponSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Weapons selectedEnum = (Weapons)Enum.Parse(typeof(Weapons), weaponSelectBox.SelectedItem.ToString());
            //MessageBox.Show(selectedEnum.GetHashCode().ToString());
            weaponInTextBox.Enabled = true;
            weaponOutTextBox.Enabled = true;
            gunBindsSaveBtn.Enabled = true;
            LoadWeaponIntoForm(selectedEnum);
        }

        private void LoadWeaponIntoForm(Weapons selectedEnum)
        {
            _selectedWeaponId = selectedEnum.GetHashCode();
            WeaponKeybindModel weaponKeybind = SettingsManager.Settings.WeaponKeybinds.Find(x => x.WeaponID == _selectedWeaponId);
            if (weaponKeybind == null)
            {
                weaponKeybind = new WeaponKeybindModel() { WeaponID = _selectedWeaponId };
                SettingsManager.Settings.WeaponKeybinds.Add(weaponKeybind);
            }
            weaponIdLbl.Text = _selectedWeaponId.ToString();
            weaponOutTextBox.Text = weaponKeybind.GunOutAction;
            weaponInTextBox.Text = weaponKeybind.GunInAction;
        }

        private void gunBindsSaveBtn_Click(object sender, EventArgs e)
        {
            WeaponKeybindModel weaponKeybind = SettingsManager.Settings.WeaponKeybinds.Find(x => x.WeaponID == _selectedWeaponId);
            weaponKeybind.GunInAction = weaponInTextBox.Text;
            weaponKeybind.GunOutAction = weaponOutTextBox.Text;
            SettingsManager.UpdateSettingsFile();
        }
    }
}
