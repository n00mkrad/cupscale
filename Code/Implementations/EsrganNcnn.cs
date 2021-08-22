using Cupscale.Cupscale;
using Cupscale.IO;
using Cupscale.Main;
using Upscale = Cupscale.Main.Upscale;
using Cupscale.UI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Paths = Cupscale.IO.Paths;
using Cupscale.Implementations;
using Cupscale.OS;

namespace Cupscale.Implementations
{
    class EsrganNcnn : ImplementationBase
    {
        static readonly string exeName = "esrgan-ncnn-vulkan.exe";

        public static async Task Run(string inpath, string outpath, ModelData mdl)
        {
            if (!CheckIfExeExists(Imps.esrganNcnn, exeName))
                return;

            string modelPath = mdl.model1Path;
            Program.lastModelName = mdl.model1Name;

            bool showWindow = Config.GetInt("cmdDebugMode") > 0;
            bool stayOpen = Config.GetInt("cmdDebugMode") == 2;

            Program.mainForm.SetProgress(1f, "Converting model...");
            await NcnnUtils.ConvertNcnnModel(modelPath, "x*");
            Logger.Log("[ESRGAN] NCNN Model is ready: " + NcnnUtils.currentNcnnModel);
            Program.mainForm.SetProgress(3f, "Loading ESRGAN (NCNN)...");
            int scale = NcnnUtils.GetNcnnModelScale(NcnnUtils.currentNcnnModel);
            string opt = stayOpen ? "/K" : "/C";
            string tta = Config.GetBool("esrganNcnnTta") ? "-x" : "";
            string ts = Config.GetInt("esrganNcnnTilesize") >= 32 ? $"-t {Config.GetInt("esrganNcnnTilesize")}" : "";
            string cmd = $"{opt} cd /D {Path.Combine(Paths.binPath, Imps.esrganNcnn.dir).Wrap()} & {exeName} -i {inpath.Wrap()} -o {outpath.Wrap()}" +
                $" -g {Config.GetInt("esrganNcnnGpu")} -m {NcnnUtils.currentNcnnModel.Wrap()} -s {scale} {tta} {ts}";
            Logger.Log("[CMD] " + cmd);

            Process ncnnProcess = OsUtils.NewProcess(!showWindow);
            ncnnProcess.StartInfo.Arguments = cmd;

            if (!showWindow)
            {
                ncnnProcess.OutputDataReceived += NcnnOutputHandler;
                ncnnProcess.ErrorDataReceived += NcnnOutputHandler;
            }

            Program.currentEsrganProcess = ncnnProcess;
            ncnnProcess.Start();

            if (!showWindow)
            {
                ncnnProcess.BeginOutputReadLine();
                ncnnProcess.BeginErrorReadLine();
            }

            while (!ncnnProcess.HasExited)
                await Task.Delay(50);

            if (Upscale.currentMode == Upscale.UpscaleMode.Batch)
            {
                await Task.Delay(1000);
                Program.mainForm.SetProgress(100f, "[ESRGAN] Post-Processing...");
                PostProcessingQueue.Stop();
            }
        }

        private static void NcnnOutputHandler(object sendingProcess, DataReceivedEventArgs output)
        {
            if (output == null || output.Data == null)
                return;

            string data = output.Data;
            Logger.Log("[NCNN] " + data.Replace("\n", " ").Replace("\r", " "));

            if (data.Contains("failed"))
            {
                Program.KillEsrgan();
                Program.ShowMessage("Error occurred during upscaling: \n\n" + data + "\n\n", "Error");
            }

            if (data.Contains("vkAllocateMemory"))
                Program.ShowMessage("ESRGAN-NCNN ran out of memory. Try reducing the tile size and avoid running programs in the background (especially games) that take up your VRAM.", "Error");
        }
    }
}
