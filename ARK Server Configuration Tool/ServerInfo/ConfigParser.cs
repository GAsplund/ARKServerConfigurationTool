using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IniParser;
using IniParser.Model;
using System.Windows.Forms;

namespace ARK_Server_Configuration_Tool
{
    class ConfigParser
    {
        public ConfigParser(string FolderPath)
        {
            var parser = new FileIniDataParser();

            // Read game configs
            IniData GameIni = parser.ReadFile(FolderPath + "\\Game.ini");
            IniData GameUserSettingsIni = parser.ReadFile(FolderPath + "\\GameUserSettings.ini");
            
        }
    }
}
