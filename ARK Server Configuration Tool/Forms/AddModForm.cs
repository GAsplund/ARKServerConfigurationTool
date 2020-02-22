using ARK_Server_Configuration_Tool.Structs;
using ARK_Server_Configuration_Tool.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARK_Server_Configuration_Tool
{
    public partial class AddModForm : Form
    {
        public AddModForm()
        {
            InitializeComponent();
        }

        private void commitAddModButton_Click(object sender, EventArgs e)
        {
            List<string> temp = new List<string>();
            temp.Add(modSearchTermTextBox.Text);
            PublishedFileDetailsResponse wsFile = SteamWorkshop.GetSteamModDetails(temp);
            if (wsFile.publishedfiledetails == null)
            {
                MessageBox.Show("Mod was not found. Please try again.");
                return;
            }
            PublishedFileDetail wsDetail = wsFile.publishedfiledetails[0];
            Mod newMod = new Mod() { Name = wsDetail.title, Id = Convert.ToUInt32(modSearchTermTextBox.Text), LastUpdate = SteamWorkshop.FromUnixTime(wsDetail.time_updated) };
            Profiles.currentProfile.mods[Profiles.currentProfile.mods.Count + 1] = newMod;
            Profiles.currentProfile.save();
            ConfigUI.LoadProfileMods(Profiles.currentProfile.mods);
            Close();
        }
    }
}
