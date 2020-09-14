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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabList1 = new Cyotek.Windows.Forms.TabList();
            this.settingsPage = new Cyotek.Windows.Forms.TabListPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.confAlphaBgColorBtn = new System.Windows.Forms.Button();
            this.confAlphaBgColorTbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.confAlpha = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.confTilesize = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.modelPathBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.logPage = new Cyotek.Windows.Forms.TabListPage();
            this.logTbox = new System.Windows.Forms.TextBox();
            this.alphaBgColorDialog = new System.Windows.Forms.ColorDialog();
            this.tabList1.SuspendLayout();
            this.settingsPage.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.logPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabList1
            // 
            this.tabList1.Controls.Add(this.settingsPage);
            this.tabList1.Controls.Add(this.logPage);
            this.tabList1.ForeColor = System.Drawing.Color.White;
            this.tabList1.Location = new System.Drawing.Point(12, 12);
            this.tabList1.Name = "tabList1";
            this.tabList1.Size = new System.Drawing.Size(920, 477);
            this.tabList1.TabIndex = 0;
            // 
            // settingsPage
            // 
            this.settingsPage.Controls.Add(this.tableLayoutPanel3);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Size = new System.Drawing.Size(762, 469);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(762, 469);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.confAlphaBgColorBtn);
            this.panel7.Controls.Add(this.confAlphaBgColorTbox);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Controls.Add(this.confAlpha);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.confTilesize);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(375, 463);
            this.panel7.TabIndex = 4;
            // 
            // confAlphaBgColorBtn
            // 
            this.confAlphaBgColorBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.confAlphaBgColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confAlphaBgColorBtn.ForeColor = System.Drawing.Color.White;
            this.confAlphaBgColorBtn.Location = new System.Drawing.Point(232, 135);
            this.confAlphaBgColorBtn.Name = "confAlphaBgColorBtn";
            this.confAlphaBgColorBtn.Size = new System.Drawing.Size(28, 23);
            this.confAlphaBgColorBtn.TabIndex = 10;
            this.confAlphaBgColorBtn.Text = "...";
            this.confAlphaBgColorBtn.UseVisualStyleBackColor = false;
            this.confAlphaBgColorBtn.Click += new System.EventHandler(this.confAlphaBgColorBtn_Click);
            // 
            // confAlphaBgColorTbox
            // 
            this.confAlphaBgColorTbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.confAlphaBgColorTbox.ForeColor = System.Drawing.Color.White;
            this.confAlphaBgColorTbox.Location = new System.Drawing.Point(160, 137);
            this.confAlphaBgColorTbox.Name = "confAlphaBgColorTbox";
            this.confAlphaBgColorTbox.Size = new System.Drawing.Size(66, 20);
            this.confAlphaBgColorTbox.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Background Color";
            // 
            // confAlpha
            // 
            this.confAlpha.AutoSize = true;
            this.confAlpha.Location = new System.Drawing.Point(160, 110);
            this.confAlpha.Name = "confAlpha";
            this.confAlpha.Size = new System.Drawing.Size(15, 14);
            this.confAlpha.TabIndex = 5;
            this.confAlpha.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Enable Alpha";
            // 
            // confTilesize
            // 
            this.confTilesize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.confTilesize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confTilesize.ForeColor = System.Drawing.Color.White;
            this.confTilesize.FormattingEnabled = true;
            this.confTilesize.Items.AddRange(new object[] {
            "2048",
            "1536",
            "1024",
            "768",
            "512",
            "384",
            "256",
            "192",
            "128"});
            this.confTilesize.Location = new System.Drawing.Point(160, 77);
            this.confTilesize.Margin = new System.Windows.Forms.Padding(8);
            this.confTilesize.Name = "confTilesize";
            this.confTilesize.Size = new System.Drawing.Size(100, 21);
            this.confTilesize.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 80);
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
            this.panel6.Controls.Add(this.modelPathBox);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Location = new System.Drawing.Point(384, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(375, 463);
            this.panel6.TabIndex = 3;
            // 
            // modelPathBox
            // 
            this.modelPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.modelPathBox.ForeColor = System.Drawing.Color.White;
            this.modelPathBox.Location = new System.Drawing.Point(160, 77);
            this.modelPathBox.Name = "modelPathBox";
            this.modelPathBox.Size = new System.Drawing.Size(210, 20);
            this.modelPathBox.TabIndex = 7;
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
            // logPage
            // 
            this.logPage.Controls.Add(this.logTbox);
            this.logPage.Name = "logPage";
            this.logPage.Size = new System.Drawing.Size(762, 469);
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
            this.logTbox.Size = new System.Drawing.Size(762, 469);
            this.logTbox.TabIndex = 12;
            this.logTbox.VisibleChanged += new System.EventHandler(this.logTbox_VisibleChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.tabList1);
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
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
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
        private System.Windows.Forms.TextBox confAlphaBgColorTbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox confAlpha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox confTilesize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox modelPathBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog alphaBgColorDialog;
    }
}