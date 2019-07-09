using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DiscordRPModifier
{
    /// <summary>
    /// Interaction logic for Preview.xaml
    /// </summary>
    public partial class Preview : Window
    {
        public Preview(string State, string Details, bool Timer)
        {
            InitializeComponent();
            StateLabel.Content = State;
            DetailsLabel.Content = Details;
            TimeLabel.Content = Timer ? "00:00:00 Elapsed" : "00:00:00 Left";
        }
    }
}
