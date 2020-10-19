using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cupscale.Forms
{
    public partial class MsgBox : Form
    {
        public MsgBox(string msg, string title = "Message")
        {
            InitializeComponent();
            Text = title;
            msgLabel.Text = msg;
        }

        private void MsgBox_Load(object sender, EventArgs e)
        {

        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
