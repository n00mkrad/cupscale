namespace Cupscale.Forms
{
    partial class ModelComparisonForm
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
            this.cancelBtn = new HTAlt.WinForms.HTButton();
            this.runBtn = new HTAlt.WinForms.HTButton();
            this.modelPathsBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.addModelBtn = new HTAlt.WinForms.HTButton();
            this.compositionMode = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comparisonMode = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.scaleFactor = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cropMode = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.Location = new System.Drawing.Point(367, 404);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(6, 6, 180, 6);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(158, 32);
            this.cancelBtn.TabIndex = 49;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.runBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.runBtn.FlatAppearance.BorderSize = 0;
            this.runBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runBtn.ForeColor = System.Drawing.Color.White;
            this.runBtn.Location = new System.Drawing.Point(189, 404);
            this.runBtn.Margin = new System.Windows.Forms.Padding(180, 6, 6, 6);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(158, 32);
            this.runBtn.TabIndex = 48;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = false;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // modelPathsBox
            // 
            this.modelPathsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.modelPathsBox.ForeColor = System.Drawing.Color.White;
            this.modelPathsBox.Location = new System.Drawing.Point(222, 136);
            this.modelPathsBox.Margin = new System.Windows.Forms.Padding(8);
            this.modelPathsBox.Multiline = true;
            this.modelPathsBox.Name = "modelPathsBox";
            this.modelPathsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.modelPathsBox.Size = new System.Drawing.Size(475, 254);
            this.modelPathsBox.TabIndex = 50;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(12, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(593, 15);
            this.label16.TabIndex = 51;
            this.label16.Text = "Here you can create an image that compares multiple models based on the currently" +
    " loaded preview image.";
            // 
            // addModelBtn
            // 
            this.addModelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addModelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addModelBtn.FlatAppearance.BorderSize = 0;
            this.addModelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addModelBtn.ForeColor = System.Drawing.Color.White;
            this.addModelBtn.Location = new System.Drawing.Point(539, 90);
            this.addModelBtn.Margin = new System.Windows.Forms.Padding(180, 6, 6, 6);
            this.addModelBtn.Name = "addModelBtn";
            this.addModelBtn.Size = new System.Drawing.Size(158, 32);
            this.addModelBtn.TabIndex = 52;
            this.addModelBtn.Text = "Add Model";
            this.addModelBtn.UseVisualStyleBackColor = false;
            this.addModelBtn.Click += new System.EventHandler(this.addModelBtn_Click);
            // 
            // compositionMode
            // 
            this.compositionMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.compositionMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compositionMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.compositionMode.ForeColor = System.Drawing.Color.White;
            this.compositionMode.FormattingEnabled = true;
            this.compositionMode.Items.AddRange(new object[] {
            "Horizonal",
            "Vertical"});
            this.compositionMode.Location = new System.Drawing.Point(11, 24);
            this.compositionMode.Margin = new System.Windows.Forms.Padding(8);
            this.compositionMode.Name = "compositionMode";
            this.compositionMode.Size = new System.Drawing.Size(175, 21);
            this.compositionMode.TabIndex = 53;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.compositionMode);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(15, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 59);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Composition Mode";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comparisonMode);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(15, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 59);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Comparison Mode";
            // 
            // comparisonMode
            // 
            this.comparisonMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comparisonMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comparisonMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comparisonMode.ForeColor = System.Drawing.Color.White;
            this.comparisonMode.FormattingEnabled = true;
            this.comparisonMode.Items.AddRange(new object[] {
            "Original + Models",
            "Only Models"});
            this.comparisonMode.Location = new System.Drawing.Point(11, 24);
            this.comparisonMode.Margin = new System.Windows.Forms.Padding(8);
            this.comparisonMode.Name = "comparisonMode";
            this.comparisonMode.Size = new System.Drawing.Size(175, 21);
            this.comparisonMode.TabIndex = 53;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.scaleFactor);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(15, 331);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(196, 59);
            this.groupBox3.TabIndex = 57;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Scale (Relative To Original)";
            // 
            // scaleFactor
            // 
            this.scaleFactor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.scaleFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scaleFactor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scaleFactor.ForeColor = System.Drawing.Color.White;
            this.scaleFactor.FormattingEnabled = true;
            this.scaleFactor.Items.AddRange(new object[] {
            "1x (Same As Original)",
            "2x",
            "4x",
            "8x"});
            this.scaleFactor.Location = new System.Drawing.Point(11, 24);
            this.scaleFactor.Margin = new System.Windows.Forms.Padding(8);
            this.scaleFactor.Name = "scaleFactor";
            this.scaleFactor.Size = new System.Drawing.Size(175, 21);
            this.scaleFactor.TabIndex = 53;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cropMode);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(15, 136);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(196, 59);
            this.groupBox4.TabIndex = 56;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Image Crop Mode";
            // 
            // cropMode
            // 
            this.cropMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cropMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cropMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cropMode.ForeColor = System.Drawing.Color.White;
            this.cropMode.FormattingEnabled = true;
            this.cropMode.Items.AddRange(new object[] {
            "Use Full Image",
            "Use Current Preview Cutout"});
            this.cropMode.Location = new System.Drawing.Point(11, 24);
            this.cropMode.Margin = new System.Windows.Forms.Padding(8);
            this.cropMode.Name = "cropMode";
            this.cropMode.Size = new System.Drawing.Size(175, 21);
            this.cropMode.TabIndex = 53;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(226, 96);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(231, 26);
            this.label21.TabIndex = 58;
            this.label21.Text = "Model Paths:\r\nAlso works with models outside the model folder";
            // 
            // ModelComparisonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(714, 451);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.addModelBtn);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.modelPathsBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.runBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ModelComparisonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Model Comparison Wizard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModelComparisonForm_FormClosing);
            this.Load += new System.EventHandler(this.ModelComparisonForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HTAlt.WinForms.HTButton cancelBtn;
        private HTAlt.WinForms.HTButton runBtn;
        private System.Windows.Forms.TextBox modelPathsBox;
        private System.Windows.Forms.Label label16;
        private HTAlt.WinForms.HTButton addModelBtn;
        private System.Windows.Forms.ComboBox compositionMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comparisonMode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox scaleFactor;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cropMode;
        private System.Windows.Forms.Label label21;
    }
}