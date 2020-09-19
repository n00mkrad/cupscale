using Cupscale.IO;
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

namespace Cupscale.Forms
{
    public partial class ModelSelectForm : Form
    {
        public string selectedModel;

        public ModelSelectForm()
        {
            InitializeComponent();
            Show();
            CenterToScreen();
        }

        private void ModelSelectForm_Load(object sender, EventArgs e)
        {
            DirectoryInfo modelsDir = new DirectoryInfo(Config.Get("modelPath"));
            BuildTree(modelsDir, modelTree.Nodes);
            modelTree.ExpandAll();
        }

        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.Name);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                curNode.Nodes.Add(file.FullName, Path.ChangeExtension(file.Name, null));
            }
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                if(subdir.GetFiles().Length > 0)
                    BuildTree(subdir, curNode.Nodes);
            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            selectedModel = modelTree.SelectedNode.Text;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
