using DiscordRPC;
using System;
using System.Windows;

namespace DiscordRPModifier
{
    class RichPresenceHandler
    {
        private static DiscordRpcClient client;
        private static DateTime gameTime;
        public static bool initialised = false;

        public static void Initalize(MainWindow window)
        {
            if (initialised && window.ClientIDTextBox.Text != "")
            {
                ShutDown();
            }

            client = new DiscordRpcClient(window.ClientIDTextBox.Text, true);

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
            ChangePresence(window);
            client.Invoke();
            initialised = true;
        }

        public static void ShutDown()
        {
            //temporarily shuts down the rich presence to set a new one up with a different ID
            client.ShutdownOnly = true;
            client.ClearPresence();
            client.Dispose();
        }

        public static void ChangePresence(MainWindow window)
        {
            DateTime utcTime = DateTime.UtcNow;
            gameTime = DateTime.UtcNow.AddSeconds(Convert.ToDouble(window.EndTimeBox.Value));
            TimeSpan elapseTime = gameTime - utcTime;
            client.SetPresence(new RichPresence
            {
                Details = window.DetailsTextBox.Text,
                State = window.StateTextBox.Text,
                Party = new Party
                {
                    ID = window.PartyIDTextBox.Text,
                    Max = 21,
                    Size = 1,
                },
                Secrets = new Secrets
                {
                    JoinSecret = window.JoinSecretTextBox.Text,
                },
                Assets = new Assets
                {
                    LargeImageKey = window.LargeImageKeyTextBox.Text,
                    LargeImageText = window.LargeImageTextBox.Text,
                    SmallImageKey = window.SmallImageKeyTextBox.Text,
                    SmallImageText = window.SmallImageTextBox.Text,
                },
                Timestamps = window.TimeElapsedCheckBox.IsChecked.Value ? Timestamps.Now : Timestamps.FromTimeSpan(elapseTime)
            });
            client.Invoke();
        }
    }
}
