using Cupscale.Main;
using Cupscale.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Cupscale.Main.AdvancedModelSelection;

namespace Cupscale.Forms
{
    public partial class AdvancedModelForm : Form
    {

        public AdvancedModelForm()
        {
            InitializeComponent();
            Show();
        }

        private void entry1Model1Interp_TextChanged(object sender, EventArgs e)
        {
            int input = entry1Model1Interp.GetInt().Clamp(0, 100);
            entry1Model1Interp.Text = input.ToString();
            e1m1i = input;
            e1m2i = 100 - e1m1i;
            entry1Model2Interp.Text = e1m2i.ToString();
        }

        private void entry2Model1Interp_TextChanged(object sender, EventArgs e)
        {
            int input = entry2Model1Interp.GetInt().Clamp(0, 100);
            entry2Model1Interp.Text = input.ToString();
            e2m1i = input;
            e2m2i = 100 - e2m1i;
            entry2Model2Interp.Text = e2m2i.ToString();
        }

        private void entry3Model1Interp_TextChanged(object sender, EventArgs e)
        {
            int input = entry3Model1Interp.GetInt().Clamp(0, 100);
            entry3Model1Interp.Text = input.ToString();
            e3m1i = input;
            e3m2i = 100 - e3m1i;
            entry3Model2Interp.Text = e3m2i.ToString();
        }

        private void entry1Model1_Click(object sender, EventArgs e)
        {
            using (var modelForm = new ModelSelectForm(entry1Model1, 0))
            {
                if (modelForm.ShowDialog() == DialogResult.OK)
                    e1m1 = modelForm.selectedModel;
            }
        }

        private void entry1Model2_Click(object sender, EventArgs e)
        {
            using (var modelForm = new ModelSelectForm(entry1Model2, 0))
            {
                if (modelForm.ShowDialog() == DialogResult.OK)
                    e1m2 = modelForm.selectedModel;
            }
        }

        private void entry2Model1_Click(object sender, EventArgs e)
        {
            using (var modelForm = new ModelSelectForm(entry2Model1, 0))
            {
                if (modelForm.ShowDialog() == DialogResult.OK)
                    e2m1 = modelForm.selectedModel;
            }
        }

        private void entry2Model2_Click(object sender, EventArgs e)
        {
            using (var modelForm = new ModelSelectForm(entry2Model2, 0))
            {
                if (modelForm.ShowDialog() == DialogResult.OK)
                    e2m2 = modelForm.selectedModel;
            }
        }

        private void entry3Model1_Click(object sender, EventArgs e)
        {
            using (var modelForm = new ModelSelectForm(entry3Model1, 0))
            {
                if (modelForm.ShowDialog() == DialogResult.OK)
                    e3m1 = modelForm.selectedModel;
            }
        }

        private void entry3Model2_Click(object sender, EventArgs e)
        {
            using (var modelForm = new ModelSelectForm(entry3Model2, 0))
            {
                if (modelForm.ShowDialog() == DialogResult.OK)
                    e3m2 = modelForm.selectedModel;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            e1m1 = null;
            e1m2 = null;
            e2m1 = null;
            e2m2 = null;
            e3m1 = null;
            e3m2 = null;
            Close();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            Logger.Log("Advanced Model Arg: " + GetArg());
            SavePreset("lastUsed");
            Close();
        }

        private void AdvancedModelForm_Load(object sender, EventArgs e)
        {
            if (!LoadPreset("lastUsed"))
                return;

            ChangeButtonText(entry1Model1, GetModelName(e1m1));
            entry1Model1Interp.Text = e1m1i.ToString();
            ChangeButtonText(entry1Model2, GetModelName(e1m2));
            entry1Model2Interp.Text = e1m2i.ToString();

            ChangeButtonText(entry2Model1, GetModelName(e2m1));
            entry2Model1Interp.Text = e2m1i.ToString();
            ChangeButtonText(entry2Model2, GetModelName(e2m2));
            entry2Model2Interp.Text = e3m2i.ToString();

            ChangeButtonText(entry3Model1, GetModelName(e3m1));
            entry3Model1Interp.Text = e3m1i.ToString();
            ChangeButtonText(entry3Model2, GetModelName(e3m2));
            entry3Model2Interp.Text = e3m2i.ToString();
        }

        void ChangeButtonText (Button btn, string newText)
        {
            if (!string.IsNullOrWhiteSpace(newText))
                btn.Text = newText;

        }

        string GetModelName (string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }
    }
}
