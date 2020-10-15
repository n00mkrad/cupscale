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
using System.Diagnostics;
using Cupscale.OS;
using Microsoft.WindowsAPICodePack.Dialogs;

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
			UIHelpers.InitCombox(preResizeScale, 1);
			UIHelpers.InitCombox(preResizeMode, 0);
			UIHelpers.FillEnumComboBox(preResizeFilter, typeof(Upscale.Filter), 0);
			// Right Panel
			UIHelpers.InitCombox(prevOverwriteCombox, 0);
			UIHelpers.InitCombox(prevOutputFormatCombox, 0);
			UIHelpers.FillEnumComboBox(prevOutputFormatCombox, typeof(Upscale.ExportFormats));
			UIHelpers.InitCombox(postResizeScale, 1);
			UIHelpers.InitCombox(postResizeMode, 0);
			UIHelpers.FillEnumComboBox(postResizeFilter, typeof(Upscale.Filter), 0);
			// Batch Upscale
			UIHelpers.InitCombox(batchOutMode, 0);
			UIHelpers.InitCombox(preprocessMode, 0);
			await CheckInstallation();

			NvApi.Init();
		}

		public async Task CheckInstallation ()
        {
			await ShippedFiles.Init();
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
				htProgBar.Value = percent;
				htProgBar.Refresh();
				lastProg = prog;
			}
			if (!string.IsNullOrWhiteSpace(statusText) && lastStatus != statusText)
            {
				statusLabel.Text = statusText;
				if (Logger.doLogStatus) Logger.Log("Status changed: " + statusText);
				lastStatus = statusText;
			}
		}

		public void SetVramLabel (string text, Color color)
        {
			vramLabel.Text = text;
			vramLabel.ForeColor = color;
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
			new SettingsForm().ShowDialog();
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
			model1TreeBtn.Enabled = !advancedBtn.Checked;
			model2TreeBtn.Enabled = (interpRbtn.Checked || chainRbtn.Checked);
			interpConfigureBtn.Visible = interpRbtn.Checked;
			advancedConfigureBtn.Visible = advancedBtn.Checked;
			if (singleModelRbtn.Checked) MainUIHelper.currentMode = MainUIHelper.Mode.Single;
			if (interpRbtn.Checked) MainUIHelper.currentMode = MainUIHelper.Mode.Interp;
			if (chainRbtn.Checked) MainUIHelper.currentMode = MainUIHelper.Mode.Chain;
			if (advancedBtn.Checked) MainUIHelper.currentMode = MainUIHelper.Mode.Advanced;
		}

        private void interpConfigureBtn_Click(object sender, EventArgs e)
        {
			
			if (!MainUIHelper.HasValidModelSelection())
            {
				MessageBox.Show("Please select two models for interpolation.", "Message");
				return;
            }

			AdvancedModelsForm interpForm = new AdvancedModelsForm(model1TreeBtn.Text.Trim(), model2TreeBtn.Text.Trim());
			interpForm.ShowDialog();
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
			Logger.Log("[MainUI] Dropped " + files.Length + " file(s), files[0] = " + files[0]);
			IOUtils.ClearDir(Paths.tempImgPath.GetParentDir());
			string path = files[0];
			DialogForm loadingDialogForm = null;
			if (IOUtils.IsPathDirectory(path))
			{
				htTabControl.SelectedIndex = 1;
				int compatFilesAmount = IOUtils.GetAmountOfCompatibleFiles(path, true);
				batchDirLabel.Text = "Loaded " + path.Wrap() + " - Found " + compatFilesAmount + " compatible files.";
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
			await Task.Delay(20);
			MainUIHelper.ResetCachedImages();
			if (!MainUIHelper.DroppedImageIsValid(path))
            {
				SetProgress(0f, "Ready.");
				await Task.Delay(1);
				Program.CloseTempForms();
				return;
			}
			Program.lastFilename = path;
			ReloadImage(false);
			if (failed) { FailReset(); return; }
			SetHasPreview(false);
			loadingDialogForm.Close();
			SetRefreshPreviewBtns(true);
			SetProgress(0f, "Ready.");
		}

		public bool failed = false;
		public void FailReset ()
        {
			SetProgress(0f, "Reset after error.");
			Program.CloseTempForms();
			Program.lastFilename = null;
			failed = false;
        }

		public void SetRefreshPreviewBtns (bool state)
        {
			refreshPreviewCutoutBtn.Enabled = state;
			refreshPreviewFullBtn.Enabled = state;
		}

		public async void ReloadImage (bool allowFail = true)	// Returns false on error
        {
			try
			{
				string path = Program.lastFilename;
				File.Copy(path, Paths.tempImgPath, true);
				bool fillAlpha = !bool.Parse(Config.Get("alpha"));
				await ImageProcessing.ConvertImage(path, ImageProcessing.Format.PngRaw, fillAlpha, ImageProcessing.ExtMode.UseNew, false, Paths.tempImgPath, true);
				previewImg.Image = ImgUtils.GetImage(Paths.tempImgPath);
				MainUIHelper.currentScale = 1;
				previewImg.ZoomToFit();
				lastZoom = previewImg.Zoom;
			}
			catch (Exception e)
			{
				Logger.Log("Failed to reload image from source path - Maybe image is from clipboard or has been deleted. " + e.Message);
                if (!allowFail)
                {
					Logger.ErrorMessage("Failed to load image:", e);
					failed = true;
				}
			}
		}

		public void ForceMaximize ()
        {
			WindowState = FormWindowState.Minimized;
			WindowState = FormWindowState.Maximized;
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

			bool useNcnn = (Config.Get("cudaFallback").GetInt() == 2 || Config.Get("cudaFallback").GetInt() == 3);
			if (useNcnn && !Program.mainForm.HasValidNcnnModelSelection())
			{
				MessageBox.Show("Invalid model selection - NCNN does not support interpolation or chaining.", "Error");
				return;
			}

			if (Config.GetBool("reloadImageBeforeUpscale"))
				ReloadImage();
			UpdateResizeMode();
			if (htTabControl.SelectedIndex == 0)
				await MainUIHelper.UpscaleImage();
			if (htTabControl.SelectedIndex == 1)
				await BatchUpscaleUI.Run(preprocessMode.SelectedIndex == 0);
		}

		public void UpdateResizeMode ()
        {
			ImageProcessing.postFilter = (Upscale.Filter)Enum.Parse(typeof(Upscale.Filter), postResizeFilter.Text.RemoveSpaces());
			ImageProcessing.postScaleMode = (Upscale.ScaleMode)Enum.Parse(typeof(Upscale.ScaleMode), postResizeMode.Text.RemoveSpaces());
			ImageProcessing.postScaleValue = postResizeScale.GetInt();
			ImageProcessing.postOnlyDownscale = postResizeOnlyDownscale.Checked;

			ImageProcessing.preFilter = (Upscale.Filter)Enum.Parse(typeof(Upscale.Filter), preResizeFilter.Text.RemoveSpaces());
			ImageProcessing.preScaleMode = (Upscale.ScaleMode)Enum.Parse(typeof(Upscale.ScaleMode), preResizeMode.Text.RemoveSpaces());
			ImageProcessing.preScaleValue = preResizeScale.GetInt();
			ImageProcessing.preOnlyDownscale = preResizeOnlyDownscale.Checked;
		}

		public bool HasValidNcnnModelSelection ()
        {
			return singleModelRbtn.Checked;
		}

        private async void refreshPreviewFullBtn_Click(object sender, EventArgs e)
        {
			if (Config.GetBool("reloadImageBeforeUpscale"))
				ReloadImage();
			UpdateResizeMode();
			MainUIHelper.UpscalePreview(true);
		}

        private void refreshPreviewCutoutBtn_Click(object sender, EventArgs e)
        {
			UpdateResizeMode();
			MainUIHelper.UpscalePreview();
		}

        private void copyCompToClipboardBtn_Click(object sender, EventArgs e)
        {
			if (prevClipboardTypeCombox.SelectedIndex == 0) ClipboardPreview.CopyToClipboardSideBySide(false);
			if (prevClipboardTypeCombox.SelectedIndex == 1) ClipboardPreview.CopyToClipboardSlider(false);
			if (prevClipboardTypeCombox.SelectedIndex == 2) ClipboardPreview.BeforeAfterAnim(false, false);
			if (prevClipboardTypeCombox.SelectedIndex == 3) ClipboardPreview.BeforeAfterAnim(false, true);
			if (prevClipboardTypeCombox.SelectedIndex == 4) ClipboardPreview.OnlyResult(false);
		}

        private void model1TreeBtn_Click(object sender, EventArgs e)
        {
			new ModelSelectForm(model1TreeBtn, 1).ShowDialog();
        }

        private void model2TreeBtn_Click(object sender, EventArgs e)
        {
			new ModelSelectForm(model2TreeBtn, 2).ShowDialog();
		}

        private void savePreviewToFileBtn_Click(object sender, EventArgs e)
        {
			if (prevClipboardTypeCombox.SelectedIndex == 0) ClipboardPreview.CopyToClipboardSideBySide(true);
			if (prevClipboardTypeCombox.SelectedIndex == 1) ClipboardPreview.CopyToClipboardSlider(true);
			if (prevClipboardTypeCombox.SelectedIndex == 2) ClipboardPreview.BeforeAfterAnim(true, false);
			if (prevClipboardTypeCombox.SelectedIndex == 3) ClipboardPreview.BeforeAfterAnim(true, true);
			if (prevClipboardTypeCombox.SelectedIndex == 4) ClipboardPreview.OnlyResult(true);
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

        private void openOutFolderBtn_Click(object sender, EventArgs e)
        {
			MainUIHelper.OpenLastOutputFolder();
        }

		public void AfterFirstUpscale ()
        {
			openOutFolderBtn.Enabled = true;
		}

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { Program.Cleanup(); }
			catch { }                       // This is fine if it fails due to locks, runs on startup anyway.
		}

		public void SetHasPreview (bool state)
        {
			copyCompToClipboardBtn.Enabled = state;
			savePreviewToFileBtn.Enabled = state;
			saveMergedPreviewBtn.Enabled = state;
		}

        private async void saveMergedPreviewBtn_Click(object sender, EventArgs e)
        {
			Upscale.currentMode = Upscale.UpscaleMode.Single;
			string ext = Path.GetExtension(Program.lastFilename);
			string outPath = Path.ChangeExtension(Program.lastFilename, null) + "[temp]" + ext + ".tmp";
			previewImg.Image.Save(outPath);
			await Upscale.PostprocessingSingle(outPath, true);
			string outFilename = Upscale.FilenamePostprocess(MainUIHelper.lastOutfile);
			string finalPath = IOUtils.ReplaceInFilename(outFilename, "[temp]", "");
			MessageBox.Show("Saved to " + finalPath + ".", "Message");
		}

        private void batchOutMode_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (batchOutMode.SelectedIndex == 0)
				PostProcessingQueue.copyMode = PostProcessingQueue.CopyMode.KeepStructure;
			if (batchOutMode.SelectedIndex == 1)
				PostProcessingQueue.copyMode = PostProcessingQueue.CopyMode.CopyToRoot;
		}

        private void advancedBtn_CheckedChanged(object sender, EventArgs e)
        {
			UpdateModelMode();
		}

        private void advancedConfigureBtn_Click(object sender, EventArgs e)
        {
			new AdvancedModelForm();
        }

        private async void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
			if (e.KeyData == (Keys.Control | Keys.V))
			{
				if (htTabControl.SelectedIndex != 0 || !Enabled)
					return;
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

        private void comparisonToolBtn_Click(object sender, EventArgs e)
        {
			new ModelComparisonForm().ShowDialog();
        }

        private void openModelFolderBtn_Click(object sender, EventArgs e)
        {
			Process.Start("explorer.exe", Config.Get("modelPath"));
		}

        private void selectOutPathBtn_Click(object sender, EventArgs e)
        {
			CommonOpenFileDialog folderDialog = new CommonOpenFileDialog();
			if(Directory.Exists(batchOutDir.Text.Trim()))
				folderDialog.InitialDirectory = batchOutDir.Text;
			folderDialog.IsFolderPicker = true;
			if (folderDialog.ShowDialog() == CommonFileDialogResult.Ok)
				batchOutDir.Text = folderDialog.FileName;
		}
    }
}
