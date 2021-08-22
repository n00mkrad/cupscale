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

        public static async Task DoUpscale(string inpath, string outpath, ModelData mdl, bool cacheSplitDepth, bool alpha, PreviewMode mode, bool showTileProgress = true)
        {
            Program.canceled = false;      // Reset cancel flag

            try
            {
                if (Upscale.currentAi == Implementations.Imps.esrganPytorch)
                    await EsrganPytorch.Run(inpath, outpath, mdl, cacheSplitDepth, alpha, showTileProgress);

                if (Upscale.currentAi == Implementations.Imps.esrganNcnn)
                    await EsrganNcnn.Run(inpath, outpath, mdl);

                if (Upscale.currentAi == Implementations.Imps.realEsrganNcnn)
                    await RealEsrganNcnn.Run(inpath, outpath, mdl);

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

                if (Program.canceled)
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

            string cmd = $"{opt} cd /D {Paths.GetAiDir(Implementations.Imps.esrganPytorch).Wrap()} & ";
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