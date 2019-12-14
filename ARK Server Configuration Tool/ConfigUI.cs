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
using ARK_Server_Configuration_Tool.Structs;

namespace ARK_Server_Configuration_Tool
{
    class ConfigUI
    {

        // Values in px
        int PaddingTop = 12;
        int PaddingLeft = 10;
        int Spacing = 15;


        // Function to add controls and events for an option
        public void AddConfigOption(Form MainForm_Control, TabPage TabTarget, Setting setting, Point Position)
        {

            Control InputElement;

            // Define the control for saving the setting
            Button SaveSettingButton = new Button
            {
                Name = "Save" + setting.configName + "Button",
                Location = new Point(TabTarget.Width - 72, Position.Y - 3),
                Image = Bitmap.FromHicon(SystemIcons.Application.Handle),
                Size = new Size(30, 25),
                Enabled = false
            };

            // Define the control for making the input

            switch (setting.inputType)
            {
                case "bool": // Boolean input
                    CheckBox InputElementCheckBox = new CheckBox();
                    InputElementCheckBox.Name = setting.configName + "CheckBox";
                    InputElementCheckBox.CheckedChanged += (s, e) => { };
                    if (setting.value == null) InputElementCheckBox.Checked = setting.defaultValue;
                    else if (setting.defaultValue == null) InputElementCheckBox.Checked = false;
                    else InputElementCheckBox.Checked = setting.value;
                    InputElement = InputElementCheckBox;

                    InputElementCheckBox.CheckedChanged += (s, e) => { SaveSettingButton.Enabled = true; };

                    SaveSettingButton.Click += (s, e) => {
                        setting.value = InputElementCheckBox.Checked;
                        if (!setting.save()) MessageBox.Show("Could not save bool setting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else SaveSettingButton.Enabled = false;
                    };

                    break;
                case "slider": // Integer input
                    ElementHost InputElementTrackBar = new ElementHost();
                    ARK_Server_Manager.AnnotatedSlider Slider = new ARK_Server_Manager.AnnotatedSlider
                    {
                        Maximum = Convert.ToSingle(setting.range[1]),
                        Minimum = Convert.ToSingle(setting.range[0]),
                        Value = 1,
                        Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFF, 0xFF, 0xFF))
                    };

                    if (setting.value == null && setting.defaultValue != null) Slider.Value = setting.defaultValue;
                    else if (setting.defaultValue == null) Slider.Value = 0;
                    else Slider.Value = setting.value;
                    Slider.ValueChanged += (s, e) => { SaveSettingButton.Enabled = true; };
                    dynamic HostedElement = MainForm_Control.Controls[setting.configName + "TrackBar"];
                    InputElementTrackBar.Child = Slider;
                    InputElementTrackBar.Name = setting.configName + "TrackBar";
                    InputElementTrackBar.Height = 25;
                    InputElement = InputElementTrackBar;
                    InputElement = InputElementTrackBar;

                    SaveSettingButton.Click += (s, e) => {
                        setting.value = Slider.Value;
                        if (!setting.save()) MessageBox.Show("Could not save int setting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                        else SaveSettingButton.Enabled = false;
                    };

                    break;
                default: // Text input or unidentified input
                    TextBox InputElementTextBox = new TextBox();
                    InputElementTextBox.Name = setting.configName + "TextBox";
                    if (setting.value == null) InputElementTextBox.Text = setting.defaultValue.ToString();
                    else if (setting.defaultValue == null) InputElementTextBox.Text = "";
                    else InputElementTextBox.Text = setting.value;
                    InputElementTextBox.TextChanged += (s, e) => { };
                    InputElement = InputElementTextBox;

                    InputElementTextBox.TextChanged += (s, e) => { SaveSettingButton.Enabled = true; };

                    SaveSettingButton.Click += (s, e) => {
                        setting.value = InputElementTextBox.Text;
                        if (!setting.save()) MessageBox.Show("Could not save string setting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                        else SaveSettingButton.Enabled = false;
                    };

                    break;
            }

            // Define the controls for setting name and saving the setting

            Label SettingNameLabel = new Label
            {
                Name = setting.configName + "Label",
                Location = Position,
                Text = setting.name
            };
            SettingNameLabel.Font = new Font(SettingNameLabel.Font.Name, 9.25F, SettingNameLabel.Font.Style, SettingNameLabel.Font.Unit);
            Position.X += SettingNameLabel.Width;

            InputElement.Font = new Font(InputElement.Font.Name, 10.25F, InputElement.Font.Style, InputElement.Font.Unit);

            InputElement.Location = new Point(Position.X, SettingNameLabel.Location.Y - (InputElement.Height - SettingNameLabel.Height)/2 - 2 );
            InputElement.Width = TabTarget.Width - 186;


            // Define the control for choosing between syncing setting with cluster
            Button SelectSyncButton = new Button
            {
                Name = "SyncSelect" + setting.configName + "Button",
                Location = new Point(TabTarget.Width - 40, Position.Y - 3),
                Image = Bitmap.FromHicon(SystemIcons.Error.Handle),
                Size = new Size(30, 25)
            };
            // Switch between syncing
            SelectSyncButton.Click += (s, e) => {

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

        public async Task AddConfigForCategories()
        {

            // Get the serialized JSON data for the defaults
            dynamic ConfigSeri = await System.IO.File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "ServerSettingsList.json").ReadToEndAsync();

            // Create the list of default setting parameters
            Dictionary<string, List<Setting>> defaultSettings = JsonConvert.DeserializeObject<Dictionary<string, List<Setting>>>(ConfigSeri, new Settings.SettingConverterPreset());
            Settings.defaultSettings = defaultSettings.Values.SelectMany(array => array).ToList();

            // Get the control for the main form
            MainForm MainForm_Control = Application.OpenForms.OfType<MainForm>().First();
            TabControl.TabPageCollection SettingsTabs = MainForm_Control.ServerSettingsTabControl.TabPages;

            // Create a new position for the position of each form
            Point Position = new Point(10, 10);

            // Add a collection of controls for each setting
            foreach (KeyValuePair<string, List<Setting>> settingsList in defaultSettings)
            {
                // Reset the position for each TabPager
                Position.X = PaddingLeft;
                Position.Y = PaddingTop;
                foreach (Setting setting in settingsList.Value)
                {
                    // Start the procedure to add the collecton of controls for each setting
                    AddConfigOption(MainForm_Control, SettingsTabs[SettingsTabs.IndexOfKey(settingsList.Key)], setting, Position);
                    Position.Y += PaddingTop + Spacing;
                }
            }

        }
    }
}
