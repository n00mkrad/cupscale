namespace Cupscale.Forms
{
    partial class AdvancedModelsForm
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
            this.interpSlider = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.leftModelLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rightModelLabel = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.interpSlider)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // interpSlider
            // 
            this.interpSlider.Location = new System.Drawing.Point(109, 185);
            this.interpSlider.Margin = new System.Windows.Forms.Padding(100, 10, 100, 10);
            this.interpSlider.Maximum = 20;
            this.interpSlider.Name = "interpSlider";
            this.interpSlider.Size = new System.Drawing.Size(366, 45);
            this.interpSlider.TabIndex = 0;
            this.interpSlider.Value = 10;
            this.interpSlider.ValueChanged += new System.EventHandler(this.interpSlider_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(560, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Drag the slider to adjust how strong the effect of each model will be.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.leftModelLabel);
            this.panel1.Location = new System.Drawing.Point(12, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 40);
            this.panel1.TabIndex = 2;
            // 
            // leftModelLabel
            // 
            this.leftModelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftModelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftModelLabel.Location = new System.Drawing.Point(0, 0);
            this.leftModelLabel.Margin = new System.Windows.Forms.Padding(3);
            this.leftModelLabel.Name = "leftModelLabel";
            this.leftModelLabel.Size = new System.Drawing.Size(558, 38);
            this.leftModelLabel.TabIndex = 0;
            this.leftModelLabel.Text = "Left Model Name: 50%";
            this.leftModelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rightModelLabel);
            this.panel2.Location = new System.Drawing.Point(12, 125);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 40);
            this.panel2.TabIndex = 3;
            // 
            // rightModelLabel
            // 
            this.rightModelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightModelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightModelLabel.Location = new System.Drawing.Point(0, 0);
            this.rightModelLabel.Name = "rightModelLabel";
            this.rightModelLabel.Size = new System.Drawing.Size(558, 38);
            this.rightModelLabel.TabIndex = 0;
            this.rightModelLabel.Text = "Right Model Name: 50%";
            this.rightModelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Location = new System.Drawing.Point(159, 243);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(150, 3, 150, 3);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(266, 30);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // AdvancedModelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(584, 285);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.interpSlider);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AdvancedModelsForm";
            this.Text = "Set Interpolation Factor";
            this.Load += new System.EventHandler(this.InterpForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.interpSlider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar interpSlider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label leftModelLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label rightModelLabel;
        private System.Windows.Forms.Button saveBtn;
    }
}