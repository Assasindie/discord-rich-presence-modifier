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
        public bool initialised = false;

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
            if(initialised && clientIDTextBox.Text != "")
            {
                //temporarily shuts down the rich presence to set a new one up with a different ID
                client.ShutdownOnly = true;
                client.DequeueAll();
                client.ClearPresence();
                client.Dispose();
            }

            client = new DiscordRpcClient(clientIDTextBox.Text, true);

            client.OnReady += (sender, e) =>
            {

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

        public void CheckBoxes()
        {
            foreach (Control c in Controls)
            {
                if(c.Text.Length <= 1 && c.Name != "fileNameTextBox")
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

        private void CheckFile(string dir)
        {
            if(File.Exists(dir))
            {
                DotNetEnv.Env.Load(dir);
                foreach (Control c in Controls)
                {
                    if (c is RichTextBox || c is NumericUpDown)
                    {
                        c.Text = Environment.GetEnvironmentVariable(c.Name.ToUpper());
                    }
                }
            }
        }

        private void CreateFile(string fileName)
        {
            string path = Environment.CurrentDirectory + @"\" + fileName + ".env";
            try
            {
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
                MessageBox.Show("Made file of current values");
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong! " + e.Message);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            CheckBoxes();
            ChangePresence();
        }

        private void CreateFileButton_Click(object sender, EventArgs e)
        {
            CreateFile(fileNameTextBox.Text);
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
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CheckFile(openFileDialog.FileName);
                }
            }
        }
    }
}
