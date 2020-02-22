using ARK_Server_Configuration_Tool.Structs;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARK_Server_Configuration_Tool
{
    class Settings
    {

        public static List<Setting> defaultSettings;

        // For deserializing the default setting parameters
        public class SettingConverterPreset : Utilities.AbstractJsonConverter<Setting>
        {
            protected override Setting Create(Type objectType, JObject jObject, string path)
            {
                if (FieldExists(jObject, "section", JTokenType.String))
                    return new GUSSetting();

                if (FieldExists(jObject, "argType", JTokenType.Boolean))
                    return new LaunchSetting();

                return new GameSetting();

                throw new InvalidOperationException();
            }
        }

        // For deserializing the settings from the profile
        public class SettingConverterProfile : Utilities.AbstractJsonConverter<Setting>
        {
            protected override Setting Create(Type objectType, JObject jObject, string path)
            {
                string settingType = defaultSettings.Where(s => s.ConfigName == path).First().GetType().Name;

                switch (settingType)
                {
                    case "GUSSetting":
                        return new GUSSetting();
                    case "LaunchSetting":
                        return new LaunchSetting();
                    case "GameSetting":
                        return new GameSetting();
                }

                throw new InvalidOperationException();
            }
        }
    }
}
