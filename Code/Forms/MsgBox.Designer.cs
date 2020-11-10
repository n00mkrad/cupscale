namespace Cupscale.Forms
{
    partial class MsgBox
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
            this.confirmBtn = new HTAlt.WinForms.HTButton();
            this.msgTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // confirmBtn
            // 
            this.confirmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.confirmBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.confirmBtn.FlatAppearance.BorderSize = 0;
            this.confirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmBtn.ForeColor = System.Drawing.Color.White;
            this.confirmBtn.Location = new System.Drawing.Point(407, 177);
            this.confirmBtn.Margin = new System.Windows.Forms.Padding(8);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(200, 32);
            this.confirmBtn.TabIndex = 13;
            this.confirmBtn.Text = "OK";
            this.confirmBtn.UseVisualStyleBackColor = false;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // msgTextbox
            // 
            this.msgTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.msgTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.msgTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgTextbox.ForeColor = System.Drawing.Color.White;
            this.msgTextbox.Location = new System.Drawing.Point(28, 17);
            this.msgTextbox.Margin = new System.Windows.Forms.Padding(8);
            this.msgTextbox.Multiline = true;
            this.msgTextbox.Name = "msgTextbox";
            this.msgTextbox.ReadOnly = true;
            this.msgTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.msgTextbox.Size = new System.Drawing.Size(579, 144);
            this.msgTextbox.TabIndex = 35;
            this.msgTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.msgTextbox.TextChanged += new System.EventHandler(this.msgTextbox_TextChanged);
            // 
            // MsgBox
            // 
            this.AcceptButton = this.confirmBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(624, 226);
            this.Controls.Add(this.msgTextbox);
            this.Controls.Add(this.confirmBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MsgBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MsgBox_FormClosing);
            this.Load += new System.EventHandler(this.MsgBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HTAlt.WinForms.HTButton confirmBtn;
        private System.Windows.Forms.TextBox msgTextbox;
    }
}