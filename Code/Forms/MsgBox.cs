using Cupscale.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cupscale.Forms
{
    public partial class MsgBox : Form
    {
        public bool usedConfirmBtn;

        public MsgBox(string msg, string title = "Message")
        {
            InitializeComponent();
            Text = title;
            msgTextbox.Text = msg;
        }

        private void MsgBox_Load(object sender, EventArgs e)
        {

        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            usedConfirmBtn = true;
            DialogResult = DialogResult.OK;
            DialogQueue.CloseCurrent();
        }

        private void msgTextbox_TextChanged(object sender, EventArgs e)
        {
            int linebreaks = Regex.Split(msgTextbox.Text, "\r\n|\r|\n").Length;
            if (linebreaks > 6)
                msgTextbox.ScrollBars = ScrollBars.Vertical;
            else
                msgTextbox.ScrollBars = ScrollBars.None;

            if (linebreaks > 10)
                Size = new Size(Size.Width, 450);

            if (msgTextbox.Text.Contains("Stack Trace"))
                msgTextbox.TextAlign = HorizontalAlignment.Left;
            else
                msgTextbox.TextAlign = HorizontalAlignment.Center;
        }

        private void MsgBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!usedConfirmBtn)
            {
                DialogResult = DialogResult.OK;
                DialogQueue.CloseCurrent();
            }
        }
    }
}
