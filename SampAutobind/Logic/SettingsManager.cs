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
        public static List<WeaponKeybindModel> Settings { get; set; }
        public static void LoadSettingsFile()
        {
            Settings = new List<WeaponKeybindModel>();
            if (File.Exists(settingsFile))
            {
                using (StreamReader sr = new StreamReader(settingsFile))
                {
                    string text = sr.ReadToEnd();
                    Settings = JsonConvert.DeserializeObject<List<WeaponKeybindModel>>(text);
                    sr.Close();
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(settingsFile))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(Settings));
                    sw.Close();
                }
            }
        }
    }
}
