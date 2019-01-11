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

namespace ARK_Server_Configuration_Tool
{
    class ConfigUI
    {

        // Values in px
        int PaddingTop = 12;
        int PaddingBottom = 10;
        int PaddingLeft = 10;
        int Spacing = 15;

        public void AddConfigOption(Form TargetForm, TabPage TabTarget, JObject SettingParams, System.Drawing.Point Position)
        {
            MainForm MainForm_Control = Application.OpenForms.OfType<MainForm>().First();

            Control InputElement;

            // Define the controls for the setting

            switch (SettingParams["type"].ToString())
            {
                case "bool": // Boolean input
                    CheckBox InputElementCheckBox = new CheckBox();
                    InputElementCheckBox.Name = SettingParams["name"].ToString().Replace(" ", "") + "CheckBox";
                    InputElement = InputElementCheckBox;
                    break;
                case "slider": // Integer input
                    ElementHost InputElementTrackBar = new ElementHost();
                    ARK_Server_Manager.AnnotatedSlider Sliderrrr = new ARK_Server_Manager.AnnotatedSlider();
                    Sliderrrr.Maximum = Convert.ToSingle(SettingParams["range"][1]);
                    Sliderrrr.Minimum = Convert.ToSingle(SettingParams["range"][0]);
                    Sliderrrr.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0xFF, 0xFF, 0xFF));
                    InputElementTrackBar.Child = Sliderrrr;
                    InputElementTrackBar.Name = SettingParams["name"].ToString().Replace(" ", "") + "TrackBar";
                    InputElementTrackBar.Height = 25;
                    //InputElementTrackBar.Child.
                    InputElement = InputElementTrackBar;
                    InputElement = InputElementTrackBar;

                    break;
                default: // Text input or unidentified input
                    TextBox InputElementTextBox = new TextBox();
                    InputElementTextBox.Name = SettingParams["name"].ToString().Replace(" ", "") + "TextBox";
                    InputElement = InputElementTextBox;
                    break;
            }

            

            // Create event for setting changed
            switch (InputElement.GetType().ToString())
            {
                case "System.Windows.Forms.CheckBox":
                    // Despite being click event, it still works. (CheckedChanged does not exist for Control type)
                    InputElement.Click += (s, e) => {  };
                    break;
                case "System.Windows.Forms.TextBox":
                    InputElement.TextChanged += (s, e) => {  };
                    break;
                case "System.Windows":
                    //InputElement;
                    break;
            }

            Label SettingNameLabel = new Label
            {
                Name = SettingParams["name"].ToString().Replace(" ", "") + "Label",
                Location = Position,
                Text = SettingParams["name"].ToString()
            };
            SettingNameLabel.Font = new System.Drawing.Font(SettingNameLabel.Font.Name, 9.25F, SettingNameLabel.Font.Style, SettingNameLabel.Font.Unit);
            Position.X += SettingNameLabel.Width;

            InputElement.Font = new System.Drawing.Font(InputElement.Font.Name, 10.25F, InputElement.Font.Style, InputElement.Font.Unit);

            InputElement.Location = new System.Drawing.Point(Position.X, SettingNameLabel.Location.Y - (InputElement.Height - SettingNameLabel.Height)/2 - 2 );
            InputElement.Width = TabTarget.Width - InputElement.Width-100;

            // Add the controls for the setting here
            void AddToLayout()
            {
                TabTarget.Controls.Add(InputElement);
                TabTarget.Controls.Add(SettingNameLabel);
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

        private void SetStyle()
        {
            throw new NotImplementedException();
        }

        public async Task AddConfigForCategories()
        {

            System.Drawing.Point Position = new System.Drawing.Point(10, 10);

            MainForm MainForm_Control = Application.OpenForms.OfType<MainForm>().First();

            dynamic ConfigSeri = await System.IO.File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "ServerSettingsList.json").ReadToEndAsync();
            dynamic ConfigList = JsonConvert.DeserializeObject(ConfigSeri);

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
