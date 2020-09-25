using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Cupscale.UI;
using Cyotek.Windows.Forms;
using ImageBox = Cyotek.Windows.Forms.ImageBox;
using Cupscale.Properties;
using System.Drawing.Drawing2D;
using Cupscale.Forms;
using Cupscale.Main;
using System.Threading.Tasks;
using System.IO;
using Cupscale.IO;
using Cupscale.Cupscale;
using Win32Interop.Structs;
using Cupscale.ImageUtils;

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

		private async void MainForm_Load(object sender, EventArgs e)
		{
			// Left Panel
            UIHelpers.InitCombox(prevClipboardTypeCombox, 0);
			// Right Panel
			UIHelpers.InitCombox(prevOverwriteCombox, 0);
			UIHelpers.InitCombox(prevOutputFormatCombox, 0);
			UIHelpers.FillEnumComboBox(prevOutputFormatCombox, typeof(Upscale.ExportFormats));
			UIHelpers.InitCombox(postResizeScale, 1);
			UIHelpers.InitCombox(postResizeMode, 0);
			UIHelpers.FillEnumComboBox(postResizeFilter, typeof(Upscale.Filter), 0);
			await CheckInstallation();
		}

		public async Task CheckInstallation ()
        {
			await ShippedEsrgan.Init();
			Enabled = true;
		}

		float lastProg;
		string lastStatus = "";
		public void SetProgress(float prog, string statusText = "")
		{
			if(lastProg != prog)
            {
				int percent = (int)Math.Round(prog);
				if (percent < 0) percent = 0;
				if (percent > 100) percent = 100;
				htProgBar.Visible = false;
				htProgBar.Value = percent;
				htProgBar.Visible = true;
				lastProg = prog;
			}
			if (!string.IsNullOrWhiteSpace(statusText) && lastStatus != statusText)
            {
				statusLabel.Text = statusText;
				Logger.Log("Status changed: " + statusText);
				lastStatus = statusText;
			}
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

		async Task DragNDrop (string [] files)
        {
			Logger.Log("Dropped " + files.Length + " file(s), files[0] = " + files[0]);
			IOUtils.DeleteContentsOfDir(Paths.tempImgPath.GetParentDir());
			string path = files[0];
			DialogForm loadingDialogForm = null;
			if (IOUtils.IsPathDirectory(path))
			{
				htTabControl.SelectedIndex = 1;
				int compatFilesAmount = IOUtils.GetAmountOfCompatibleFiles(path, true);
				batchDirLabel.Text = "Loaded " + path.WrapPath() + " - Found " + compatFilesAmount + " compatible files.";
				BatchUpscaleUI.LoadDir(path);
				upscaleBtn.Text = "Upscale " + compatFilesAmount + " Images";
				return;
			}
			if(files.Length > 1)
            {
				htTabControl.SelectedIndex = 1;
				int compatFilesAmount = IOUtils.GetAmountOfCompatibleFiles(files);
				BatchUpscaleUI.LoadImages(files);
				batchDirLabel.Text = "Loaded " + compatFilesAmount + " compatible files.";
				upscaleBtn.Text = "Upscale " + compatFilesAmount + " Images";
				return;
			}
			upscaleBtn.Text = "Upscale And Save";
			htTabControl.SelectedIndex = 0;
			previewImg.Text = "";
			SetProgress(0f, "Loading image...");
			loadingDialogForm = new DialogForm("Loading " + Path.GetFileName(path) +"...");
			await Task.Delay(1);
			MainUIHelper.ResetCachedImages();
			if (!MainUIHelper.DroppedImageIsValid(path))
            {
				SetProgress(0f, "Ready.");
				await Task.Delay(1);
				Program.CloseTempForms();
				return;
			}
			File.Copy(path, Paths.tempImgPath, true);
			bool fillAlpha = !bool.Parse(Config.Get("alpha"));
			await ImageProcessing.ConvertImage(path, ImageProcessing.Format.PngRaw, fillAlpha, false, false, Paths.tempImgPath);
			Logger.Log("Done Preprocessing");
			previewImg.Image = ImgUtils.GetImage(Paths.tempImgPath);
			Program.lastFilename = path;
			MainUIHelper.currentScale = 1;
			previewImg.ZoomToFit();
			lastZoom = previewImg.Zoom;
			loadingDialogForm.Close();
			SetProgress(0f, "Ready.");
		}

        private async void upscaleBtn_Click(object sender, EventArgs e)
        {
			if (Program.busy)
				return;

            if (!MainUIHelper.HasValidModelSelection())
            {
				MessageBox.Show("Invalid model selection.\nMake sure you have selected a model and that the file still exists.", "Error");
				return;
            }

			UpdateResizeMode();
			if (htTabControl.SelectedIndex == 0)
				await MainUIHelper.UpscaleImage();
			if (htTabControl.SelectedIndex == 1)
				await BatchUpscaleUI.Run();
		}

		public void UpdateResizeMode ()
        {
			ImageProcessing.currentFilter = (Upscale.Filter)Enum.Parse(typeof(Upscale.Filter), postResizeFilter.Text.RemoveSpaces());
			ImageProcessing.currentScaleMode = (Upscale.ScaleMode)Enum.Parse(typeof(Upscale.ScaleMode), postResizeMode.Text.RemoveSpaces());
			ImageProcessing.currentScaleValue = postResizeScale.GetInt();
			ImageProcessing.onlyDownscale = postResizeOnlyDownscale.Checked;
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
			if (prevClipboardTypeCombox.SelectedIndex == 2) ClipboardPreview.BeforeAfterAnim(false, false);
			if (prevClipboardTypeCombox.SelectedIndex == 3) ClipboardPreview.BeforeAfterAnim(false, true);
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
			if (prevClipboardTypeCombox.SelectedIndex == 2) ClipboardPreview.BeforeAfterAnim(true, false);
			if (prevClipboardTypeCombox.SelectedIndex == 3) ClipboardPreview.BeforeAfterAnim(true, true);
		}

		public void ResetToLastState ()
        {
			previewImg.Image = resetState.image;
			previewImg.Zoom = resetState.zoom;
			previewImg.AutoScrollPosition = resetState.autoScrollPosition;		// This doesn't work correctly :/
			MainUIHelper.ResetCachedImages();
			resetImageOnMove = false;
		}

        private void prevOverwriteCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (prevOverwriteCombox.SelectedIndex == 0)
				Upscale.overwriteMode = Upscale.Overwrite.No;
			if (prevOverwriteCombox.SelectedIndex == 1)
				Upscale.overwriteMode = Upscale.Overwrite.Yes;
		}

        private void postResizeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
			postResizeOnlyDownscale.Enabled = postResizeMode.SelectedIndex != 0;
        }

        private async void previewImg_KeyUp(object sender, KeyEventArgs e)
        {
			if (e.KeyData == (Keys.Control | Keys.V))
			{
                try
                {
					Image clipboardImg = Clipboard.GetImage();
					string savePath = Path.Combine(Paths.clipboardFolderPath, "Clipboard.png");
					clipboardImg.Save(savePath);
					await DragNDrop(new string[] { savePath });
				}
				catch
                {
					MessageBox.Show("Failed to paste image from clipboard. Make sure you have a raw image (not a file) copied.", "Error");
                }
			}
		}

        private void openOutFolderBtn_Click(object sender, EventArgs e)
        {
			MainUIHelper.OpenLastOutputFolder();
        }

		public void AfterFirstUpscale ()
        {
			openOutFolderBtn.Enabled = true;
		}

		public void AfterFirstPreview ()
		{
			copyCompToClipboardBtn.Enabled = true;
			savePreviewToFileBtn.Enabled = true;
		}

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { Program.Cleanup(); }
			catch { }                       // This is fine if it fails due to locks, runs on startup anyway.
		}
    }
}
