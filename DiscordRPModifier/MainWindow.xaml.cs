using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiscordRPModifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
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
        private string _CurrentBackground = "#FF1E1E1E";
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
        }

        private void LightThemeCheckBox_Click(object sender, RoutedEventArgs e)
        {

            DarkMode = !LightThemeCheckBox.IsChecked.Value;
            CurrentBackground = DarkMode ? "#FF1E1E1E" : "#FFE5E5E5";
            CurrentForeground = DarkMode ? "White" : "Black";
        }

        #region Theme Change bindings
        private void SetBindings()
        {
            MainGrid.SetBinding(BackgroundProperty, new Binding("CurrentBackground"));
            SetGridBindings(DetailsGrid);
            SetGridBindings(ActionsGrid);
            SetGridBindings(SettingsGrid);
        }

        private void SetGridBindings(Grid grid)
        {
            grid.SetBinding(BackgroundProperty, new Binding("CurrentBackground"));
            foreach(Control control in grid.Children)
            {
                if(control is Label || control is CheckBox)
                {
                    control.SetBinding(ForegroundProperty, new Binding("CurrentForeground"));
                }
                
                if(control is RichTextBox || control is Xceed.Wpf.Toolkit.IntegerUpDown) {
                    control.SetBinding(ForegroundProperty, new Binding("CurrentForeground"));
                    control.SetBinding(BackgroundProperty, new Binding("CurrentBackground"));
                }
            }
        }
        #endregion

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            System.Threading.Interlocked.CompareExchange(ref PropertyChanged, null, null)?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
