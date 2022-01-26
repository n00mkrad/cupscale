using Cupscale.Cupscale;
using Cupscale.IO;
using Cupscale.Main;
using Upscale = Cupscale.Main.Upscale;
using Cupscale.UI;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Paths = Cupscale.IO.Paths;
using Cupscale.Implementations;
using Cupscale.OS;
using Cupscale.Data;

namespace Cupscale.Implementations
{
    class RealEsrganNcnn : ImplementationBase
    {
        static readonly string exeName = "realesrgan-ncnn-vulkan.exe";

        public static async Task Run(string inpath, string outpath, ModelData mdl)
        {
            if (!CheckIfExeExists(Imps.realEsrganNcnn, exeName))
                return;

            string modelPath = mdl.model1Path;
            Program.lastModelName = mdl.model1Name;

            bool showWindow = Config.GetInt("cmdDebugMode") > 0;
            bool stayOpen = Config.GetInt("cmdDebugMode") == 2;

            Program.mainForm.SetProgress(1f, "Converting model...");
            await NcnnUtils.ConvertNcnnModel(modelPath, "esrgan-x*");
            Logger.Log("[ESRGAN] NCNN Model is ready: " + NcnnUtils.currentNcnnModel);
            Program.mainForm.SetProgress(3f, "Loading RealESRGAN (NCNN)...");
            int scale = NcnnUtils.GetNcnnModelScale(NcnnUtils.currentNcnnModel);

            if(scale != 4)
            {
                Program.ShowMessage($"Error: This implementation currently only supports 4x scale models.", "Error");
                return;
            }

            string opt = stayOpen ? "/K" : "/C";
            string tta = Config.GetBool("realEsrganNcnnTta") ? "-x" : "";
            string ts = Config.GetInt("realEsrganNcnnTilesize") >= 32 ? $"-t {Config.GetInt("realEsrganNcnnTilesize")}" : "";
            string cmd = $"{opt} cd /D {Path.Combine(Paths.binPath, Imps.realEsrganNcnn.dir).Wrap()} & {exeName} -i {inpath.Wrap()} -o {outpath.Wrap()}" +
                $" -g {Config.GetInt("realEsrganNcnnGpus")} -m {NcnnUtils.currentNcnnModel.Wrap()} -n esrgan-x4 -s {scale} {tta} {ts}";
            Logger.Log("[CMD] " + cmd);

            Process proc = OsUtils.NewProcess(!showWindow);
            proc.StartInfo.Arguments = cmd;

            if (!showWindow)
            {
                proc.OutputDataReceived += (sender, outLine) => { OutputHandler(outLine.Data, false); };
                proc.ErrorDataReceived += (sender, outLine) => { OutputHandler(outLine.Data, true); };
            }

            Program.lastImpProcess = proc;
            proc.Start();

            if (!showWindow)
            {
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
            }

            while (!proc.HasExited)
                await Task.Delay(50);

            if (Upscale.currentMode == Upscale.UpscaleMode.Batch)
            {
                await Task.Delay(1000);
                Program.mainForm.SetProgress(100f, "Post-Processing...");
                PostProcessingQueue.Stop();
            }

        }

        private static void OutputHandler(string line, bool error)
        {
            if (string.IsNullOrWhiteSpace(line) || line.Length < 6)
                return;

            Logger.Log("[NCNN] " + line.Replace("\n", " ").Replace("\r", " "));

            bool showTileProgress = Upscale.currentMode == Upscale.UpscaleMode.Preview || Upscale.currentMode == Upscale.UpscaleMode.Single;

            if (showTileProgress && line.Trim().EndsWith("%"))
            {
                float percent = float.Parse(line.Replace("%", "").Replace(",", "."));
                Program.mainForm.SetProgress(percent, $"Upscaling Tiles ({percent}%)");
            }

            if (error)
                GeneralOutputHandler.HandleImpErrorMsgs(line, GeneralOutputHandler.ProcessType.Ncnn);
        }
    }
}
