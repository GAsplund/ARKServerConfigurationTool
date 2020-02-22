using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ARK_Server_Configuration_Tool.Utilities;

namespace ARK_Server_Configuration_Tool
{
    public partial class NewServerProfileForm : Form
    {
        Profiles Prof = new Profiles();

        public NewServerProfileForm()
        {
            InitializeComponent();
        }

        private void BrowseForServerRootDirectoryButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                //InitialDirectory = "C:\\Users";
                IsFolderPicker = true
            };

            if (dialog.ShowDialog(this.Handle) == CommonFileDialogResult.Ok)
            {
                ServerRootDirectoryTextBox.Text = dialog.FileName;
            }
        }

        private void ServerRootDirectoryTextBox_TextChanged(object sender, EventArgs e)
        {
            // Recheck for every time if the directory is valid and has config files

            try
            {
                // Check if both ini files are present
                if (File.Exists(ServerRootDirectoryTextBox.Text+"\\ShooterGame\\Saved\\Config\\WindowsServer\\GameUserSettings.ini") && File.Exists(ServerRootDirectoryTextBox.Text + "\\ShooterGame\\Saved\\Config\\WindowsServer\\GameUserSettings.ini"))
                {
                    ImportInisCheckBox.Enabled = true;
                } else
                {
                    ImportInisCheckBox.Enabled = false;
                    ImportInisCheckBox.Checked = false;
                }
            } catch
            {
                ImportInisCheckBox.Enabled = false;
                ImportInisCheckBox.Checked = false;
            }
        }

        private void CommitCreateProfileButton_Click(object sender, EventArgs e)
        {
            // Create profile and close the form
            Prof.CreateProfile(ServerRootDirectoryTextBox.Text, ProfileNameTextBox.Text);
            Prof.GetProfiles();
            Close();
        }

        private void CancelCreateProfileButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
