using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace ARK_Server_Configuration_Tool
{
    public static class Dinos
    {

        public static JObject SettingsList = new JObject();

        public static JObject DinoAliases = new JObject();

        public static string getDinoAlias(string dinoClassName)
        {
            return "";
        }

    }
}
