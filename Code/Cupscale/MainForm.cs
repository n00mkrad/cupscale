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
using Cupscale.Main;
using System.Threading.Tasks;
using System.IO;
using Cupscale.IO;

namespace Cupscale
{
	public partial class MainForm : Form
	{

		public MainForm()
		{
			EsrganData.ReloadModelList();
			CheckForIllegalCrossThreadCalls = false;
			InitializeComponent();
			MainUIHelper.Init(previewImg, modelCombox1, modelCombox2, prevOutputFormatCombox, prevOverwriteCombox);
			BatchUpscaleUI.Init(batchOutDir, batchFileList);
			Program.mainForm = this;
			WindowState = FormWindowState.Maximized;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
            UIHelpers.InitCombox(prevOverwriteCombox, 0);
            UIHelpers.InitCombox(prevOutputFormatCombox, 0);
            UIHelpers.InitCombox(prevClipboardTypeCombox, 0);
        }

		public void SetProgress(float prog, string statusText = "")
		{
			int percent = (int)Math.Round(prog);
			if (percent < 0) percent = 0;
			if (percent > 100) percent = 100;
			htProgBar.Visible = false;
			htProgBar.Value = percent;
			htProgBar.Visible = true;
			if (!string.IsNullOrWhiteSpace(statusText))
                statusLabel.Text = statusText;
		}

		public void SetBusy (bool state)
        {
			Program.busy = state;
			upscaleBtn.Enabled = !state;
			refreshPreviewCutoutBtn.Enabled = !state;
			refreshPreviewFullBtn.Enabled = !state;
		}

		private void refreshModelsBtn_Click(object sender, EventArgs e)
		{
			EsrganData.ReloadModelList();
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
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}

		private void previewImg_DragDrop(object sender, DragEventArgs e)
		{
			string[] array = e.Data.GetData(DataFormats.FileDrop) as string[];
			DragNDrop(array);
		}

		private void previewImg_MouseDown(object sender, MouseEventArgs e)
		{
			PreviewMerger.ShowOriginal();
		}

		private void previewImg_MouseUp(object sender, MouseEventArgs e)
		{
			PreviewMerger.ShowOutput();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        private void previewImg_Zoomed(object sender, ImageBoxZoomEventArgs e)
        {
			if (previewImg.Image == null)
				return;
            UpdatePreviewInfo();
            if (previewImg.Zoom < 25) previewImg.Zoom = 25;
        }

        void UpdatePreviewInfo ()
        {
            MainUIHelper.UpdatePreviewLabels(prevZoomLabel, prevSizeLabel, prevCutoutLabel);
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
			if (singleModelRbtn.Checked) MainUIHelper.currentMode = MainUIHelper.Mode.Single;
			if (interpRbtn.Checked) MainUIHelper.currentMode = MainUIHelper.Mode.Interp;
			if (chainRbtn.Checked) MainUIHelper.currentMode = MainUIHelper.Mode.Chain;
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

        private void batchTab_DragEnter(object sender, DragEventArgs e)
        {
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}

        private void batchTab_DragDrop(object sender, DragEventArgs e)
        {
			string[] array = e.Data.GetData(DataFormats.FileDrop) as string[];
			DragNDrop(array);
		}

		async Task DragNDrop (string [] array)
        {
			string path = array[0];
			if (IOUtils.IsPathDirectory(path))
			{
				htTabControl.SelectedIndex = 1;
				int compatFilesAmount = IOUtils.GetAmountOfCompatibleFiles(path, true);
				batchDirLabel.Text = "Loaded \"" + path + "\" - Found " + compatFilesAmount + " compatible files.";
				BatchUpscaleUI.LoadDir(path);
				BringToFront();
				upscaleBtn.Text = "Upscale " + compatFilesAmount + " Images";
				return;
			}
			upscaleBtn.Text = "Upscale And Save";
			htTabControl.SelectedIndex = 0;
			previewImg.Text = "";
			SetProgress(0f, "Loading image...");
			DialogForm loadingDialogForm = new DialogForm("Loading image...");
			await Task.Delay(1);
			MainUIHelper.ResetCachedImages();
			if (!MainUIHelper.DroppedImageIsValid(array[0]))
            {
				SetProgress(0f, "Ready.");
				await Task.Delay(1);
				Program.CloseTempForms();
				return;
			}
			string imgTempPath = Path.Combine(Paths.imgInPath, "temp.png");
			File.Copy(array[0], imgTempPath, true);
			await Upscale.Preprocessing(Paths.imgInPath);
			previewImg.Image = IOUtils.GetImage(imgTempPath);
			Program.lastFilename = array[0];
			MainUIHelper.currentScale = 1;
			previewImg.ZoomToFit();
			loadingDialogForm.Close();
			SetProgress(0f, "Ready.");
		}

        private void upscaleBtn_Click(object sender, EventArgs e)
        {
			if (Program.busy)
				return;
			if(htTabControl.SelectedIndex == 0)
            {
				MainUIHelper.UpscaleImage();
			}
			if (htTabControl.SelectedIndex == 1)
			{
				BatchUpscaleUI.Run();
			}
		}

        private void refreshPreviewFullBtn_Click(object sender, EventArgs e)
        {
			MainUIHelper.UpscalePreview(true);
		}

        private void refreshPreviewCutoutBtn_Click(object sender, EventArgs e)
        {
			MainUIHelper.UpscalePreview();
		}

        private void copyCompToClipboardBtn_Click(object sender, EventArgs e)
        {
			if (prevClipboardTypeCombox.SelectedIndex == 0) ClipboardPreview.CopyToClipboardSideBySide();
			if (prevClipboardTypeCombox.SelectedIndex == 1) ClipboardPreview.CopyToClipboardSlider();
		}
    }
}
