using Newtonsoft.Json;
using JsonRequest;
using System.Windows;

namespace DiscordRPModifier.Handlers
{
    class UploadHandler
    {
        public static DRPenv env = new DRPenv();
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

            string json = JsonConvert.SerializeObject(env);
            var request = new Request();
            var response = (string)request.Execute("https://localhost:44330/api/values", env, "Post");
            MessageBox.Show(response.ToString());
        }

    }
}
