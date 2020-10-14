using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Cupscale.UI;
using ImageBox = Cyotek.Windows.Forms.ImageBox;
using Cupscale.Properties;
using System.Drawing.Drawing2D;

namespace Cupscale
{
    partial class MainForm
    {
        private IContainer components = null;
        private Panel leftPanel;
        private Panel panel2;
        private Panel panel1;
        private ImageBox img;
        private Panel rightPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel3;
        private Label label2;
        private Button button1;
        private Label label1;
        private Panel panel5;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label10;
        private ComboBox prevOverwriteCombox;
        private Label label11;
        private GroupBox previewGroupbox;
        private ComboBox prevClipboardTypeCombox;
        private Label label12;
        private GroupBox groupBox1;
        private Label prevZoomLabel;
        private TableLayoutPanel tableLayoutPanel5;
        private Label statusLabel;
        private TableLayoutPanel tableLayoutPanel6;
        private Label prevSizeLabel;
        private Label prevCutoutLabel;
        private ComboBox prevOutputFormatCombox;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.img = new Cyotek.Windows.Forms.ImageBox();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.advancedBtn = new System.Windows.Forms.RadioButton();
            this.advancedConfigureBtn = new System.Windows.Forms.Button();
            this.model2TreeBtn = new System.Windows.Forms.Button();
            this.model1TreeBtn = new System.Windows.Forms.Button();
            this.interpConfigureBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.chainRbtn = new System.Windows.Forms.RadioButton();
            this.interpRbtn = new System.Windows.Forms.RadioButton();
            this.singleModelRbtn = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.refreshPreviewCutoutBtn = new HTAlt.WinForms.HTButton();
            this.refreshPreviewFullBtn = new HTAlt.WinForms.HTButton();
            this.prevToggleFilterBtn = new HTAlt.WinForms.HTButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.prevCutoutLabel = new System.Windows.Forms.Label();
            this.prevSizeLabel = new System.Windows.Forms.Label();
            this.prevZoomLabel = new System.Windows.Forms.Label();
            this.previewGroupbox = new System.Windows.Forms.GroupBox();
            this.savePreviewToFileBtn = new HTAlt.WinForms.HTButton();
            this.copyCompToClipboardBtn = new HTAlt.WinForms.HTButton();
            this.label12 = new System.Windows.Forms.Label();
            this.prevClipboardTypeCombox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.preResizeOnlyDownscale = new System.Windows.Forms.CheckBox();
            this.preResizeMode = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.preResizeScale = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.preResizeFilter = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
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
            this.selectOutPathBtn = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.preprocessMode = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.batchOutMode = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.batchOutDir = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.batchFileList = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.saveMergedPreviewBtn = new HTAlt.WinForms.HTButton();
            this.openOutFolderBtn = new HTAlt.WinForms.HTButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.postResizeOnlyDownscale = new System.Windows.Forms.CheckBox();
            this.postResizeMode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.postResizeScale = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.postResizeFilter = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.prevOverwriteCombox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.prevOutputFormatCombox = new System.Windows.Forms.ComboBox();
            this.upscaleBtn = new HTAlt.WinForms.HTButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.openModelFolderBtn = new HTAlt.WinForms.HTButton();
            this.comparisonToolBtn = new HTAlt.WinForms.HTButton();
            this.settingsBtn = new HTAlt.WinForms.HTButton();
            this.panel15 = new System.Windows.Forms.Panel();
            this.vramLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.previewGroupbox.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.panel10.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel15.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel15, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 921);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel13, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(344, 875);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.advancedBtn);
            this.panel5.Controls.Add(this.advancedConfigureBtn);
            this.panel5.Controls.Add(this.model2TreeBtn);
            this.panel5.Controls.Add(this.model1TreeBtn);
            this.panel5.Controls.Add(this.interpConfigureBtn);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.chainRbtn);
            this.panel5.Controls.Add(this.interpRbtn);
            this.panel5.Controls.Add(this.singleModelRbtn);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(338, 285);
            this.panel5.TabIndex = 1;
            // 
            // advancedBtn
            // 
            this.advancedBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedBtn.AutoSize = true;
            this.advancedBtn.ForeColor = System.Drawing.Color.White;
            this.advancedBtn.Location = new System.Drawing.Point(12, 140);
            this.advancedBtn.Name = "advancedBtn";
            this.advancedBtn.Size = new System.Drawing.Size(74, 17);
            this.advancedBtn.TabIndex = 20;
            this.advancedBtn.Text = "Advanced";
            this.advancedBtn.UseVisualStyleBackColor = true;
            this.advancedBtn.CheckedChanged += new System.EventHandler(this.advancedBtn_CheckedChanged);
            // 
            // advancedConfigureBtn
            // 
            this.advancedConfigureBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedConfigureBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.advancedConfigureBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.advancedConfigureBtn.ForeColor = System.Drawing.Color.White;
            this.advancedConfigureBtn.Location = new System.Drawing.Point(199, 137);
            this.advancedConfigureBtn.Name = "advancedConfigureBtn";
            this.advancedConfigureBtn.Size = new System.Drawing.Size(129, 23);
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
            this.model2TreeBtn.Location = new System.Drawing.Point(6, 252);
            this.model2TreeBtn.Margin = new System.Windows.Forms.Padding(8);
            this.model2TreeBtn.Name = "model2TreeBtn";
            this.model2TreeBtn.Size = new System.Drawing.Size(322, 23);
            this.model2TreeBtn.TabIndex = 18;
            this.model2TreeBtn.Text = "None Selected. Click To Change.";
            this.model2TreeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.model2TreeBtn.UseVisualStyleBackColor = false;
            this.model2TreeBtn.Click += new System.EventHandler(this.model2TreeBtn_Click);
            // 
            // model1TreeBtn
            // 
            this.model1TreeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.model1TreeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.model1TreeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.model1TreeBtn.ForeColor = System.Drawing.Color.White;
            this.model1TreeBtn.Location = new System.Drawing.Point(6, 202);
            this.model1TreeBtn.Margin = new System.Windows.Forms.Padding(8);
            this.model1TreeBtn.Name = "model1TreeBtn";
            this.model1TreeBtn.Size = new System.Drawing.Size(322, 23);
            this.model1TreeBtn.TabIndex = 17;
            this.model1TreeBtn.Text = "None Selected. Click To Change.";
            this.model1TreeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.model1TreeBtn.UseVisualStyleBackColor = false;
            this.model1TreeBtn.Click += new System.EventHandler(this.model1TreeBtn_Click);
            // 
            // interpConfigureBtn
            // 
            this.interpConfigureBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.interpConfigureBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.interpConfigureBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.interpConfigureBtn.ForeColor = System.Drawing.Color.White;
            this.interpConfigureBtn.Location = new System.Drawing.Point(199, 91);
            this.interpConfigureBtn.Name = "interpConfigureBtn";
            this.interpConfigureBtn.Size = new System.Drawing.Size(129, 23);
            this.interpConfigureBtn.TabIndex = 16;
            this.interpConfigureBtn.Text = "Configure...";
            this.interpConfigureBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.interpConfigureBtn.UseVisualStyleBackColor = false;
            this.interpConfigureBtn.Visible = false;
            this.interpConfigureBtn.Click += new System.EventHandler(this.interpConfigureBtn_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Model Mode:";
            // 
            // chainRbtn
            // 
            this.chainRbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chainRbtn.AutoSize = true;
            this.chainRbtn.ForeColor = System.Drawing.Color.White;
            this.chainRbtn.Location = new System.Drawing.Point(12, 117);
            this.chainRbtn.Name = "chainRbtn";
            this.chainRbtn.Size = new System.Drawing.Size(113, 17);
            this.chainRbtn.TabIndex = 14;
            this.chainRbtn.Text = "Chain Two Models";
            this.chainRbtn.UseVisualStyleBackColor = true;
            this.chainRbtn.CheckedChanged += new System.EventHandler(this.chainRbtn_CheckedChanged);
            // 
            // interpRbtn
            // 
            this.interpRbtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.interpRbtn.AutoSize = true;
            this.interpRbtn.ForeColor = System.Drawing.Color.White;
            this.interpRbtn.Location = new System.Drawing.Point(12, 94);
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
            this.singleModelRbtn.Location = new System.Drawing.Point(12, 71);
            this.singleModelRbtn.Name = "singleModelRbtn";
            this.singleModelRbtn.Size = new System.Drawing.Size(108, 17);
            this.singleModelRbtn.TabIndex = 12;
            this.singleModelRbtn.TabStop = true;
            this.singleModelRbtn.Text = "Use Single Model";
            this.singleModelRbtn.UseVisualStyleBackColor = true;
            this.singleModelRbtn.CheckedChanged += new System.EventHandler(this.singleModelRbtn_CheckedChanged);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(6, 233);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Model 2:";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(6, 181);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Model 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "ESRGAN Options";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.refreshPreviewCutoutBtn);
            this.panel3.Controls.Add(this.refreshPreviewFullBtn);
            this.panel3.Controls.Add(this.prevToggleFilterBtn);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.previewGroupbox);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 585);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(338, 287);
            this.panel3.TabIndex = 0;
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
            this.refreshPreviewCutoutBtn.Location = new System.Drawing.Point(171, 250);
            this.refreshPreviewCutoutBtn.Name = "refreshPreviewCutoutBtn";
            this.refreshPreviewCutoutBtn.Size = new System.Drawing.Size(162, 30);
            this.refreshPreviewCutoutBtn.TabIndex = 11;
            this.refreshPreviewCutoutBtn.Text = "Refresh Preview (Cutout)";
            this.refreshPreviewCutoutBtn.UseVisualStyleBackColor = false;
            this.refreshPreviewCutoutBtn.Click += new System.EventHandler(this.refreshPreviewCutoutBtn_Click);
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
            this.refreshPreviewFullBtn.Location = new System.Drawing.Point(3, 250);
            this.refreshPreviewFullBtn.Name = "refreshPreviewFullBtn";
            this.refreshPreviewFullBtn.Size = new System.Drawing.Size(162, 30);
            this.refreshPreviewFullBtn.TabIndex = 10;
            this.refreshPreviewFullBtn.Text = "Refresh Preview (Full Image)";
            this.refreshPreviewFullBtn.UseVisualStyleBackColor = false;
            this.refreshPreviewFullBtn.Click += new System.EventHandler(this.refreshPreviewFullBtn_Click);
            // 
            // prevToggleFilterBtn
            // 
            this.prevToggleFilterBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prevToggleFilterBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.prevToggleFilterBtn.FlatAppearance.BorderSize = 0;
            this.prevToggleFilterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevToggleFilterBtn.ForeColor = System.Drawing.Color.White;
            this.prevToggleFilterBtn.Location = new System.Drawing.Point(3, 216);
            this.prevToggleFilterBtn.Name = "prevToggleFilterBtn";
            this.prevToggleFilterBtn.Size = new System.Drawing.Size(330, 30);
            this.prevToggleFilterBtn.TabIndex = 9;
            this.prevToggleFilterBtn.Text = "Switch To Bicubic Filtering";
            this.prevToggleFilterBtn.UseVisualStyleBackColor = false;
            this.prevToggleFilterBtn.Click += new System.EventHandler(this.prevToggleFilterBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.prevCutoutLabel);
            this.groupBox1.Controls.Add(this.prevSizeLabel);
            this.groupBox1.Controls.Add(this.prevZoomLabel);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 69);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview Info";
            // 
            // prevCutoutLabel
            // 
            this.prevCutoutLabel.AutoSize = true;
            this.prevCutoutLabel.Location = new System.Drawing.Point(6, 48);
            this.prevCutoutLabel.Name = "prevCutoutLabel";
            this.prevCutoutLabel.Size = new System.Drawing.Size(38, 13);
            this.prevCutoutLabel.TabIndex = 8;
            this.prevCutoutLabel.Text = "Cutout";
            // 
            // prevSizeLabel
            // 
            this.prevSizeLabel.AutoSize = true;
            this.prevSizeLabel.Location = new System.Drawing.Point(6, 32);
            this.prevSizeLabel.Name = "prevSizeLabel";
            this.prevSizeLabel.Size = new System.Drawing.Size(27, 13);
            this.prevSizeLabel.TabIndex = 7;
            this.prevSizeLabel.Text = "Size";
            // 
            // prevZoomLabel
            // 
            this.prevZoomLabel.AutoSize = true;
            this.prevZoomLabel.Location = new System.Drawing.Point(6, 16);
            this.prevZoomLabel.Name = "prevZoomLabel";
            this.prevZoomLabel.Size = new System.Drawing.Size(34, 13);
            this.prevZoomLabel.TabIndex = 6;
            this.prevZoomLabel.Text = "Zoom";
            // 
            // previewGroupbox
            // 
            this.previewGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewGroupbox.Controls.Add(this.savePreviewToFileBtn);
            this.previewGroupbox.Controls.Add(this.copyCompToClipboardBtn);
            this.previewGroupbox.Controls.Add(this.label12);
            this.previewGroupbox.Controls.Add(this.prevClipboardTypeCombox);
            this.previewGroupbox.ForeColor = System.Drawing.Color.White;
            this.previewGroupbox.Location = new System.Drawing.Point(3, 117);
            this.previewGroupbox.Name = "previewGroupbox";
            this.previewGroupbox.Size = new System.Drawing.Size(330, 93);
            this.previewGroupbox.TabIndex = 5;
            this.previewGroupbox.TabStop = false;
            this.previewGroupbox.Text = "Save Comparison";
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
            this.savePreviewToFileBtn.Location = new System.Drawing.Point(168, 56);
            this.savePreviewToFileBtn.Name = "savePreviewToFileBtn";
            this.savePreviewToFileBtn.Size = new System.Drawing.Size(156, 30);
            this.savePreviewToFileBtn.TabIndex = 13;
            this.savePreviewToFileBtn.Text = "Save To File";
            this.savePreviewToFileBtn.UseVisualStyleBackColor = false;
            this.savePreviewToFileBtn.Click += new System.EventHandler(this.savePreviewToFileBtn_Click);
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
            this.copyCompToClipboardBtn.Location = new System.Drawing.Point(6, 56);
            this.copyCompToClipboardBtn.Name = "copyCompToClipboardBtn";
            this.copyCompToClipboardBtn.Size = new System.Drawing.Size(156, 30);
            this.copyCompToClipboardBtn.TabIndex = 12;
            this.copyCompToClipboardBtn.Text = "Copy To Clipboard";
            this.copyCompToClipboardBtn.UseVisualStyleBackColor = false;
            this.copyCompToClipboardBtn.Click += new System.EventHandler(this.copyCompToClipboardBtn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Comparison Type";
            // 
            // prevClipboardTypeCombox
            // 
            this.prevClipboardTypeCombox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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
            this.prevClipboardTypeCombox.Location = new System.Drawing.Point(117, 24);
            this.prevClipboardTypeCombox.Margin = new System.Windows.Forms.Padding(8);
            this.prevClipboardTypeCombox.Name = "prevClipboardTypeCombox";
            this.prevClipboardTypeCombox.Size = new System.Drawing.Size(207, 21);
            this.prevClipboardTypeCombox.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(3, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(397, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Refresh Preview";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Preview Options";
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(3, 294);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(338, 285);
            this.panel13.TabIndex = 2;
            // 
            // panel14
            // 
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Controls.Add(this.groupBox4);
            this.panel14.Controls.Add(this.label21);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(338, 285);
            this.panel14.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.preResizeOnlyDownscale);
            this.groupBox4.Controls.Add(this.preResizeMode);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.preResizeScale);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.preResizeFilter);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(3, 137);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(330, 143);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Resize Before Upscaling";
            // 
            // preResizeOnlyDownscale
            // 
            this.preResizeOnlyDownscale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.preResizeOnlyDownscale.AutoSize = true;
            this.preResizeOnlyDownscale.Checked = true;
            this.preResizeOnlyDownscale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.preResizeOnlyDownscale.Enabled = false;
            this.preResizeOnlyDownscale.Location = new System.Drawing.Point(6, 120);
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
            this.preResizeMode.Location = new System.Drawing.Point(121, 38);
            this.preResizeMode.Margin = new System.Windows.Forms.Padding(8);
            this.preResizeMode.Name = "preResizeMode";
            this.preResizeMode.Size = new System.Drawing.Size(201, 21);
            this.preResizeMode.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(5, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "New Size";
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
            this.preResizeScale.Location = new System.Drawing.Point(5, 38);
            this.preResizeScale.Margin = new System.Windows.Forms.Padding(8);
            this.preResizeScale.Name = "preResizeScale";
            this.preResizeScale.Size = new System.Drawing.Size(100, 21);
            this.preResizeScale.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(5, 67);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "Scaling Filter";
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
            "Nearest Neighbor",
            "Bicubic"});
            this.preResizeFilter.Location = new System.Drawing.Point(5, 88);
            this.preResizeFilter.Margin = new System.Windows.Forms.Padding(8);
            this.preResizeFilter.Name = "preResizeFilter";
            this.preResizeFilter.Size = new System.Drawing.Size(318, 21);
            this.preResizeFilter.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(3, 4);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(113, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Preprocessing Options";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.htTabControl, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(353, 43);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(608, 875);
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
            this.tableLayoutPanel5.Size = new System.Drawing.Size(602, 19);
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
            this.htProgBar.Size = new System.Drawing.Size(396, 13);
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
            this.htTabControl.DisableClose = false;
            this.htTabControl.DisableDragging = false;
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
            this.htTabControl.Size = new System.Drawing.Size(602, 844);
            this.htTabControl.TabIndex = 2;
            this.htTabControl.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.htTabControl.UnderBorderTabLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(70)))));
            this.htTabControl.UnselectedBorderTabLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.htTabControl.UnselectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.htTabControl.UpDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.htTabControl.UpDownTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(112)))));
            // 
            // previewTab
            // 
            this.previewTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.previewTab.Controls.Add(this.previewImg);
            this.previewTab.Location = new System.Drawing.Point(4, 27);
            this.previewTab.Margin = new System.Windows.Forms.Padding(0);
            this.previewTab.Name = "previewTab";
            this.previewTab.Size = new System.Drawing.Size(594, 813);
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
            this.previewImg.Size = new System.Drawing.Size(594, 813);
            this.previewImg.TabIndex = 0;
            this.previewImg.TabStop = false;
            this.previewImg.Text = "Drag And Drop An Image Or A Folder Into This Area";
            this.previewImg.Zoomed += new System.EventHandler<Cyotek.Windows.Forms.ImageBoxZoomEventArgs>(this.previewImg_Zoomed);
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
            this.batchTab.Size = new System.Drawing.Size(594, 813);
            this.batchTab.TabIndex = 1;
            this.batchTab.Text = "Batch Upscale";
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
            this.tableLayoutPanel7.Size = new System.Drawing.Size(588, 807);
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
            this.batchDirLabel.Size = new System.Drawing.Size(582, 55);
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
            this.panel8.Size = new System.Drawing.Size(582, 721);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(582, 721);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.tableLayoutPanel9);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(291, 721);
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
            this.tableLayoutPanel9.Size = new System.Drawing.Size(291, 721);
            this.tableLayoutPanel9.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(8, 8);
            this.label7.Margin = new System.Windows.Forms.Padding(8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "Options";
            // 
            // panel12
            // 
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
            this.panel12.Size = new System.Drawing.Size(291, 691);
            this.panel12.TabIndex = 11;
            // 
            // selectOutPathBtn
            // 
            this.selectOutPathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectOutPathBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.selectOutPathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectOutPathBtn.ForeColor = System.Drawing.Color.White;
            this.selectOutPathBtn.Location = new System.Drawing.Point(249, 0);
            this.selectOutPathBtn.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.selectOutPathBtn.Name = "selectOutPathBtn";
            this.selectOutPathBtn.Size = new System.Drawing.Size(26, 23);
            this.selectOutPathBtn.TabIndex = 18;
            this.selectOutPathBtn.Text = "...";
            this.selectOutPathBtn.UseVisualStyleBackColor = false;
            this.selectOutPathBtn.Click += new System.EventHandler(this.selectOutPathBtn_Click);
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
            "Disabled - Skips The Conversion Process. Make Sure Images Are Compatible!"});
            this.preprocessMode.Location = new System.Drawing.Point(8, 134);
            this.preprocessMode.Margin = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.preprocessMode.Name = "preprocessMode";
            this.preprocessMode.Size = new System.Drawing.Size(275, 23);
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
            this.batchOutMode.Size = new System.Drawing.Size(275, 23);
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
            // batchOutDir
            // 
            this.batchOutDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batchOutDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.batchOutDir.ForeColor = System.Drawing.Color.White;
            this.batchOutDir.Location = new System.Drawing.Point(0, 0);
            this.batchOutDir.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.batchOutDir.Name = "batchOutDir";
            this.batchOutDir.Size = new System.Drawing.Size(245, 23);
            this.batchOutDir.TabIndex = 10;
            this.batchOutDir.Text = "Will get auto-filled once you load a directory.";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.tableLayoutPanel8);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(291, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(291, 721);
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
            this.tableLayoutPanel8.Size = new System.Drawing.Size(291, 721);
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
            this.batchFileList.Size = new System.Drawing.Size(275, 675);
            this.batchFileList.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "File List";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(967, 43);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(294, 875);
            this.tableLayoutPanel6.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.saveMergedPreviewBtn);
            this.panel4.Controls.Add(this.openOutFolderBtn);
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.upscaleBtn);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(288, 869);
            this.panel4.TabIndex = 3;
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
            this.saveMergedPreviewBtn.Location = new System.Drawing.Point(3, 796);
            this.saveMergedPreviewBtn.Name = "saveMergedPreviewBtn";
            this.saveMergedPreviewBtn.Size = new System.Drawing.Size(280, 30);
            this.saveMergedPreviewBtn.TabIndex = 12;
            this.saveMergedPreviewBtn.Text = "Save Current Merged Preview";
            this.saveMergedPreviewBtn.UseVisualStyleBackColor = false;
            this.saveMergedPreviewBtn.Click += new System.EventHandler(this.saveMergedPreviewBtn_Click);
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
            this.openOutFolderBtn.Location = new System.Drawing.Point(3, 760);
            this.openOutFolderBtn.Name = "openOutFolderBtn";
            this.openOutFolderBtn.Size = new System.Drawing.Size(280, 30);
            this.openOutFolderBtn.TabIndex = 11;
            this.openOutFolderBtn.Text = "Open Folder Of Last Upscale";
            this.openOutFolderBtn.UseVisualStyleBackColor = false;
            this.openOutFolderBtn.Click += new System.EventHandler(this.openOutFolderBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.postResizeOnlyDownscale);
            this.groupBox3.Controls.Add(this.postResizeMode);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.postResizeScale);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.postResizeFilter);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(3, 479);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 143);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resize After Upscaling";
            // 
            // postResizeOnlyDownscale
            // 
            this.postResizeOnlyDownscale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.postResizeOnlyDownscale.AutoSize = true;
            this.postResizeOnlyDownscale.Checked = true;
            this.postResizeOnlyDownscale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.postResizeOnlyDownscale.Enabled = false;
            this.postResizeOnlyDownscale.Location = new System.Drawing.Point(6, 120);
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
            this.postResizeMode.Location = new System.Drawing.Point(121, 38);
            this.postResizeMode.Margin = new System.Windows.Forms.Padding(8);
            this.postResizeMode.Name = "postResizeMode";
            this.postResizeMode.Size = new System.Drawing.Size(151, 21);
            this.postResizeMode.TabIndex = 6;
            this.postResizeMode.SelectedIndexChanged += new System.EventHandler(this.postResizeMode_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "New Size";
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
            this.postResizeScale.Location = new System.Drawing.Point(5, 38);
            this.postResizeScale.Margin = new System.Windows.Forms.Padding(8);
            this.postResizeScale.Name = "postResizeScale";
            this.postResizeScale.Size = new System.Drawing.Size(100, 21);
            this.postResizeScale.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Scaling Filter";
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
            this.postResizeFilter.Location = new System.Drawing.Point(5, 88);
            this.postResizeFilter.Margin = new System.Windows.Forms.Padding(8);
            this.postResizeFilter.Name = "postResizeFilter";
            this.postResizeFilter.Size = new System.Drawing.Size(268, 21);
            this.postResizeFilter.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.prevOverwriteCombox);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.prevOutputFormatCombox);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(3, 627);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 117);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saving";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Overwrite Mode";
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
            this.prevOverwriteCombox.Location = new System.Drawing.Point(6, 37);
            this.prevOverwriteCombox.Margin = new System.Windows.Forms.Padding(8);
            this.prevOverwriteCombox.Name = "prevOverwriteCombox";
            this.prevOverwriteCombox.Size = new System.Drawing.Size(268, 21);
            this.prevOverwriteCombox.TabIndex = 2;
            this.prevOverwriteCombox.SelectedIndexChanged += new System.EventHandler(this.prevOverwriteCombox_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(6, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Output Format";
            // 
            // prevOutputFormatCombox
            // 
            this.prevOutputFormatCombox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prevOutputFormatCombox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.prevOutputFormatCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.prevOutputFormatCombox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevOutputFormatCombox.ForeColor = System.Drawing.Color.White;
            this.prevOutputFormatCombox.FormattingEnabled = true;
            this.prevOutputFormatCombox.Items.AddRange(new object[] {
            "PNG",
            "Same As Input",
            "JPEG - High",
            "JPEG - Medium",
            "WEBP - High",
            "WEBP - Medium"});
            this.prevOutputFormatCombox.Location = new System.Drawing.Point(6, 87);
            this.prevOutputFormatCombox.Margin = new System.Windows.Forms.Padding(8);
            this.prevOutputFormatCombox.Name = "prevOutputFormatCombox";
            this.prevOutputFormatCombox.Size = new System.Drawing.Size(268, 21);
            this.prevOutputFormatCombox.TabIndex = 4;
            // 
            // upscaleBtn
            // 
            this.upscaleBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.upscaleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.upscaleBtn.FlatAppearance.BorderSize = 0;
            this.upscaleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upscaleBtn.ForeColor = System.Drawing.Color.White;
            this.upscaleBtn.Location = new System.Drawing.Point(3, 832);
            this.upscaleBtn.Name = "upscaleBtn";
            this.upscaleBtn.Size = new System.Drawing.Size(280, 30);
            this.upscaleBtn.TabIndex = 8;
            this.upscaleBtn.Text = "Upscale And Save";
            this.upscaleBtn.UseVisualStyleBackColor = false;
            this.upscaleBtn.Click += new System.EventHandler(this.upscaleBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Saving Options";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(344, 34);
            this.panel6.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(344, 34);
            this.label5.TabIndex = 1;
            this.label5.Text = "Cupscale [Build 21 - 10/13/20]";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.openModelFolderBtn);
            this.panel7.Controls.Add(this.comparisonToolBtn);
            this.panel7.Controls.Add(this.settingsBtn);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(964, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(300, 40);
            this.panel7.TabIndex = 8;
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
            this.openModelFolderBtn.Location = new System.Drawing.Point(220, 6);
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
            this.comparisonToolBtn.ButtonImage = global::Cupscale.Properties.Resources.baseline_photo_library_white_48dp;
            this.comparisonToolBtn.DrawImage = true;
            this.comparisonToolBtn.FlatAppearance.BorderSize = 0;
            this.comparisonToolBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comparisonToolBtn.ForeColor = System.Drawing.Color.White;
            this.comparisonToolBtn.ImageIndex = 0;
            this.comparisonToolBtn.ImageSizeMode = HTAlt.WinForms.HTButton.ButtonImageSizeMode.Stretch;
            this.comparisonToolBtn.Location = new System.Drawing.Point(180, 6);
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
            this.settingsBtn.Location = new System.Drawing.Point(260, 6);
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
            this.panel15.Location = new System.Drawing.Point(350, 0);
            this.panel15.Margin = new System.Windows.Forms.Padding(0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(614, 40);
            this.panel15.TabIndex = 9;
            // 
            // vramLabel
            // 
            this.vramLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vramLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vramLabel.ForeColor = System.Drawing.Color.White;
            this.vramLabel.Location = new System.Drawing.Point(0, 0);
            this.vramLabel.Name = "vramLabel";
            this.vramLabel.Size = new System.Drawing.Size(614, 40);
            this.vramLabel.TabIndex = 2;
            this.vramLabel.Text = "No Nvidia GPU detected!";
            this.vramLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(275, 23);
            this.tableLayoutPanel10.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1264, 921);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = global::Cupscale.Properties.Resources.CupscaleLogo1;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Cupscale GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.previewGroupbox.ResumeLayout(false);
            this.previewGroupbox.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
            this.panel10.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
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
        private GroupBox groupBox3;
        private Label label8;
        private ComboBox postResizeScale;
        private Label label9;
        private ComboBox postResizeFilter;
        private GroupBox groupBox2;
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
        private Panel panel13;
        private Panel panel14;
        private GroupBox groupBox4;
        private CheckBox preResizeOnlyDownscale;
        private ComboBox preResizeMode;
        private Label label17;
        private ComboBox preResizeScale;
        private Label label18;
        private ComboBox preResizeFilter;
        private Label label21;
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
    }
}
