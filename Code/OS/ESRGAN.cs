using Cupscale.Cupscale;
using Cupscale.Forms;
using Cupscale.ImageUtils;
using Cupscale.IO;
using Cupscale.Main;
using Upscale = Cupscale.Main.Upscale;
using Cupscale.UI;
using ImageMagick;
using System;
using System.CodeDom;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paths = Cupscale.IO.Paths;
using Cupscale.Implementations;

namespace Cupscale.OS
{
    internal class ESRGAN
    {
        public enum PreviewMode { None, Cutout, FullImage }
        public enum Backend { Cuda, Cpu, Ncnn };
        //public static bool cacheTiling = false;

        public static async Task DoUpscale(string inpath, string outpath, ModelData mdl, bool cacheSplitDepth, bool alpha, PreviewMode mode, bool showTileProgress = true)
        {
            Program.cancelled = false;      // Reset cancel flag
            try
            {
                if (Upscale.currentAi == Implementations.Implementations.esrganPytorch)
                {
                    Program.mainForm.SetProgress(2f, "Loading ESRGAN (Pytorch)...");
                    await EsrganPytorch.Run(inpath, outpath, mdl, cacheSplitDepth, alpha, showTileProgress);
                }

                if (Upscale.currentAi == Implementations.Implementations.esrganNcnn)
                {
                    Program.lastModelName = mdl.model1Name;
                    await RunNcnn(inpath, outpath, mdl.model1Path);
                }

                if (Upscale.currentAi == Implementations.Implementations.realEsrganNcnn)
                {
                    Program.lastModelName = "RealESRGAN";
                    await RunRealEsrgan(inpath, outpath);
                }

                if (mode == PreviewMode.Cutout)
                {
                    await ScalePreviewOutput();
                    Program.mainForm.SetProgress(100f, "Merging into preview...");
                    await Program.PutTaskDelay();
                    PreviewMerger.Merge();
                    Program.mainForm.SetHasPreview(true);
                }
                if (mode == PreviewMode.FullImage)
                {
                    await ScalePreviewOutput();
                    Program.mainForm.SetProgress(100f, "Merging into preview...");
                    await Program.PutTaskDelay();
                    Image outImg = ImgUtils.GetImage(Directory.GetFiles(Paths.previewOutPath, "preview.*", SearchOption.AllDirectories)[0]);
                    Image inputImg = ImgUtils.GetImage(Paths.tempImgPath);
                    PreviewUI.previewImg.Image = outImg;
                    PreviewUI.currentOriginal = inputImg;
                    PreviewUI.currentOutput = outImg;
                    PreviewUI.currentScale = ImgUtils.GetScaleFloat(inputImg, outImg);
                    PreviewUI.previewImg.ZoomToFit();
                    Program.mainForm.SetHasPreview(true);
                    //Program.mainForm.SetProgress(0f, "Done.");
                }

            }
            catch (Exception e)
            {
                Program.mainForm.SetProgress(0f, "Cancelled.");
                if (Program.cancelled)
                    return;
                if (e.Message.Contains("No such file"))
                    Program.ShowMessage("An error occured during upscaling.\nThe upscale process seems to have exited before completion!", "Error");
                else
                    Program.ShowMessage("An error occured during upscaling.", "Error");
                Logger.Log("[ESRGAN] Upscaling Error: " + e.Message + "\n" + e.StackTrace);
            }

        }

        public static async Task ScalePreviewOutput()
        {
            if (ImageProcessing.postScaleMode == Upscale.ScaleMode.Percent && ImageProcessing.postScaleValue == 100)   // Skip if target scale is 100%)
                return;

            Program.mainForm.SetProgress(1f, "[ESRGAN] Resizing preview output...");
            await Task.Delay(1);
            MagickImage img = ImgUtils.GetMagickImage(Directory.GetFiles(Paths.previewOutPath, "*.png.*", SearchOption.AllDirectories)[0]);
            MagickImage magickImage = ImageProcessing.ResizeImagePostMagick(img);
            img = magickImage;
            img.Write(img.FileName);
            //string img = Directory.GetFiles(Paths.previewOutPath, "*.png.*", SearchOption.AllDirectories)[0];
            //ImageProcessing.ResizeImagePost(img);
        }

        public static string currentNcnnModel = "";

        #region ESRGAN NCNN

        public static async Task RunNcnn(string inpath, string outpath, string modelPath)
        {
            bool showWindow = Config.GetInt("cmdDebugMode") > 0;
            bool stayOpen = Config.GetInt("cmdDebugMode") == 2;

            Program.mainForm.SetProgress(1f, "Converting model...");
            await NcnnUtils.ConvertNcnnModel(modelPath);
            Logger.Log("[ESRGAN] NCNN Model is ready: " + currentNcnnModel);
            Program.mainForm.SetProgress(3f, "Loading ESRGAN-NCNN...");
            int scale = NcnnUtils.GetNcnnModelScale(currentNcnnModel);

            string opt = stayOpen ? "/K" : "/C";

            string cmd = $"{opt} cd /D {Paths.implementationsPath.Wrap()} & esrgan-ncnn-vulkan.exe -i {inpath.Wrap()} -o {outpath.Wrap()}" +
                $" -g {Config.GetInt("gpuId")} -m " + currentNcnnModel.Wrap() + " -s " + scale;
            Logger.Log("[CMD] " + cmd);

            Process ncnnProcess = OSUtils.NewProcess(!showWindow);
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

        #endregion

        #region RealESRGAN

        public static async Task RunRealEsrgan(string inpath, string outpath, string modelPath = "")
        {
            bool showWindow = Config.GetInt("cmdDebugMode") > 0;
            bool stayOpen = Config.GetInt("cmdDebugMode") == 2;

            Program.mainForm.SetProgress(3f, "Loading RealESRGAN...");
            //int scale = NcnnUtils.GetNcnnModelScale(currentNcnnModel);

            string opt = stayOpen ? "/K" : "/C";

            string cmd = $"{opt} cd /D {Paths.implementationsPath.Wrap()} & realesrgan-ncnn-vulkan.exe -i {inpath.Wrap()} -o {outpath.Wrap()}" +
                $" -g {Config.GetInt("gpuId")} -m realesrgan-models -s 4";
            Logger.Log("[CMD] " + cmd);

            Process proc = OSUtils.NewProcess(!showWindow);
            proc.StartInfo.Arguments = cmd;

            if (!showWindow)
            {
                proc.OutputDataReceived += RealEsrganOutputHandler;
                proc.ErrorDataReceived += RealEsrganOutputHandler;
            }

            Program.currentEsrganProcess = proc;
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
                Program.mainForm.SetProgress(100f, "[ESRGAN] Post-Processing...");
                PostProcessingQueue.Stop();
            }

        }

        private static void RealEsrganOutputHandler(object sendingProcess, DataReceivedEventArgs output)
        {
            if (output == null || output.Data == null)
                return;

            string data = output.Data;
            Logger.Log("[NCNN] " + data.Replace("\n", " ").Replace("\r", " "));

            bool showTileProgress = Upscale.currentMode == Upscale.UpscaleMode.Preview || Upscale.currentMode == Upscale.UpscaleMode.Single;

            if (showTileProgress && data.Trim().EndsWith("%"))
            {
                float percent = float.Parse(data.Replace("%", "").Replace(",", ".")) / 100f;
                Program.mainForm.SetProgress(percent, $"Upscaling Tiles ({percent}%)");
            }

            if (data.Contains("failed"))
            {
                Program.KillEsrgan();
                Program.ShowMessage("Error occurred during upscaling: \n\n" + data + "\n\n", "Error");
            }

            if (data.Contains("vkAllocateMemory"))
                Program.ShowMessage("ESRGAN-NCNN ran out of memory. Try reducing the tile size and avoid running programs in the background (especially games) that take up your VRAM.", "Error");
        }

        #endregion

        public static string Interpolate(ModelData mdl)
        {
            bool showWindow = Config.GetInt("cmdDebugMode") > 0;
            bool stayOpen = Config.GetInt("cmdDebugMode") == 2;

            Process py = OSUtils.NewProcess(!showWindow);

            string opt = stayOpen ? "/K" : "/C";

            string alphaStr = (mdl.interp / 100f).ToString("0.00").Replace(",", ".");
            string outPath = mdl.model1Path.GetParentDir();
            string filename = $"{mdl.model1Name}-{mdl.model2Name}-interp{alphaStr}.pth";
            outPath = Path.Combine(outPath, filename);

            string cmd = $"{opt} cd /D {Paths.implementationsPath.Wrap()} & ";
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
    }
}