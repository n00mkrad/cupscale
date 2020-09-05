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
        public DialogForm(string message)
        {
            InitializeComponent();
            mainLabel.Text = message;
            Show();
            TopMost = true;
        }
    }
}
