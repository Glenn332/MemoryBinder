using Newtonsoft.Json;
using SampAutobind.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampAutobind.Logic
{
    public static class SettingsManager
    {
        private static string settingsFile = "settings.json";
        public static SettingsModel Settings { get; set; }
        public static bool SettingsFileExist()
        {
            return File.Exists(settingsFile);
        }
        public static bool LoadSettingsFile()
        {
            if (!SettingsFileExist())
                return false;
            
            using (StreamReader sr = new StreamReader(settingsFile))
            {
                string text = sr.ReadToEnd();
                Settings = JsonConvert.DeserializeObject<SettingsModel>(text);
                sr.Close();
            }
            return true;
        }

        public static void CreateNewSettingsFile()
        {
            Settings = new SettingsModel() { WeaponKeybinds = new List<WeaponKeybindModel>() };
            using (StreamWriter sw = new StreamWriter(settingsFile))
            {
                sw.WriteLine(JsonConvert.SerializeObject(Settings));
                sw.Close();
            }
        }

        public static void UpdateSettingsFile()
        {
            using (StreamWriter sw = new StreamWriter(settingsFile))
            {
                sw.WriteLine(JsonConvert.SerializeObject(Settings));
                sw.Close();
            }
        }
    }
}
