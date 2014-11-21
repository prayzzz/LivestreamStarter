using System.Diagnostics;
using System.IO;

using BaseEntities.Enum;

using Common.Common;
using Common.Enum;
using Common.Exceptions;

using Localization;

using Services.Interfaces;

namespace Services.Common
{
    public class LivestreamProcessManager : ProcessManagerNew, ILivestreamProcessManager
    {
        public LivestreamProcessManager()
        {
            this.Process = this.GetProcess();
        }

        public void StartStream(string streamLink, QualityEnum quality)
        {
            if (string.IsNullOrEmpty(Settings.LivestreamerPath) || !File.Exists(Settings.LivestreamerPath))
            {
                throw new SettingsException(CodeStrings.CheckLivestreamerPath);
            }

            if (string.IsNullOrWhiteSpace(Settings.VlcPath) || !File.Exists(Settings.VlcPath))
            {
                throw new SettingsException(CodeStrings.CheckVLCPath);
            }

            if (this.IsProcessRunning)
            {
                throw new ProcessException(CodeStrings.StreamAlreadyRunning);
            }

            this.StartProcess(this.Process, streamLink, quality);

            Logger.Log(LogTypeEnum.Start, "Starting Livestreamer with arguments:");
            Logger.Log(LogTypeEnum.Work, this.Process.StartInfo.Arguments);
        }

        public void Stop()
        {
            if (this.Process != null)
            {
                this.Process.Close();
            }
        }

        private static string GetProcessArguments(string streamLink, QualityEnum quality)
        {
            return string.Format("-p \"{0}\" {1} {2} -v", Settings.VlcPath, streamLink, quality);
        }

        private static void OnDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (args == null || args.Data == null)
            {
                return;
            }

            Logger.Log(LogTypeEnum.Work, args.Data);

            if (args.Data.StartsWith("error:"))
            {
                return;
            }

            if (args.Data.StartsWith("[cli][info] Starting player"))
            {
                return;
            }
        }

        private void StartProcess(Process process, string streamLink, QualityEnum quality)
        {
            this.IsProcessRunning = true;

            process.StartInfo.FileName = Settings.LivestreamerPath;
            process.StartInfo.Arguments = GetProcessArguments(streamLink, quality);

            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }

        private Process GetProcess()
        {
            var process = new Process();
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardError = true;
            process.EnableRaisingEvents = true;
            process.OutputDataReceived += OnDataReceived;
            process.ErrorDataReceived += OnDataReceived;
            process.Exited += this.OnProcessExit;

            return process;
        }
    }
}