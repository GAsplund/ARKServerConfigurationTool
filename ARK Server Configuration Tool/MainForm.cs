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
            MapInfoDinoListDataGridView.Columns[MapInfoDinoListDataGridView.Columns.Count -1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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

        public static Task StartSTATask(Action func)
        {
            var tcs = new TaskCompletionSource<object>();
            var thread = new Thread(() =>
            {
                try
                {
                    func();
                    tcs.SetResult(null);
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            return tcs.Task;
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
                else
                {
                    ServerStatusLabel.Text = ("Server: " + Status.CheckServerStatus().ToString().Replace("_", " "));
                }

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
                string serverSpaceUsageString = "Server Space Usage: " + SizeSuffix(DirectorySize(new System.IO.DirectoryInfo(Utilities.Profiles.currentProfile.path), true), 2);
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

        static long DirectorySize(System.IO.DirectoryInfo dInfo, bool includeSubDir)
        {
            long totalSize = dInfo.EnumerateFiles()
                         .Sum(file => file.Length);
            if (includeSubDir)
            {
                totalSize += dInfo.EnumerateDirectories()
                         .Sum(dir => DirectorySize(dir, true));
            }
            return totalSize;
        }

        static readonly string[] SizeSuffixes =
                   { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }

    }
}
