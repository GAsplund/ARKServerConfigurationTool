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
    public partial class UpdaterForm : Form
    {
        ServerProfile targetProfile;
        SteamCmd cmd;
        public UpdaterForm(ServerProfile profile)
        {
            InitializeComponent();
            targetProfile = profile;
            cmd = new SteamCmd(targetProfile, steamCmdLogTextBox);
        }

        public void UpdateMod(Mod mod, bool updatingMultipleMods)
        {
            cmd.UpdateMod(mod);
            mod.LastDownload = DateTime.Now;
            List<int> modsToUpdate = new List<int>();
            Profiles.currentProfile.mods.Where(m => m.Value.Id == mod.Id).ToList().ForEach(mv => modsToUpdate.Add(mv.Key));
            foreach (int modIndex in modsToUpdate) 
                Profiles.currentProfile.mods[modIndex] = mod;
        }

        public void UpdateServer() 
        {
            cmd.UpdateServer(true);
        }

        public void InstallServer()
        {
            cmd.UpdateServer(false);
        }

        private void UpdaterForm_Load(object sender, EventArgs e)
        {

        }

        private void steamCmdLogTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void skipCurrentModButton_Click(object sender, EventArgs e)
        {
            if (!cmd.p.HasExited) { cmd.p.Kill(); cmd.SkippedMod = true; }
            steamCmdLogTextBox.AppendText("Skipping current mod.\r\n");
        }
    }
}
