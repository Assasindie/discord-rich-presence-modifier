using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using DiscordRPC;
using Microsoft.Win32;
using Newtonsoft.Json;
using Xceed.Wpf.Toolkit;
using MessageBox = Xceed.Wpf.Toolkit.MessageBox;

namespace DiscordRPModifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private DiscordRpcClient client;
        private DateTime gameTime;
        private bool initialised = false;
        private Settings settings;
        public static readonly RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        #region Theme Change Variable get/set
        bool DarkMode = true;
        //Foreground color get/set
        private string _CurrentForeground = "White";
        public string CurrentForeground
        {
            get { return _CurrentForeground; }
            set
            {
                if (value != _CurrentForeground)
                {
                    _CurrentForeground = value;
                    //If the value was different calls the OnPropertyChanged Event which will update the UI
                    OnPropertyChanged("CurrentForeground");
                }
            }
        }
        //Background get/set
        private string _CurrentBackground = "#FF343A40";
        public string CurrentBackground
        {
            get { return _CurrentBackground; }
            set
            {
                if (value != _CurrentBackground)
                {
                    _CurrentBackground = value;
                    //If the value was different calls the OnPropertyChanged Event which will update the UI
                    OnPropertyChanged("CurrentBackground");
                }
            }
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            SetBindings();
            LoadSettings();
        }

        #region Settings
        private void LoadSettings()
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
                    CheckFile(Environment.CurrentDirectory + @"\Presets\" + settings.StartPreset + ".env");
                    StartPresetTextBox.Text = settings.StartPreset;
                }
                LightThemeCheckBox.IsChecked = settings.DarkMode ? false : true;
                DarkMode = settings.DarkMode;
                ChangeTheme();
            }
            StartupCheckBox.IsChecked = RegKey.GetValueNames().Contains("DRPmodifier") ? true : false;
        }

        private void WriteSettings()
        {
            settings.StartPreset = StartPresetTextBox.Text;
            settings.DarkMode = DarkMode;
            string json = JsonConvert.SerializeObject(settings);
            using (StreamWriter sw = File.CreateText(Environment.CurrentDirectory + @"\settings.json"))
            {
                sw.Write(json);
            }
            MessageBox.Show("Saved Settings!");
        }
        #endregion

        #region File Functions
        private void CheckFile(string dir)
        {
            if (File.Exists(dir))
            {
                DotNetEnv.Env.Load(dir);

                foreach (TextBox t in FindVisualChildren<TextBox>(DetailsGrid))
                {
                    t.Text = Environment.GetEnvironmentVariable(t.Name.ToUpper());
                }
                foreach (IntegerUpDown i in FindVisualChildren<IntegerUpDown>(DetailsGrid))
                {
                    i.Value = int.Parse(Environment.GetEnvironmentVariable(i.Name.ToUpper()));
                }
                FileNameTextBox.Text = Environment.GetEnvironmentVariable("FILENAMETEXTBOX");
            }
        }

        private void CreateFile(string fileName)
        {
            string path = Environment.CurrentDirectory + @"\Presets\" + fileName + ".env";
            try
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (TextBox t in FindVisualChildren<TextBox>(DetailsGrid))
                    {
                        sw.WriteLine(t.Name.ToUpper() + "=" + t.Text);
                    }
                    foreach (IntegerUpDown i in FindVisualChildren<IntegerUpDown>(DetailsGrid))
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
        #endregion

        #region Field Checks
        //function for finding what type of control it is.
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public bool CheckBoxes()
        {
            foreach (TextBox t in FindVisualChildren<TextBox>(DetailsGrid))
            {
                //Part_TextBox is part of the IntegerUpAndDown and doesnt like this
                if (t.Text.Length <= 1 && t.Name != "PART_TextBox")
                {
                    MessageBox.Show("All fields must contain at least 2 characters! " + t.Name);
                    return false;
                }
            }
            return true;
        }
        #endregion 

        #region Rich Presence Functions
        private void Initalize()
        {
            if (initialised && ClientIDTextBox.Text != "")
            {
                ShutDown();
            }
            //true maybe
            client = new DiscordRpcClient(ClientIDTextBox.Text, true);

            client.OnError += (sender, e) =>
            {
                MessageBox.Show("Error");
            };

            client.OnReady += (sender, e) =>
            {

            };

            client.OnConnectionFailed += (sender, e) =>
            {
                MessageBox.Show("Connection Failed");
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                MessageBox.Show("Updated Presence");
            };

            client.Initialize();
            ChangePresence();
            client.Invoke();
            initialised = true;
        }

        public void ShutDown()
        {
            //temporarily shuts down the rich presence to set a new one up with a different ID
            client.ShutdownOnly = true;
            client.ClearPresence();
            client.Dispose();
        }

        public void ChangePresence()
        {
            DateTime utcTime = DateTime.UtcNow;
            gameTime = DateTime.UtcNow.AddSeconds(Convert.ToDouble(EndTimeBox.Value));
            TimeSpan elapseTime = gameTime - utcTime;
            client.SetPresence(new RichPresence()
            {
                Details = DetailsTextBox.Text,
                State = StateTextBox.Text,
                Party = new Party()
                {
                    ID = PartyIDTextBox.Text,
                    Max = 21,
                    Size = 1,
                },
                Secrets = new Secrets()
                {
                    JoinSecret = JoinSecretTextBox.Text,
                },
                Assets = new Assets()
                {
                    LargeImageKey = LargeImageKeyTextBox.Text,
                    LargeImageText = LargeImageTextBox.Text,
                    SmallImageKey = SmallImageKeyTextBox.Text,
                    SmallImageText = SmallImageTextBox.Text,
                },
                Timestamps = TimeElapsedCheckBox.IsChecked.Value ? Timestamps.Now : Timestamps.FromTimeSpan(elapseTime)
            });
            client.Invoke();
        }
        #endregion

        #region Theme Change bindings
        private void SetBindings()
        {
            MainGrid.SetBinding(BackgroundProperty, new Binding("CurrentBackground"));
            SetGridBindings(DetailsGrid);
            SetGridBindings(ActionsGrid);
            SetGridBindings(SettingsGrid);
            UpdateButton.SetBinding(ForegroundProperty, new Binding("CurrentForeground"));
            StopButton.SetBinding(ForegroundProperty, new Binding("CurrentForeground"));
        }

        private void SetGridBindings(Grid grid)
        {
            grid.SetBinding(BackgroundProperty, new Binding("CurrentBackground"));
            foreach (Control control in grid.Children)
            {
                if (control is Label || control is CheckBox)
                {
                    control.SetBinding(ForegroundProperty, new Binding("CurrentForeground"));
                }

                if (control is TextBox || control is Xceed.Wpf.Toolkit.IntegerUpDown)
                {
                    control.SetBinding(ForegroundProperty, new Binding("CurrentForeground"));
                    control.SetBinding(BackgroundProperty, new Binding("CurrentBackground"));
                }
            }
        }

        private void ChangeTheme()
        {
            CurrentBackground = DarkMode ? "#FF343A40" : "#FFE5E5E5";
            CurrentForeground = DarkMode ? "White" : "Black";
        }
        #endregion

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            System.Threading.Interlocked.CompareExchange(ref PropertyChanged, null, null)?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Button Events

        #region CheckBoxes
        private void TimeElapsedCheckBox_Click(object sender, RoutedEventArgs e)
        {
            //prevent from unselecting one
            TimeElapsedCheckBox.IsChecked = true;
            //unselects the other one
            EndTimeCheckBox.IsChecked = TimeElapsedCheckBox.IsChecked.Value ? false : true;
        }

        private void EndTimeCheckBox_Click(object sender, RoutedEventArgs e)
        {
            //prevent from unselecting one
            EndTimeCheckBox.IsChecked = true;
            //unselects the other one
            TimeElapsedCheckBox.IsChecked = EndTimeCheckBox.IsChecked.Value ? false : true;
        }

        private void LightThemeCheckBox_Click(object sender, RoutedEventArgs e)
        {

            DarkMode = !LightThemeCheckBox.IsChecked.Value;
            ChangeTheme();
        }
        #endregion

        #region Action Buttons
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxes())
            {
                Initalize();
                UpdateButton.IsEnabled = true;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxes())
            {
                ChangePresence();
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (initialised == true)
            {
                ShutDown();
                initialised = false;
            }
        }
        #endregion

        #region File Buttons
        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory + @"\Presets",
                Filter = "env files (*.env,env)|env;*.env;",
                RestoreDirectory = true,
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == true)
            {
                CheckFile(openFileDialog.FileName);
            }
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            CreateFile(FileNameTextBox.Text);
        }

        #endregion

        private void PreviewButton_Click(object sender, RoutedEventArgs e)
        {
            Preview prev = new Preview(StateTextBox.Text, DetailsTextBox.Text, TimeElapsedCheckBox.IsChecked.Value);
            prev.Show();
        }

        private void StartupCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(StartupCheckBox.IsChecked.Value == true)
            {
                Settings.AddToRegistry();
            }else
            {
                Settings.DeleteFromRegistery();
            }
        }

        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            WriteSettings();
        }

        #endregion

    }
}
