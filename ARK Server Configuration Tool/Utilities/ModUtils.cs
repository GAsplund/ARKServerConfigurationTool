using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ionic.Zlib;

namespace ARK_Server_Configuration_Tool.Utilities
{
    public static class ModUtils
    {
        public const string MODTYPE_UNKNOWN = "0";
        public const string MODTYPE_MAP = "2";
        public const string MODTYPE_MAPEXT = "4";
        public const string MODTYPE_MOD = "1";
        public const string MODTYPE_TOTCONV = "3";

        public const string MODTYPENAME_UNKNOWN = "<unknown>";
        public const string MODTYPENAME_NOTDOWNLOADED = "<not downloaded>";
        public const string MODTYPENAME_MAP = "Map";
        public const string MODTYPENAME_MAPEXT = "Map Extension";
        public const string MODTYPENAME_MOD = "Mod";
        public const string MODTYPENAME_TOTCONV = "Total Conversion";

        public const string MODID_PRIMITIVEPLUS = "111111111";
        public const string MODID_THECENTER = "TheCenter";
        public const string MODID_RAGNAROK = "Ragnarok";

        private class FCompressedChunkInfo
        {
            public const uint LOADING_COMPRESSION_CHUNK_SIZE = 131072U;
            public const uint PACKAGE_FILE_TAG = 2653586369U;
            public const uint PACKAGE_FILE_TAG_SWAPPED = 3246598814U;

            public long CompressedSize;
            public long UncompressedSize;

            public void Serialize(BinaryReader reader)
            {
                CompressedSize = reader.ReadInt64();
                UncompressedSize = reader.ReadInt64();
            }
        }

        //public static string NormalizePath(string path) => Path.GetFullPath(new Uri(path).LocalPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).ToLowerInvariant();

        static void AddTextToTextBox(System.Windows.Forms.TextBox outputLogBox, string text)
        {
            if (outputLogBox.InvokeRequired)
            {
                outputLogBox.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                {
                    outputLogBox.AppendText(text + "\r\n");
                }));
            }
            else
            {
                outputLogBox.AppendText(text + "\r\n");
            }
        }

        public static void CopyMod(string sourceFolder, string destinationFolder, string modId, System.Windows.Forms.TextBox outputLogBox)
        {
            if (string.IsNullOrWhiteSpace(sourceFolder) || !Directory.Exists(sourceFolder))
                throw new DirectoryNotFoundException($"Source folder was not found.\r\n{sourceFolder}");

            var modSourceFolder = sourceFolder;

            
            AddTextToTextBox(outputLogBox, "Reading mod base information.");

            var fileName = Path.Combine(modSourceFolder, "mod.info");
            var list = new List<string>();
            ParseBaseInformation(fileName, list);

            AddTextToTextBox(outputLogBox, "Reading mod meta information.");

            fileName = Path.Combine(modSourceFolder, "modmeta.info");
            var metaInformation = new Dictionary<string, string>();
            if (ParseMetaInformation(fileName, metaInformation))
                modSourceFolder = Path.Combine(modSourceFolder, "WindowsNoEditor");

            var modFile = $"{destinationFolder}.mod";

            AddTextToTextBox(outputLogBox, "Deleting existing mod files.");

            // delete the server mod folder and mod file.
            if (Directory.Exists(destinationFolder))
                Directory.Delete(destinationFolder, true);
            if (File.Exists(modFile))
                File.Delete(modFile);

            AddTextToTextBox(outputLogBox, "Copying mod files.");

            // update the mod files from the cache.
            var flag = Copy(modSourceFolder, destinationFolder, true);

            if (metaInformation.Count == 0 && flag)
                metaInformation["ModType"] = "1";

            AddTextToTextBox(outputLogBox, "Creating mod file.");

            // create the mod file.
            WriteModFile(modFile, modId, metaInformation, list);

            // copy the last updated file.
            fileName = Path.Combine(sourceFolder, "LastUpdateTime");
            if (File.Exists(fileName))
            {
                AddTextToTextBox(outputLogBox, "Copying mod version file.");

                var tempFile = fileName.Replace(sourceFolder, destinationFolder);
                File.Copy(fileName, tempFile, true);
            }
        }

        public static bool Copy(string sourceFolder, string destinationFolder, bool copySubFolders)
        {
            if (!Directory.Exists(sourceFolder))
                return false;

            var flag = false;

            foreach (var sourceFile in Directory.GetFiles(sourceFolder, "*.*", copySubFolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
            {
                var modFile = sourceFile.Replace(sourceFolder, destinationFolder);
                var modFilePath = Path.GetDirectoryName(modFile);

                if (!Directory.Exists(modFilePath))
                    Directory.CreateDirectory(modFilePath);

                if (Path.GetFileNameWithoutExtension(sourceFile).Contains("PrimalGameData"))
                    flag = true;

                Copy(sourceFile, modFilePath);
            }

            return flag;
        }

        public static void Copy(string sourceFile, string destinationFolder)
        {
            string fileExtension = Path.GetExtension(sourceFile).ToUpper();

            if (string.Compare(fileExtension, ".uncompressed_size", StringComparison.OrdinalIgnoreCase) != 0)
            {
                string tempFile = Path.Combine(destinationFolder, Path.GetFileName(sourceFile));

                if (string.Compare(fileExtension, ".z", StringComparison.OrdinalIgnoreCase) == 0)
                    UE4ChunkUnzip(sourceFile, tempFile.Substring(0, tempFile.Length - 2));
                else
                    File.Copy(sourceFile, tempFile, true);
            }
        }

        public static bool ParseBaseInformation(string fileName, List<string> mapNames)
        {
            if (!File.Exists(fileName))
                return false;

            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                string readString1;
                ReadUE4String(reader, out readString1);

                int num = reader.ReadInt32();
                for (int index = 0; index < num; ++index)
                {
                    string readString2;
                    ReadUE4String(reader, out readString2);
                    mapNames.Add(readString2);
                }
            }
            return true;
        }

        public static bool ParseMetaInformation(string fileName, Dictionary<string, string> metaInformation)
        {
            if (!File.Exists(fileName))
                return false;

            using (BinaryReader binaryReader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                int num = binaryReader.ReadInt32();
                for (int index1 = 0; index1 < num; ++index1)
                {
                    string index2 = string.Empty;
                    int count1 = binaryReader.ReadInt32();
                    bool flag1 = false;
                    if (count1 < 0)
                    {
                        flag1 = true;
                        count1 = -count1;
                    }
                    if (!flag1 && count1 > 0)
                    {
                        byte[] bytes = binaryReader.ReadBytes(count1);
                        index2 = Encoding.UTF8.GetString(bytes, 0, bytes.Length - 1);
                    }
                    string str = string.Empty;
                    int count2 = binaryReader.ReadInt32();
                    bool flag2 = false;
                    if (count2 < 0)
                    {
                        flag2 = true;
                        count2 = -count2;
                    }
                    if (!flag2 && count2 > 0)
                    {
                        byte[] bytes = binaryReader.ReadBytes(count2);
                        str = Encoding.UTF8.GetString(bytes, 0, bytes.Length - 1);
                    }
                    metaInformation[index2] = str;
                }
            }
            return true;
        }

        private static void ReadUE4String(BinaryReader reader, out string readString)
        {
            readString = string.Empty;
            int count = reader.ReadInt32();
            bool flag = false;
            if (count < 0)
            {
                flag = true;
                count = -count;
            }
            if (flag || count <= 0)
                return;
            byte[] bytes = reader.ReadBytes(count);
            readString = Encoding.UTF8.GetString(bytes, 0, bytes.Length - 1);
        }

        private static void UE4ChunkUnzip(string source, string destination)
        {
            if (!File.Exists(source)) return;
            using (BinaryReader inReader = new BinaryReader(File.Open(source, FileMode.Open)))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(destination, FileMode.Create)))
                {
                    FCompressedChunkInfo fcompressedChunkInfo1 = new FCompressedChunkInfo();
                    fcompressedChunkInfo1.Serialize(inReader);
                    FCompressedChunkInfo fcompressedChunkInfo2 = new FCompressedChunkInfo();
                    fcompressedChunkInfo2.Serialize(inReader);

                    long num1 = fcompressedChunkInfo1.CompressedSize;
                    long num2 = fcompressedChunkInfo1.UncompressedSize;
                    if (num2 == 2653586369L)
                        num2 = 131072L;
                    long length = (fcompressedChunkInfo2.UncompressedSize + num2 - 1L) / num2;

                    FCompressedChunkInfo[] fcompressedChunkInfoArray = new FCompressedChunkInfo[length];
                    long val2 = 0L;

                    for (int index = 0; index < length; ++index)
                    {
                        fcompressedChunkInfoArray[index] = new FCompressedChunkInfo();
                        fcompressedChunkInfoArray[index].Serialize(inReader);
                        val2 = Math.Max(fcompressedChunkInfoArray[index].CompressedSize, val2);
                    }

                    for (long index = 0L; index < length; ++index)
                    {
                        FCompressedChunkInfo fcompressedChunkInfo3 = fcompressedChunkInfoArray[index];
                        byte[] buffer = ZlibStream.UncompressBuffer(inReader.ReadBytes((int)fcompressedChunkInfo3.CompressedSize));
                        binaryWriter.Write(buffer);
                    }
                }
            }
        }

        public static void WriteModFile(string fileName, string modId, Dictionary<string, string> metaInformation, List<string> mapNames)
        {
            using (BinaryWriter outWriter = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                ulong num1 = ulong.Parse(modId);
                outWriter.Write(num1);
                WriteUE4String("ModName", outWriter);
                WriteUE4String(string.Empty, outWriter);
                int count1 = mapNames.Count;
                outWriter.Write(count1);
                for (int index = 0; index < mapNames.Count; ++index)
                {
                    WriteUE4String(mapNames[index], outWriter);
                }
                uint num2 = 4280483635U;
                outWriter.Write(num2);
                int num3 = 2;
                outWriter.Write(num3);
                byte num4 = metaInformation.ContainsKey("ModType") ? (byte)1 : (byte)0;
                outWriter.Write(num4);
                int count2 = metaInformation.Count;
                outWriter.Write(count2);
                foreach (KeyValuePair<string, string> keyValuePair in metaInformation)
                {
                    WriteUE4String(keyValuePair.Key, outWriter);
                    WriteUE4String(keyValuePair.Value, outWriter);
                }
            }
        }

        private static void WriteUE4String(string writeString, BinaryWriter writer)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(writeString);
            int num1 = bytes.Length + 1;
            writer.Write(num1);
            writer.Write(bytes);
            byte num2 = 0;
            writer.Write(num2);
        }
    }
}
