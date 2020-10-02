namespace Cupscale.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabList1 = new Cyotek.Windows.Forms.TabList();
            this.settingsPage = new Cyotek.Windows.Forms.TabListPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.seamless = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.esrganVersion = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.useNcnn = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.useCpu = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.alpha = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tilesize = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.jpegExtension = new System.Windows.Forms.ComboBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.selectModelsPathBtn = new System.Windows.Forms.Button();
            this.previewFormat = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.modelPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.confAlphaBgColorBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.alphaBgColor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.formatsPage = new Cyotek.Windows.Forms.TabListPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dxtMode = new System.Windows.Forms.ComboBox();
            this.ddsEnableMips = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.webpQ = new System.Windows.Forms.TextBox();
            this.jpegQ = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.logPage = new Cyotek.Windows.Forms.TabListPage();
            this.logTbox = new System.Windows.Forms.TextBox();
            this.resourceFilesPage = new Cyotek.Windows.Forms.TabListPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uninstallFullBtn = new HTAlt.WinForms.HTButton();
            this.label18 = new System.Windows.Forms.Label();
            this.uninstallResBtn = new HTAlt.WinForms.HTButton();
            this.label17 = new System.Windows.Forms.Label();
            this.reinstallCleanBtn = new HTAlt.WinForms.HTButton();
            this.reinstallOverwriteBtn = new HTAlt.WinForms.HTButton();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.alphaBgColorDialog = new System.Windows.Forms.ColorDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.modelsPathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.seamlessJoeyWarn = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.tabList1.SuspendLayout();
            this.settingsPage.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.formatsPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.logPage.SuspendLayout();
            this.resourceFilesPage.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // tabList1
            // 
            this.tabList1.Controls.Add(this.settingsPage);
            this.tabList1.Controls.Add(this.formatsPage);
            this.tabList1.Controls.Add(this.logPage);
            this.tabList1.Controls.Add(this.resourceFilesPage);
            this.tabList1.ForeColor = System.Drawing.Color.White;
            this.tabList1.Location = new System.Drawing.Point(12, 12);
            this.tabList1.Name = "tabList1";
            this.tabList1.Size = new System.Drawing.Size(1080, 477);
            this.tabList1.TabIndex = 0;
            // 
            // settingsPage
            // 
            this.settingsPage.Controls.Add(this.tableLayoutPanel3);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Size = new System.Drawing.Size(922, 469);
            this.settingsPage.Text = "Settings";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(922, 469);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.pictureBox6);
            this.panel7.Controls.Add(this.seamlessJoeyWarn);
            this.panel7.Controls.Add(this.seamless);
            this.panel7.Controls.Add(this.label22);
            this.panel7.Controls.Add(this.pictureBox2);
            this.panel7.Controls.Add(this.label16);
            this.panel7.Controls.Add(this.esrganVersion);
            this.panel7.Controls.Add(this.pictureBox1);
            this.panel7.Controls.Add(this.useNcnn);
            this.panel7.Controls.Add(this.label15);
            this.panel7.Controls.Add(this.useCpu);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.alpha);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.tilesize);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(455, 463);
            this.panel7.TabIndex = 4;
            // 
            // seamless
            // 
            this.seamless.AutoSize = true;
            this.seamless.Location = new System.Drawing.Point(178, 170);
            this.seamless.Name = "seamless";
            this.seamless.Size = new System.Drawing.Size(15, 14);
            this.seamless.TabIndex = 15;
            this.seamless.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 170);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(82, 13);
            this.label22.TabIndex = 14;
            this.label22.Text = "Seamless Mode";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox2.Image = global::Cupscale.Properties.Resources.questmark;
            this.pictureBox2.Location = new System.Drawing.Point(102, 76);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox2, resources.GetString("pictureBox2.ToolTip"));
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "ESRGAN Version";
            // 
            // esrganVersion
            // 
            this.esrganVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.esrganVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.esrganVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.esrganVersion.ForeColor = System.Drawing.Color.White;
            this.esrganVersion.FormattingEnabled = true;
            this.esrganVersion.Items.AddRange(new object[] {
            "esrgan-launcher",
            "Joey\'s ESRGAN"});
            this.esrganVersion.Location = new System.Drawing.Point(180, 77);
            this.esrganVersion.Margin = new System.Windows.Forms.Padding(8);
            this.esrganVersion.Name = "esrganVersion";
            this.esrganVersion.Size = new System.Drawing.Size(200, 21);
            this.esrganVersion.TabIndex = 11;
            this.esrganVersion.SelectedIndexChanged += new System.EventHandler(this.esrganVersion_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.Image = global::Cupscale.Properties.Resources.questmark;
            this.pictureBox1.Location = new System.Drawing.Point(112, 226);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox1, "Use this if you have an AMD GPU.\r\nOnly works in batch upscaling mode, as the load" +
        "ing time is too long for the preview.\r\nIf you want to use the preview without an" +
        " Nvidia GPU, enable CPU mode.");
            // 
            // useNcnn
            // 
            this.useNcnn.AutoSize = true;
            this.useNcnn.Location = new System.Drawing.Point(178, 230);
            this.useNcnn.Name = "useNcnn";
            this.useNcnn.Size = new System.Drawing.Size(15, 14);
            this.useNcnn.TabIndex = 9;
            this.useNcnn.UseVisualStyleBackColor = true;
            this.useNcnn.CheckedChanged += new System.EventHandler(this.useNcnn_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 230);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Use Vulkan (NCNN)";
            // 
            // useCpu
            // 
            this.useCpu.AutoSize = true;
            this.useCpu.Location = new System.Drawing.Point(178, 200);
            this.useCpu.Name = "useCpu";
            this.useCpu.Size = new System.Drawing.Size(15, 14);
            this.useCpu.TabIndex = 7;
            this.useCpu.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Use CPU instead of CUDA";
            // 
            // alpha
            // 
            this.alpha.AutoSize = true;
            this.alpha.Location = new System.Drawing.Point(180, 140);
            this.alpha.Name = "alpha";
            this.alpha.Size = new System.Drawing.Size(15, 14);
            this.alpha.TabIndex = 5;
            this.alpha.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Enable Alpha";
            // 
            // tilesize
            // 
            this.tilesize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tilesize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tilesize.ForeColor = System.Drawing.Color.White;
            this.tilesize.FormattingEnabled = true;
            this.tilesize.Items.AddRange(new object[] {
            "2048",
            "1536",
            "1024",
            "768",
            "512",
            "384",
            "256",
            "192",
            "128"});
            this.tilesize.Location = new System.Drawing.Point(180, 107);
            this.tilesize.Margin = new System.Windows.Forms.Padding(8);
            this.tilesize.Name = "tilesize";
            this.tilesize.Size = new System.Drawing.Size(100, 21);
            this.tilesize.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tile Size (HR)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "ESRGAN Settings";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.pictureBox5);
            this.panel6.Controls.Add(this.jpegExtension);
            this.panel6.Controls.Add(this.pictureBox4);
            this.panel6.Controls.Add(this.selectModelsPathBtn);
            this.panel6.Controls.Add(this.previewFormat);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Controls.Add(this.pictureBox3);
            this.panel6.Controls.Add(this.modelPath);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.confAlphaBgColorBtn);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.alphaBgColor);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Location = new System.Drawing.Point(464, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(455, 463);
            this.panel6.TabIndex = 3;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox5.Image = global::Cupscale.Properties.Resources.questmark;
            this.pictureBox5.Location = new System.Drawing.Point(78, 75);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(22, 22);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 19;
            this.pictureBox5.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox5, "The root folder for ESRGAN models.\r\nCan have subfolders.");
            // 
            // jpegExtension
            // 
            this.jpegExtension.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.jpegExtension.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jpegExtension.ForeColor = System.Drawing.Color.White;
            this.jpegExtension.FormattingEnabled = true;
            this.jpegExtension.Items.AddRange(new object[] {
            "jpg",
            "jpeg",
            "jfif"});
            this.jpegExtension.Location = new System.Drawing.Point(180, 137);
            this.jpegExtension.Margin = new System.Windows.Forms.Padding(8);
            this.jpegExtension.Name = "jpegExtension";
            this.jpegExtension.Size = new System.Drawing.Size(100, 21);
            this.jpegExtension.TabIndex = 18;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox4.Image = global::Cupscale.Properties.Resources.questmark;
            this.pictureBox4.Location = new System.Drawing.Point(138, 165);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(22, 22);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 17;
            this.pictureBox4.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox4, "File format to use when saving the preview comparison to a file.\r\nNote that JPEG " +
        "and WEBP will use the same quality levels that can be configured for upscaled im" +
        "ages.");
            // 
            // selectModelsPathBtn
            // 
            this.selectModelsPathBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.selectModelsPathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectModelsPathBtn.ForeColor = System.Drawing.Color.White;
            this.selectModelsPathBtn.Location = new System.Drawing.Point(386, 75);
            this.selectModelsPathBtn.Name = "selectModelsPathBtn";
            this.selectModelsPathBtn.Size = new System.Drawing.Size(28, 23);
            this.selectModelsPathBtn.TabIndex = 16;
            this.selectModelsPathBtn.Text = "...";
            this.selectModelsPathBtn.UseVisualStyleBackColor = false;
            this.selectModelsPathBtn.Click += new System.EventHandler(this.selectModelsPathBtn_Click);
            // 
            // previewFormat
            // 
            this.previewFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.previewFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.previewFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previewFormat.ForeColor = System.Drawing.Color.White;
            this.previewFormat.FormattingEnabled = true;
            this.previewFormat.Items.AddRange(new object[] {
            "PNG",
            "JPEG",
            "WEBP"});
            this.previewFormat.Location = new System.Drawing.Point(180, 167);
            this.previewFormat.Margin = new System.Windows.Forms.Padding(8);
            this.previewFormat.Name = "previewFormat";
            this.previewFormat.Size = new System.Drawing.Size(100, 21);
            this.previewFormat.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 170);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Comparison ImageFormat";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox3.Image = global::Cupscale.Properties.Resources.questmark;
            this.pictureBox3.Location = new System.Drawing.Point(104, 105);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(22, 22);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox3, "When Alpha is disabled, the background will be filled with this color.");
            // 
            // modelPath
            // 
            this.modelPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.modelPath.ForeColor = System.Drawing.Color.White;
            this.modelPath.Location = new System.Drawing.Point(180, 77);
            this.modelPath.Name = "modelPath";
            this.modelPath.Size = new System.Drawing.Size(200, 20);
            this.modelPath.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "JPEG File Extension";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Models Path";
            // 
            // confAlphaBgColorBtn
            // 
            this.confAlphaBgColorBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.confAlphaBgColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confAlphaBgColorBtn.ForeColor = System.Drawing.Color.White;
            this.confAlphaBgColorBtn.Location = new System.Drawing.Point(261, 105);
            this.confAlphaBgColorBtn.Name = "confAlphaBgColorBtn";
            this.confAlphaBgColorBtn.Size = new System.Drawing.Size(28, 23);
            this.confAlphaBgColorBtn.TabIndex = 10;
            this.confAlphaBgColorBtn.Text = "...";
            this.confAlphaBgColorBtn.UseVisualStyleBackColor = false;
            this.confAlphaBgColorBtn.Click += new System.EventHandler(this.confAlphaBgColorBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cupscale Settings";
            // 
            // alphaBgColor
            // 
            this.alphaBgColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.alphaBgColor.ForeColor = System.Drawing.Color.White;
            this.alphaBgColor.Location = new System.Drawing.Point(180, 107);
            this.alphaBgColor.Name = "alphaBgColor";
            this.alphaBgColor.Size = new System.Drawing.Size(75, 20);
            this.alphaBgColor.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Background Color";
            // 
            // formatsPage
            // 
            this.formatsPage.Controls.Add(this.tableLayoutPanel1);
            this.formatsPage.Name = "formatsPage";
            this.formatsPage.Size = new System.Drawing.Size(922, 469);
            this.formatsPage.Text = "Output Formats";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(922, 469);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dxtMode);
            this.panel1.Controls.Add(this.ddsEnableMips);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.webpQ);
            this.panel1.Controls.Add(this.jpegQ);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 463);
            this.panel1.TabIndex = 4;
            // 
            // dxtMode
            // 
            this.dxtMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dxtMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dxtMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dxtMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dxtMode.ForeColor = System.Drawing.Color.White;
            this.dxtMode.FormattingEnabled = true;
            this.dxtMode.Items.AddRange(new object[] {
            "Off",
            "BC1 (DXT1)",
            "BC2 (DXT3)",
            "BC3 (DXT5)",
            "BC4 ",
            "BC5"});
            this.dxtMode.Location = new System.Drawing.Point(180, 137);
            this.dxtMode.Margin = new System.Windows.Forms.Padding(8);
            this.dxtMode.Name = "dxtMode";
            this.dxtMode.Size = new System.Drawing.Size(100, 21);
            this.dxtMode.TabIndex = 18;
            // 
            // ddsEnableMips
            // 
            this.ddsEnableMips.AutoSize = true;
            this.ddsEnableMips.Location = new System.Drawing.Point(180, 169);
            this.ddsEnableMips.Name = "ddsEnableMips";
            this.ddsEnableMips.Size = new System.Drawing.Size(15, 14);
            this.ddsEnableMips.TabIndex = 17;
            this.ddsEnableMips.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 170);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "DDS: Generate Mipmaps";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "DDS: DXT Compression Mode";
            // 
            // webpQ
            // 
            this.webpQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.webpQ.ForeColor = System.Drawing.Color.White;
            this.webpQ.Location = new System.Drawing.Point(180, 107);
            this.webpQ.Name = "webpQ";
            this.webpQ.Size = new System.Drawing.Size(50, 20);
            this.webpQ.TabIndex = 13;
            // 
            // jpegQ
            // 
            this.jpegQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.jpegQ.ForeColor = System.Drawing.Color.White;
            this.jpegQ.Location = new System.Drawing.Point(180, 77);
            this.jpegQ.Name = "jpegQ";
            this.jpegQ.Size = new System.Drawing.Size(50, 20);
            this.jpegQ.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "WEBP: Quality Level";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "JPEG: Quality Level";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(172, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "Image Format Settings";
            // 
            // logPage
            // 
            this.logPage.Controls.Add(this.logTbox);
            this.logPage.Name = "logPage";
            this.logPage.Size = new System.Drawing.Size(922, 469);
            this.logPage.Text = "View Session Log";
            // 
            // logTbox
            // 
            this.logTbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.logTbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTbox.ForeColor = System.Drawing.Color.Silver;
            this.logTbox.Location = new System.Drawing.Point(0, 0);
            this.logTbox.Margin = new System.Windows.Forms.Padding(24);
            this.logTbox.Multiline = true;
            this.logTbox.Name = "logTbox";
            this.logTbox.ReadOnly = true;
            this.logTbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTbox.Size = new System.Drawing.Size(922, 469);
            this.logTbox.TabIndex = 12;
            this.logTbox.VisibleChanged += new System.EventHandler(this.logTbox_VisibleChanged);
            // 
            // resourceFilesPage
            // 
            this.resourceFilesPage.Controls.Add(this.tableLayoutPanel2);
            this.resourceFilesPage.Name = "resourceFilesPage";
            this.resourceFilesPage.Size = new System.Drawing.Size(922, 469);
            this.resourceFilesPage.Text = "Resource Files";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(922, 469);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.uninstallFullBtn);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.uninstallResBtn);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.reinstallCleanBtn);
            this.panel2.Controls.Add(this.reinstallOverwriteBtn);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(455, 463);
            this.panel2.TabIndex = 4;
            // 
            // uninstallFullBtn
            // 
            this.uninstallFullBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uninstallFullBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uninstallFullBtn.FlatAppearance.BorderSize = 0;
            this.uninstallFullBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uninstallFullBtn.ForeColor = System.Drawing.Color.White;
            this.uninstallFullBtn.Location = new System.Drawing.Point(260, 165);
            this.uninstallFullBtn.Name = "uninstallFullBtn";
            this.uninstallFullBtn.Size = new System.Drawing.Size(156, 22);
            this.uninstallFullBtn.TabIndex = 19;
            this.uninstallFullBtn.Text = "Uninstall All Files";
            this.uninstallFullBtn.UseVisualStyleBackColor = false;
            this.uninstallFullBtn.Click += new System.EventHandler(this.uninstallFullBtn_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 170);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(153, 13);
            this.label18.TabIndex = 18;
            this.label18.Text = "Uninstall Including Settings File";
            // 
            // uninstallResBtn
            // 
            this.uninstallResBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uninstallResBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uninstallResBtn.FlatAppearance.BorderSize = 0;
            this.uninstallResBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uninstallResBtn.ForeColor = System.Drawing.Color.White;
            this.uninstallResBtn.Location = new System.Drawing.Point(260, 135);
            this.uninstallResBtn.Name = "uninstallResBtn";
            this.uninstallResBtn.Size = new System.Drawing.Size(156, 22);
            this.uninstallResBtn.TabIndex = 17;
            this.uninstallResBtn.Text = "Uninstall Resources";
            this.uninstallResBtn.UseVisualStyleBackColor = false;
            this.uninstallResBtn.Click += new System.EventHandler(this.uninstallResBtn_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 140);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(188, 13);
            this.label17.TabIndex = 16;
            this.label17.Text = "Uninstall (Cupscale will exit afterwards)";
            // 
            // reinstallCleanBtn
            // 
            this.reinstallCleanBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reinstallCleanBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.reinstallCleanBtn.FlatAppearance.BorderSize = 0;
            this.reinstallCleanBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reinstallCleanBtn.ForeColor = System.Drawing.Color.White;
            this.reinstallCleanBtn.Location = new System.Drawing.Point(260, 105);
            this.reinstallCleanBtn.Name = "reinstallCleanBtn";
            this.reinstallCleanBtn.Size = new System.Drawing.Size(156, 22);
            this.reinstallCleanBtn.TabIndex = 15;
            this.reinstallCleanBtn.Text = "Clean Reinstall";
            this.reinstallCleanBtn.UseVisualStyleBackColor = false;
            this.reinstallCleanBtn.Click += new System.EventHandler(this.reinstallCleanBtn_Click);
            // 
            // reinstallOverwriteBtn
            // 
            this.reinstallOverwriteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reinstallOverwriteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.reinstallOverwriteBtn.FlatAppearance.BorderSize = 0;
            this.reinstallOverwriteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reinstallOverwriteBtn.ForeColor = System.Drawing.Color.White;
            this.reinstallOverwriteBtn.Location = new System.Drawing.Point(260, 75);
            this.reinstallOverwriteBtn.Name = "reinstallOverwriteBtn";
            this.reinstallOverwriteBtn.Size = new System.Drawing.Size(156, 22);
            this.reinstallOverwriteBtn.TabIndex = 14;
            this.reinstallOverwriteBtn.Text = "Reinstall";
            this.reinstallOverwriteBtn.UseVisualStyleBackColor = false;
            this.reinstallOverwriteBtn.Click += new System.EventHandler(this.reinstallOverwriteBtn_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 110);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(160, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "Re-Install Resource Files (Clean)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 80);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(178, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "Re-Install Resource Files (Overwrite)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(3, 4);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(115, 20);
            this.label21.TabIndex = 1;
            this.label21.Text = "Resource Files";
            // 
            // seamlessJoeyWarn
            // 
            this.seamlessJoeyWarn.AutoSize = true;
            this.seamlessJoeyWarn.ForeColor = System.Drawing.Color.Silver;
            this.seamlessJoeyWarn.Location = new System.Drawing.Point(199, 170);
            this.seamlessJoeyWarn.Name = "seamlessJoeyWarn";
            this.seamlessJoeyWarn.Size = new System.Drawing.Size(182, 13);
            this.seamlessJoeyWarn.TabIndex = 16;
            this.seamlessJoeyWarn.Text = "Only Available With Joey\'s ESRGAN.";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox6.Image = global::Cupscale.Properties.Resources.questmark;
            this.pictureBox6.Location = new System.Drawing.Point(94, 166);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(22, 22);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 17;
            this.pictureBox6.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox6, "Use this if you want to upscale seamless/tiled textures.\r\nIt tried to preserve th" +
        "e tiling.");
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1104, 501);
            this.Controls.Add(this.tabList1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Cupscale Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabList1.ResumeLayout(false);
            this.settingsPage.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.formatsPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.logPage.ResumeLayout(false);
            this.logPage.PerformLayout();
            this.resourceFilesPage.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cyotek.Windows.Forms.TabList tabList1;
        private Cyotek.Windows.Forms.TabListPage settingsPage;
        private Cyotek.Windows.Forms.TabListPage logPage;
        private System.Windows.Forms.TextBox logTbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button confAlphaBgColorBtn;
        private System.Windows.Forms.TextBox alphaBgColor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox alpha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox tilesize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox modelPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog alphaBgColorDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox useCpu;
        private System.Windows.Forms.Label label2;
        private Cyotek.Windows.Forms.TabListPage formatsPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox webpQ;
        private System.Windows.Forms.TextBox jpegQ;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox ddsEnableMips;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox useNcnn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox esrganVersion;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox dxtMode;
        private System.Windows.Forms.ComboBox jpegExtension;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button selectModelsPathBtn;
        private System.Windows.Forms.ComboBox previewFormat;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.FolderBrowserDialog modelsPathDialog;
        private System.Windows.Forms.PictureBox pictureBox5;
        private Cyotek.Windows.Forms.TabListPage resourceFilesPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private HTAlt.WinForms.HTButton uninstallFullBtn;
        private System.Windows.Forms.Label label18;
        private HTAlt.WinForms.HTButton uninstallResBtn;
        private System.Windows.Forms.Label label17;
        private HTAlt.WinForms.HTButton reinstallCleanBtn;
        private HTAlt.WinForms.HTButton reinstallOverwriteBtn;
        private System.Windows.Forms.CheckBox seamless;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label seamlessJoeyWarn;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}