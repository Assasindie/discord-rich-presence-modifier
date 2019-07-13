using DiscordRPModifier.Handlers;
using System;
using System.IO;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace DiscordRPModifier
{
    class FileHandler
    {
        public static void CreateFile(MainWindow window, string FileName)
        {
            string path = Environment.CurrentDirectory + @"\Presets\" + FileName + ".env";
            try
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(window.FileNameTextBox.Name.ToUpper() + "=" + window.FileNameTextBox.Text);
                    foreach (TextBox t in CheckHandlers.FindVisualChildren<TextBox>(window.DetailsGrid))
                    {
                        sw.WriteLine(t.Name.ToUpper() + "=" + t.Text);
                    }
                    foreach (IntegerUpDown i in CheckHandlers.FindVisualChildren<IntegerUpDown>(window.DetailsGrid))
                    {
                        sw.WriteLine(i.Name.ToUpper() + "=" + i.Value);
                    }
                }
                MessageBox.Show("Made file of current values");
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong! " + e.Message);
            }
        }

        public static void CheckFile(MainWindow window, string dir)
        {
            if (File.Exists(dir))
            {
                DotNetEnv.Env.Load(dir);

                foreach (TextBox t in CheckHandlers.FindVisualChildren<TextBox>(window.DetailsGrid))
                {
                    t.Text = Environment.GetEnvironmentVariable(t.Name.ToUpper());
                }
                foreach (IntegerUpDown i in CheckHandlers.FindVisualChildren<IntegerUpDown>(window.DetailsGrid))
                {
                    i.Value = int.Parse(Environment.GetEnvironmentVariable(i.Name.ToUpper()));
                }
                window.FileNameTextBox.Text = Environment.GetEnvironmentVariable("FILENAMETEXTBOX");
            }
        }
    }
}
