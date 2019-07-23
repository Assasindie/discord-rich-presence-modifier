using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DiscordRPModifier.Handlers;
using Microsoft.Win32;

namespace DiscordRPModifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Theme Change Variable get/set
        public bool DarkMode = true;
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
            SettingsHandler.LoadSettings(this);
        }

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

        private static void SetGridBindings(Grid grid)
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

        public void ChangeTheme()
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
            if (CheckHandlers.CheckBoxes(this))
            {
                RichPresenceHandler.Initalize(this);
                UpdateButton.IsEnabled = true;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckHandlers.CheckBoxes(this))
            {
                RichPresenceHandler.ChangePresence(this);
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (RichPresenceHandler.initialised == true)
            {
                RichPresenceHandler.ShutDown();
                RichPresenceHandler.initialised = false;
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
                FileHandler.CheckFile(this, openFileDialog.FileName);
            }
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            FileHandler.CreateFile(this, FileNameTextBox.Text);
        }

        #endregion

        private void PreviewButton_Click(object sender, RoutedEventArgs e)
        {
            Preview prev = new Preview(StateTextBox.Text, DetailsTextBox.Text, TimeElapsedCheckBox.IsChecked.Value);
            prev.Show();
        }

        private void StartupCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (StartupCheckBox.IsChecked.Value == true)
            {
                SettingsHandler.AddToRegistry();
            }
            else
            {
                SettingsHandler.DeleteFromRegistery();
            }
        }

        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsHandler.WriteSettings(this);
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckHandlers.CheckBoxes(this) && UploadHandler.AllowUpload())
            {
                UploadHandler.UploadFile(this);
            }
        }
        #endregion

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
        }
    }
}
