using Cupscale.UI;
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
        public DialogForm(string message, float selfDestructTime = 60f)
        {
            InitializeComponent();
            Program.currentTemporaryForms.Add(this);
            mainLabel.Text = message;
            Show();
            //TopMost = true;
            SelfDestruct(selfDestructTime);
        }

        public void ChangeText (string s)
        {
            mainLabel.Text = s;
        }

        public string GetText ()
        {
            return mainLabel.Text;
        }

        private async Task SelfDestruct (float time)
        {
            await Task.Delay((time * 1000f).RoundToInt());
            Close();
        }

        private void DialogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.currentTemporaryForms.Remove(this);
        }
    }
}
