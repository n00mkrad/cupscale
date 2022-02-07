using System.ComponentModel;
using System.Windows.Forms;
using ImageBox = Cyotek.Windows.Forms.ImageBox;

namespace Cupscale.Main
{
    partial class MainForm
    {
        private IContainer components = null;
        private Panel leftPanel;
        private Panel panel2;
        private Panel panel1;
        private ImageBox img;
        private Panel rightPanel;
        private TableLayoutPanel mainTableLayoutPanel;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label10;
        private ComboBox prevOverwriteCombox;
        private Label label11;
        private ComboBox prevClipboardTypeCombox;
        private Label label12;
        private Label prevZoomLabel;
        private TableLayoutPanel tableLayoutPanel5;
        private Label statusLabel;
        private Label prevSizeLabel;
        private Label prevCutoutLabel;
        private ComboBox imageOutputFormat;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.leftPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.img = new Cyotek.Windows.Forms.ImageBox();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.htProgBar = new HTAlt.WinForms.HTProgressBar();
            this.panel11 = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.htTabControl = new HTAlt.WinForms.HTTabControl();
            this.previewTab = new System.Windows.Forms.TabPage();
            this.previewImg = new Cyotek.Windows.Forms.ImageBox();
            this.batchTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.batchDirLabel = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.batchCacheSplitDepth = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.selectOutPathBtn = new System.Windows.Forms.Button();
            this.batchOutDir = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.preprocessMode = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.batchOutMode = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.batchFileList = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.videoTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.videoPathLabel = new System.Windows.Forms.Label();
            this.panel37 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.panel38 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.videoFileListBox = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.panel39 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.videoPreprocessMode = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.videoOutPathBtn = new System.Windows.Forms.Button();
            this.videoOutDir = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.panel40 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.videoLogBox = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.discordBtn = new HTAlt.WinForms.HTButton();
            this.patreonBtn = new HTAlt.WinForms.HTButton();
            this.offlineInterpBtn = new HTAlt.WinForms.HTButton();
            this.htButton1 = new HTAlt.WinForms.HTButton();
            this.paypalBtn = new HTAlt.WinForms.HTButton();
            this.openModelFolderBtn = new HTAlt.WinForms.HTButton();
            this.comparisonToolBtn = new HTAlt.WinForms.HTButton();
            this.settingsBtn = new HTAlt.WinForms.HTButton();
            this.panel15 = new System.Windows.Forms.Panel();
            this.vramLabel = new System.Windows.Forms.Label();
            this.flowPanelRight = new System.Windows.Forms.FlowLayoutPanel();
            this.upscalePanel = new System.Windows.Forms.Panel();
            this.cancelBtn = new HTAlt.WinForms.HTButton();
            this.saveMergedPreviewBtn = new HTAlt.WinForms.HTButton();
            this.label20 = new System.Windows.Forms.Label();
            this.openOutFolderBtn = new HTAlt.WinForms.HTButton();
            this.upscaleBtn = new HTAlt.WinForms.HTButton();
            this.rSpacer1 = new System.Windows.Forms.Panel();
            this.panel28 = new System.Windows.Forms.Panel();
            this.savePanel = new System.Windows.Forms.Panel();
            this.videoOutputFormat = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.prevOverwriteCombox = new System.Windows.Forms.ComboBox();
            this.imageOutputFormat = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.rSpacer2 = new System.Windows.Forms.Panel();
            this.panel26 = new System.Windows.Forms.Panel();
            this.postResizePanel = new System.Windows.Forms.Panel();
            this.postResizeOnlyDownscale = new System.Windows.Forms.CheckBox();
            this.postResizeMode = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.postResizeFilter = new System.Windows.Forms.ComboBox();
            this.postResizeScale = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rSpacer3 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.preResizePanel = new System.Windows.Forms.Panel();
            this.preResizeOnlyDownscale = new System.Windows.Forms.CheckBox();
            this.preResizeMode = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.preResizeFilter = new System.Windows.Forms.ComboBox();
            this.preResizeScale = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.rSpacer4 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.imgOptsPanel = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.openSourceFolderBtn = new HTAlt.WinForms.HTButton();
            this.reloadImgBtn = new HTAlt.WinForms.HTButton();
            this.flowPanelLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.prevCtrlPanel = new System.Windows.Forms.Panel();
            this.prevToggleFilterBtn = new HTAlt.WinForms.HTButton();
            this.refreshPreviewCutoutBtn = new HTAlt.WinForms.HTButton();
            this.label21 = new System.Windows.Forms.Label();
            this.refreshPreviewFullBtn = new HTAlt.WinForms.HTButton();
            this.leftSpacer1 = new System.Windows.Forms.Panel();
            this.panel30 = new System.Windows.Forms.Panel();
            this.prevInfoPanel = new System.Windows.Forms.Panel();
            this.prevCutoutLabel = new System.Windows.Forms.Label();
            this.prevSizeLabel = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.prevZoomLabel = new System.Windows.Forms.Label();
            this.leftSpacer2 = new System.Windows.Forms.Panel();
            this.panel34 = new System.Windows.Forms.Panel();
            this.compPanel = new System.Windows.Forms.Panel();
            this.savePreviewToFileBtn = new HTAlt.WinForms.HTButton();
            this.label27 = new System.Windows.Forms.Label();
            this.copyCompToClipboardBtn = new HTAlt.WinForms.HTButton();
            this.label12 = new System.Windows.Forms.Label();
            this.prevClipboardTypeCombox = new System.Windows.Forms.ComboBox();
            this.leftSpacer3 = new System.Windows.Forms.Panel();
            this.panel32 = new System.Windows.Forms.Panel();
            this.esrganPanel = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.seamlessMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.alpha = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.leftSpacer4 = new System.Windows.Forms.Panel();
            this.panel36 = new System.Windows.Forms.Panel();
            this.mdlPanel = new System.Windows.Forms.Panel();
            this.advancedBtn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.advancedConfigureBtn = new System.Windows.Forms.Button();
            this.model2TreeBtn = new System.Windows.Forms.Button();
            this.interpConfigureBtn = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.model1TreeBtn = new System.Windows.Forms.Button();
            this.chainRbtn = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.interpRbtn = new System.Windows.Forms.RadioButton();
            this.singleModelRbtn = new System.Windows.Forms.RadioButton();
            this.leftSpacer5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.aiPanel = new System.Windows.Forms.Panel();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.aiSelect = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mainTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel11.SuspendLayout();
            this.htTabControl.SuspendLayout();
            this.previewTab.SuspendLayout();
            this.batchTab.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.panel12.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.videoTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel37.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panel38.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.panel39.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.panel40.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel15.SuspendLayout();
            this.flowPanelRight.SuspendLayout();
            this.upscalePanel.SuspendLayout();
            this.rSpacer1.SuspendLayout();
            this.savePanel.SuspendLayout();
            this.rSpacer2.SuspendLayout();
            this.postResizePanel.SuspendLayout();
            this.rSpacer3.SuspendLayout();
            this.preResizePanel.SuspendLayout();
            this.rSpacer4.SuspendLayout();
            this.imgOptsPanel.SuspendLayout();
            this.flowPanelLeft.SuspendLayout();
            this.prevCtrlPanel.SuspendLayout();
            this.leftSpacer1.SuspendLayout();
            this.prevInfoPanel.SuspendLayout();
            this.leftSpacer2.SuspendLayout();
            this.compPanel.SuspendLayout();
            this.leftSpacer3.SuspendLayout();
            this.esrganPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.leftSpacer4.SuspendLayout();
            this.mdlPanel.SuspendLayout();
            this.leftSpacer5.SuspendLayout();
            this.aiPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.AutoSize = true;
            this.leftPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.leftPanel.Location = new System.Drawing.Point(3, 3);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(200, 532);
            this.leftPanel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(190, 94);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(3, 431);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 94);
            this.panel1.TabIndex = 2;
            // 
            // img
            // 
            this.img.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.img.Location = new System.Drawing.Point(259, 3);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(568, 556);
            this.img.TabIndex = 0;
            // 
            // rightPanel
            // 
            this.rightPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rightPanel.Location = new System.Drawing.Point(833, 3);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(239, 552);
            this.rightPanel.TabIndex = 2;
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.mainTableLayoutPanel.ColumnCount = 3;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 370F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.mainTableLayoutPanel.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.mainTableLayoutPanel.Controls.Add(this.panel6, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.panel7, 2, 0);
            this.mainTableLayoutPanel.Controls.Add(this.panel15, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.flowPanelRight, 2, 1);
            this.mainTableLayoutPanel.Controls.Add(this.flowPanelLeft, 0, 1);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1264, 921);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.htTabControl, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(373, 43);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(568, 875);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.htProgBar, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.panel11, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 853);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(562, 19);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // htProgBar
            // 
            this.htProgBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.htProgBar.BorderThickness = 0;
            this.htProgBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htProgBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.htProgBar.ForeColor = System.Drawing.Color.White;
            this.htProgBar.Location = new System.Drawing.Point(203, 3);
            this.htProgBar.Name = "htProgBar";
            this.htProgBar.Size = new System.Drawing.Size(356, 13);
            this.htProgBar.TabIndex = 8;
            this.htProgBar.TabStop = false;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.statusLabel);
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(200, 19);
            this.panel11.TabIndex = 9;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoEllipsis = true;
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(-3, 3);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(204, 16);
            this.statusLabel.TabIndex = 7;
            this.statusLabel.Text = "Ready. ";
            this.statusLabel.UseMnemonic = false;
            // 
            // htTabControl
            // 
            this.htTabControl.AllowDrop = true;
            this.htTabControl.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.htTabControl.BorderTabLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.htTabControl.Controls.Add(this.previewTab);
            this.htTabControl.Controls.Add(this.batchTab);
            this.htTabControl.Controls.Add(this.videoTab);
            this.htTabControl.DisableClose = true;
            this.htTabControl.DisableDragging = true;
            this.htTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htTabControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.htTabControl.HoverTabButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(176)))), ((int)(((byte)(239)))));
            this.htTabControl.HoverTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(151)))), ((int)(((byte)(234)))));
            this.htTabControl.HoverUnselectedTabButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.htTabControl.Location = new System.Drawing.Point(3, 3);
            this.htTabControl.Name = "htTabControl";
            this.htTabControl.Padding = new System.Drawing.Point(14, 4);
            this.htTabControl.SelectedIndex = 0;
            this.htTabControl.SelectedTabButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(151)))), ((int)(((byte)(234)))));
            this.htTabControl.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.htTabControl.Size = new System.Drawing.Size(562, 844);
            this.htTabControl.TabIndex = 2;
            this.htTabControl.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.htTabControl.UnderBorderTabLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(70)))));
            this.htTabControl.UnselectedBorderTabLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.htTabControl.UnselectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.htTabControl.UpDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.htTabControl.UpDownTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(112)))));
            this.htTabControl.SelectedIndexChanged += new System.EventHandler(this.htTabControl_SelectedIndexChanged);
            // 
            // previewTab
            // 
            this.previewTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.previewTab.Controls.Add(this.previewImg);
            this.previewTab.Location = new System.Drawing.Point(4, 27);
            this.previewTab.Margin = new System.Windows.Forms.Padding(0);
            this.previewTab.Name = "previewTab";
            this.previewTab.Size = new System.Drawing.Size(554, 813);
            this.previewTab.TabIndex = 0;
            this.previewTab.Text = "Preview Image";
            // 
            // previewImg
            // 
            this.previewImg.AllowDrop = true;
            this.previewImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewImg.ForeColor = System.Drawing.Color.White;
            this.previewImg.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.previewImg.GridColorAlternate = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.previewImg.GridScale = Cyotek.Windows.Forms.ImageBoxGridScale.Medium;
            this.previewImg.Location = new System.Drawing.Point(0, 0);
            this.previewImg.Margin = new System.Windows.Forms.Padding(0);
            this.previewImg.Name = "previewImg";
            this.previewImg.Size = new System.Drawing.Size(554, 813);
            this.previewImg.TabIndex = 0;
            this.previewImg.TabStop = false;
            this.previewImg.Text = "Drag And Drop An Image Or A Folder Into This Area.";
            this.previewImg.Zoomed += new System.EventHandler<Cyotek.Windows.Forms.ImageBoxZoomEventArgs>(this.previewImg_Zoomed);
            this.previewImg.Click += new System.EventHandler(this.previewImg_Click);
            this.previewImg.DragDrop += new System.Windows.Forms.DragEventHandler(this.previewImg_DragDrop);
            this.previewImg.DragEnter += new System.Windows.Forms.DragEventHandler(this.previewImg_DragEnter);
            this.previewImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.previewImg_MouseDown);
            this.previewImg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.previewImg_MouseUp);
            // 
            // batchTab
            // 
            this.batchTab.AllowDrop = true;
            this.batchTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.batchTab.Controls.Add(this.tableLayoutPanel7);
            this.batchTab.Location = new System.Drawing.Point(4, 27);
            this.batchTab.Name = "batchTab";
            this.batchTab.Padding = new System.Windows.Forms.Padding(3);
            this.batchTab.Size = new System.Drawing.Size(554, 813);
            this.batchTab.TabIndex = 1;
            this.batchTab.Text = "Upscale Images";
            this.batchTab.DragDrop += new System.Windows.Forms.DragEventHandler(this.batchTab_DragDrop);
            this.batchTab.DragEnter += new System.Windows.Forms.DragEventHandler(this.batchTab_DragEnter);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.batchDirLabel, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.panel8, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(548, 807);
            this.tableLayoutPanel7.TabIndex = 13;
            // 
            // batchDirLabel
            // 
            this.batchDirLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batchDirLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.batchDirLabel.ForeColor = System.Drawing.Color.White;
            this.batchDirLabel.Location = new System.Drawing.Point(3, 0);
            this.batchDirLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 25);
            this.batchDirLabel.Name = "batchDirLabel";
            this.batchDirLabel.Size = new System.Drawing.Size(542, 55);
            this.batchDirLabel.TabIndex = 11;
            this.batchDirLabel.Text = "Drag And Drop Multiple Images Or A Folder Into This Area";
            this.batchDirLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.tableLayoutPanel3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 83);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(542, 721);
            this.panel8.TabIndex = 12;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel9, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel10, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(542, 721);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.tableLayoutPanel9);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(271, 721);
            this.panel9.TabIndex = 0;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.panel12, 0, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(271, 721);
            this.tableLayoutPanel9.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(8, 8);
            this.label7.Margin = new System.Windows.Forms.Padding(8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "Options";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.label24);
            this.panel12.Controls.Add(this.batchCacheSplitDepth);
            this.panel12.Controls.Add(this.tableLayoutPanel10);
            this.panel12.Controls.Add(this.label19);
            this.panel12.Controls.Add(this.preprocessMode);
            this.panel12.Controls.Add(this.label15);
            this.panel12.Controls.Add(this.batchOutMode);
            this.panel12.Controls.Add(this.label13);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 30);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(271, 691);
            this.panel12.TabIndex = 11;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(8, 167);
            this.label24.Margin = new System.Windows.Forms.Padding(8, 8, 8, 2);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(175, 15);
            this.label24.TabIndex = 21;
            this.label24.Text = "Auto-Tiling Mode: (CUDA Only)";
            // 
            // batchCacheSplitDepth
            // 
            this.batchCacheSplitDepth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batchCacheSplitDepth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.batchCacheSplitDepth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.batchCacheSplitDepth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.batchCacheSplitDepth.ForeColor = System.Drawing.Color.White;
            this.batchCacheSplitDepth.FormattingEnabled = true;
            this.batchCacheSplitDepth.Items.AddRange(new object[] {
            "Check Tile Size For Each Image",
            "Cache Tile Size (If all images are the same size)"});
            this.batchCacheSplitDepth.Location = new System.Drawing.Point(8, 186);
            this.batchCacheSplitDepth.Margin = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.batchCacheSplitDepth.Name = "batchCacheSplitDepth";
            this.batchCacheSplitDepth.Size = new System.Drawing.Size(255, 23);
            this.batchCacheSplitDepth.TabIndex = 20;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel10.Controls.Add(this.selectOutPathBtn, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.batchOutDir, 0, 0);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(8, 32);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(255, 23);
            this.tableLayoutPanel10.TabIndex = 19;
            // 
            // selectOutPathBtn
            // 
            this.selectOutPathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectOutPathBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.selectOutPathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectOutPathBtn.ForeColor = System.Drawing.Color.White;
            this.selectOutPathBtn.Location = new System.Drawing.Point(229, 0);
            this.selectOutPathBtn.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.selectOutPathBtn.Name = "selectOutPathBtn";
            this.selectOutPathBtn.Size = new System.Drawing.Size(26, 23);
            this.selectOutPathBtn.TabIndex = 18;
            this.selectOutPathBtn.Text = "...";
            this.selectOutPathBtn.UseVisualStyleBackColor = false;
            this.selectOutPathBtn.Click += new System.EventHandler(this.selectOutPathBtn_Click);
            // 
            // batchOutDir
            // 
            this.batchOutDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batchOutDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.batchOutDir.ForeColor = System.Drawing.Color.White;
            this.batchOutDir.Location = new System.Drawing.Point(0, 0);
            this.batchOutDir.Margin = new System.Windows.Forms.Padding(0);
            this.batchOutDir.Name = "batchOutDir";
            this.batchOutDir.Size = new System.Drawing.Size(225, 23);
            this.batchOutDir.TabIndex = 10;
            this.batchOutDir.Text = "Will get auto-filled once you load a directory.";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(8, 115);
            this.label19.Margin = new System.Windows.Forms.Padding(8, 8, 8, 2);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(89, 15);
            this.label19.TabIndex = 17;
            this.label19.Text = "Pre-Processing:";
            // 
            // preprocessMode
            // 
            this.preprocessMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.preprocessMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.preprocessMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.preprocessMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preprocessMode.ForeColor = System.Drawing.Color.White;
            this.preprocessMode.FormattingEnabled = true;
            this.preprocessMode.Items.AddRange(new object[] {
            "Enabled - Convert, Fill Alpha If Needed, Resize If Enabled",
            "Disabled - Skip Conversion. Make Sure Images Are Compatible!"});
            this.preprocessMode.Location = new System.Drawing.Point(8, 134);
            this.preprocessMode.Margin = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.preprocessMode.Name = "preprocessMode";
            this.preprocessMode.Size = new System.Drawing.Size(255, 23);
            this.preprocessMode.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(8, 63);
            this.label15.Margin = new System.Windows.Forms.Padding(8, 8, 8, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 15);
            this.label15.TabIndex = 15;
            this.label15.Text = "Output Mode:";
            // 
            // batchOutMode
            // 
            this.batchOutMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batchOutMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.batchOutMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.batchOutMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.batchOutMode.ForeColor = System.Drawing.Color.White;
            this.batchOutMode.FormattingEnabled = true;
            this.batchOutMode.Items.AddRange(new object[] {
            "Keep Folder Structure [Currently not supported with NCNN!]",
            "Place All Images In Root Directory"});
            this.batchOutMode.Location = new System.Drawing.Point(8, 82);
            this.batchOutMode.Margin = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.batchOutMode.Name = "batchOutMode";
            this.batchOutMode.Size = new System.Drawing.Size(255, 23);
            this.batchOutMode.TabIndex = 14;
            this.batchOutMode.SelectedIndexChanged += new System.EventHandler(this.batchOutMode_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(8, 7);
            this.label13.Margin = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 15);
            this.label13.TabIndex = 13;
            this.label13.Text = "Output Directory:";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.tableLayoutPanel8);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(271, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(271, 721);
            this.panel10.TabIndex = 1;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.batchFileList, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(271, 721);
            this.tableLayoutPanel8.TabIndex = 12;
            // 
            // batchFileList
            // 
            this.batchFileList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.batchFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.batchFileList.ForeColor = System.Drawing.Color.White;
            this.batchFileList.Location = new System.Drawing.Point(8, 38);
            this.batchFileList.Margin = new System.Windows.Forms.Padding(8);
            this.batchFileList.Multiline = true;
            this.batchFileList.Name = "batchFileList";
            this.batchFileList.ReadOnly = true;
            this.batchFileList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.batchFileList.Size = new System.Drawing.Size(255, 675);
            this.batchFileList.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "File List";
            // 
            // videoTab
            // 
            this.videoTab.AllowDrop = true;
            this.videoTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.videoTab.Controls.Add(this.tableLayoutPanel2);
            this.videoTab.Location = new System.Drawing.Point(4, 27);
            this.videoTab.Name = "videoTab";
            this.videoTab.Padding = new System.Windows.Forms.Padding(3);
            this.videoTab.Size = new System.Drawing.Size(554, 813);
            this.videoTab.TabIndex = 2;
            this.videoTab.Text = "Upscale Videos";
            this.videoTab.DragDrop += new System.Windows.Forms.DragEventHandler(this.videoTab_DragDrop);
            this.videoTab.DragEnter += new System.Windows.Forms.DragEventHandler(this.videoTab_DragEnter);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.videoPathLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel37, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(548, 807);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // videoPathLabel
            // 
            this.videoPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.videoPathLabel.ForeColor = System.Drawing.Color.White;
            this.videoPathLabel.Location = new System.Drawing.Point(3, 0);
            this.videoPathLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 25);
            this.videoPathLabel.Name = "videoPathLabel";
            this.videoPathLabel.Size = new System.Drawing.Size(542, 55);
            this.videoPathLabel.TabIndex = 11;
            this.videoPathLabel.Text = "Drag And Drop GIF/Video Files Here";
            this.videoPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel37
            // 
            this.panel37.Controls.Add(this.tableLayoutPanel6);
            this.panel37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel37.Location = new System.Drawing.Point(3, 83);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(542, 721);
            this.panel37.TabIndex = 12;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.panel38, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.panel40, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(542, 721);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // panel38
            // 
            this.panel38.Controls.Add(this.tableLayoutPanel11);
            this.panel38.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel38.Location = new System.Drawing.Point(0, 0);
            this.panel38.Margin = new System.Windows.Forms.Padding(0);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(271, 721);
            this.panel38.TabIndex = 0;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.videoFileListBox, 0, 3);
            this.tableLayoutPanel11.Controls.Add(this.label31, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.panel39, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.label36, 0, 2);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 4;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 541F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(271, 721);
            this.tableLayoutPanel11.TabIndex = 13;
            // 
            // videoFileListBox
            // 
            this.videoFileListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.videoFileListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoFileListBox.ForeColor = System.Drawing.Color.White;
            this.videoFileListBox.Location = new System.Drawing.Point(8, 188);
            this.videoFileListBox.Margin = new System.Windows.Forms.Padding(8);
            this.videoFileListBox.Multiline = true;
            this.videoFileListBox.Name = "videoFileListBox";
            this.videoFileListBox.ReadOnly = true;
            this.videoFileListBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.videoFileListBox.Size = new System.Drawing.Size(255, 525);
            this.videoFileListBox.TabIndex = 14;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(8, 8);
            this.label31.Margin = new System.Windows.Forms.Padding(8);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(50, 14);
            this.label31.TabIndex = 12;
            this.label31.Text = "Options";
            // 
            // panel39
            // 
            this.panel39.Controls.Add(this.label30);
            this.panel39.Controls.Add(this.videoPreprocessMode);
            this.panel39.Controls.Add(this.tableLayoutPanel12);
            this.panel39.Controls.Add(this.label34);
            this.panel39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel39.Location = new System.Drawing.Point(0, 30);
            this.panel39.Margin = new System.Windows.Forms.Padding(0);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(271, 122);
            this.panel39.TabIndex = 11;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(5, 63);
            this.label30.Margin = new System.Windows.Forms.Padding(8, 8, 8, 2);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(89, 15);
            this.label30.TabIndex = 19;
            this.label30.Text = "Pre-Processing:";
            // 
            // videoPreprocessMode
            // 
            this.videoPreprocessMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoPreprocessMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.videoPreprocessMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoPreprocessMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoPreprocessMode.ForeColor = System.Drawing.Color.White;
            this.videoPreprocessMode.FormattingEnabled = true;
            this.videoPreprocessMode.Items.AddRange(new object[] {
            "Enabled - Fill Alpha If Needed, Resize If Enabled",
            "Disabled - Skip Preprocessing."});
            this.videoPreprocessMode.Location = new System.Drawing.Point(5, 82);
            this.videoPreprocessMode.Margin = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.videoPreprocessMode.Name = "videoPreprocessMode";
            this.videoPreprocessMode.Size = new System.Drawing.Size(255, 23);
            this.videoPreprocessMode.TabIndex = 18;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel12.Controls.Add(this.videoOutPathBtn, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.videoOutDir, 0, 0);
            this.tableLayoutPanel12.Location = new System.Drawing.Point(8, 32);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(255, 23);
            this.tableLayoutPanel12.TabIndex = 19;
            // 
            // videoOutPathBtn
            // 
            this.videoOutPathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoOutPathBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.videoOutPathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoOutPathBtn.ForeColor = System.Drawing.Color.White;
            this.videoOutPathBtn.Location = new System.Drawing.Point(229, 0);
            this.videoOutPathBtn.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.videoOutPathBtn.Name = "videoOutPathBtn";
            this.videoOutPathBtn.Size = new System.Drawing.Size(26, 23);
            this.videoOutPathBtn.TabIndex = 18;
            this.videoOutPathBtn.Text = "...";
            this.videoOutPathBtn.UseVisualStyleBackColor = false;
            this.videoOutPathBtn.Click += new System.EventHandler(this.videoOutPathBtn_Click);
            // 
            // videoOutDir
            // 
            this.videoOutDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoOutDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.videoOutDir.ForeColor = System.Drawing.Color.White;
            this.videoOutDir.Location = new System.Drawing.Point(0, 0);
            this.videoOutDir.Margin = new System.Windows.Forms.Padding(0);
            this.videoOutDir.Name = "videoOutDir";
            this.videoOutDir.Size = new System.Drawing.Size(225, 23);
            this.videoOutDir.TabIndex = 10;
            this.videoOutDir.Text = "Will get auto-filled once you load a file.";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.Color.White;
            this.label34.Location = new System.Drawing.Point(8, 7);
            this.label34.Margin = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(99, 15);
            this.label34.TabIndex = 13;
            this.label34.Text = "Output Directory:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label36.ForeColor = System.Drawing.Color.White;
            this.label36.Location = new System.Drawing.Point(8, 160);
            this.label36.Margin = new System.Windows.Forms.Padding(8);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(48, 12);
            this.label36.TabIndex = 13;
            this.label36.Text = "File List";
            // 
            // panel40
            // 
            this.panel40.Controls.Add(this.tableLayoutPanel13);
            this.panel40.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel40.Location = new System.Drawing.Point(271, 0);
            this.panel40.Margin = new System.Windows.Forms.Padding(0);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(271, 721);
            this.panel40.TabIndex = 1;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 1;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Controls.Add(this.videoLogBox, 0, 1);
            this.tableLayoutPanel13.Controls.Add(this.label35, 0, 0);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 2;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(271, 721);
            this.tableLayoutPanel13.TabIndex = 12;
            // 
            // videoLogBox
            // 
            this.videoLogBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.videoLogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoLogBox.ForeColor = System.Drawing.Color.White;
            this.videoLogBox.Location = new System.Drawing.Point(8, 38);
            this.videoLogBox.Margin = new System.Windows.Forms.Padding(8);
            this.videoLogBox.Multiline = true;
            this.videoLogBox.Name = "videoLogBox";
            this.videoLogBox.ReadOnly = true;
            this.videoLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.videoLogBox.Size = new System.Drawing.Size(255, 675);
            this.videoLogBox.TabIndex = 12;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(8, 8);
            this.label35.Margin = new System.Windows.Forms.Padding(8);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(118, 14);
            this.label35.TabIndex = 11;
            this.label35.Text = "Video Upscaling Log";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(364, 34);
            this.panel6.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(364, 34);
            this.label5.TabIndex = 1;
            this.label5.Text = "Cupscale 1.38.0 - 08/23/21";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.discordBtn);
            this.panel7.Controls.Add(this.patreonBtn);
            this.panel7.Controls.Add(this.offlineInterpBtn);
            this.panel7.Controls.Add(this.htButton1);
            this.panel7.Controls.Add(this.paypalBtn);
            this.panel7.Controls.Add(this.openModelFolderBtn);
            this.panel7.Controls.Add(this.comparisonToolBtn);
            this.panel7.Controls.Add(this.settingsBtn);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(944, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(320, 40);
            this.panel7.TabIndex = 8;
            // 
            // discordBtn
            // 
            this.discordBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.discordBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.discordBtn.ButtonImage = global::Cupscale.Properties.Resources.discordIcoColored;
            this.discordBtn.DrawImage = true;
            this.discordBtn.FlatAppearance.BorderSize = 0;
            this.discordBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.discordBtn.ForeColor = System.Drawing.Color.White;
            this.discordBtn.ImageIndex = 0;
            this.discordBtn.ImageSizeMode = HTAlt.WinForms.HTButton.ButtonImageSizeMode.Stretch;
            this.discordBtn.Location = new System.Drawing.Point(83, 6);
            this.discordBtn.Name = "discordBtn";
            this.discordBtn.Size = new System.Drawing.Size(34, 34);
            this.discordBtn.TabIndex = 16;
            this.discordBtn.Text = " ";
            this.toolTip1.SetToolTip(this.discordBtn, "Chat on Discord");
            this.discordBtn.UseVisualStyleBackColor = false;
            this.discordBtn.Click += new System.EventHandler(this.discordBtn_Click);
            // 
            // patreonBtn
            // 
            this.patreonBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patreonBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.patreonBtn.ButtonImage = global::Cupscale.Properties.Resources.patreon256pxColored;
            this.patreonBtn.DrawImage = true;
            this.patreonBtn.FlatAppearance.BorderSize = 0;
            this.patreonBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.patreonBtn.ForeColor = System.Drawing.Color.White;
            this.patreonBtn.ImageIndex = 0;
            this.patreonBtn.ImageSizeMode = HTAlt.WinForms.HTButton.ButtonImageSizeMode.Stretch;
            this.patreonBtn.Location = new System.Drawing.Point(43, 6);
            this.patreonBtn.Name = "patreonBtn";
            this.patreonBtn.Size = new System.Drawing.Size(34, 34);
            this.patreonBtn.TabIndex = 15;
            this.patreonBtn.Text = " ";
            this.toolTip1.SetToolTip(this.patreonBtn, "Become a Patron");
            this.patreonBtn.UseVisualStyleBackColor = false;
            this.patreonBtn.Click += new System.EventHandler(this.patreonBtn_Click);
            // 
            // offlineInterpBtn
            // 
            this.offlineInterpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.offlineInterpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.offlineInterpBtn.ButtonImage = global::Cupscale.Properties.Resources.interp;
            this.offlineInterpBtn.DrawImage = true;
            this.offlineInterpBtn.FlatAppearance.BorderSize = 0;
            this.offlineInterpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.offlineInterpBtn.ForeColor = System.Drawing.Color.White;
            this.offlineInterpBtn.ImageIndex = 0;
            this.offlineInterpBtn.ImageSizeMode = HTAlt.WinForms.HTButton.ButtonImageSizeMode.Stretch;
            this.offlineInterpBtn.Location = new System.Drawing.Point(163, 6);
            this.offlineInterpBtn.Name = "offlineInterpBtn";
            this.offlineInterpBtn.Size = new System.Drawing.Size(34, 34);
            this.offlineInterpBtn.TabIndex = 14;
            this.offlineInterpBtn.Text = " ";
            this.toolTip1.SetToolTip(this.offlineInterpBtn, "Create Interpolated Model");
            this.offlineInterpBtn.UseVisualStyleBackColor = false;
            this.offlineInterpBtn.Click += new System.EventHandler(this.offlineInterpBtn_Click);
            // 
            // htButton1
            // 
            this.htButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.htButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.htButton1.ButtonImage = global::Cupscale.Properties.Resources.baseline_fact_check_white_48dp;
            this.htButton1.DrawImage = true;
            this.htButton1.FlatAppearance.BorderSize = 0;
            this.htButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.htButton1.ForeColor = System.Drawing.Color.White;
            this.htButton1.ImageIndex = 0;
            this.htButton1.ImageSizeMode = HTAlt.WinForms.HTButton.ButtonImageSizeMode.Stretch;
            this.htButton1.Location = new System.Drawing.Point(243, 6);
            this.htButton1.Name = "htButton1";
            this.htButton1.Size = new System.Drawing.Size(34, 34);
            this.htButton1.TabIndex = 13;
            this.htButton1.Text = " ";
            this.toolTip1.SetToolTip(this.htButton1, "Dependency Checker");
            this.htButton1.UseVisualStyleBackColor = false;
            this.htButton1.Click += new System.EventHandler(this.htButton1_Click);
            // 
            // paypalBtn
            // 
            this.paypalBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paypalBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.paypalBtn.ButtonImage = global::Cupscale.Properties.Resources.paypal256px;
            this.paypalBtn.DrawImage = true;
            this.paypalBtn.FlatAppearance.BorderSize = 0;
            this.paypalBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paypalBtn.ForeColor = System.Drawing.Color.White;
            this.paypalBtn.ImageIndex = 0;
            this.paypalBtn.ImageSizeMode = HTAlt.WinForms.HTButton.ButtonImageSizeMode.Stretch;
            this.paypalBtn.Location = new System.Drawing.Point(3, 6);
            this.paypalBtn.Name = "paypalBtn";
            this.paypalBtn.Size = new System.Drawing.Size(34, 34);
            this.paypalBtn.TabIndex = 12;
            this.paypalBtn.Text = " ";
            this.toolTip1.SetToolTip(this.paypalBtn, "Donate via PayPal");
            this.paypalBtn.UseVisualStyleBackColor = false;
            this.paypalBtn.Click += new System.EventHandler(this.paypalBtn_Click);
            // 
            // openModelFolderBtn
            // 
            this.openModelFolderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openModelFolderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.openModelFolderBtn.ButtonImage = global::Cupscale.Properties.Resources.baseline_folder_open_white_48dp;
            this.openModelFolderBtn.DrawImage = true;
            this.openModelFolderBtn.FlatAppearance.BorderSize = 0;
            this.openModelFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openModelFolderBtn.ForeColor = System.Drawing.Color.White;
            this.openModelFolderBtn.ImageIndex = 0;
            this.openModelFolderBtn.ImageSizeMode = HTAlt.WinForms.HTButton.ButtonImageSizeMode.Stretch;
            this.openModelFolderBtn.Location = new System.Drawing.Point(203, 6);
            this.openModelFolderBtn.Name = "openModelFolderBtn";
            this.openModelFolderBtn.Size = new System.Drawing.Size(34, 34);
            this.openModelFolderBtn.TabIndex = 11;
            this.openModelFolderBtn.Text = " ";
            this.toolTip1.SetToolTip(this.openModelFolderBtn, "Open Models Folder");
            this.openModelFolderBtn.UseVisualStyleBackColor = false;
            this.openModelFolderBtn.Click += new System.EventHandler(this.openModelFolderBtn_Click);
            // 
            // comparisonToolBtn
            // 
            this.comparisonToolBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comparisonToolBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comparisonToolBtn.ButtonImage = global::Cupscale.Properties.Resources.modelCompare;
            this.comparisonToolBtn.DrawImage = true;
            this.comparisonToolBtn.FlatAppearance.BorderSize = 0;
            this.comparisonToolBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comparisonToolBtn.ForeColor = System.Drawing.Color.White;
            this.comparisonToolBtn.ImageIndex = 0;
            this.comparisonToolBtn.ImageSizeMode = HTAlt.WinForms.HTButton.ButtonImageSizeMode.Stretch;
            this.comparisonToolBtn.Location = new System.Drawing.Point(123, 6);
            this.comparisonToolBtn.Name = "comparisonToolBtn";
            this.comparisonToolBtn.Size = new System.Drawing.Size(34, 34);
            this.comparisonToolBtn.TabIndex = 10;
            this.comparisonToolBtn.Text = " ";
            this.toolTip1.SetToolTip(this.comparisonToolBtn, "Model Comparison Tool");
            this.comparisonToolBtn.UseVisualStyleBackColor = false;
            this.comparisonToolBtn.Click += new System.EventHandler(this.comparisonToolBtn_Click);
            // 
            // settingsBtn
            // 
            this.settingsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.settingsBtn.ButtonImage = global::Cupscale.Properties.Resources.baseline_settings_white_48dp;
            this.settingsBtn.DrawImage = true;
            this.settingsBtn.FlatAppearance.BorderSize = 0;
            this.settingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsBtn.ForeColor = System.Drawing.Color.White;
            this.settingsBtn.ImageIndex = 0;
            this.settingsBtn.ImageSizeMode = HTAlt.WinForms.HTButton.ButtonImageSizeMode.Stretch;
            this.settingsBtn.Location = new System.Drawing.Point(283, 6);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(34, 34);
            this.settingsBtn.TabIndex = 9;
            this.settingsBtn.Text = " ";
            this.toolTip1.SetToolTip(this.settingsBtn, "Settings");
            this.settingsBtn.UseVisualStyleBackColor = false;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.vramLabel);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(370, 0);
            this.panel15.Margin = new System.Windows.Forms.Padding(0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(574, 40);
            this.panel15.TabIndex = 9;
            // 
            // vramLabel
            // 
            this.vramLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vramLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vramLabel.ForeColor = System.Drawing.Color.White;
            this.vramLabel.Location = new System.Drawing.Point(0, 0);
            this.vramLabel.Name = "vramLabel";
            this.vramLabel.Size = new System.Drawing.Size(574, 40);
            this.vramLabel.TabIndex = 2;
            this.vramLabel.Text = " ";
            this.vramLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowPanelRight
            // 
            this.flowPanelRight.AutoScroll = true;
            this.flowPanelRight.Controls.Add(this.upscalePanel);
            this.flowPanelRight.Controls.Add(this.rSpacer1);
            this.flowPanelRight.Controls.Add(this.savePanel);
            this.flowPanelRight.Controls.Add(this.rSpacer2);
            this.flowPanelRight.Controls.Add(this.postResizePanel);
            this.flowPanelRight.Controls.Add(this.rSpacer3);
            this.flowPanelRight.Controls.Add(this.preResizePanel);
            this.flowPanelRight.Controls.Add(this.rSpacer4);
            this.flowPanelRight.Controls.Add(this.imgOptsPanel);
            this.flowPanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelRight.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowPanelRight.Location = new System.Drawing.Point(944, 43);
            this.flowPanelRight.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.flowPanelRight.Name = "flowPanelRight";
            this.flowPanelRight.Size = new System.Drawing.Size(317, 875);
            this.flowPanelRight.TabIndex = 10;
            this.flowPanelRight.WrapContents = false;
            // 
            // upscalePanel
            // 
            this.upscalePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.upscalePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.upscalePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.upscalePanel.Controls.Add(this.cancelBtn);
            this.upscalePanel.Controls.Add(this.saveMergedPreviewBtn);
            this.upscalePanel.Controls.Add(this.label20);
            this.upscalePanel.Controls.Add(this.openOutFolderBtn);
            this.upscalePanel.Controls.Add(this.upscaleBtn);
            this.upscalePanel.Location = new System.Drawing.Point(3, 737);
            this.upscalePanel.Name = "upscalePanel";
            this.upscalePanel.Size = new System.Drawing.Size(310, 135);
            this.upscalePanel.TabIndex = 0;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.ForeColor = System.Drawing.Color.Tomato;
            this.cancelBtn.Location = new System.Drawing.Point(6, 96);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(297, 30);
            this.cancelBtn.TabIndex = 13;
            this.cancelBtn.Text = "Cancel Upscale";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Visible = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveMergedPreviewBtn
            // 
            this.saveMergedPreviewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveMergedPreviewBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.saveMergedPreviewBtn.Enabled = false;
            this.saveMergedPreviewBtn.FlatAppearance.BorderSize = 0;
            this.saveMergedPreviewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveMergedPreviewBtn.ForeColor = System.Drawing.Color.White;
            this.saveMergedPreviewBtn.Location = new System.Drawing.Point(6, 60);
            this.saveMergedPreviewBtn.Name = "saveMergedPreviewBtn";
            this.saveMergedPreviewBtn.Size = new System.Drawing.Size(297, 30);
            this.saveMergedPreviewBtn.TabIndex = 12;
            this.saveMergedPreviewBtn.Text = "Save Current Merged Preview";
            this.saveMergedPreviewBtn.UseVisualStyleBackColor = false;
            this.saveMergedPreviewBtn.Click += new System.EventHandler(this.saveMergedPreviewBtn_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(3, 4);
            this.label20.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "Upscale/Save";
            // 
            // openOutFolderBtn
            // 
            this.openOutFolderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openOutFolderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.openOutFolderBtn.Enabled = false;
            this.openOutFolderBtn.FlatAppearance.BorderSize = 0;
            this.openOutFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openOutFolderBtn.ForeColor = System.Drawing.Color.White;
            this.openOutFolderBtn.Location = new System.Drawing.Point(6, 24);
            this.openOutFolderBtn.Name = "openOutFolderBtn";
            this.openOutFolderBtn.Size = new System.Drawing.Size(297, 30);
            this.openOutFolderBtn.TabIndex = 11;
            this.openOutFolderBtn.Text = "Open Folder Of Last Upscale";
            this.openOutFolderBtn.UseVisualStyleBackColor = false;
            this.openOutFolderBtn.Click += new System.EventHandler(this.openOutFolderBtn_Click);
            // 
            // upscaleBtn
            // 
            this.upscaleBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.upscaleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.upscaleBtn.FlatAppearance.BorderSize = 0;
            this.upscaleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upscaleBtn.ForeColor = System.Drawing.Color.White;
            this.upscaleBtn.Location = new System.Drawing.Point(6, 96);
            this.upscaleBtn.Name = "upscaleBtn";
            this.upscaleBtn.Size = new System.Drawing.Size(297, 30);
            this.upscaleBtn.TabIndex = 8;
            this.upscaleBtn.Text = "Upscale And Save";
            this.upscaleBtn.UseVisualStyleBackColor = false;
            this.upscaleBtn.Click += new System.EventHandler(this.upscaleBtn_Click);
            // 
            // rSpacer1
            // 
            this.rSpacer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rSpacer1.BackColor = System.Drawing.Color.Transparent;
            this.rSpacer1.Controls.Add(this.panel28);
            this.rSpacer1.Location = new System.Drawing.Point(8, 714);
            this.rSpacer1.Name = "rSpacer1";
            this.rSpacer1.Size = new System.Drawing.Size(305, 17);
            this.rSpacer1.TabIndex = 8;
            // 
            // panel28
            // 
            this.panel28.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel28.Location = new System.Drawing.Point(5, 5);
            this.panel28.Margin = new System.Windows.Forms.Padding(5);
            this.panel28.Name = "panel28";
            this.panel28.Padding = new System.Windows.Forms.Padding(10);
            this.panel28.Size = new System.Drawing.Size(294, 7);
            this.panel28.TabIndex = 0;
            // 
            // savePanel
            // 
            this.savePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.savePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.savePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.savePanel.Controls.Add(this.videoOutputFormat);
            this.savePanel.Controls.Add(this.label10);
            this.savePanel.Controls.Add(this.label23);
            this.savePanel.Controls.Add(this.prevOverwriteCombox);
            this.savePanel.Controls.Add(this.imageOutputFormat);
            this.savePanel.Controls.Add(this.label11);
            this.savePanel.Location = new System.Drawing.Point(3, 585);
            this.savePanel.Name = "savePanel";
            this.savePanel.Size = new System.Drawing.Size(310, 123);
            this.savePanel.TabIndex = 2;
            // 
            // videoOutputFormat
            // 
            this.videoOutputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoOutputFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.videoOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoOutputFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoOutputFormat.ForeColor = System.Drawing.Color.White;
            this.videoOutputFormat.FormattingEnabled = true;
            this.videoOutputFormat.Location = new System.Drawing.Point(5, 94);
            this.videoOutputFormat.Margin = new System.Windows.Forms.Padding(8);
            this.videoOutputFormat.Name = "videoOutputFormat";
            this.videoOutputFormat.Size = new System.Drawing.Size(298, 21);
            this.videoOutputFormat.TabIndex = 6;
            this.videoOutputFormat.Visible = false;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(5, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Overwrite Mode";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(3, 4);
            this.label23.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(79, 13);
            this.label23.TabIndex = 2;
            this.label23.Text = "Saving Options";
            // 
            // prevOverwriteCombox
            // 
            this.prevOverwriteCombox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prevOverwriteCombox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.prevOverwriteCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.prevOverwriteCombox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevOverwriteCombox.ForeColor = System.Drawing.Color.White;
            this.prevOverwriteCombox.FormattingEnabled = true;
            this.prevOverwriteCombox.Items.AddRange(new object[] {
            "No - Add Suffix To Upscaled Images",
            "Yes - Don\'t Add Suffix, Overwrite If Extension Matches"});
            this.prevOverwriteCombox.Location = new System.Drawing.Point(5, 44);
            this.prevOverwriteCombox.Margin = new System.Windows.Forms.Padding(8);
            this.prevOverwriteCombox.Name = "prevOverwriteCombox";
            this.prevOverwriteCombox.Size = new System.Drawing.Size(298, 21);
            this.prevOverwriteCombox.TabIndex = 2;
            this.prevOverwriteCombox.SelectedIndexChanged += new System.EventHandler(this.prevOverwriteCombox_SelectedIndexChanged);
            // 
            // imageOutputFormat
            // 
            this.imageOutputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageOutputFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.imageOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageOutputFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageOutputFormat.ForeColor = System.Drawing.Color.White;
            this.imageOutputFormat.FormattingEnabled = true;
            this.imageOutputFormat.Items.AddRange(new object[] {
            "PNG",
            "Same As Input",
            "JPEG - High",
            "JPEG - Medium",
            "WEBP - High",
            "WEBP - Medium"});
            this.imageOutputFormat.Location = new System.Drawing.Point(5, 94);
            this.imageOutputFormat.Margin = new System.Windows.Forms.Padding(8);
            this.imageOutputFormat.Name = "imageOutputFormat";
            this.imageOutputFormat.Size = new System.Drawing.Size(298, 21);
            this.imageOutputFormat.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Output Format";
            // 
            // rSpacer2
            // 
            this.rSpacer2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rSpacer2.BackColor = System.Drawing.Color.Transparent;
            this.rSpacer2.Controls.Add(this.panel26);
            this.rSpacer2.Location = new System.Drawing.Point(8, 562);
            this.rSpacer2.Name = "rSpacer2";
            this.rSpacer2.Size = new System.Drawing.Size(305, 17);
            this.rSpacer2.TabIndex = 7;
            // 
            // panel26
            // 
            this.panel26.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel26.Location = new System.Drawing.Point(5, 5);
            this.panel26.Margin = new System.Windows.Forms.Padding(5);
            this.panel26.Name = "panel26";
            this.panel26.Padding = new System.Windows.Forms.Padding(10);
            this.panel26.Size = new System.Drawing.Size(294, 7);
            this.panel26.TabIndex = 0;
            // 
            // postResizePanel
            // 
            this.postResizePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.postResizePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.postResizePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.postResizePanel.Controls.Add(this.postResizeOnlyDownscale);
            this.postResizePanel.Controls.Add(this.postResizeMode);
            this.postResizePanel.Controls.Add(this.label22);
            this.postResizePanel.Controls.Add(this.label8);
            this.postResizePanel.Controls.Add(this.postResizeFilter);
            this.postResizePanel.Controls.Add(this.postResizeScale);
            this.postResizePanel.Controls.Add(this.label9);
            this.postResizePanel.Location = new System.Drawing.Point(3, 408);
            this.postResizePanel.Name = "postResizePanel";
            this.postResizePanel.Size = new System.Drawing.Size(310, 148);
            this.postResizePanel.TabIndex = 1;
            // 
            // postResizeOnlyDownscale
            // 
            this.postResizeOnlyDownscale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.postResizeOnlyDownscale.AutoSize = true;
            this.postResizeOnlyDownscale.Checked = true;
            this.postResizeOnlyDownscale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.postResizeOnlyDownscale.Enabled = false;
            this.postResizeOnlyDownscale.ForeColor = System.Drawing.Color.White;
            this.postResizeOnlyDownscale.Location = new System.Drawing.Point(6, 124);
            this.postResizeOnlyDownscale.Name = "postResizeOnlyDownscale";
            this.postResizeOnlyDownscale.Size = new System.Drawing.Size(239, 17);
            this.postResizeOnlyDownscale.TabIndex = 7;
            this.postResizeOnlyDownscale.Text = "Only Downscale (Ignore if smaller than target)";
            this.postResizeOnlyDownscale.UseVisualStyleBackColor = true;
            // 
            // postResizeMode
            // 
            this.postResizeMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.postResizeMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.postResizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.postResizeMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.postResizeMode.ForeColor = System.Drawing.Color.White;
            this.postResizeMode.FormattingEnabled = true;
            this.postResizeMode.Items.AddRange(new object[] {
            "Percent",
            "Pixels Height",
            "Pixels Width",
            "Pixels Longer Side",
            "Pixels Shorter Side"});
            this.postResizeMode.Location = new System.Drawing.Point(124, 44);
            this.postResizeMode.Margin = new System.Windows.Forms.Padding(8);
            this.postResizeMode.Name = "postResizeMode";
            this.postResizeMode.Size = new System.Drawing.Size(179, 21);
            this.postResizeMode.TabIndex = 6;
            this.postResizeMode.SelectedIndexChanged += new System.EventHandler(this.postResizeMode_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(3, 4);
            this.label22.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(114, 13);
            this.label22.TabIndex = 2;
            this.label22.Text = "Resize After Upscaling";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "New Size";
            // 
            // postResizeFilter
            // 
            this.postResizeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.postResizeFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.postResizeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.postResizeFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.postResizeFilter.ForeColor = System.Drawing.Color.White;
            this.postResizeFilter.FormattingEnabled = true;
            this.postResizeFilter.Items.AddRange(new object[] {
            "Mitchell",
            "Nearest Neighbor",
            "Bicubic"});
            this.postResizeFilter.Location = new System.Drawing.Point(5, 94);
            this.postResizeFilter.Margin = new System.Windows.Forms.Padding(8);
            this.postResizeFilter.Name = "postResizeFilter";
            this.postResizeFilter.Size = new System.Drawing.Size(298, 21);
            this.postResizeFilter.TabIndex = 4;
            // 
            // postResizeScale
            // 
            this.postResizeScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.postResizeScale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.postResizeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.postResizeScale.ForeColor = System.Drawing.Color.White;
            this.postResizeScale.FormattingEnabled = true;
            this.postResizeScale.Items.AddRange(new object[] {
            "200",
            "100",
            "50",
            "25"});
            this.postResizeScale.Location = new System.Drawing.Point(5, 44);
            this.postResizeScale.Margin = new System.Windows.Forms.Padding(8);
            this.postResizeScale.Name = "postResizeScale";
            this.postResizeScale.Size = new System.Drawing.Size(103, 21);
            this.postResizeScale.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Scaling Filter";
            // 
            // rSpacer3
            // 
            this.rSpacer3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rSpacer3.BackColor = System.Drawing.Color.Transparent;
            this.rSpacer3.Controls.Add(this.panel24);
            this.rSpacer3.Location = new System.Drawing.Point(8, 385);
            this.rSpacer3.Name = "rSpacer3";
            this.rSpacer3.Size = new System.Drawing.Size(305, 17);
            this.rSpacer3.TabIndex = 6;
            // 
            // panel24
            // 
            this.panel24.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel24.Location = new System.Drawing.Point(5, 5);
            this.panel24.Margin = new System.Windows.Forms.Padding(5);
            this.panel24.Name = "panel24";
            this.panel24.Padding = new System.Windows.Forms.Padding(10);
            this.panel24.Size = new System.Drawing.Size(294, 7);
            this.panel24.TabIndex = 0;
            // 
            // preResizePanel
            // 
            this.preResizePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.preResizePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.preResizePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.preResizePanel.Controls.Add(this.preResizeOnlyDownscale);
            this.preResizePanel.Controls.Add(this.preResizeMode);
            this.preResizePanel.Controls.Add(this.label28);
            this.preResizePanel.Controls.Add(this.label17);
            this.preResizePanel.Controls.Add(this.preResizeFilter);
            this.preResizePanel.Controls.Add(this.preResizeScale);
            this.preResizePanel.Controls.Add(this.label18);
            this.preResizePanel.Location = new System.Drawing.Point(3, 231);
            this.preResizePanel.Name = "preResizePanel";
            this.preResizePanel.Size = new System.Drawing.Size(310, 148);
            this.preResizePanel.TabIndex = 3;
            // 
            // preResizeOnlyDownscale
            // 
            this.preResizeOnlyDownscale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.preResizeOnlyDownscale.AutoSize = true;
            this.preResizeOnlyDownscale.Checked = true;
            this.preResizeOnlyDownscale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.preResizeOnlyDownscale.Enabled = false;
            this.preResizeOnlyDownscale.ForeColor = System.Drawing.Color.White;
            this.preResizeOnlyDownscale.Location = new System.Drawing.Point(6, 124);
            this.preResizeOnlyDownscale.Name = "preResizeOnlyDownscale";
            this.preResizeOnlyDownscale.Size = new System.Drawing.Size(239, 17);
            this.preResizeOnlyDownscale.TabIndex = 7;
            this.preResizeOnlyDownscale.Text = "Only Downscale (Ignore if smaller than target)";
            this.preResizeOnlyDownscale.UseVisualStyleBackColor = true;
            // 
            // preResizeMode
            // 
            this.preResizeMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.preResizeMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.preResizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.preResizeMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preResizeMode.ForeColor = System.Drawing.Color.White;
            this.preResizeMode.FormattingEnabled = true;
            this.preResizeMode.Items.AddRange(new object[] {
            "Percent",
            "Pixels Height",
            "Pixels Width",
            "Pixels Longer Side",
            "Pixels Shorter Side"});
            this.preResizeMode.Location = new System.Drawing.Point(124, 44);
            this.preResizeMode.Margin = new System.Windows.Forms.Padding(8);
            this.preResizeMode.Name = "preResizeMode";
            this.preResizeMode.Size = new System.Drawing.Size(179, 21);
            this.preResizeMode.TabIndex = 6;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(3, 4);
            this.label28.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(123, 13);
            this.label28.TabIndex = 2;
            this.label28.Text = "Resize Before Upscaling";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(5, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "New Size";
            // 
            // preResizeFilter
            // 
            this.preResizeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.preResizeFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.preResizeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.preResizeFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preResizeFilter.ForeColor = System.Drawing.Color.White;
            this.preResizeFilter.FormattingEnabled = true;
            this.preResizeFilter.Items.AddRange(new object[] {
            "Mitchell",
            "Lanczos",
            "Bicubic",
            "Nearest Neighbor"});
            this.preResizeFilter.Location = new System.Drawing.Point(5, 94);
            this.preResizeFilter.Margin = new System.Windows.Forms.Padding(8);
            this.preResizeFilter.Name = "preResizeFilter";
            this.preResizeFilter.Size = new System.Drawing.Size(298, 21);
            this.preResizeFilter.TabIndex = 4;
            // 
            // preResizeScale
            // 
            this.preResizeScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.preResizeScale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.preResizeScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preResizeScale.ForeColor = System.Drawing.Color.White;
            this.preResizeScale.FormattingEnabled = true;
            this.preResizeScale.Items.AddRange(new object[] {
            "200",
            "100",
            "50",
            "25"});
            this.preResizeScale.Location = new System.Drawing.Point(5, 44);
            this.preResizeScale.Margin = new System.Windows.Forms.Padding(8);
            this.preResizeScale.Name = "preResizeScale";
            this.preResizeScale.Size = new System.Drawing.Size(103, 21);
            this.preResizeScale.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(5, 73);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "Scaling Filter";
            // 
            // rSpacer4
            // 
            this.rSpacer4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rSpacer4.BackColor = System.Drawing.Color.Transparent;
            this.rSpacer4.Controls.Add(this.panel16);
            this.rSpacer4.Location = new System.Drawing.Point(8, 208);
            this.rSpacer4.Name = "rSpacer4";
            this.rSpacer4.Size = new System.Drawing.Size(305, 17);
            this.rSpacer4.TabIndex = 5;
            // 
            // panel16
            // 
            this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel16.Location = new System.Drawing.Point(5, 5);
            this.panel16.Margin = new System.Windows.Forms.Padding(5);
            this.panel16.Name = "panel16";
            this.panel16.Padding = new System.Windows.Forms.Padding(10);
            this.panel16.Size = new System.Drawing.Size(294, 7);
            this.panel16.TabIndex = 0;
            // 
            // imgOptsPanel
            // 
            this.imgOptsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgOptsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.imgOptsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgOptsPanel.Controls.Add(this.label25);
            this.imgOptsPanel.Controls.Add(this.openSourceFolderBtn);
            this.imgOptsPanel.Controls.Add(this.reloadImgBtn);
            this.imgOptsPanel.Location = new System.Drawing.Point(3, 105);
            this.imgOptsPanel.Name = "imgOptsPanel";
            this.imgOptsPanel.Size = new System.Drawing.Size(310, 97);
            this.imgOptsPanel.TabIndex = 4;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(3, 4);
            this.label25.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(114, 13);
            this.label25.TabIndex = 2;
            this.label25.Text = "Loaded Image Options";
            // 
            // openSourceFolderBtn
            // 
            this.openSourceFolderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openSourceFolderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.openSourceFolderBtn.Enabled = false;
            this.openSourceFolderBtn.FlatAppearance.BorderSize = 0;
            this.openSourceFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openSourceFolderBtn.ForeColor = System.Drawing.Color.White;
            this.openSourceFolderBtn.Location = new System.Drawing.Point(4, 26);
            this.openSourceFolderBtn.Name = "openSourceFolderBtn";
            this.openSourceFolderBtn.Size = new System.Drawing.Size(300, 30);
            this.openSourceFolderBtn.TabIndex = 11;
            this.openSourceFolderBtn.Text = "Open Folder Containing Source File";
            this.openSourceFolderBtn.UseVisualStyleBackColor = false;
            this.openSourceFolderBtn.Click += new System.EventHandler(this.openSourceFolderBtn_Click);
            // 
            // reloadImgBtn
            // 
            this.reloadImgBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reloadImgBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.reloadImgBtn.Enabled = false;
            this.reloadImgBtn.FlatAppearance.BorderSize = 0;
            this.reloadImgBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reloadImgBtn.ForeColor = System.Drawing.Color.White;
            this.reloadImgBtn.Location = new System.Drawing.Point(4, 62);
            this.reloadImgBtn.Name = "reloadImgBtn";
            this.reloadImgBtn.Size = new System.Drawing.Size(300, 30);
            this.reloadImgBtn.TabIndex = 8;
            this.reloadImgBtn.Text = "Reload Image From Source File";
            this.reloadImgBtn.UseVisualStyleBackColor = false;
            this.reloadImgBtn.Click += new System.EventHandler(this.reloadImgBtn_Click);
            // 
            // flowPanelLeft
            // 
            this.flowPanelLeft.Controls.Add(this.prevCtrlPanel);
            this.flowPanelLeft.Controls.Add(this.leftSpacer1);
            this.flowPanelLeft.Controls.Add(this.prevInfoPanel);
            this.flowPanelLeft.Controls.Add(this.leftSpacer2);
            this.flowPanelLeft.Controls.Add(this.compPanel);
            this.flowPanelLeft.Controls.Add(this.leftSpacer3);
            this.flowPanelLeft.Controls.Add(this.esrganPanel);
            this.flowPanelLeft.Controls.Add(this.leftSpacer4);
            this.flowPanelLeft.Controls.Add(this.mdlPanel);
            this.flowPanelLeft.Controls.Add(this.leftSpacer5);
            this.flowPanelLeft.Controls.Add(this.aiPanel);
            this.flowPanelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelLeft.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowPanelLeft.Location = new System.Drawing.Point(3, 43);
            this.flowPanelLeft.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.flowPanelLeft.Name = "flowPanelLeft";
            this.flowPanelLeft.Size = new System.Drawing.Size(367, 875);
            this.flowPanelLeft.TabIndex = 11;
            this.flowPanelLeft.WrapContents = false;
            // 
            // prevCtrlPanel
            // 
            this.prevCtrlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.prevCtrlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prevCtrlPanel.Controls.Add(this.prevToggleFilterBtn);
            this.prevCtrlPanel.Controls.Add(this.refreshPreviewCutoutBtn);
            this.prevCtrlPanel.Controls.Add(this.label21);
            this.prevCtrlPanel.Controls.Add(this.refreshPreviewFullBtn);
            this.prevCtrlPanel.Location = new System.Drawing.Point(3, 773);
            this.prevCtrlPanel.Name = "prevCtrlPanel";
            this.prevCtrlPanel.Size = new System.Drawing.Size(361, 99);
            this.prevCtrlPanel.TabIndex = 3;
            // 
            // prevToggleFilterBtn
            // 
            this.prevToggleFilterBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prevToggleFilterBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.prevToggleFilterBtn.FlatAppearance.BorderSize = 0;
            this.prevToggleFilterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevToggleFilterBtn.ForeColor = System.Drawing.Color.White;
            this.prevToggleFilterBtn.Location = new System.Drawing.Point(5, 26);
            this.prevToggleFilterBtn.Name = "prevToggleFilterBtn";
            this.prevToggleFilterBtn.Size = new System.Drawing.Size(351, 30);
            this.prevToggleFilterBtn.TabIndex = 9;
            this.prevToggleFilterBtn.Text = "Switch To Bicubic Filtering";
            this.prevToggleFilterBtn.UseVisualStyleBackColor = false;
            this.prevToggleFilterBtn.Click += new System.EventHandler(this.prevToggleFilterBtn_Click);
            // 
            // refreshPreviewCutoutBtn
            // 
            this.refreshPreviewCutoutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshPreviewCutoutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.refreshPreviewCutoutBtn.Enabled = false;
            this.refreshPreviewCutoutBtn.FlatAppearance.BorderSize = 0;
            this.refreshPreviewCutoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshPreviewCutoutBtn.ForeColor = System.Drawing.Color.White;
            this.refreshPreviewCutoutBtn.Location = new System.Drawing.Point(185, 62);
            this.refreshPreviewCutoutBtn.Name = "refreshPreviewCutoutBtn";
            this.refreshPreviewCutoutBtn.Size = new System.Drawing.Size(171, 30);
            this.refreshPreviewCutoutBtn.TabIndex = 11;
            this.refreshPreviewCutoutBtn.Text = "Refresh Preview (Cutout)";
            this.refreshPreviewCutoutBtn.UseVisualStyleBackColor = false;
            this.refreshPreviewCutoutBtn.Click += new System.EventHandler(this.refreshPreviewCutoutBtn_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(3, 4);
            this.label21.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(86, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "Preview Controls";
            // 
            // refreshPreviewFullBtn
            // 
            this.refreshPreviewFullBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshPreviewFullBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.refreshPreviewFullBtn.Enabled = false;
            this.refreshPreviewFullBtn.FlatAppearance.BorderSize = 0;
            this.refreshPreviewFullBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshPreviewFullBtn.ForeColor = System.Drawing.Color.White;
            this.refreshPreviewFullBtn.Location = new System.Drawing.Point(5, 62);
            this.refreshPreviewFullBtn.Name = "refreshPreviewFullBtn";
            this.refreshPreviewFullBtn.Size = new System.Drawing.Size(171, 30);
            this.refreshPreviewFullBtn.TabIndex = 10;
            this.refreshPreviewFullBtn.Text = "Refresh Preview (Full Image)";
            this.refreshPreviewFullBtn.UseVisualStyleBackColor = false;
            this.refreshPreviewFullBtn.Click += new System.EventHandler(this.refreshPreviewFullBtn_Click);
            // 
            // leftSpacer1
            // 
            this.leftSpacer1.BackColor = System.Drawing.Color.Transparent;
            this.leftSpacer1.Controls.Add(this.panel30);
            this.leftSpacer1.Location = new System.Drawing.Point(3, 750);
            this.leftSpacer1.Name = "leftSpacer1";
            this.leftSpacer1.Size = new System.Drawing.Size(361, 17);
            this.leftSpacer1.TabIndex = 8;
            // 
            // panel30
            // 
            this.panel30.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel30.Location = new System.Drawing.Point(5, 5);
            this.panel30.Margin = new System.Windows.Forms.Padding(5);
            this.panel30.Name = "panel30";
            this.panel30.Padding = new System.Windows.Forms.Padding(10);
            this.panel30.Size = new System.Drawing.Size(350, 7);
            this.panel30.TabIndex = 0;
            // 
            // prevInfoPanel
            // 
            this.prevInfoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.prevInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prevInfoPanel.Controls.Add(this.prevCutoutLabel);
            this.prevInfoPanel.Controls.Add(this.prevSizeLabel);
            this.prevInfoPanel.Controls.Add(this.label26);
            this.prevInfoPanel.Controls.Add(this.prevZoomLabel);
            this.prevInfoPanel.Location = new System.Drawing.Point(3, 667);
            this.prevInfoPanel.Name = "prevInfoPanel";
            this.prevInfoPanel.Size = new System.Drawing.Size(361, 77);
            this.prevInfoPanel.TabIndex = 4;
            // 
            // prevCutoutLabel
            // 
            this.prevCutoutLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prevCutoutLabel.AutoSize = true;
            this.prevCutoutLabel.ForeColor = System.Drawing.Color.White;
            this.prevCutoutLabel.Location = new System.Drawing.Point(5, 55);
            this.prevCutoutLabel.Name = "prevCutoutLabel";
            this.prevCutoutLabel.Size = new System.Drawing.Size(38, 13);
            this.prevCutoutLabel.TabIndex = 8;
            this.prevCutoutLabel.Text = "Cutout";
            // 
            // prevSizeLabel
            // 
            this.prevSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prevSizeLabel.AutoSize = true;
            this.prevSizeLabel.ForeColor = System.Drawing.Color.White;
            this.prevSizeLabel.Location = new System.Drawing.Point(5, 39);
            this.prevSizeLabel.Name = "prevSizeLabel";
            this.prevSizeLabel.Size = new System.Drawing.Size(27, 13);
            this.prevSizeLabel.TabIndex = 7;
            this.prevSizeLabel.Text = "Size";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(3, 4);
            this.label26.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(66, 13);
            this.label26.TabIndex = 2;
            this.label26.Text = "Preview Info";
            // 
            // prevZoomLabel
            // 
            this.prevZoomLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prevZoomLabel.AutoSize = true;
            this.prevZoomLabel.ForeColor = System.Drawing.Color.White;
            this.prevZoomLabel.Location = new System.Drawing.Point(5, 23);
            this.prevZoomLabel.Name = "prevZoomLabel";
            this.prevZoomLabel.Size = new System.Drawing.Size(34, 13);
            this.prevZoomLabel.TabIndex = 6;
            this.prevZoomLabel.Text = "Zoom";
            // 
            // leftSpacer2
            // 
            this.leftSpacer2.BackColor = System.Drawing.Color.Transparent;
            this.leftSpacer2.Controls.Add(this.panel34);
            this.leftSpacer2.Location = new System.Drawing.Point(3, 644);
            this.leftSpacer2.Name = "leftSpacer2";
            this.leftSpacer2.Size = new System.Drawing.Size(361, 17);
            this.leftSpacer2.TabIndex = 10;
            // 
            // panel34
            // 
            this.panel34.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel34.Location = new System.Drawing.Point(5, 5);
            this.panel34.Margin = new System.Windows.Forms.Padding(5);
            this.panel34.Name = "panel34";
            this.panel34.Padding = new System.Windows.Forms.Padding(10);
            this.panel34.Size = new System.Drawing.Size(350, 7);
            this.panel34.TabIndex = 0;
            // 
            // compPanel
            // 
            this.compPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.compPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.compPanel.Controls.Add(this.savePreviewToFileBtn);
            this.compPanel.Controls.Add(this.label27);
            this.compPanel.Controls.Add(this.copyCompToClipboardBtn);
            this.compPanel.Controls.Add(this.label12);
            this.compPanel.Controls.Add(this.prevClipboardTypeCombox);
            this.compPanel.Location = new System.Drawing.Point(3, 551);
            this.compPanel.Name = "compPanel";
            this.compPanel.Size = new System.Drawing.Size(361, 87);
            this.compPanel.TabIndex = 5;
            // 
            // savePreviewToFileBtn
            // 
            this.savePreviewToFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.savePreviewToFileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.savePreviewToFileBtn.Enabled = false;
            this.savePreviewToFileBtn.FlatAppearance.BorderSize = 0;
            this.savePreviewToFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savePreviewToFileBtn.ForeColor = System.Drawing.Color.White;
            this.savePreviewToFileBtn.Location = new System.Drawing.Point(184, 52);
            this.savePreviewToFileBtn.Name = "savePreviewToFileBtn";
            this.savePreviewToFileBtn.Size = new System.Drawing.Size(172, 30);
            this.savePreviewToFileBtn.TabIndex = 13;
            this.savePreviewToFileBtn.Text = "Save To File";
            this.savePreviewToFileBtn.UseVisualStyleBackColor = false;
            this.savePreviewToFileBtn.Click += new System.EventHandler(this.savePreviewToFileBtn_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(3, 4);
            this.label27.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(96, 13);
            this.label27.TabIndex = 2;
            this.label27.Text = "Create Comparison";
            // 
            // copyCompToClipboardBtn
            // 
            this.copyCompToClipboardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.copyCompToClipboardBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.copyCompToClipboardBtn.Enabled = false;
            this.copyCompToClipboardBtn.FlatAppearance.BorderSize = 0;
            this.copyCompToClipboardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyCompToClipboardBtn.ForeColor = System.Drawing.Color.White;
            this.copyCompToClipboardBtn.Location = new System.Drawing.Point(5, 52);
            this.copyCompToClipboardBtn.Name = "copyCompToClipboardBtn";
            this.copyCompToClipboardBtn.Size = new System.Drawing.Size(171, 30);
            this.copyCompToClipboardBtn.TabIndex = 12;
            this.copyCompToClipboardBtn.Text = "Copy To Clipboard";
            this.copyCompToClipboardBtn.UseVisualStyleBackColor = false;
            this.copyCompToClipboardBtn.Click += new System.EventHandler(this.copyCompToClipboardBtn_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(5, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Comparison Type";
            // 
            // prevClipboardTypeCombox
            // 
            this.prevClipboardTypeCombox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prevClipboardTypeCombox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.prevClipboardTypeCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.prevClipboardTypeCombox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevClipboardTypeCombox.ForeColor = System.Drawing.Color.White;
            this.prevClipboardTypeCombox.FormattingEnabled = true;
            this.prevClipboardTypeCombox.Items.AddRange(new object[] {
            "Side By Side",
            "50/50 View",
            "Before/After Animation (GIF)",
            "Before/After Animation (MP4)",
            "Only Result"});
            this.prevClipboardTypeCombox.Location = new System.Drawing.Point(116, 20);
            this.prevClipboardTypeCombox.Margin = new System.Windows.Forms.Padding(8);
            this.prevClipboardTypeCombox.Name = "prevClipboardTypeCombox";
            this.prevClipboardTypeCombox.Size = new System.Drawing.Size(235, 21);
            this.prevClipboardTypeCombox.TabIndex = 5;
            // 
            // leftSpacer3
            // 
            this.leftSpacer3.BackColor = System.Drawing.Color.Transparent;
            this.leftSpacer3.Controls.Add(this.panel32);
            this.leftSpacer3.Location = new System.Drawing.Point(3, 528);
            this.leftSpacer3.Name = "leftSpacer3";
            this.leftSpacer3.Size = new System.Drawing.Size(361, 17);
            this.leftSpacer3.TabIndex = 9;
            // 
            // panel32
            // 
            this.panel32.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel32.Location = new System.Drawing.Point(5, 5);
            this.panel32.Margin = new System.Windows.Forms.Padding(5);
            this.panel32.Name = "panel32";
            this.panel32.Padding = new System.Windows.Forms.Padding(10);
            this.panel32.Size = new System.Drawing.Size(350, 7);
            this.panel32.TabIndex = 0;
            // 
            // esrganPanel
            // 
            this.esrganPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.esrganPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.esrganPanel.Controls.Add(this.pictureBox6);
            this.esrganPanel.Controls.Add(this.seamlessMode);
            this.esrganPanel.Controls.Add(this.label2);
            this.esrganPanel.Controls.Add(this.alpha);
            this.esrganPanel.Controls.Add(this.label3);
            this.esrganPanel.Controls.Add(this.label29);
            this.esrganPanel.Location = new System.Drawing.Point(3, 434);
            this.esrganPanel.Name = "esrganPanel";
            this.esrganPanel.Size = new System.Drawing.Size(361, 88);
            this.esrganPanel.TabIndex = 6;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox6.Image = global::Cupscale.Properties.Resources.questmark;
            this.pictureBox6.Location = new System.Drawing.Point(92, 56);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(22, 22);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 21;
            this.pictureBox6.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox6, resources.GetString("pictureBox6.ToolTip"));
            // 
            // seamlessMode
            // 
            this.seamlessMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seamlessMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.seamlessMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seamlessMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seamlessMode.ForeColor = System.Drawing.Color.White;
            this.seamlessMode.FormattingEnabled = true;
            this.seamlessMode.Items.AddRange(new object[] {
            "Off",
            "Repeat: Tile",
            "Repeat: Mirror",
            "Padding: Extend",
            "Padding: Alpha"});
            this.seamlessMode.Location = new System.Drawing.Point(174, 57);
            this.seamlessMode.Margin = new System.Windows.Forms.Padding(8);
            this.seamlessMode.Name = "seamlessMode";
            this.seamlessMode.Size = new System.Drawing.Size(177, 21);
            this.seamlessMode.TabIndex = 25;
            this.seamlessMode.SelectedIndexChanged += new System.EventHandler(this.seamlessMode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Seamless Mode";
            // 
            // alpha
            // 
            this.alpha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.alpha.AutoSize = true;
            this.alpha.Location = new System.Drawing.Point(174, 32);
            this.alpha.Name = "alpha";
            this.alpha.Size = new System.Drawing.Size(15, 14);
            this.alpha.TabIndex = 23;
            this.alpha.UseVisualStyleBackColor = true;
            this.alpha.CheckedChanged += new System.EventHandler(this.alpha_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Enable Transparency";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(3, 4);
            this.label29.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(146, 13);
            this.label29.TabIndex = 2;
            this.label29.Text = "ESRGAN Processing Options";
            // 
            // leftSpacer4
            // 
            this.leftSpacer4.BackColor = System.Drawing.Color.Transparent;
            this.leftSpacer4.Controls.Add(this.panel36);
            this.leftSpacer4.Location = new System.Drawing.Point(3, 411);
            this.leftSpacer4.Name = "leftSpacer4";
            this.leftSpacer4.Size = new System.Drawing.Size(361, 17);
            this.leftSpacer4.TabIndex = 11;
            // 
            // panel36
            // 
            this.panel36.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel36.Location = new System.Drawing.Point(5, 5);
            this.panel36.Margin = new System.Windows.Forms.Padding(5);
            this.panel36.Name = "panel36";
            this.panel36.Padding = new System.Windows.Forms.Padding(10);
            this.panel36.Size = new System.Drawing.Size(350, 7);
            this.panel36.TabIndex = 0;
            // 
            // mdlPanel
            // 
            this.mdlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mdlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mdlPanel.Controls.Add(this.advancedBtn);
            this.mdlPanel.Controls.Add(this.label1);
            this.mdlPanel.Controls.Add(this.advancedConfigureBtn);
            this.mdlPanel.Controls.Add(this.model2TreeBtn);
            this.mdlPanel.Controls.Add(this.interpConfigureBtn);
            this.mdlPanel.Controls.Add(this.label14);
            this.mdlPanel.Controls.Add(this.label4);
            this.mdlPanel.Controls.Add(this.model1TreeBtn);
            this.mdlPanel.Controls.Add(this.chainRbtn);
            this.mdlPanel.Controls.Add(this.label16);
            this.mdlPanel.Controls.Add(this.interpRbtn);
            this.mdlPanel.Controls.Add(this.singleModelRbtn);
            this.mdlPanel.Location = new System.Drawing.Point(3, 147);
            this.mdlPanel.Name = "mdlPanel";
            this.mdlPanel.Size = new System.Drawing.Size(361, 258);
            this.mdlPanel.TabIndex = 7;
            // 
            // advancedBtn
            // 
            this.advancedBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedBtn.AutoSize = true;
            this.advancedBtn.ForeColor = System.Drawing.Color.White;
            this.advancedBtn.Location = new System.Drawing.Point(15, 109);
            this.advancedBtn.Name = "advancedBtn";
            this.advancedBtn.Size = new System.Drawing.Size(74, 17);
            this.advancedBtn.TabIndex = 20;
            this.advancedBtn.Text = "Advanced";
            this.advancedBtn.UseVisualStyleBackColor = true;
            this.advancedBtn.CheckedChanged += new System.EventHandler(this.advancedBtn_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ESRGAN Model Options";
            // 
            // advancedConfigureBtn
            // 
            this.advancedConfigureBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedConfigureBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.advancedConfigureBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.advancedConfigureBtn.ForeColor = System.Drawing.Color.White;
            this.advancedConfigureBtn.Location = new System.Drawing.Point(202, 108);
            this.advancedConfigureBtn.Name = "advancedConfigureBtn";
            this.advancedConfigureBtn.Size = new System.Drawing.Size(149, 23);
            this.advancedConfigureBtn.TabIndex = 19;
            this.advancedConfigureBtn.Text = "Configure...";
            this.advancedConfigureBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.advancedConfigureBtn.UseVisualStyleBackColor = false;
            this.advancedConfigureBtn.Visible = false;
            this.advancedConfigureBtn.Click += new System.EventHandler(this.advancedConfigureBtn_Click);
            // 
            // model2TreeBtn
            // 
            this.model2TreeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.model2TreeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.model2TreeBtn.Enabled = false;
            this.model2TreeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.model2TreeBtn.ForeColor = System.Drawing.Color.White;
            this.model2TreeBtn.Location = new System.Drawing.Point(8, 225);
            this.model2TreeBtn.Margin = new System.Windows.Forms.Padding(8);
            this.model2TreeBtn.Name = "model2TreeBtn";
            this.model2TreeBtn.Size = new System.Drawing.Size(343, 23);
            this.model2TreeBtn.TabIndex = 18;
            this.model2TreeBtn.Text = "None Selected. Click To Change.";
            this.model2TreeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.model2TreeBtn.UseVisualStyleBackColor = false;
            this.model2TreeBtn.Click += new System.EventHandler(this.model2TreeBtn_Click);
            // 
            // interpConfigureBtn
            // 
            this.interpConfigureBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.interpConfigureBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.interpConfigureBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.interpConfigureBtn.ForeColor = System.Drawing.Color.White;
            this.interpConfigureBtn.Location = new System.Drawing.Point(202, 62);
            this.interpConfigureBtn.Name = "interpConfigureBtn";
            this.interpConfigureBtn.Size = new System.Drawing.Size(149, 23);
            this.interpConfigureBtn.TabIndex = 16;
            this.interpConfigureBtn.Text = "Configure...";
            this.interpConfigureBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.interpConfigureBtn.UseVisualStyleBackColor = false;
            this.interpConfigureBtn.Visible = false;
            this.interpConfigureBtn.Click += new System.EventHandler(this.interpConfigureBtn_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(8, 154);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Model 1:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Model Mode:";
            // 
            // model1TreeBtn
            // 
            this.model1TreeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.model1TreeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.model1TreeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.model1TreeBtn.ForeColor = System.Drawing.Color.White;
            this.model1TreeBtn.Location = new System.Drawing.Point(8, 175);
            this.model1TreeBtn.Margin = new System.Windows.Forms.Padding(8);
            this.model1TreeBtn.Name = "model1TreeBtn";
            this.model1TreeBtn.Size = new System.Drawing.Size(343, 23);
            this.model1TreeBtn.TabIndex = 17;
            this.model1TreeBtn.Text = "None Selected. Click To Change.";
            this.model1TreeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.model1TreeBtn.UseVisualStyleBackColor = false;
            this.model1TreeBtn.Click += new System.EventHandler(this.model1TreeBtn_Click);
            // 
            // chainRbtn
            // 
            this.chainRbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chainRbtn.AutoSize = true;
            this.chainRbtn.ForeColor = System.Drawing.Color.White;
            this.chainRbtn.Location = new System.Drawing.Point(15, 86);
            this.chainRbtn.Name = "chainRbtn";
            this.chainRbtn.Size = new System.Drawing.Size(113, 17);
            this.chainRbtn.TabIndex = 14;
            this.chainRbtn.Text = "Chain Two Models";
            this.chainRbtn.UseVisualStyleBackColor = true;
            this.chainRbtn.CheckedChanged += new System.EventHandler(this.chainRbtn_CheckedChanged);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(8, 206);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Model 2:";
            // 
            // interpRbtn
            // 
            this.interpRbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.interpRbtn.AutoSize = true;
            this.interpRbtn.ForeColor = System.Drawing.Color.White;
            this.interpRbtn.Location = new System.Drawing.Point(15, 63);
            this.interpRbtn.Name = "interpRbtn";
            this.interpRbtn.Size = new System.Drawing.Size(181, 17);
            this.interpRbtn.TabIndex = 13;
            this.interpRbtn.Text = "Interpolate Between Two Models";
            this.interpRbtn.UseVisualStyleBackColor = true;
            this.interpRbtn.CheckedChanged += new System.EventHandler(this.interpRbtn_CheckedChanged);
            // 
            // singleModelRbtn
            // 
            this.singleModelRbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.singleModelRbtn.AutoSize = true;
            this.singleModelRbtn.Checked = true;
            this.singleModelRbtn.ForeColor = System.Drawing.Color.White;
            this.singleModelRbtn.Location = new System.Drawing.Point(15, 40);
            this.singleModelRbtn.Name = "singleModelRbtn";
            this.singleModelRbtn.Size = new System.Drawing.Size(108, 17);
            this.singleModelRbtn.TabIndex = 12;
            this.singleModelRbtn.TabStop = true;
            this.singleModelRbtn.Text = "Use Single Model";
            this.singleModelRbtn.UseVisualStyleBackColor = true;
            this.singleModelRbtn.CheckedChanged += new System.EventHandler(this.singleModelRbtn_CheckedChanged);
            // 
            // leftSpacer5
            // 
            this.leftSpacer5.BackColor = System.Drawing.Color.Transparent;
            this.leftSpacer5.Controls.Add(this.panel4);
            this.leftSpacer5.Location = new System.Drawing.Point(3, 124);
            this.leftSpacer5.Name = "leftSpacer5";
            this.leftSpacer5.Size = new System.Drawing.Size(361, 17);
            this.leftSpacer5.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel4.Location = new System.Drawing.Point(5, 5);
            this.panel4.Margin = new System.Windows.Forms.Padding(5);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(10);
            this.panel4.Size = new System.Drawing.Size(350, 7);
            this.panel4.TabIndex = 0;
            // 
            // aiPanel
            // 
            this.aiPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.aiPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.aiPanel.Controls.Add(this.label32);
            this.aiPanel.Controls.Add(this.label33);
            this.aiPanel.Controls.Add(this.aiSelect);
            this.aiPanel.Location = new System.Drawing.Point(3, 66);
            this.aiPanel.Name = "aiPanel";
            this.aiPanel.Size = new System.Drawing.Size(361, 52);
            this.aiPanel.TabIndex = 12;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(3, 4);
            this.label32.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(17, 13);
            this.label32.TabIndex = 2;
            this.label32.Text = "AI";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.ForeColor = System.Drawing.Color.White;
            this.label33.Location = new System.Drawing.Point(5, 23);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(99, 13);
            this.label33.TabIndex = 6;
            this.label33.Text = "AI Network To Run";
            // 
            // aiSelect
            // 
            this.aiSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aiSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aiSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aiSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aiSelect.ForeColor = System.Drawing.Color.White;
            this.aiSelect.FormattingEnabled = true;
            this.aiSelect.Location = new System.Drawing.Point(116, 20);
            this.aiSelect.Margin = new System.Windows.Forms.Padding(8);
            this.aiSelect.Name = "aiSelect";
            this.aiSelect.Size = new System.Drawing.Size(235, 21);
            this.aiSelect.TabIndex = 5;
            this.aiSelect.SelectedIndexChanged += new System.EventHandler(this.aiSelect_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1264, 921);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Icon = global::Cupscale.Properties.Resources.CupscaleLogo1;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Cupscale GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.htTabControl.ResumeLayout(false);
            this.previewTab.ResumeLayout(false);
            this.batchTab.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.videoTab.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel37.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.panel38.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.panel39.ResumeLayout(false);
            this.panel39.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.panel40.ResumeLayout(false);
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.flowPanelRight.ResumeLayout(false);
            this.upscalePanel.ResumeLayout(false);
            this.upscalePanel.PerformLayout();
            this.rSpacer1.ResumeLayout(false);
            this.savePanel.ResumeLayout(false);
            this.savePanel.PerformLayout();
            this.rSpacer2.ResumeLayout(false);
            this.postResizePanel.ResumeLayout(false);
            this.postResizePanel.PerformLayout();
            this.rSpacer3.ResumeLayout(false);
            this.preResizePanel.ResumeLayout(false);
            this.preResizePanel.PerformLayout();
            this.rSpacer4.ResumeLayout(false);
            this.imgOptsPanel.ResumeLayout(false);
            this.imgOptsPanel.PerformLayout();
            this.flowPanelLeft.ResumeLayout(false);
            this.prevCtrlPanel.ResumeLayout(false);
            this.prevCtrlPanel.PerformLayout();
            this.leftSpacer1.ResumeLayout(false);
            this.prevInfoPanel.ResumeLayout(false);
            this.prevInfoPanel.PerformLayout();
            this.leftSpacer2.ResumeLayout(false);
            this.compPanel.ResumeLayout(false);
            this.compPanel.PerformLayout();
            this.leftSpacer3.ResumeLayout(false);
            this.esrganPanel.ResumeLayout(false);
            this.esrganPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.leftSpacer4.ResumeLayout(false);
            this.mdlPanel.ResumeLayout(false);
            this.mdlPanel.PerformLayout();
            this.leftSpacer5.ResumeLayout(false);
            this.aiPanel.ResumeLayout(false);
            this.aiPanel.PerformLayout();
            this.ResumeLayout(false);

        }
        private Label label16;
        private Label label14;
        private RadioButton singleModelRbtn;
        private RadioButton interpRbtn;
        private Label label4;
        private RadioButton chainRbtn;
        private Panel panel6;
        private Label label5;
        private Panel panel7;
        private ToolTip toolTip1;
        private Button interpConfigureBtn;
        private HTAlt.WinForms.HTTabControl htTabControl;
        private TabPage previewTab;
        private TabPage batchTab;
        private ImageBox previewImg;
        public HTAlt.WinForms.HTProgressBar htProgBar;
        private HTAlt.WinForms.HTButton upscaleBtn;
        private HTAlt.WinForms.HTButton prevToggleFilterBtn;
        private HTAlt.WinForms.HTButton refreshPreviewCutoutBtn;
        private HTAlt.WinForms.HTButton refreshPreviewFullBtn;
        private HTAlt.WinForms.HTButton copyCompToClipboardBtn;
        private Label batchDirLabel;
        private Panel panel8;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel9;
        private Panel panel10;
        private Label label6;
        private TextBox batchFileList;
        private TableLayoutPanel tableLayoutPanel7;
        private HTAlt.WinForms.HTButton settingsBtn;
        private Button model1TreeBtn;
        private Button model2TreeBtn;
        private HTAlt.WinForms.HTButton savePreviewToFileBtn;
        private Label label8;
        private ComboBox postResizeScale;
        private Label label9;
        private ComboBox postResizeFilter;
        private ComboBox postResizeMode;
        private TableLayoutPanel tableLayoutPanel8;
        private CheckBox postResizeOnlyDownscale;
        private Panel panel11;
        private HTAlt.WinForms.HTButton openOutFolderBtn;
        private HTAlt.WinForms.HTButton saveMergedPreviewBtn;
        private TableLayoutPanel tableLayoutPanel9;
        private Label label7;
        private Panel panel12;
        private Label label13;
        private TextBox batchOutDir;
        private Label label15;
        private ComboBox batchOutMode;
        private CheckBox preResizeOnlyDownscale;
        private ComboBox preResizeMode;
        private Label label17;
        private ComboBox preResizeScale;
        private Label label18;
        private ComboBox preResizeFilter;
        private Panel panel15;
        private Label vramLabel;
        private RadioButton advancedBtn;
        private Button advancedConfigureBtn;
        private HTAlt.WinForms.HTButton comparisonToolBtn;
        private HTAlt.WinForms.HTButton openModelFolderBtn;
        private Label label19;
        private ComboBox preprocessMode;
        private Button selectOutPathBtn;
        private TableLayoutPanel tableLayoutPanel10;
        private HTAlt.WinForms.HTButton paypalBtn;
        private HTAlt.WinForms.HTButton htButton1;
        private HTAlt.WinForms.HTButton offlineInterpBtn;
        private FlowLayoutPanel flowPanelRight;
        private Panel upscalePanel;
        private Label label20;
        private Panel postResizePanel;
        private Label label22;
        private Panel preResizePanel;
        private Label label28;
        private Panel savePanel;
        private Label label23;
        private FlowLayoutPanel flowPanelLeft;
        private Panel prevCtrlPanel;
        private Label label21;
        private Panel prevInfoPanel;
        private Label label26;
        private Panel compPanel;
        private Label label27;
        private Panel esrganPanel;
        private Label label29;
        private Panel mdlPanel;
        private Label label1;
        private ComboBox seamlessMode;
        private Label label2;
        private CheckBox alpha;
        private Label label3;
        private PictureBox pictureBox6;
        private Panel imgOptsPanel;
        private Label label25;
        private HTAlt.WinForms.HTButton openSourceFolderBtn;
        private HTAlt.WinForms.HTButton reloadImgBtn;
        private Panel rSpacer4;
        private Panel panel16;
        private Panel rSpacer1;
        private Panel panel28;
        private Panel rSpacer2;
        private Panel panel26;
        private Panel rSpacer3;
        private Panel panel24;
        private Panel leftSpacer1;
        private Panel panel30;
        private Panel leftSpacer2;
        private Panel panel34;
        private Panel leftSpacer3;
        private Panel panel32;
        private Panel leftSpacer4;
        private Panel panel36;
        private TabPage videoTab;
        private TableLayoutPanel tableLayoutPanel2;
        private Label videoPathLabel;
        private Panel panel37;
        private TableLayoutPanel tableLayoutPanel6;
        private Panel panel38;
        private TableLayoutPanel tableLayoutPanel11;
        private Label label31;
        private Panel panel39;
        private TableLayoutPanel tableLayoutPanel12;
        private Button videoOutPathBtn;
        private TextBox videoOutDir;
        private Label label34;
        private Panel panel40;
        private TableLayoutPanel tableLayoutPanel13;
        private TextBox videoLogBox;
        private Label label35;
        private ComboBox videoOutputFormat;
        private HTAlt.WinForms.HTButton cancelBtn;
        private Label label30;
        private ComboBox videoPreprocessMode;
        private HTAlt.WinForms.HTButton patreonBtn;
        private Label label24;
        private ComboBox batchCacheSplitDepth;
        private HTAlt.WinForms.HTButton discordBtn;
        private Panel aiPanel;
        private Label label32;
        private Label label33;
        private ComboBox aiSelect;
        private Panel leftSpacer5;
        private Panel panel4;
        private TextBox videoFileListBox;
        private Label label36;
    }
}
