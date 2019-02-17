using DiscordRPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drpmodifier
{
    public partial class Form1 : Form
    {
        public DiscordRpcClient client;
        public DateTime gameTime;

        public Form1()
        {
            InitializeComponent();
            CheckFile();
        }

        private void initializeButton_Click(object sender, EventArgs e)
        {
            CheckBoxes();
            Initalize();
            updateButton.Enabled = true;
        }
        void Initalize()
        {
            client = new DiscordRpcClient(clientIDTextBox.Text, true);

            client.OnReady += (sender, e) =>
            {
                MessageBox.Show("Started with user " + e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                
            };
            client.Initialize();
            ChangePresence();
            var timer = new System.Timers.Timer(150);
            timer.Elapsed += (sender, args) => { client.Invoke(); };
            timer.Start();
            initializeButton.Enabled = false;
        }

        public void CheckBoxes()
        {
            foreach (Control c in Controls)
            {
                if(c.Text.Length <= 1)
                {
                    MessageBox.Show("All fields must contain at least 2 characters!");
                }
            }
        }

        public void ChangePresence()
        {
            DateTime utcTime = DateTime.UtcNow;
            gameTime = DateTime.UtcNow.AddSeconds(Convert.ToDouble(endTimeBox.Value));
            TimeSpan elapseTime = gameTime - utcTime;

            client.SetPresence(new RichPresence()
            {
                Details = detailsTextBox.Text,
                State = stateTextBox.Text,
                Party = new Party()
                {
                    ID = partyIDTextBox.Text,
                    Max = 21,
                    Size = 1,
                },
                Secrets = new Secrets()
                {
                    JoinSecret = joinSecretTextBox.Text,
                },
                Assets = new Assets()
                {
                    LargeImageKey = largeImageKeyTextBox.Text,
                    LargeImageText = largeImageTextBox.Text,
                    SmallImageKey = smallImageKeyTextBox.Text,
                    SmallImageText = smallImageTextBox.Text,
                },
                Timestamps = timeElapsedCheckBox.Checked ? Timestamps.Now : Timestamps.FromTimeSpan(elapseTime)

            });
        }

        private void endTimeBox_ValueChanged(object sender, EventArgs e)
        {
        }

        private void CheckFile()
        {
            if(File.Exists(Environment.CurrentDirectory + @"\.env"))
            {
                DotNetEnv.Env.Load();
                MessageBox.Show("Importing saved values!");
                foreach (Control c in Controls)
                {
                    if (c is RichTextBox || c is NumericUpDown)
                    {
                        c.Text = Environment.GetEnvironmentVariable(c.Name.ToUpper());
                    }
                }
            }
        }

        private void CreateFile()
        {
            string path = Environment.CurrentDirectory + @"\.env";
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (Control c in Controls)
                {
                    if (c is RichTextBox || c is NumericUpDown)
                    {
                        sw.WriteLine(c.Name.ToUpper() + "=" + c.Text);
                    }
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            CheckBoxes();
            ChangePresence();
        }

        private void createFileButton_Click(object sender, EventArgs e)
        {
            CreateFile();
        }

        private void timeElapsedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            endTimeCheckBox.Checked = timeElapsedCheckBox.Checked ? false : true;
            endTimeBox.Enabled = timeElapsedCheckBox.Checked ? false : true;
        }

        private void endTimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            timeElapsedCheckBox.Checked = endTimeCheckBox.Checked ? false : true;
        }
    }
}
