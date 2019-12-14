using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARK_Server_Configuration_Tool.Structs
{
    class LaunchSetting : Setting
    {
        public enum Type { QuestionMark, Dash }
        public Type type;
    }
}
