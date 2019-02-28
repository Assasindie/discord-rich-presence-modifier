using DiscordRPC;
using System;
using System.IO;
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
        }

        private void InitializeButton_Click(object sender, EventArgs e)
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
            client.Invoke();
        }


        private void EndTimeBox_ValueChanged(object sender, EventArgs e)
        {
        }

        private void CheckFile(string dir)
        {
            if(File.Exists(dir))
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

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            CheckBoxes();
            ChangePresence();
        }

        private void CreateFileButton_Click(object sender, EventArgs e)
        {
            CreateFile();
        }

        private void TimeElapsedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            endTimeCheckBox.Checked = timeElapsedCheckBox.Checked ? false : true;
            endTimeBox.Enabled = timeElapsedCheckBox.Checked ? false : true;
        }

        private void EndTimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            timeElapsedCheckBox.Checked = endTimeCheckBox.Checked ? false : true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckFile(Environment.CurrentDirectory + @"\.env");
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.CurrentDirectory;
                openFileDialog.Filter = "env files (*.env,env)|env;*.env;";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CheckFile(openFileDialog.FileName);
                }
            }
        }
    }
}
