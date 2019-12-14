using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ARK_Server_Configuration_Tool.Structs
{
    class ServerProfile
    {
        Server server;
        public string name;
        public string path;

        public Dictionary<string, Setting> settings = new Dictionary<string, Setting>();
        [JsonIgnore]
        public string savepath
        {
            get
            {
                return path + "\\ShooterGame\\Saved\\SavedArks\\" + map + ".ark";
            }
        }

        public bool saveSettings()
        {
            List<string> GameSettings = new List<string>();
            Dictionary<string, List<string>> GameUserSettings = new Dictionary<string, List<string>>();
            List<LaunchSetting> LaunchSettings = new List<LaunchSetting>();


            foreach(KeyValuePair<string, Setting> settingPair in settings)
            {
                Setting setting = settingPair.Value;
                switch (setting.GetType().Name)
                {
                    case "GameSetting":
                        GameSettings.Add(setting.name + "=" + setting.value);
                        break;
                    case "GUSSetting":
                        GUSSetting gussetting = (GUSSetting)setting;
                        if (gussetting.section == null) continue;
                        if (!GameUserSettings.ContainsKey(gussetting.section))
                        {
                            List<string> newList = new List<string> { setting.configName + "=" + setting.value };
                            GameUserSettings.Add(gussetting.section, newList);
                        } else GameUserSettings[gussetting.section].Add(setting.configName + "=" + setting.value);
                        break;
                    case "LaunchSetting":
                        LaunchSettings.Add((LaunchSetting)setting);
                        break;
                }
            }
            string GameSettingsString = "";
            foreach (string setting in GameSettings)
            {
                GameSettingsString += (setting + "\n");
            }
            string GameUserSettingsString = "";
            foreach(KeyValuePair<string, List<string>> category in GameUserSettings)
            {
                GameUserSettingsString += ("[" + category.Key + "]\n");
                foreach (string setting in category.Value)
                {
                    GameUserSettingsString += (setting + "\n").Replace(",",".");
                }
            }
            string LaunchString = "";
            LaunchString += map;
            foreach(LaunchSetting setting in LaunchSettings.Where(s => s.type == LaunchSetting.Type.QuestionMark))
            {
                LaunchString += "?" + setting.configName + "=" + setting.value;
            }
            foreach (LaunchSetting setting in LaunchSettings.Where(s => s.type == LaunchSetting.Type.Dash))
            {
                LaunchString += " -" + setting.configName;
            }


            // Remove illegal characters and create a new profile folder
            string illegal = name;
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));

            string ProfileDir = AppDomain.CurrentDomain.BaseDirectory + "\\Profiles\\" + r.Replace(illegal, "");

            Directory.CreateDirectory(ProfileDir);

            // Create a new JSON
            FileStream ServerGameIni = File.Create(ProfileDir + "\\Game.ini");
            ServerGameIni.Close();
            FileStream ServerGameUserSettingsIni = File.Create(ProfileDir + "\\GameUserSettings.ini");
            ServerGameUserSettingsIni.Close();

            // Write data to JSON file
            File.WriteAllText(ProfileDir + "\\Game.ini", GameSettingsString);
            File.WriteAllText(ProfileDir + "\\GameUserSettings.ini", GameUserSettingsString);
            File.WriteAllText(ProfileDir + "\\LaunchArgs.ini", LaunchString);

            return false;
        }

        public bool save()
        {
            try
            {
                // Remove illegal characters
                string illegal = name;
                string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
                Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));

                string ProfileDir = AppDomain.CurrentDomain.BaseDirectory + "\\Profiles\\" + r.Replace(illegal, "");

                File.WriteAllText(ProfileDir + "\\profile.json", JsonConvert.SerializeObject(this, Formatting.Indented));
                return true;
            }
            catch
            {
                return false;
            }

        }

        public string map;
        public UInt16 port = 7777;
        public UInt16 queryPort = 27015;
    }
}
