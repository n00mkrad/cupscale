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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.jpegExtension = new System.Windows.Forms.TextBox();
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
            this.label14 = new System.Windows.Forms.Label();
            this.ddsUseDxt = new System.Windows.Forms.CheckBox();
            this.ddsMipsAmount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.webpQ = new System.Windows.Forms.TextBox();
            this.jpegQ = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logPage = new Cyotek.Windows.Forms.TabListPage();
            this.logTbox = new System.Windows.Forms.TextBox();
            this.alphaBgColorDialog = new System.Windows.Forms.ColorDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabList1.SuspendLayout();
            this.settingsPage.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.formatsPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.logPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabList1
            // 
            this.tabList1.Controls.Add(this.settingsPage);
            this.tabList1.Controls.Add(this.formatsPage);
            this.tabList1.Controls.Add(this.logPage);
            this.tabList1.ForeColor = System.Drawing.Color.White;
            this.tabList1.Location = new System.Drawing.Point(12, 12);
            this.tabList1.Name = "tabList1";
            this.tabList1.Size = new System.Drawing.Size(984, 477);
            this.tabList1.TabIndex = 0;
            // 
            // settingsPage
            // 
            this.settingsPage.Controls.Add(this.tableLayoutPanel3);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Size = new System.Drawing.Size(826, 469);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(826, 469);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panel7.Size = new System.Drawing.Size(407, 463);
            this.panel7.TabIndex = 4;
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
            this.toolTip.SetToolTip(this.pictureBox2, "Use esrgan-launcher for on-the-fly interpolation and model chaining.\r\nTry Joey\'s " +
        "ESRGAN if there are visible tiling seams.");
            this.pictureBox2.Visible = false;
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
            "(Coming Soon?)"});
            this.esrganVersion.Location = new System.Drawing.Point(180, 77);
            this.esrganVersion.Margin = new System.Windows.Forms.Padding(8);
            this.esrganVersion.Name = "esrganVersion";
            this.esrganVersion.Size = new System.Drawing.Size(217, 21);
            this.esrganVersion.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.Image = global::Cupscale.Properties.Resources.questmark;
            this.pictureBox1.Location = new System.Drawing.Point(114, 196);
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
            this.useNcnn.Location = new System.Drawing.Point(180, 200);
            this.useNcnn.Name = "useNcnn";
            this.useNcnn.Size = new System.Drawing.Size(15, 14);
            this.useNcnn.TabIndex = 9;
            this.useNcnn.UseVisualStyleBackColor = true;
            this.useNcnn.CheckedChanged += new System.EventHandler(this.useNcnn_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 200);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Use Vulkan (NCNN)";
            // 
            // useCpu
            // 
            this.useCpu.AutoSize = true;
            this.useCpu.Location = new System.Drawing.Point(180, 170);
            this.useCpu.Name = "useCpu";
            this.useCpu.Size = new System.Drawing.Size(15, 14);
            this.useCpu.TabIndex = 7;
            this.useCpu.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 170);
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
            this.panel6.Controls.Add(this.pictureBox3);
            this.panel6.Controls.Add(this.jpegExtension);
            this.panel6.Controls.Add(this.modelPath);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.confAlphaBgColorBtn);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.alphaBgColor);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Location = new System.Drawing.Point(416, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(407, 463);
            this.panel6.TabIndex = 3;
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
            // jpegExtension
            // 
            this.jpegExtension.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.jpegExtension.ForeColor = System.Drawing.Color.White;
            this.jpegExtension.Location = new System.Drawing.Point(180, 137);
            this.jpegExtension.Name = "jpegExtension";
            this.jpegExtension.Size = new System.Drawing.Size(66, 20);
            this.jpegExtension.TabIndex = 12;
            // 
            // modelPath
            // 
            this.modelPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.modelPath.ForeColor = System.Drawing.Color.White;
            this.modelPath.Location = new System.Drawing.Point(180, 77);
            this.modelPath.Name = "modelPath";
            this.modelPath.Size = new System.Drawing.Size(222, 20);
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
            this.confAlphaBgColorBtn.Location = new System.Drawing.Point(252, 105);
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
            this.alphaBgColor.Size = new System.Drawing.Size(66, 20);
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
            this.formatsPage.Size = new System.Drawing.Size(826, 469);
            this.formatsPage.Text = "Output Formats";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(826, 469);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.ddsUseDxt);
            this.panel1.Controls.Add(this.ddsMipsAmount);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.webpQ);
            this.panel1.Controls.Add(this.jpegQ);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 463);
            this.panel1.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Silver;
            this.label14.Location = new System.Drawing.Point(252, 170);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "Use 0 to disable mipmaps";
            // 
            // ddsUseDxt
            // 
            this.ddsUseDxt.AutoSize = true;
            this.ddsUseDxt.Location = new System.Drawing.Point(180, 140);
            this.ddsUseDxt.Name = "ddsUseDxt";
            this.ddsUseDxt.Size = new System.Drawing.Size(15, 14);
            this.ddsUseDxt.TabIndex = 17;
            this.ddsUseDxt.UseVisualStyleBackColor = true;
            // 
            // ddsMipsAmount
            // 
            this.ddsMipsAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ddsMipsAmount.ForeColor = System.Drawing.Color.White;
            this.ddsMipsAmount.Location = new System.Drawing.Point(180, 167);
            this.ddsMipsAmount.Name = "ddsMipsAmount";
            this.ddsMipsAmount.Size = new System.Drawing.Size(66, 20);
            this.ddsMipsAmount.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 170);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "DDS: Amount Of Mipmaps";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "DDS: Use DXT Compression";
            // 
            // webpQ
            // 
            this.webpQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.webpQ.ForeColor = System.Drawing.Color.White;
            this.webpQ.Location = new System.Drawing.Point(180, 107);
            this.webpQ.Name = "webpQ";
            this.webpQ.Size = new System.Drawing.Size(66, 20);
            this.webpQ.TabIndex = 13;
            // 
            // jpegQ
            // 
            this.jpegQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.jpegQ.ForeColor = System.Drawing.Color.White;
            this.jpegQ.Location = new System.Drawing.Point(180, 77);
            this.jpegQ.Name = "jpegQ";
            this.jpegQ.Size = new System.Drawing.Size(66, 20);
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
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(416, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(407, 463);
            this.panel2.TabIndex = 3;
            // 
            // logPage
            // 
            this.logPage.Controls.Add(this.logTbox);
            this.logPage.Name = "logPage";
            this.logPage.Size = new System.Drawing.Size(826, 469);
            this.logPage.Text = "View Log";
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
            this.logTbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTbox.Size = new System.Drawing.Size(826, 469);
            this.logTbox.TabIndex = 12;
            this.logTbox.VisibleChanged += new System.EventHandler(this.logTbox_VisibleChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1008, 501);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.formatsPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.logPage.ResumeLayout(false);
            this.logPage.PerformLayout();
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
        private System.Windows.Forms.TextBox jpegExtension;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox ddsUseDxt;
        private System.Windows.Forms.TextBox ddsMipsAmount;
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
    }
}