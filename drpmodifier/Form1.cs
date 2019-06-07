using DiscordRPC;
using System;
using System.IO;
using System.Windows.Forms;

namespace drpmodifier
{
    public partial class Form1 : Form
    {
        private DiscordRpcClient client;
        private DateTime gameTime;
        private bool initialised = false;
        private Form2 f2;
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeButton_Click(object sender, EventArgs e)
        {
            if (CheckBoxes())
            {
                Initalize();
                updateButton.Enabled = true;
            }
        }

        void Initalize()
        {
            if(initialised && clientIDTextBox.Text != "")
            {
                ShutDown();
            }

            client = new DiscordRpcClient(clientIDTextBox.Text, true);

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
            client.DequeueAll();
            client.ClearPresence();
            client.Dispose();
        }

        public bool CheckBoxes()
        {
            foreach (Control c in Controls)
            {
                if(c.Text.Length <= 1 && c.Name != "fileNameTextBox")
                {
                    MessageBox.Show("All fields must contain at least 2 characters!");
                    return false;
                }
            }
            return true;
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
            if (CheckBoxes())
            {
                ChangePresence();
            }
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

        private void StopPresenceButton_Click(object sender, EventArgs e)
        {
            if(initialised == true)
            {
                ShutDown();
                initialised = false;
            }           
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            f2 = new Form2(stateTextBox.Text, detailsTextBox.Text, timeElapsedCheckBox.Checked);
            f2.Show();
        }
    }
}
