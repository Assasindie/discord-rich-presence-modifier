using Newtonsoft.Json;
using System.Windows;
using System;

namespace DiscordRPModifier.Handlers
{
    // class is unused now as website down
    static class UploadHandler
    {
        public class DRPenv
        {
            public string FILENAMETEXTBOX { get; set; }
            public string JOINSECRETTEXTBOX { get; set; }
            public string PARTYIDTEXTBOX { get; set; }
            public string SMALLIMAGEKEYTEXTBOX { get; set; }
            public string LARGEIMAGEKEYTEXTBOX { get; set; }
            public string SMALLIMAGETEXTBOX { get; set; }
            public string ENDTIMEBOX { get; set; }
            public string STATETEXTBOX { get; set; }
            public string CLIENTIDTEXTBOX { get; set; }
            public string LARGEIMAGETEXTBOX { get; set; }
            public string DETAILSTEXTBOX { get; set; }
        }

        public static readonly DRPenv env = new DRPenv();
        private static string LastResponse = "";
        private static DateTime UploadTime = DateTime.Now;


        public static void UploadFile(MainWindow window)
        {     
            env.FILENAMETEXTBOX = window.FileNameTextBox.Text;
            env.JOINSECRETTEXTBOX = window.JoinSecretTextBox.Text;
            env.PARTYIDTEXTBOX = window.PartyIDTextBox.Text;
            env.SMALLIMAGEKEYTEXTBOX = window.SmallImageKeyTextBox.Text;
            env.LARGEIMAGEKEYTEXTBOX = window.LargeImageKeyTextBox.Text;
            env.SMALLIMAGETEXTBOX = window.SmallImageTextBox.Text;
            env.ENDTIMEBOX = window.EndTimeBox.Text;
            env.STATETEXTBOX = window.StateTextBox.Text;
            env.CLIENTIDTEXTBOX = window.ClientIDTextBox.Text;
            env.LARGEIMAGETEXTBOX = window.LargeImageTextBox.Text;
            env.DETAILSTEXTBOX = window.DetailsTextBox.Text;

            /*
            var request = new Request();
            try
            {
                var response = (string)request.Execute("https://drpmodifierapi.azurewebsites.net/api/values", env, "Post");
                LastResponse = response;
            }
            catch
            {
                MessageBox.Show("Error occured connecting to the server");
            }
            */
            UploadTime = DateTime.Now;
            MessageBox.Show(LastResponse);
        }

        public static bool AllowUpload()
        {
            TimeSpan Span = DateTime.Now - UploadTime;
            if(LastResponse == "Success" && Span.TotalSeconds < 300)
            {
                //There is a 5 min cooldown on the API adding 
                MessageBox.Show("Error : Please wait ~5min before trying to upload again!");
                return false;
            } else if(Span.TotalSeconds < 20 && LastResponse != "") 
            {
                //Failed upload has a 20 second cooldown to prevent spam to the API
                MessageBox.Show("Error : Please wait ~20 seconds before trying to upload again!");
                return false;
            }
            return true;
        }

    }
}
