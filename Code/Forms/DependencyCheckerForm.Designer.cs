namespace Cupscale.Forms
{
    partial class DependencyCheckerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DependencyCheckerForm));
            this.tabList1 = new Cyotek.Windows.Forms.TabList();
            this.tabListPage1 = new Cyotek.Windows.Forms.TabListPage();
            this.tabListPage2 = new Cyotek.Windows.Forms.TabListPage();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nvGpu = new System.Windows.Forms.Label();
            this.sysPython = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.embedPython = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.torch = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cv2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.installBtn = new HTAlt.WinForms.HTButton();
            this.label16 = new System.Windows.Forms.Label();
            this.installerLogBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gpu = new System.Windows.Forms.Label();
            this.tabList1.SuspendLayout();
            this.tabListPage1.SuspendLayout();
            this.tabListPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabList1
            // 
            this.tabList1.Controls.Add(this.tabListPage1);
            this.tabList1.Controls.Add(this.tabListPage2);
            this.tabList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabList1.ForeColor = System.Drawing.Color.White;
            this.tabList1.Location = new System.Drawing.Point(0, 0);
            this.tabList1.Name = "tabList1";
            this.tabList1.Size = new System.Drawing.Size(714, 451);
            this.tabList1.TabIndex = 0;
            // 
            // tabListPage1
            // 
            this.tabListPage1.Controls.Add(this.gpu);
            this.tabListPage1.Controls.Add(this.label5);
            this.tabListPage1.Controls.Add(this.label7);
            this.tabListPage1.Controls.Add(this.cv2);
            this.tabListPage1.Controls.Add(this.label2);
            this.tabListPage1.Controls.Add(this.label8);
            this.tabListPage1.Controls.Add(this.torch);
            this.tabListPage1.Controls.Add(this.label6);
            this.tabListPage1.Controls.Add(this.embedPython);
            this.tabListPage1.Controls.Add(this.label4);
            this.tabListPage1.Controls.Add(this.sysPython);
            this.tabListPage1.Controls.Add(this.nvGpu);
            this.tabListPage1.Controls.Add(this.label1);
            this.tabListPage1.Controls.Add(this.label14);
            this.tabListPage1.Name = "tabListPage1";
            this.tabListPage1.Size = new System.Drawing.Size(556, 443);
            this.tabListPage1.Text = "Dependency Status";
            // 
            // tabListPage2
            // 
            this.tabListPage2.Controls.Add(this.installerLogBox);
            this.tabListPage2.Controls.Add(this.label16);
            this.tabListPage2.Controls.Add(this.installBtn);
            this.tabListPage2.Controls.Add(this.label3);
            this.tabListPage2.Name = "tabListPage2";
            this.tabListPage2.Size = new System.Drawing.Size(556, 443);
            this.tabListPage2.Text = "Embedded Python Installer";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(6, 112);
            this.label14.Margin = new System.Windows.Forms.Padding(6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 20);
            this.label14.TabIndex = 20;
            this.label14.Text = "Nvidia GPU:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 144);
            this.label1.Margin = new System.Windows.Forms.Padding(6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "System Python:";
            // 
            // nvGpu
            // 
            this.nvGpu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nvGpu.AutoSize = true;
            this.nvGpu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nvGpu.ForeColor = System.Drawing.Color.Silver;
            this.nvGpu.Location = new System.Drawing.Point(287, 112);
            this.nvGpu.Margin = new System.Windows.Forms.Padding(6);
            this.nvGpu.Name = "nvGpu";
            this.nvGpu.Size = new System.Drawing.Size(98, 20);
            this.nvGpu.TabIndex = 22;
            this.nvGpu.Text = "Checking...";
            // 
            // sysPython
            // 
            this.sysPython.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sysPython.AutoSize = true;
            this.sysPython.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sysPython.ForeColor = System.Drawing.Color.Silver;
            this.sysPython.Location = new System.Drawing.Point(287, 144);
            this.sysPython.Margin = new System.Windows.Forms.Padding(6);
            this.sysPython.Name = "sysPython";
            this.sysPython.Size = new System.Drawing.Size(98, 20);
            this.sysPython.TabIndex = 23;
            this.sysPython.Text = "Checking...";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 176);
            this.label4.Margin = new System.Windows.Forms.Padding(6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Embedded Python:";
            // 
            // embedPython
            // 
            this.embedPython.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.embedPython.AutoSize = true;
            this.embedPython.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.embedPython.ForeColor = System.Drawing.Color.Silver;
            this.embedPython.Location = new System.Drawing.Point(287, 176);
            this.embedPython.Margin = new System.Windows.Forms.Padding(6);
            this.embedPython.Name = "embedPython";
            this.embedPython.Size = new System.Drawing.Size(98, 20);
            this.embedPython.TabIndex = 25;
            this.embedPython.Text = "Checking...";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(6, 208);
            this.label6.Margin = new System.Windows.Forms.Padding(6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "[Python] Torch:";
            // 
            // torch
            // 
            this.torch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.torch.AutoSize = true;
            this.torch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.torch.ForeColor = System.Drawing.Color.Silver;
            this.torch.Location = new System.Drawing.Point(287, 208);
            this.torch.Margin = new System.Windows.Forms.Padding(6);
            this.torch.Name = "torch";
            this.torch.Size = new System.Drawing.Size(98, 20);
            this.torch.TabIndex = 27;
            this.torch.Text = "Checking...";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 240);
            this.label2.Margin = new System.Windows.Forms.Padding(6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "[Python] OpenCV:";
            // 
            // cv2
            // 
            this.cv2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cv2.AutoSize = true;
            this.cv2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cv2.ForeColor = System.Drawing.Color.Silver;
            this.cv2.Location = new System.Drawing.Point(287, 240);
            this.cv2.Margin = new System.Windows.Forms.Padding(6);
            this.cv2.Name = "cv2";
            this.cv2.Size = new System.Drawing.Size(98, 20);
            this.cv2.TabIndex = 29;
            this.cv2.Text = "Checking...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Dependencies";
            this.label8.VisibleChanged += new System.EventHandler(this.label8_VisibleChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Install Embedded Python";
            // 
            // installBtn
            // 
            this.installBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.installBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.installBtn.FlatAppearance.BorderSize = 0;
            this.installBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.installBtn.ForeColor = System.Drawing.Color.White;
            this.installBtn.Location = new System.Drawing.Point(348, 71);
            this.installBtn.Name = "installBtn";
            this.installBtn.Size = new System.Drawing.Size(200, 30);
            this.installBtn.TabIndex = 32;
            this.installBtn.Text = "Install";
            this.installBtn.UseVisualStyleBackColor = false;
            this.installBtn.Click += new System.EventHandler(this.installBtn_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(311, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "Download And Install Embedded Python With All Dependencies:";
            // 
            // installerLogBox
            // 
            this.installerLogBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.installerLogBox.ForeColor = System.Drawing.Color.Silver;
            this.installerLogBox.Location = new System.Drawing.Point(24, 128);
            this.installerLogBox.Margin = new System.Windows.Forms.Padding(24);
            this.installerLogBox.Multiline = true;
            this.installerLogBox.Name = "installerLogBox";
            this.installerLogBox.ReadOnly = true;
            this.installerLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.installerLogBox.Size = new System.Drawing.Size(503, 286);
            this.installerLogBox.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(6, 304);
            this.label7.Margin = new System.Windows.Forms.Padding(6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(539, 128);
            this.label7.TabIndex = 31;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(6, 80);
            this.label5.Margin = new System.Windows.Forms.Padding(6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "GPU:";
            // 
            // gpu
            // 
            this.gpu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gpu.AutoSize = true;
            this.gpu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpu.ForeColor = System.Drawing.Color.Silver;
            this.gpu.Location = new System.Drawing.Point(287, 80);
            this.gpu.Margin = new System.Windows.Forms.Padding(6);
            this.gpu.Name = "gpu";
            this.gpu.Size = new System.Drawing.Size(98, 20);
            this.gpu.TabIndex = 33;
            this.gpu.Text = "Checking...";
            // 
            // DependencyCheckerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(714, 451);
            this.Controls.Add(this.tabList1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DependencyCheckerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dependency Checker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DependencyCheckerForm_FormClosing);
            this.Load += new System.EventHandler(this.DependencyCheckerForm_Load);
            this.tabList1.ResumeLayout(false);
            this.tabListPage1.ResumeLayout(false);
            this.tabListPage1.PerformLayout();
            this.tabListPage2.ResumeLayout(false);
            this.tabListPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Cyotek.Windows.Forms.TabList tabList1;
        private Cyotek.Windows.Forms.TabListPage tabListPage1;
        private Cyotek.Windows.Forms.TabListPage tabListPage2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label torch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label embedPython;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label sysPython;
        private System.Windows.Forms.Label nvGpu;
        private System.Windows.Forms.Label cv2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private HTAlt.WinForms.HTButton installBtn;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox installerLogBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label gpu;
        private System.Windows.Forms.Label label5;
    }
}