using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARK_Server_Configuration_Tool.Structs
{
    class Mods
    {
        public static SortedDictionary<int, Mod> SortKeys(SortedDictionary<int, Mod> mods)
        {
            SortedDictionary<int, Mod> newMods = new SortedDictionary<int, Mod>();
            int i = 1;
            foreach (Mod mod in mods.Values)
            {
                //KeyValuePair<int, Setting> newKvp = new KeyValuePair<int, Setting>(i, setting);
                newMods[i] = mod;
                i++;
            }
            return newMods;
        }

        public static SortedDictionary<int, Mod> MoveMod(SortedDictionary<int, Mod> mods, int key, bool up)
        {
            int upDown = up ? 1 : -1;

            Mod swap = mods[key];
            mods[key] = mods[key + upDown];
            mods[key + upDown] = swap;

            return mods;
        }
    }
}
