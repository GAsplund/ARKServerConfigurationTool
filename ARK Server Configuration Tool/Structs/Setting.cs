using IniParser.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARK_Server_Configuration_Tool
{

    abstract class Setting
    {
        public enum SyncSetting { Server, Cluster }

        public SyncSetting sync = SyncSetting.Server;

        [JsonProperty("displayName")]
        public string name;
        [JsonProperty("name")]
        public string configName;
        public dynamic value;
        [JsonProperty("default")]
        public dynamic defaultValue;
        [JsonIgnore]
        private IniData file;
        [JsonProperty("type")]
        public string inputType;
        public int[] range = new int[2];

        public bool ShouldSerializename() { return false; }
        public bool ShouldSerializeconfigName() { return false; }
        public bool ShouldSerializeinputType() { return false; }
        public bool ShouldSerializedefaultValue() { return false; }
        public bool ShouldSerializerange() { return false; }

        public bool save()
        {
            switch (sync)
            {
                case SyncSetting.Server:
                    Utilities.Profiles.currentProfile.settings[configName] = this;
                    break;
                case SyncSetting.Cluster:
                    return false;
                    break;
            }
            return true;
        }

        //public bool save()
        //{
        //    string ConfigPath = GlobalVariables.CurrentServerConfig["path"].ToString() + "\\ShooterGame\\Saved\\Config\\WindowsServer";
            
        //    switch (location)
        //    {
        //        case SettingLocation.LaunchArgument: // Launch argument
        //            file.WriteKey("LaunchArgs", configName, value);
        //            //GlobalVariables.CurrentServerConfig["LaunchArgs"][configName]["value"] = value.ToString();
        //            return file.WriteFile();
        //        case SettingLocation.GameUserSettings:    // GameUserSettings.ini
        //            // Check if INI section was added, otherwise return false
        //            if (GUSsection == string.Empty) { return false; }
        //            file = new SystemIniFile(ConfigPath + "GameUserSettings.ini");
        //            file.
        //            file.WriteKey(GUSsection, configName, value.ToString());
        //            //GlobalVariables.CurrentConfigInis.GameUserSettingsIni[GUSsection][configName] = value.ToString();
        //            //GlobalVariables.CurrentConfigInis.Parser.WriteFile(ConfigPath + "\\GameUserSettings.ini", GlobalVariables.CurrentConfigInis.GameUserSettingsIni);
        //            return file.WriteFile();
        //        case SettingLocation.Game:   // Game.ini
        //            file = new IniFile(ConfigPath + "Game.ini");
        //            file.WriteKey("/script/shootergame.shootergamemode", configName, value.ToString());
        //            //GlobalVariables.CurrentConfigInis.GameIni["/script/shootergame.shootergamemode"][configName] = value.ToString();
        //            //GlobalVariables.CurrentConfigInis.Parser.WriteFile(ConfigPath + "\\Game.ini", GlobalVariables.CurrentConfigInis.GameIni);
        //            return file.WriteFile();
        //    }
        //    // No location was chosen, return false
        //    return false;
        //}

    }
}
