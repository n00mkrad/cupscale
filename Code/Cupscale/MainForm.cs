using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Cupscale.UI;
using Cyotek.Windows.Forms;
using Manina.Windows.Forms;
using TabControl = Manina.Windows.Forms.TabControl;
using Tab = Manina.Windows.Forms.Tab;
using ImageBox = Cyotek.Windows.Forms.ImageBox;
using Cupscale.Properties;
using System.Drawing.Drawing2D;

namespace Cupscale
{
	public partial class MainForm : Form
	{

		public MainForm()
		{
			EsrganData.ReloadModelList();
			CheckForIllegalCrossThreadCalls = false;
			InitializeComponent();
			ConfigTabHelper.LoadEsrganSettings(confTilesize, confAlpha, modelPathBox, confAlphaBgColorTbox);
			PreviewTabHelper.Init(previewImg, singleModelBox, prevOutputFormatCombox, prevOverwriteCombox);
			UIHelpers.FillModelComboBox(singleModelBox);
			Program.mainForm = this;
			WindowState = FormWindowState.Maximized;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			Logger.textbox = logTbox;
            UIHelpers.InitCombox(prevOverwriteCombox, 0);
            UIHelpers.InitCombox(prevOutputFormatCombox, 0);
            UIHelpers.InitCombox(prevClipboardTypeCombox, 0);
        }

		public void SetPreviewProgress(float prog, string statusText = "")
		{
			prevProgbar.Value = (int)Math.Round(prog);
            if (!string.IsNullOrWhiteSpace(statusText))
                statusLabel.Text = statusText;
		}

		private void refreshModelsBtn_Click(object sender, EventArgs e)
		{
			EsrganData.ReloadModelList();
		}

		private void confSaveEsrganBtn_Click(object sender, EventArgs e)
		{
			ConfigTabHelper.SaveEsrganSettings(confTilesize, confAlpha, modelPathBox, confAlphaBgColorTbox);
		}

		private void refreshPrevBtn_Click(object sender, EventArgs e)
		{
			PreviewTabHelper.UpscalePreview();
		}

		private void prevToggleFilterBtn_Click(object sender, EventArgs e)
		{
			if (previewImg.InterpolationMode != InterpolationMode.NearestNeighbor)
			{
				previewImg.InterpolationMode = InterpolationMode.NearestNeighbor;
                prevToggleFilterBtn.Text = "Switch To Bicubic Filtering";
                Program.currentFilter = ImageMagick.FilterType.Point;
            }
			else
			{
				previewImg.InterpolationMode = InterpolationMode.HighQualityBicubic;
                prevToggleFilterBtn.Text = "Switch To Point Filtering";
                Program.currentFilter = ImageMagick.FilterType.Catrom;
            }
		}

		private void modelTabControl_PageChanged(object sender, PageChangedEventArgs e)
		{
			PreviewTabHelper.UpdateMode(modelTabControl.SelectedIndex);
		}

		private void previewImg_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void previewImg_DragDrop(object sender, DragEventArgs e)
		{
			string[] array = e.Data.GetData(DataFormats.FileDrop) as string[];
            previewImg.Text = "";
			PreviewTabHelper.ResetCachedImages();
            if (!PreviewTabHelper.DroppedImageIsValid(array[0]))
                return;
            previewImg.Image = IOUtils.GetImage(array[0]);
            Program.lastFilename = array[0];
            PreviewTabHelper.currentScale = 1;
			previewImg.ZoomToFit();
		}

		private void previewImg_MouseDown(object sender, MouseEventArgs e)
		{
			PreviewMerger.ShowOriginal();
		}

		private void previewImg_MouseUp(object sender, MouseEventArgs e)
		{
			PreviewMerger.ShowOutput();
		}

		private void upscalePrevBtn_Click(object sender, EventArgs e)
		{
			PreviewTabHelper.UpscaleImage();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        private void singleModelBox_DropDown(object sender, EventArgs e)
        {
            UIHelpers.FillModelComboBox(singleModelBox);
        }

        private void copyComparisonClipboardBtn_Click(object sender, EventArgs e)
        {
            if(prevClipboardTypeCombox.SelectedIndex == 0) ClipboardPreview.CopyToClipboardSideBySide();
            if(prevClipboardTypeCombox.SelectedIndex == 1) ClipboardPreview.CopyToClipboardSlider();
        }

        private void previewImg_Zoomed(object sender, ImageBoxZoomEventArgs e)
        {
            UpdatePreviewInfo();
            if (previewImg.Zoom < 25) previewImg.Zoom = 25;
        }

        void UpdatePreviewInfo ()
        {
            PreviewTabHelper.UpdatePreviewLabels(prevZoomLabel, prevSizeLabel, prevCutoutLabel);
        }

        private void confAlphaBgColorBtn_Click(object sender, EventArgs e)
        {
            alphaBgColorDialog.ShowDialog();
            string colorStr = ColorTranslator.ToHtml(Color.FromArgb(alphaBgColorDialog.Color.ToArgb())).Replace("#", "") + "FF";
            confAlphaBgColorTbox.Text = colorStr;
            Config.Set("alphaBgColor", colorStr);
        }

        private void refreshPrevFullBtn_Click(object sender, EventArgs e)
        {
            PreviewTabHelper.UpscalePreview(true);
        }
    }
}
