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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            Show();
            CenterToParent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Program.mainForm.Enabled = false;
            Logger.textbox = logTbox;
            ConfigTabHelper.LoadEsrganSettings(confTilesize, confAlpha, modelPathBox, confAlphaBgColorTbox);
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigTabHelper.SaveSettings(confTilesize, confAlpha, modelPathBox, confAlphaBgColorTbox);
            Program.mainForm.Enabled = true;
        }

        private void confAlphaBgColorBtn_Click(object sender, EventArgs e)
        {
            alphaBgColorDialog.ShowDialog();
            string colorStr = ColorTranslator.ToHtml(Color.FromArgb(alphaBgColorDialog.Color.ToArgb())).Replace("#", "") + "FF";
            confAlphaBgColorTbox.Text = colorStr;
            Config.Set("alphaBgColor", colorStr);
        }

        private void logTbox_VisibleChanged(object sender, EventArgs e)
        {
            if (logTbox.Visible)
                logTbox.Text = Logger.GetSessionLog();
        }
    }
}
