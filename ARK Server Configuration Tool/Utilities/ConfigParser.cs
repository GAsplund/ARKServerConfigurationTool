using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IniParser;
using IniParser.Model;
using System.Windows.Forms;
using IniParser.Model.Configuration;

namespace ARK_Server_Configuration_Tool
{
    public class ConfigParser
    {
        public IniData GameUserSettingsIni;
        public IniData GameIni;
        public FileIniDataParser Parser;
        public ConfigParser(string FolderPath)
        {
            Parser = new FileIniDataParser();
            Parser.Parser.Configuration.AllowDuplicateKeys = true;

            // Read game configs
            try
            {
                GameIni = Parser.ReadFile(FolderPath + "\\Game.ini");
                GameUserSettingsIni = Parser.ReadFile(FolderPath + "\\GameUserSettings.ini");

            } catch (Exception ex)
            {
                MessageBox.Show("Could not load INI files. Try loading another server. Error:\n" + ex.Message);
                MainForm MainForm_Control = Application.OpenForms.OfType<MainForm>().First();
                MainForm_Control.ServerSelectionComboBox.SelectedIndex = 0;
            }
            
            
        }
    }
}
