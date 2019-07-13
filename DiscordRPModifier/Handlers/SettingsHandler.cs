using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace DiscordRPModifier
{
    class SettingsHandler
    {
        class Settings
        {
            public bool DarkMode { get; set; }
            public string StartPreset { get; set; }
        }
    
        private static Settings settings;
        public static readonly RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public static void AddToRegistry()
        {
            if (RegKey.GetValueNames().Contains("DRPmodifier"))
            {
                RegKey.SetValue("DRPmodifier", "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\"");
            }
        }

        public static void DeleteFromRegistery()
        {
            if (RegKey.GetValueNames().Contains("DRPmodifier"))
            {
                RegKey.DeleteValue("DRPmodifier");
            }
        }

        public static void LoadSettings(MainWindow window)
        {
            //loads the settings from settings.json
            if (File.Exists(Environment.CurrentDirectory + @"\settings.json"))
            {
                string json;
                using (StreamReader sr = File.OpenText(Environment.CurrentDirectory + @"\settings.json"))
                {
                    json = sr.ReadToEnd();
                }
                settings = JsonConvert.DeserializeObject<Settings>(json);
                if (settings.StartPreset != null)
                {
                    FileHandler.CheckFile(window, Environment.CurrentDirectory + @"\Presets\" + settings.StartPreset + ".env");
                    window.StartPresetTextBox.Text = settings.StartPreset;
                }
                window.LightThemeCheckBox.IsChecked = settings.DarkMode ? false : true;
                window.DarkMode = settings.DarkMode;
                window.ChangeTheme();
            }
            window.StartupCheckBox.IsChecked = RegKey.GetValueNames().Contains("DRPmodifier") ? true : false;
        }

        public static void WriteSettings(MainWindow window)
        {
            settings.StartPreset = window.StartPresetTextBox.Text;
            settings.DarkMode = window.DarkMode;
            string json = JsonConvert.SerializeObject(settings);
            using (StreamWriter sw = File.CreateText(Environment.CurrentDirectory + @"\settings.json"))
            {
                sw.Write(json);
            }
            MessageBox.Show("Saved Settings!");
        }
    }
}
