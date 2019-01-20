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
    public static class GlobalVariables
    {
        // The config for the current server
        public static JObject CurrentServerConfig = new JObject();

        // Get the servers for the cluster
        public static Dictionary<string, string> ClustersList = new Dictionary<string, string>();

        public static JObject SettingsList = new JObject();

        public static ConfigParser CurrentConfigInis;
    }
}
