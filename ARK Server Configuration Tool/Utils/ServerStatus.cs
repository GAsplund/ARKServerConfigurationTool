using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;
using ARK_Server_Configuration_Tool.Structs;

namespace ARK_Server_Configuration_Tool
{
    /// <summary>Adopted from Valve description: https://developer.valvesoftware.com/wiki/Server_queries#A2S_INFO </summary>
    public class ServerStatus
    {
        public enum Status
        {
            // The binary could not be found
            Not_Installed,
            // The server is running and can be pinged from external IP
            Running,
            // The server process was not found
            Not_Running,
            // The server process was found, but cannot be pinged locally.
            Starting,
            // The server is running and can be pinged locally, but not externally.
            NoPortForward
        }

        // \xFF\xFF\xFF\xFFTSource Engine Query\x00 because UTF-8 doesn't like to encode 0xFF
        public static readonly byte[] REQUEST = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x54, 0x53, 0x6F, 0x75, 0x72, 0x63, 0x65, 0x20, 0x45, 0x6E, 0x67, 0x69, 0x6E, 0x65, 0x20, 0x51, 0x75, 0x65, 0x72, 0x79, 0x00 };
        #region Strong Typing Enumerators
        [Flags]
        public enum ExtraDataFlags : byte
        {
            GameID = 0x01,
            SteamID = 0x10,
            Keywords = 0x20,
            Spectator = 0x40,
            Port = 0x80
        }
        public enum VACFlags : byte
        {
            Unsecured = 0,
            Secured = 1
        }
        public enum VisibilityFlags : byte
        {
            Public = 0,
            Private = 1
        }
        public enum EnvironmentFlags : byte
        {
            Linux = 0x6C,   //l
            Windows = 0x77, //w
            Mac = 0x6D,     //m
            MacOsX = 0x6F   //o
        }
        public enum ServerTypeFlags : byte
        {
            Dedicated = 0x64,     //d
            Nondedicated = 0x6C,   //l
            SourceTV = 0x70   //p
        }
        #endregion
        public byte Header { get; set; }        // I
        public byte Protocol { get; set; }
        public string Name { get; set; }
        public string Map { get; set; }
        public string Folder { get; set; }
        public string Game { get; set; }
        public short ID { get; set; }
        public byte Players { get; set; }
        public byte MaxPlayers { get; set; }
        public byte Bots { get; set; }
        public ServerTypeFlags ServerType { get; set; }
        public EnvironmentFlags Environment { get; set; }
        public VisibilityFlags Visibility { get; set; }
        public VACFlags VAC { get; set; }
        public string Version { get; set; }
        public ExtraDataFlags ExtraDataFlag { get; set; }
        #region Extra Data Flag Members
        public ulong GameID { get; set; }           //0x01
        public ulong SteamID { get; set; }          //0x10
        public string Keywords { get; set; }        //0x20
        public string Spectator { get; set; }       //0x40
        public short SpectatorPort { get; set; }   //0x40
        public short Port { get; set; }             //0x80
        public bool IsOnline { get; set; }
        #endregion
        public ServerStatus(IPEndPoint ep)
        {
            UdpClient udp = new UdpClient();
            udp.Client.ReceiveTimeout = 5000;
            udp.Client.SendTimeout = 5000;
            udp.Send(REQUEST, REQUEST.Length, ep);
            try
            {
                MemoryStream ms = new MemoryStream(udp.Receive(ref ep));    // Saves the received data in a memory buffer
                BinaryReader br = new BinaryReader(ms, Encoding.UTF8);      // A binary reader that treats charaters as Unicode 8-bit
                IsOnline = true;
                ms.Seek(4, SeekOrigin.Begin);   // skip the 4 0xFFs
                Header = br.ReadByte();
                Protocol = br.ReadByte();
                Name = ReadNullTerminatedString(ref br);
                Map = ReadNullTerminatedString(ref br);
                Folder = ReadNullTerminatedString(ref br);
                Game = ReadNullTerminatedString(ref br);
                ID = br.ReadInt16();
                Players = br.ReadByte();
                MaxPlayers = br.ReadByte();
                Bots = br.ReadByte();
                ServerType = (ServerTypeFlags)br.ReadByte();
                Environment = (EnvironmentFlags)br.ReadByte();
                Visibility = (VisibilityFlags)br.ReadByte();
                VAC = (VACFlags)br.ReadByte();
                Version = ReadNullTerminatedString(ref br);
                ExtraDataFlag = (ExtraDataFlags)br.ReadByte();
                #region These EDF readers have to be in this order because that's the way they are reported
                if (ExtraDataFlag.HasFlag(ExtraDataFlags.Port))
                    Port = br.ReadInt16();
                if (ExtraDataFlag.HasFlag(ExtraDataFlags.SteamID))
                    SteamID = br.ReadUInt64();
                if (ExtraDataFlag.HasFlag(ExtraDataFlags.Spectator))
                {
                    SpectatorPort = br.ReadInt16();
                    Spectator = ReadNullTerminatedString(ref br);
                }
                if (ExtraDataFlag.HasFlag(ExtraDataFlags.Keywords))
                    Keywords = ReadNullTerminatedString(ref br);
                if (ExtraDataFlag.HasFlag(ExtraDataFlags.GameID))
                    GameID = br.ReadUInt64();
                #endregion
                br.Close();
                ms.Close();
                udp.Close();
            } catch
            {
                IsOnline = false;
            }
        }
        /// <summary>Reads a null-terminated string into a .NET Framework compatible string.</summary>
        /// <param name="input">Binary reader to pull the null-terminated string from.  Make sure it is correctly positioned in the stream before calling.</param>
        /// <returns>String of the same encoding as the input BinaryReader.</returns>
        /// 

        private bool OnlineExternally()
        {
            try
            {
                string externalIP;
                externalIP = (new WebClient()).DownloadString("http://checkip.dyndns.org/");
                externalIP = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"))
                             .Matches(externalIP)[0].ToString();
                return new ServerStatus(new IPEndPoint(IPAddress.Parse(externalIP), Convert.ToInt32(Utilities.Profiles.currentProfile.queryPort))).IsOnline;
            }
            catch { return false; }
        }

        public static string ReadNullTerminatedString(ref BinaryReader input)
        {
            StringBuilder sb = new StringBuilder();
            char read = input.ReadChar();
            while (read != '\x00')
            {
                sb.Append(read);
                read = input.ReadChar();
            }
            return sb.ToString();
        }

        public Status CheckServerStatus()
        {
            string BinaryLocation = Utilities.Profiles.currentProfile.path + "\\ShooterGame\\Binaries\\Win64\\ShooterGameServer.exe";
            if (!File.Exists(BinaryLocation))
            {
                return Status.Not_Installed;
            }
            foreach (var process in Process.GetProcessesByName(Path.GetFileName(BinaryLocation)))
            {
                if (process.MainModule.FileName.ToString() == BinaryLocation)
                {
                    // Server process found
                    if (process.HasExited)
                    {
                        return Status.Not_Running;
                    }
                    // Server process is running
                }
            }

            if (!IsOnline)
            {
                return Status.Not_Running;
            } else if (!OnlineExternally())
            {
                return Status.NoPortForward;
            } else
            {
                return Status.Running;
            }

            // Nothing matched. Assume the server is installed and not running.
            return Status.Not_Running;
        }
    }
}
