using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARK_Server_Configuration_Tool.Utilities
{
    class Profiles
    {

        public void GetProfiles()
        {
            MainForm MainForm_Control = Application.OpenForms.OfType<MainForm>().First();

            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");

            List<string> Profiles = new List<string>();

            foreach(string dir in Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory + "Profiles")){
                if (File.Exists(dir + "\\profile.json"))
                {
                    dynamic ServerInfo = JsonConvert.DeserializeObject(File.ReadAllText(dir + "\\profile.json"));
                    JToken value;
                    if (ServerInfo.TryGetValue("name", out value))
                    { // Name was found, add it to the list of valid profiles
                        Profiles.Add(ServerInfo["name"].ToString());
                        //GlobalVariables.ServersList.Add(ServerInfo["name"].ToString());
                    }
                    else // Name was not found, therefore it is probably not a valid profile
                    {
                        continue;
                    }
                }
            }

            MainForm_Control.ServerSelectionComboBox.Items.Clear();

            foreach(string Profile in Profiles)
            {
                MainForm_Control.ServerSelectionComboBox.Items.Add(Profile);
            }

        }

        public void GetClusters()
        {
            MainForm MainForm_Control = Application.OpenForms.OfType<MainForm>().First();
            MainForm_Control.ClusterSelectionComboBox.Items.Clear();
            MainForm_Control.ClusterSelectionComboBox.Items.Add("(All Servers)");
            MainForm_Control.ClusterSelectionComboBox.Items.Add("(No Cluster)");
            MainForm_Control.ClusterSelectionComboBox.SelectedIndex = 0;
            foreach (string FileName in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "Clusters"))
            {
                MainForm_Control.ClusterSelectionComboBox.Items.Add(FileName);
            }
        }

        public void LoadProfile(string ProfileName)
        {
            string illegal = ProfileName;
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));

            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Profiles\\" + r.Replace(illegal, "") + "\\profile.json"))
            {
                throw new FileNotFoundException("The file for the profile was not found.");
            }
            JObject ServerInfo = JObject.Parse(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Profiles\\" + r.Replace(illegal, "") + "\\profile.json"));

            GlobalVariables.CurrentServerConfig = ServerInfo;

        }

        public void CreateProfile(string RootDir, string ProfileName)
        {
            // Ask user to create chosen directory if it doesn't exist
            if (!Directory.Exists(RootDir))
            {
                if (MessageBox.Show("The directory was not found. Would you like to create it?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    Directory.CreateDirectory(RootDir);
                }
            }

            // Remove illegal characters and create a new profile folder
            string illegal = ProfileName;
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));

            string ProfileDir = AppDomain.CurrentDomain.BaseDirectory + "\\Profiles\\" + r.Replace(illegal, "");

            Directory.CreateDirectory(ProfileDir);

            // Create a new JSON
            FileStream ServerInfoFile = File.Create(ProfileDir + "\\profile.json");
            ServerInfoFile.Close();

            dynamic ServerInfo = new JObject();

            // Write initial data to JSON
            GlobalVariables.CurrentServerConfig["path"] = RootDir;
            GlobalVariables.CurrentServerConfig["name"] = ProfileName;

            // Write data to JSON file
            File.WriteAllText(ProfileDir + "\\profile.json", JsonConvert.SerializeObject(ServerInfo, Formatting.Indented));

            // Update the profile list

            // Set the profile to the profile that was just created
        }

    }
}
