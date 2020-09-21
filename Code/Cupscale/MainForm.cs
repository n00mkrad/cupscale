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
using Cupscale.Cupscale;

namespace Cupscale
{
	public partial class MainForm : Form
	{
		public bool resetImageOnMove = false;
		public PreviewState resetState;

		public MainForm()
		{
			EsrganData.ReloadModelList();
			CheckForIllegalCrossThreadCalls = false;
			InitializeComponent();
			MainUIHelper.Init(previewImg, model1TreeBtn, model2TreeBtn, prevOutputFormatCombox, prevOverwriteCombox);
			BatchUpscaleUI.Init(batchOutDir, batchFileList);
			Program.mainForm = this;
			WindowState = FormWindowState.Maximized;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
            UIHelpers.InitCombox(prevOverwriteCombox, 0);
            UIHelpers.InitCombox(prevOutputFormatCombox, 0);
            UIHelpers.InitCombox(prevClipboardTypeCombox, 0);
			UIHelpers.FillFormatComboBox(prevOutputFormatCombox);
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

		int lastZoom;
        private void previewImg_Zoomed(object sender, ImageBoxZoomEventArgs e)
        {
			if (previewImg.Image == null)
				return;
			if (previewImg.Zoom < 25) previewImg.Zoom = 25;
			if(previewImg.Zoom != lastZoom)
            {
				if (resetImageOnMove)
					ResetToLastState();
				lastZoom = previewImg.Zoom;
			}
			UpdatePreviewInfo();
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
			model2TreeBtn.Enabled = (interpRbtn.Checked || chainRbtn.Checked);
			interpConfigureBtn.Visible = interpRbtn.Checked;
			if (singleModelRbtn.Checked) MainUIHelper.currentMode = MainUIHelper.Mode.Single;
			if (interpRbtn.Checked) MainUIHelper.currentMode = MainUIHelper.Mode.Interp;
			if (chainRbtn.Checked) MainUIHelper.currentMode = MainUIHelper.Mode.Chain;
		}

        private void interpConfigureBtn_Click(object sender, EventArgs e)
        {
			
			if (!MainUIHelper.HasValidModelSelection())
            {
				MessageBox.Show("Please select two models for interpolation.", "Message");
				return;
            }

			InterpForm interpForm = new InterpForm(model1TreeBtn.Text.Trim(), model2TreeBtn.Text.Trim());
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
			DialogForm loadingDialogForm = new DialogForm("Loading " + Path.GetFileName(path) +"...");
			await Task.Delay(1);
			MainUIHelper.ResetCachedImages();
			Logger.Log("3");
			if (!MainUIHelper.DroppedImageIsValid(path))
            {
				SetProgress(0f, "Ready.");
				await Task.Delay(1);
				Program.CloseTempForms();
				return;
			}
			File.Copy(path, Paths.tempImgPath, true);
			//await Upscale.Preprocessing(Paths.tempImgPath.GetParentDir());
			bool fillAlpha = !bool.Parse(Config.Get("alpha"));
			await ImageProcessing.ConvertImage(path, ImageProcessing.Format.PngRaw, fillAlpha, false, false, Paths.tempImgPath);
			Logger.Log("Done Preprocessing");
			previewImg.Image = IOUtils.GetImage(Paths.tempImgPath);
			Program.lastFilename = path;
			MainUIHelper.currentScale = 1;
			previewImg.ZoomToFit();
			lastZoom = previewImg.Zoom;
			loadingDialogForm.Close();
			SetProgress(0f, "Ready.");
		}

        private void upscaleBtn_Click(object sender, EventArgs e)
        {
			if (Program.busy)
				return;

            if (!MainUIHelper.HasValidModelSelection())
            {
				MessageBox.Show("Invalid model selection.\nMake sure you have selected a model and that the file still exists.", "Error");
				return;
            }

			if(htTabControl.SelectedIndex == 0)
				MainUIHelper.UpscaleImage();
			if (htTabControl.SelectedIndex == 1)
				BatchUpscaleUI.Run();
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
			if (prevClipboardTypeCombox.SelectedIndex == 0) ClipboardPreview.CopyToClipboardSideBySide(false);
			if (prevClipboardTypeCombox.SelectedIndex == 1) ClipboardPreview.CopyToClipboardSlider(false);
		}

        private void model1TreeBtn_Click(object sender, EventArgs e)
        {
			ModelSelectForm treeForm = new ModelSelectForm(model1TreeBtn, 1);
        }

        private void model2TreeBtn_Click(object sender, EventArgs e)
        {
			ModelSelectForm treeForm = new ModelSelectForm(model2TreeBtn, 2);
		}

        private void savePreviewToFileBtn_Click(object sender, EventArgs e)
        {
			if (prevClipboardTypeCombox.SelectedIndex == 0) ClipboardPreview.CopyToClipboardSideBySide(true);
			if (prevClipboardTypeCombox.SelectedIndex == 1) ClipboardPreview.CopyToClipboardSlider(true);
		}

		public void ResetToLastState ()
        {
			previewImg.Image = resetState.image;
			previewImg.Zoom = resetState.zoom;
			previewImg.AutoScrollPosition = resetState.autoScrollPosition;		// This doesn't work correctly :/
			MainUIHelper.ResetCachedImages();
			resetImageOnMove = false;
		}
    }
}
