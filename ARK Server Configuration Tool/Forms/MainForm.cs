using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARK_Server_Configuration_Tool.Structs;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Dialogs;
using ARK_Server_Configuration_Tool.Utilities;

namespace ARK_Server_Configuration_Tool
{
    public partial class MainForm : Form
    {

        Utilities.Profiles Prof = new Utilities.Profiles();
        Utilities.MapInfo MapInformation = new Utilities.MapInfo();
        ConfigUI Conf = new ConfigUI();

        public MainForm()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            if (null == System.Windows.Application.Current)
            {
                new System.Windows.Application();
            }

            InitializeComponent();
        }

        /// <summary>
        /// Create a new server profile
        /// </summary>
        private void NewProfileButton_Click(object sender, EventArgs e)
        {
            NewServerProfileForm NewProfile = new NewServerProfileForm();
            NewProfile.ShowDialog();
        }

        /// <summary>
        /// Delete a server profile
        /// </summary>
        private void DeleteServerButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the server profile?\n(It will only be forgotten, not deleted)", "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {

            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MapInfoDinoListDataGridView.Columns["LevelColumn"].ValueType = typeof(int);
            MapInfoDinoListDataGridView.Columns[MapInfoDinoListDataGridView.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            modsListDataGridView.Columns[modsListDataGridView.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Prof.GetProfiles();
            Prof.GetClusters();

            Conf.AddConfigForCategories();



            Task.Factory.StartNew(async () =>
            {
                Dinos.DinoAliases = JObject.Parse(await System.IO.File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "Aliases.json").ReadToEndAsync());
                Utilities.MapInfo MapInf = new Utilities.MapInfo();
                //await MapInformation.AddWildCreaturesToList(MapInformation.GetWildDinosInMap(GlobalVariables.CurrentServerConfig["path"] + "\\ShooterGame\\Saved\\SavedArks\\" + GlobalVariables.CurrentServerConfig["map"] + ".ark"));
            });
        }

        /// <summary>
        /// Manually update server status.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateServerStatusButton_Click(object sender, EventArgs e)
        {
            ServerStatusLabel.Text = "Server: Getting status...";
            Task.Factory.StartNew(async () =>
            {
                ServerStatus Status = new ServerStatus(new IPEndPoint(IPAddress.Parse("127.0.0.1"), Utilities.Profiles.currentProfile.queryPort));
                if (ServerStatusLabel.InvokeRequired)
                {
                    ServerStatusLabel.Invoke(new MethodInvoker(delegate
                    {
                        ServerStatusLabel.Text = ("Server: " + Status.CheckServerStatus().ToString().Replace("_", " "));
                    }));
                }
                else ServerStatusLabel.Text = ("Server: " + Status.CheckServerStatus().ToString().Replace("_", " "));

            });

        }

        /// <summary>
        /// Select new server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServerSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // A new server is selected, load the info for it
            Prof.LoadProfile(ServerSelectionComboBox.SelectedItem.ToString());
            Task.Factory.StartNew(async () =>
            {
                //ConfigParser CurrentConfigInis = new ConfigParser(ServerConfig["path"].ToString() + "\\ShooterGame\\Saved\\Config\\WindowsServer");
                //GlobalVariables.CurrentConfigInis = CurrentConfigInis;
                await MapInformation.AddWildCreaturesToList(MapInformation.GetWildDinosInMap(Utilities.Profiles.currentProfile.savepath));
            });

            //Task.Factory.StartNew(async () => { await Prof.LoadProfile(ServerSelectionComboBox.SelectedItem.ToString()); });
            ServerSettingsTabControl.Enabled = true;
            UpdateServerStatusButton.Enabled = true;
            SaveAndWriteSettingsButton.Enabled = true;
        }

        private void ClusterSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MapInfoDinoSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MapInformation.DisplayInfo(MapInfoDinoSelectionComboBox.SelectedItem.ToString(), MapInfoDinoListDataGridView);
            }
            catch
            {
                
            }
            
        }

        private void WildDinosRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (WildDinosRadioButton.Checked == true)
            {
                MapInfoDinoListDataGridView.Rows.Clear();
                Task.Factory.StartNew(async () =>
                {
                    await MapInformation.AddWildCreaturesToList(MapInformation.GetWildDinosInMap(Utilities.Profiles.currentProfile.savepath));
                });
            }
        }

        private void TamedDinosRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (TamedDinosRadioButton.Checked == true)
            {
                MapInfoDinoListDataGridView.Rows.Clear();
                Task.Factory.StartNew(async () =>
                {
                    await MapInformation.AddTamedCreaturesToList(MapInformation.GetTamedDinosInMap(Utilities.Profiles.currentProfile.savepath));
                });
            }
        }

        private void SaveAndWriteSettingsButton_Click(object sender, EventArgs e)
        {
            Utilities.Profiles.currentProfile.saveSettings();
            Utilities.Profiles.currentProfile.save();
        }

        private void globalDataLocationBrowseButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                //InitialDirectory = "C:\\Users";
                IsFolderPicker = true
            };

            if (dialog.ShowDialog(this.Handle) == CommonFileDialogResult.Ok)
            {
                globalDataLocationTextBox.Text = dialog.FileName;
            }
        }

        private void enableGlobalDataCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            globalDataLocationTextBox.Enabled = enableGlobalDataCheckBox.Checked;
            globalDataLocationBrowseButton.Enabled = enableGlobalDataCheckBox.Checked;
        }

        private void refreshSpaceUsageButton_Click(object sender, EventArgs e)
        {
            serverSpaceUsageLabel.Text = "Server Space Usage: Calculating...";
            Task.Factory.StartNew(async () =>
            {
                string serverSpaceUsageString = "Server Space Usage: " + SpaceUsage.SizeSuffix(SpaceUsage.DirectorySize(new System.IO.DirectoryInfo(Utilities.Profiles.currentProfile.path), true), 2);
                if (serverSpaceUsageLabel.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        serverSpaceUsageLabel.Text = serverSpaceUsageString;
                    }));
                }
                else
                {
                    serverSpaceUsageLabel.Text = serverSpaceUsageString;
                }
            });
            
        }

        private void addModButton_Click(object sender, EventArgs e)
        {
            AddModForm addMod = new AddModForm();
            addMod.Show();
        }

        private void updateModButton_Click(object sender, EventArgs e)
        {
            UpdaterForm updater = new UpdaterForm(Utilities.Profiles.currentProfile);
            Mod tempMod = new Mod { Id = Convert.ToUInt32(modsListDataGridView.SelectedRows[0].Cells[1].Value) };
            updater.UpdateMod(tempMod, false);
            updater.ShowDialog();
        }

        private void modsListDataGridView_CellContentClick(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (modsListDataGridView.SelectedRows.Count == 0)
            {
                modNameLabel.Text = "No Mod Selected";
                return;
            }
            else if (modsListDataGridView.SelectedRows[0].Cells[2].Value == null || modsListDataGridView.SelectedRows[0].Cells[2].Value == "")
            { 
                modNameLabel.Text = "(Unknown Mod Name)";
                modIndexTextBox.Text = modsListDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            }
            else
            { 
                modNameLabel.Text = modsListDataGridView.SelectedRows[0].Cells[2].Value.ToString();
                modIndexTextBox.Text = modsListDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            }

            decreaseModIndexButton.Enabled = modsListDataGridView.SelectedRows[0].Cells[0].Value.ToString() != "1";
            increadeModIndexButton.Enabled = modsListDataGridView.SelectedRows[0].Cells[0].Value.ToString() != modsListDataGridView.Rows.Count.ToString();
        }

        private void deleteModButton_Click(object sender, EventArgs e)
        {
            SortedDictionary<int, Mod> mods = Profiles.currentProfile.mods;
            DataGridViewRow row = modsListDataGridView.SelectedRows[0];
            mods.Remove(Convert.ToInt32(row.Cells[0].Value));
            mods = Mods.SortKeys(mods);
            Profiles.currentProfile.mods = mods;
            ConfigUI.LoadProfileMods(Profiles.currentProfile.mods);
        }

        private void increadeModIndexButton_Click(object sender, EventArgs e)
        {
            ConfigUI.MoveModUpDown(true);
        }

        private void decreaseModIndexButton_Click(object sender, EventArgs e)
        {
            ConfigUI.MoveModUpDown(false);
        }
    }
}
