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

    public abstract class Setting
    {
        public enum SyncSetting { Server, Cluster }

        public SyncSetting Sync = SyncSetting.Server;

        [JsonProperty("displayName")]
        public string Name;
        public bool ShouldSerializename() { return false; }
        [JsonProperty("name")]
        public string ConfigName;
        public bool ShouldSerializeconfigName() { return false; }
        public dynamic value;
        [JsonProperty("default")]
        public dynamic DefaultValue;
        public bool ShouldSerializedefaultValue() { return false; }
        [JsonIgnore]
        private IniData file;
        [JsonProperty("type")]
        public string InputType;
        public bool ShouldSerializeinputType() { return false; }
        public int[] Range = new int[2];
        public bool ShouldSerializerange() { return false; }
        

        public bool Save()
        {
            switch (Sync)
            {
                case SyncSetting.Server:
                    Utilities.Profiles.currentProfile.settings[ConfigName] = this;
                    break;
                case SyncSetting.Cluster:
                    return false;
            }
            return true;
        }

        //public bool save()
        //{
        //    string ConfigPath = GlobalVariables.CurrentServerConfig["path"].ToString() + "\\ShooterGame\\Saved\\Config\\WindowsServer";
        //  
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
