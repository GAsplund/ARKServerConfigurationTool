using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARK_Server_Configuration_Tool.Structs
{
    public class Mod
    {
        public uint Id;
        public string Name;
        public DateTime LastDownload;
        public DateTime LastUpdate;
        public long Size;

        public string SizeString { get { return Size.ToString() + " bytes"; } }
    }
}
