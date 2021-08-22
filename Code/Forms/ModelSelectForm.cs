using Cupscale.IO;
using Cupscale.OS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public string selectedModel { get; set; }
        public int modelNo;
        public Button modelBtn;

        public ModelSelectForm(Button modelButton, int modelNumber)
        {
            InitializeComponent();
            modelBtn = modelButton;
            modelNo = modelNumber;
            SelectLastUsed();
        }

        private void ModelSelectForm_Load(object sender, EventArgs e)
        {
            string modelDir = Config.Get("modelPath");

            if (!Directory.Exists(modelDir))
            {
                Program.ShowMessage("The saved model directory does not exist - Make sure you've set a models folder!");
                Close();
                return;
            }

            if (IoUtils.GetAmountOfFiles(modelDir, true, "*.pth") < 1)
            {
                Program.ShowMessage($"The saved model directory does not contain any model (.pth) files!\n\nPlease put some models into '{modelDir}'.");
                Close();
                Process.Start("explorer.exe", Config.Get("modelPath"));
                return;
            }

            ForceLowercaseExtensions(modelDir);
            DirectoryInfo modelsDir = new DirectoryInfo(modelDir);
            BuildTree(modelsDir, modelTree.Nodes);

            if (Config.GetBool("modelSelectAutoExpand"))
                modelTree.ExpandAll();
            else
                modelTree.Nodes[0].Expand();
        }

        private async void SelectLastUsed()
        {
            if (!Directory.Exists(Config.Get("modelPath")))
                return;

            while (modelTree.Nodes.Count < 1)
                await Task.Delay(100);

            if (string.IsNullOrWhiteSpace(Program.currentModel1))
                modelTree.SelectedNode = modelTree.Nodes[0];
            else
                CheckNodesRecursive(modelTree.Nodes[0]);
        }

        private void CheckNodesRecursive(TreeNode parentNode)
        {
            if (modelBtn != null && parentNode.Text.Trim() == modelBtn.Text.Trim())
                modelTree.SelectedNode = parentNode;

            foreach (TreeNode subNode in parentNode.Nodes)
            {
                CheckNodesRecursive(subNode);
            }
        }

        private void ForceLowercaseExtensions(string path)
        {
            foreach (FileInfo file in IoUtils.GetFileInfosSorted(path, true, "*.*"))
            {
                if (file.Extension == ".PTH")
                    file.MoveTo(Path.ChangeExtension(file.FullName, "pth"));
            }
        }

        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection nodeCollection)
        {
            TreeNode currNode = nodeCollection.Add(directoryInfo.Name);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                if (file.Extension == ".pth")    // Hide any other file extension
                    currNode.Nodes.Add(file.FullName, Path.ChangeExtension(file.Name, null));
            }

            foreach (DirectoryInfo subDir in directoryInfo.GetDirectories())
            {
                bool isNcnnModel = NcnnUtils.IsDirNcnnModel(subDir.FullName);

                if (isNcnnModel)
                    currNode.Nodes.Add(subDir.FullName, subDir.Name.Substring(0, subDir.Name.Length - 5));

                bool hasAnyPthFiles = subDir.GetFiles("*.pth", SearchOption.AllDirectories).Length > 0;
                bool hasAnyBinFiles = subDir.GetFiles("*.bin", SearchOption.AllDirectories).Length > 0;
                bool hasAnyParamFiles = subDir.GetFiles("*.param", SearchOption.AllDirectories).Length > 0;

                if (isNcnnModel || subDir.Name.StartsWith("."))
                    continue;   // Don't add this folder to the tree if it's a model, not a dir with more models

                if (hasAnyPthFiles || hasAnyBinFiles || hasAnyParamFiles)     // Don't list folders that have no model files
                    BuildTree(subDir, currNode.Nodes);
            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            selectedModel = modelTree.SelectedNode.Name;
            string modelName = Path.GetFileNameWithoutExtension(selectedModel);

            if (modelBtn != null)
                modelBtn.Text = modelName;

            if (modelNo == 1) Program.currentModel1 = selectedModel;
            if (modelNo == 2) Program.currentModel2 = selectedModel;

            Config.Set("lastMdl1", Program.currentModel1);
            Config.Set("lastMdl2", Program.currentModel2);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void modelTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            confirmBtn.Enabled = (Path.GetExtension(modelTree.SelectedNode.Name) == ".pth" || modelTree.SelectedNode.Name.EndsWith(".ncnn"));
        }

        private void ModelSelectForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (confirmBtn.Enabled)
                    confirmBtn_Click(null, null);
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            selectedModel = "";
            modelBtn.Text = "None";
            if (modelNo == 1) Program.currentModel1 = null;
            if (modelNo == 2) Program.currentModel2 = null;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void openFolderBtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Config.Get("modelPath"));
        }
    }
}
