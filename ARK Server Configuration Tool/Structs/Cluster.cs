using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARK_Server_Configuration_Tool.Structs
{
    class Cluster
    {
        public static Cluster currentCluster;
        public static List<Cluster> clusters = new List<Cluster>();

        public List<Server> servers = new List<Server>();
    }
}
