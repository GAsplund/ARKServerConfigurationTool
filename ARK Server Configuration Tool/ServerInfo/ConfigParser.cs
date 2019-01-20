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
    public class ConfigParser
    {
        public IniData GameUserSettingsIni;
        public IniData GameIni;
        public FileIniDataParser Parser;
        public ConfigParser(string FolderPath)
        {
            Parser = new FileIniDataParser();

            // Read game configs
            GameIni = Parser.ReadFile(FolderPath + "\\Game.ini");
            GameUserSettingsIni = Parser.ReadFile(FolderPath + "\\GameUserSettings.ini");
            
        }
    }
}
