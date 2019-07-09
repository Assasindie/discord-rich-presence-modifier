using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRPModifier
{
    class Settings
    {
        public bool DarkMode { get; set; }
        public string StartPreset { get; set; }
        public static void AddToRegistry()
        {
            if (!MainWindow.RegKey.GetValueNames().Contains("DRPmodifier"))
            {
                MainWindow.RegKey.SetValue("DRPmodifier", "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\"");
            }
        }

        public static void DeleteFromRegistery()
        {
            if (MainWindow.RegKey.GetValueNames().Contains("DRPmodifier"))
            {
                MainWindow.RegKey.DeleteValue("DRPmodifier");
            }
        }
    }
}
