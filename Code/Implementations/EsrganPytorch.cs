using Cupscale.Cupscale;
using Cupscale.Forms;
using Cupscale.ImageUtils;
using Cupscale.IO;
using Cupscale.Main;
using Upscale = Cupscale.Main.Upscale;
using Cupscale.UI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paths = Cupscale.IO.Paths;
using Cupscale.OS;

namespace Cupscale.Implementations
{
    class EsrganPytorch : ImplementationBase
    {
        private static string ProgressLogFile { get => Path.Combine(Paths.binPath, Imps.esrganPytorch.dir, "prog"); }

        public static async Task Run(string inpath, string outpath, ModelData mdl, bool cacheSplitDepth, bool alpha, bool showTileProgress)
        {
            Program.mainForm.SetProgress(3f, "Loading ESRGAN (Pytorch)...");
            File.Delete(ProgressLogFile);
            bool showWindow = Config.GetInt("cmdDebugMode") > 0;
            bool stayOpen = Config.GetInt("cmdDebugMode") == 2;

            string modelArg = GetModelArg(mdl);
            inpath = inpath.Wrap();
            outpath = outpath.Wrap();

            string alphaMode = alpha ? $"--alpha_mode {Config.GetInt("esrganPytorchAlphaMode")}" : "--alpha_mode 0";

            string alphaDepth = "";
            if (Config.GetInt("esrganPytorchAlphaDepth") == 1) alphaDepth = "--binary_alpha";
            if (Config.GetInt("esrganPytorchAlphaDepth") == 2) alphaDepth = "--ternary_alpha";

            string cpu = (Config.GetBool("esrganPytorchCpu")) ? "--cpu" : "";
            string device = $"--device_id {Config.GetInt("esrganPytorchGpuId")}";
            string seam = "";

            switch (Config.GetInt("esrganPytorchSeamlessMode"))
            {
                case 1: seam = "--seamless tile"; break;
                case 2: seam = "--seamless mirror"; break;
                case 3: seam = "--seamless replicate"; break;
                case 4: seam = "--seamless alpha_pad"; break;
            }

            string fp16 = Config.GetBool("esrganPytorchFp16") ? "--fp16" : "";
            string cache = cacheSplitDepth ? "--cache_max_split_depth" : "";
            string opt = stayOpen ? "/K" : "/C";
            string cmd = $"{opt} cd /D {Path.Combine(Paths.binPath, Imps.esrganPytorch.dir).Wrap()} & ";
            cmd += $"{EmbeddedPython.GetPyCmd()} upscale.py --input {inpath} --output {outpath} {cache} {cpu} {device} {fp16} {seam} {alphaMode} {alphaDepth} {modelArg}";
            Logger.Log("[CMD] " + cmd);
            Process esrganProcess = OsUtils.NewProcess(!showWindow);
            esrganProcess.StartInfo.Arguments = cmd;

            if (!showWindow)
            {
                esrganProcess.OutputDataReceived += OutputHandler;
                esrganProcess.ErrorDataReceived += OutputHandler;
            }

            Program.currentEsrganProcess = esrganProcess;
            esrganProcess.Start();

            if (!showWindow)
            {
                esrganProcess.BeginOutputReadLine();
                esrganProcess.BeginErrorReadLine();
            }

            while (!esrganProcess.HasExited)
            {
                if (showTileProgress)
                    await UpdateProgressFromFile();

                await Task.Delay(50);
            }

            if (Upscale.currentMode == Upscale.UpscaleMode.Batch)
            {
                await Task.Delay(1000);
                //Program.mainForm.SetProgress(100f, "Post-Processing...");
                PostProcessingQueue.Stop();
            }

            File.Delete(ProgressLogFile);
        }

        public static string GetModelArg(ModelData mdl)
        {
            string mdl1 = mdl.model1Path;
            string mdl2 = mdl.model2Path;
            ModelData.ModelMode mdlMode = mdl.mode;

            if (mdlMode == ModelData.ModelMode.Single)
            {
                Program.lastModelName = mdl.model1Name;
                return mdl1.Wrap(true, false);
            }

            if (mdlMode == ModelData.ModelMode.Interp)
            {
                int interpLeft = 100 - mdl.interp;
                int interpRight = mdl.interp;

                Program.lastModelName = mdl.model1Name + ":" + interpLeft + ":" + mdl.model2Name + ":" + interpRight;

                return (mdl1 + ";" + interpLeft + "&" + mdl2 + ";" + interpRight).Wrap(true);
            }

            if (mdlMode == ModelData.ModelMode.Chain)
            {
                Program.lastModelName = mdl.model1Name + ">>" + mdl.model2Name;
                return (mdl1 + ">" + mdl2).Wrap(true);
            }

            if (mdlMode == ModelData.ModelMode.Advanced)
            {
                Program.lastModelName = "Advanced";
                return AdvancedModelSelection.GetArg();
            }

            return null;
        }

        public static string Interpolate(ModelData mdl)
        {
            bool showWindow = Config.GetInt("cmdDebugMode") > 0;
            bool stayOpen = Config.GetInt("cmdDebugMode") == 2;

            Process py = OsUtils.NewProcess(!showWindow);

            string opt = stayOpen ? "/K" : "/C";
            string alphaStr = (mdl.interp / 100f).ToString("0.00").Replace(",", ".");
            string outPath = mdl.model1Path.GetParentDir();
            string filename = $"{mdl.model1Name}-{mdl.model2Name}-interp{alphaStr}.pth";
            outPath = Path.Combine(outPath, filename);

            string cmd = $"{opt} cd /D {Paths.GetAiDir(Imps.esrganPytorch).Wrap()} & ";
            cmd += $"{EmbeddedPython.GetPyCmd()} interp.py {mdl.model1Path.Wrap()} {mdl.model2Path.Wrap()} {alphaStr} {outPath.Wrap()}";

            py.StartInfo.Arguments = cmd;
            Logger.Log("[ESRGAN Interp] CMD: " + py.StartInfo.Arguments);
            py.Start();
            py.WaitForExit();
            string output = py.StandardOutput.ReadToEnd();
            string err = py.StandardError.ReadToEnd();
            if (!string.IsNullOrWhiteSpace(err)) output += "\n" + err;
            Logger.Log("[ESRGAN Interp] Output: " + output);

            if (output.ToLower().Contains("error"))
                throw new Exception("Interpolation Error - Output:\n" + output);

            return outPath;
        }

        private static void OutputHandler(object sendingProcess, DataReceivedEventArgs output)
        {
            if (output == null || output.Data == null)
                return;

            string data = output.Data;
            Logger.Log("[Python] " + data);

            if (data.ToLower().Contains("error"))
            {
                Program.KillEsrgan();
                Program.ShowMessage("Error occurred: \n\n" + data + "\n\n", "Error");
            }

            if (data.ToLower().Contains("out of memory"))
                Program.ShowMessage("ESRGAN ran out of memory. Try reducing the tile size and avoid running programs in the background (especially games) that take up your VRAM.", "Error");

            if (data.Contains("Python was not found"))
                Program.ShowMessage("Python was not found. Make sure you have a working Python 3 installation.", "Error");

            if (data.Contains("ModuleNotFoundError"))
                Program.ShowMessage("You are missing ESRGAN Python dependencies. Make sure Pytorch and cv2 (opencv-python) are installed.", "Error");

            if (data.Contains("RRDBNet"))
                Program.ShowMessage("Model appears to be incompatible!", "Error");

            if (data.Contains("UnpicklingError"))
                Program.ShowMessage("Failed to load model!", "Error");

            if (PreviewUi.currentMode == PreviewUi.MdlMode.Interp && (data.Contains("must match the size of tensor b") || data.Contains("KeyError: 'model.")))
                Program.ShowMessage("It seems like you tried to interpolate incompatible models!", "Error");
        }

        static string lastProgressString = "";

        private static async Task UpdateProgressFromFile()
        {
            string progressLogFile = ProgressLogFile;

            if (!File.Exists(progressLogFile))
                return;

            string[] lines = IoUtils.ReadLines(progressLogFile);

            if (lines.Length < 1)
                return;

            string outStr = (lines[lines.Length - 1]);

            if (outStr == lastProgressString)
                return;

            lastProgressString = outStr;

            if (outStr.Contains("Applying model") || outStr.Contains("Upscaling..."))
            {
                Program.mainForm.SetProgress(5f, "Upscaling...");
                return;
            }

            string text = outStr.Replace("Tile ", "").Trim();

            try
            {
                int num = int.Parse(text.Split('/')[0]);
                int num2 = int.Parse(text.Split('/')[1]);
                float previewProgress = (float)num / (float)num2 * 100f;
                Program.mainForm.SetProgress(previewProgress, "Processing Tiles - " + previewProgress.ToString("0") + "%");
            }
            catch
            {
                Logger.Log("[ESRGAN] Failed to parse progress from this line: " + text);
            }
        }
    }
}
