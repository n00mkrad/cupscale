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
                    await PreviewUi.ScalePreviewOutput();
                    Program.mainForm.SetProgress(100f, "Merging into preview...");
                    await Program.PutTaskDelay();
                    PreviewMerger.Merge();
                    Program.mainForm.SetHasPreview(true);
                }

                if (mode == PreviewMode.FullImage)
                {
                    await PreviewUi.ScalePreviewOutput();
                    Program.mainForm.SetProgress(100f, "Merging into preview...");
                    await Program.PutTaskDelay();
                    Image outImg = ImgUtils.GetImage(Directory.GetFiles(Paths.previewOutPath, "preview.*", SearchOption.AllDirectories)[0]);
                    Image inputImg = ImgUtils.GetImage(Paths.tempImgPath);
                    PreviewUi.previewImg.Image = outImg;
                    PreviewUi.currentOriginal = inputImg;
                    PreviewUi.currentOutput = outImg;
                    PreviewUi.currentScale = ImgUtils.GetScaleFloat(inputImg, outImg);
                    PreviewUi.previewImg.ZoomToFit();
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
    }
}