using System.Windows;

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
