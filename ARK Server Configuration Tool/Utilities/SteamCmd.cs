using ARK_Server_Configuration_Tool.Structs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARK_Server_Configuration_Tool.Utilities
{
    class SteamCmd
    {
        private TextBox outputLogBox;
        private ServerProfile targetProfile;
        public Process p;
        public bool SkippedMod = false;


        public SteamCmd(ServerProfile targetProfile, TextBox outputLogBox) 
        {
            this.targetProfile = targetProfile;
            this.outputLogBox = outputLogBox;
        }

        public void UpdateAllMods()
        {
            foreach (Mod mod in targetProfile.mods.Values)
            {
                UpdateMod(mod);
            }
        }

        public void UpdateMod(Mod mod)
        {
            SkippedMod = false;
            outputLogBox.Clear();
            outputLogBox.AppendText("Updating mod " + mod.Id + "\r\n");
            Task.Factory.StartNew(async () =>
            {
                void AddText(string text)
                {
                    if (outputLogBox.InvokeRequired)
                        outputLogBox.Invoke(new MethodInvoker(delegate
                        {
                            outputLogBox.AppendText(text + "\r\n");
                        }));
                    else outputLogBox.AppendText(text + "\r\n");
                }
                RunCmd(string.Format("+login anonymous +workshop_download_item 346110 {0} +quit", mod.Id));
                string sourceFolder = "SteamCmd\\steamapps\\workshop\\content\\346110\\" + mod.Id.ToString();
                string destinationFolder = Profiles.currentProfile.path + "\\ShooterGame\\Content\\Mods" + mod.Id.ToString();
                try
                {
                    if (!SkippedMod) ModUtils.CopyMod(sourceFolder, destinationFolder, mod.Id.ToString(), outputLogBox);
                    else SkippedMod = false;

                }
                catch (Exception e)
                {
                    AddText("Mod copy failed for mod "+mod.Id+": " + e.Message);
                }
                AddText("Finished updating mod " + mod.Id);
            });
        }

        public void UpdateServer(bool validate)
        {
            outputLogBox.Clear();
            RunCmd(string.Format("login anonymous +force_install_dir \"{0}\"  \"+app_update 376030 {1}\" +quit", targetProfile.path, validate ? "validate" : string.Empty));
        }

        public void InstallServer()
        {
            outputLogBox.Clear();
            RunCmd(string.Format("login anonymous +force_install_dir \"{0}\"  \"+app_update 376030\" +quit", targetProfile.path));
        }

        private void RunCmd(string args)
        {
            if (!Directory.Exists("SteamCmd")) InstallSteamCmd();
            // Start the child process.
            p = new Process();

            p.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);

            // Redirect the output stream of the child process.
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = "SteamCmd\\steamcmd.exe";
            p.StartInfo.Arguments = args;

            p.Start();

            p.BeginOutputReadLine();
            p.WaitForExit();
        }

        private void InstallSteamCmd()
        {
            Directory.CreateDirectory("SteamCmd");
            using (var client = new System.Net.WebClient())
            {
                client.DownloadFile("https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip", AppDomain.CurrentDomain.BaseDirectory + "SteamCmd\\steamcmd.zip");
                ZipFile.ExtractToDirectory("SteamCmd\\steamcmd.zip", "SteamCmd");
                File.Delete("SteamCmd\\steamcmd.zip");
            }
        }

        private void OutputHandler(object source, DataReceivedEventArgs outLine)
        {
            // Collect the sort command output. 
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                if (outputLogBox.InvokeRequired)
                {
                    outputLogBox.Invoke(new MethodInvoker(delegate
                    {
                        outputLogBox.AppendText(outLine.Data + "\r\n");
                    }));
                }
                else
                {
                    outputLogBox.AppendText(outLine.Data + "\r\n");
                }
            }
        }
    }
}
