using DiscordRPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drpmodifier
{
    public partial class Form1 : Form
    {
        public DiscordRpcClient client;

        public Form1()
        {
            InitializeComponent();
        }

        private void initializeButton_Click(object sender, EventArgs e)
        {
            if (clientIDTextBox.Text == "")
            {
                MessageBox.Show("Please enter a client ID!");
            }
            Initalize();

        }

        void Initalize()
        {
            client = new DiscordRpcClient(clientIDTextBox.Text);

            client.OnReady += (sender, e) =>
            {
                MessageBox.Show("Started with user " + e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                
            };
            client.Initialize();

            DateTime utcTime = DateTime.UtcNow;
            DateTime gameTime = DateTime.UtcNow.AddSeconds(Convert.ToDouble(endTimeBox.Value));
            TimeSpan elapseTime = gameTime - utcTime;
            client.SetPresence(new RichPresence()
            {
                Details = detailsTextBox.Text,
                State = stateTextBox.Text,
                Assets = new Assets()
                {
                    LargeImageKey = largeImageKeyTextBox.Text,
                    LargeImageText = largeImageTextBox.Text,
                    SmallImageKey = smallImageKeyTextBox.Text,
                    SmallImageText = smallImageTextBox.Text,
                },
                Timestamps = Timestamps.FromTimeSpan(elapseTime)
            });
            var timer = new System.Timers.Timer(150);
            timer.Elapsed += (sender, args) => { client.Invoke(); };
            timer.Start();
        }



        private void endTimeBox_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
