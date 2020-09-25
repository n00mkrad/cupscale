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
    public partial class DialogForm : Form
    {
        public DialogForm(string message, int selfDestructTime = 60)
        {
            InitializeComponent();
            Program.currentTemporaryForms.Add(this);
            mainLabel.Text = message;
            Show();
            TopMost = true;
            SelfDestruct(selfDestructTime);
        }

        private async Task SelfDestruct (int time)
        {
            await Task.Delay(time * 1000);
            Close();
        }

        private void DialogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.currentTemporaryForms.Remove(this);
        }
    }
}
