using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Shell;
using Appl = System.Windows.Application;
using System.Threading;
using System.Windows.Threading;
using System.Drawing;

namespace ARK_Server_Configuration_Tool
{
    class ConfigUI
    {

        // Values in px
        int PaddingTop = 12;
        int PaddingBottom = 10;
        int PaddingLeft = 10;
        int Spacing = 15;


        // Function to add controls and events for an option
        public void AddConfigOption(Form TargetForm, TabPage TabTarget, JObject SettingParams, System.Drawing.Point Position)
        {
            MainForm MainForm_Control = Application.OpenForms.OfType<MainForm>().First();

            Control InputElement;

            // Define the control for saving the setting
            Button SaveSettingButton = new Button
            {
                Name = "Save" + SettingParams["name"].ToString().Replace(" ", "") + "Button",
                Location = new Point(TabTarget.Width - 72, Position.Y - 3),
                Image = Bitmap.FromHicon(SystemIcons.Application.Handle),
                Size = new Size(30, 25),
                Enabled = false
            };

            // Define the control for making the input

            switch (SettingParams["type"].ToString())
            {
                case "bool": // Boolean input
                    CheckBox InputElementCheckBox = new CheckBox();
                    InputElementCheckBox.Name = SettingParams["name"].ToString().Replace(" ", "") + "CheckBox";
                    InputElementCheckBox.CheckedChanged += (s, e) => { };
                    InputElement = InputElementCheckBox;

                    InputElementCheckBox.CheckedChanged += (s, e) => { SaveSettingButton.Enabled = true; };

                    SaveSettingButton.Click += (s, e) => {
                        SaveSetting(SettingParams, InputElementCheckBox.Checked);
                        SaveSettingButton.Enabled = false;
                    };

                    break;
                case "slider": // Integer input
                    ElementHost InputElementTrackBar = new ElementHost();
                    ARK_Server_Manager.AnnotatedSlider Slider = new ARK_Server_Manager.AnnotatedSlider
                    {
                        Maximum = Convert.ToSingle(SettingParams["range"][1]),
                        Minimum = Convert.ToSingle(SettingParams["range"][0]),
                        Value = 1,
                        Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFF, 0xFF, 0xFF))
                    };

                    Slider.ValueChanged += (s, e) => { SaveSettingButton.Enabled = true; };
                    dynamic HostedElement = MainForm_Control.Controls[SettingParams["name"].ToString().Replace(" ", "") + "TrackBar"];
                    InputElementTrackBar.Child = Slider;
                    InputElementTrackBar.Name = SettingParams["name"].ToString().Replace(" ", "") + "TrackBar";
                    InputElementTrackBar.Height = 25;
                    InputElement = InputElementTrackBar;
                    InputElement = InputElementTrackBar;

                    SaveSettingButton.Click += (s, e) => {
                        SaveSetting(SettingParams, Slider.Value);
                        SaveSettingButton.Enabled = false;
                    };

                    break;
                default: // Text input or unidentified input
                    TextBox InputElementTextBox = new TextBox();
                    InputElementTextBox.Name = SettingParams["name"].ToString().Replace(" ", "") + "TextBox";
                    InputElementTextBox.TextChanged += (s, e) => { };
                    InputElement = InputElementTextBox;

                    InputElementTextBox.TextChanged += (s, e) => { SaveSettingButton.Enabled = true; };

                    SaveSettingButton.Click += (s, e) => {
                        SaveSetting(SettingParams, InputElementTextBox.Text);
                        SaveSettingButton.Enabled = false;
                    };

                    break;
            }

            // Define the controls for setting name and saving the setting

            Label SettingNameLabel = new Label
            {
                Name = SettingParams["name"].ToString().Replace(" ", "") + "Label",
                Location = Position,
                Text = SettingParams["name"].ToString()
            };
            SettingNameLabel.Font = new Font(SettingNameLabel.Font.Name, 9.25F, SettingNameLabel.Font.Style, SettingNameLabel.Font.Unit);
            Position.X += SettingNameLabel.Width;

            InputElement.Font = new Font(InputElement.Font.Name, 10.25F, InputElement.Font.Style, InputElement.Font.Unit);

            InputElement.Location = new Point(Position.X, SettingNameLabel.Location.Y - (InputElement.Height - SettingNameLabel.Height)/2 - 2 );
            InputElement.Width = TabTarget.Width - 186;


            // Define the control for choosing between syncing setting with cluster
            Button SelectSyncButton = new Button
            {
                Name = "SyncSelect" + SettingParams["name"].ToString().Replace(" ", "") + "Button",
                Location = new Point(TabTarget.Width - 40, Position.Y - 3),
                Image = Bitmap.FromHicon(SystemIcons.Application.Handle),
                Size = new Size(30, 25)
            };


            // Add the controls for the setting here
            void AddToLayout()
            {
                TabTarget.Controls.Add(InputElement);
                TabTarget.Controls.Add(SettingNameLabel);
                TabTarget.Controls.Add(SaveSettingButton);
                TabTarget.Controls.Add(SelectSyncButton);
            }

            //InputElement.Width = TabTarget.Width - PaddingLeft;


            // Call the function to finally add the controls safely
            //Appl.Current.Dispatcher.BeginInvoke((Action)AddToLayout);
            //Dispatcher.Invoke(new MethodInvoker(AddToLayout));
            //Dispatcher.BeginInvoke(new Action(() => { AddToLayout(); }));


            if (TabTarget.InvokeRequired)
            {
                MainForm_Control.Invoke(new MethodInvoker(delegate
                {
                    AddToLayout();
                }));
            } else {
                AddToLayout();
            }

        }

        // Function to save the setting when the button is clicked
        private void SaveSetting(JObject Settings, dynamic SettingValue)
        {
            string ConfigPath = GlobalVariables.CurrentServerConfig["path"].ToString() + "\\ShooterGame\\Saved\\Config\\WindowsServer";
            switch (Settings["location"].ToString())
            {
                case "launch": // Launch argument
                    GlobalVariables.CurrentServerConfig["LaunchArgs"][Settings["name"].ToString()]["value"] = SettingValue;
                    break;
                case "GUS":    // GameUserSettings.ini
                    GlobalVariables.CurrentConfigInis.GameUserSettingsIni[Settings["section"].ToString()][Settings["name"].ToString()] = SettingValue;
                    GlobalVariables.CurrentConfigInis.Parser.WriteFile(ConfigPath + "\\GameUserSettings.ini", GlobalVariables.CurrentConfigInis.GameUserSettingsIni);
                    break;
                case "game":   // Game.ini
                    GlobalVariables.CurrentConfigInis.GameIni["/script/shootergame.shootergamemode"][Settings["name"].ToString()] = SettingValue;
                    GlobalVariables.CurrentConfigInis.Parser.WriteFile(ConfigPath + "\\Game.ini", GlobalVariables.CurrentConfigInis.GameIni);
                    break;
            }
        }

        public async Task AddConfigForCategories()
        {

            System.Drawing.Point Position = new System.Drawing.Point(10, 10);

            MainForm MainForm_Control = Application.OpenForms.OfType<MainForm>().First();

            dynamic ConfigSeri = await System.IO.File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "ServerSettingsList.json").ReadToEndAsync();
            dynamic ConfigList = JsonConvert.DeserializeObject(ConfigSeri);
            GlobalVariables.SettingsList = ConfigList;

            TabControl.TabPageCollection SettingsTabs = MainForm_Control.ServerSettingsTabControl.TabPages;

            foreach (dynamic Parent in ConfigList)
            {
                Position.X = PaddingLeft;
                Position.Y = PaddingTop;
                foreach (dynamic Category in Parent)
                {
                    foreach (dynamic Setting in Category)
                    {
                        try
                        {
                            AddConfigOption(MainForm_Control, SettingsTabs[SettingsTabs.IndexOfKey(Parent.Name.ToString())], Setting, Position);
                            /*Thread t = new Thread(() => AddConfigOption(MainForm_Control, SettingsTabs[SettingsTabs.IndexOfKey(Parent.Name.ToString())], Setting, Position));
                            t.SetApartmentState(ApartmentState.STA);
                            t.IsBackground = true;
                            t.Start();*/

                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show("Error while adding config \"" + Setting["name"].ToString() + "\":\n" + ex.Message);
                        }
                        Position.Y += PaddingTop + Spacing;
                    }

                }
            }

        }
    }
}
