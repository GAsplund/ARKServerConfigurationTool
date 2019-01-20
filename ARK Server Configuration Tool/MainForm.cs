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

        private void NewProfileButton_Click(object sender, EventArgs e)
        {
            NewServerProfileForm NewProfile = new NewServerProfileForm();
            NewProfile.ShowDialog();
        }

        private void DeleteServerButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the server profile?\n(It will only be forgotten, not deleted)", "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Prof.GetProfiles();
            Prof.GetClusters();

            Conf.AddConfigForCategories();

            //Task.Factory.StartNew(async() => { await Conf.AddConfigForCategories(); });
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

        private void UpdateServerStatusButton_Click(object sender, EventArgs e)
        {
            ServerStatusLabel.Text = "Server: Getting status...";
            Task.Factory.StartNew(async () =>
            {
                ServerStatus Status = new ServerStatus(new IPEndPoint(IPAddress.Parse("127.0.0.1"), Convert.ToInt32(GlobalVariables.CurrentServerConfig["queryPort"])));
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

        private void ServerSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // A new server is selected, load the info for it
            Prof.LoadProfile(ServerSelectionComboBox.SelectedItem.ToString());
            string SavePath;
            dynamic ServerConfig;
            Task.Factory.StartNew(async () => 
            {
                ServerConfig = GlobalVariables.CurrentServerConfig;
                SavePath = GlobalVariables.CurrentServerConfig["path"] + "\\ShooterGame\\Saved\\SavedArks\\" + ServerConfig["map"] + ".ark";
                ConfigParser CurrentConfigInis = new ConfigParser(ServerConfig["path"].ToString() + "\\ShooterGame\\Saved\\Config\\WindowsServer");
                GlobalVariables.CurrentConfigInis = CurrentConfigInis;
                await MapInformation.AddWildCreaturesToList(MapInformation.GetWildDinosInMap(SavePath));
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
            MapInformation.DisplayInfo(MapInfoDinoSelectionComboBox.SelectedItem.ToString());
        }
    }
}
