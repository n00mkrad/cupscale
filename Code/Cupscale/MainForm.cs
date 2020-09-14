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
using Cupscale.Forms;

namespace Cupscale
{
	public partial class MainForm : Form
	{

		public MainForm()
		{
			EsrganData.ReloadModelList();
			CheckForIllegalCrossThreadCalls = false;
			InitializeComponent();
			PreviewTabHelper.Init(previewImg, modelCombox1, modelCombox2, prevOutputFormatCombox, prevOverwriteCombox);
			Program.mainForm = this;
			WindowState = FormWindowState.Maximized;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
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

        private void refreshPrevFullBtn_Click(object sender, EventArgs e)
        {
            PreviewTabHelper.UpscalePreview(true);
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
			SettingsForm settingsForm = new SettingsForm();
        }

        private void singleModelRbtn_CheckedChanged(object sender, EventArgs e)
        {
			UpdateModelMode();
		}

        private void interpRbtn_CheckedChanged(object sender, EventArgs e)
        {
			UpdateModelMode();
		}

        private void chainRbtn_CheckedChanged(object sender, EventArgs e)
        {
			UpdateModelMode();
		}

		public void UpdateModelMode()
		{
			modelCombox2.Enabled = (interpRbtn.Checked || chainRbtn.Checked);
			interpConfigureBtn.Visible = interpRbtn.Checked;
			if (singleModelRbtn.Checked) PreviewTabHelper.currentMode = PreviewTabHelper.Mode.Single;
			if (interpRbtn.Checked) PreviewTabHelper.currentMode = PreviewTabHelper.Mode.Interp;
			if (chainRbtn.Checked) PreviewTabHelper.currentMode = PreviewTabHelper.Mode.Chain;
		}

        private void interpConfigureBtn_Click(object sender, EventArgs e)
        {
			if (modelCombox1.SelectedIndex == -1 || modelCombox2.SelectedIndex == -1)
            {
				MessageBox.Show("Please select two models for interpolation.", "Message");
				return;
            }
			InterpForm interpForm = new InterpForm(modelCombox1.Text.Trim(), modelCombox2.Text.Trim());
        }
    }
}
