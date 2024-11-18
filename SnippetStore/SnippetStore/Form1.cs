using MongoDB.Driver;
using System.Diagnostics;

namespace SnippetStore
{
    public partial class MainForm : Form
    {
        private ToolStripStatusLabel statusLabelDate;
        private string? snippetId;
        public MainForm()
        {
            InitializeComponent();
            UpdateTreeView();
            statusLabelDate = new ToolStripStatusLabel { Text = DateTime.Now.ToString() };
            statusStrip1.Items.Add(statusLabelDate);
        }
        private void btnAddNewClick(object sender, EventArgs e)
        {
            AddNewSnippetForm addNewSnippetForm = new AddNewSnippetForm();
            addNewSnippetForm.Show();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            SetupForm setupForm = new SetupForm();
            setupForm.Show();
        }

        public void UpdateTreeView()
        {
            treeView1.Nodes.Clear();
            var mongoHelper = new MongoHelper();
            var SnipData = mongoHelper.GetSnipets().AsQueryable().ToList().GroupBy(l => l.SnipLanguage);

            foreach (var data in SnipData)
            {
                TreeNode node = new TreeNode(data.Key);
                node.Tag = data;
                treeView1.Nodes.Add(node);

                var snipName = data.GroupBy(n => n.SnipName);

                foreach (var name in snipName)
                {
                    TreeNode snipNode = new TreeNode(name.Key);
                    snipNode.Tag = name;
                    node.Nodes.Add(snipNode);
                }
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            UpdateTreeView();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            MongoHelper mongoHelper = new MongoHelper();

            rtbMainCode.Clear();
            snippetId = mongoHelper.GetMongoIdFromSnipetName(e.Node.Text);
            if (snippetId != null) { rtbMainCode.Rtf = mongoHelper.GetCodeSnipetById(snippetId); }
            if (rtbMainCode.Text == "")
            {
                btnDel.Enabled = false;
                btnEdit.Enabled = false;
            }
            else
            {
                btnDel.Enabled = true;
                btnEdit.Enabled = true;
            }

            //Debug.WriteLine(mongoHelper.GedMongoIdFromSnipetName(e.Node.Text));            
        }

        private void OnTypeSearch(object sender, EventArgs e)
        {
            if (tbSearch.Text != "")
            {
                treeView1.Nodes.Clear();
                var mongoHelper = new MongoHelper();
                var SnipData = mongoHelper.GetSnipets().AsQueryable()
                    .Where(x => x.SnipKeywords.Contains(tbSearch.Text) ||
                                x.SnipName.Contains(tbSearch.Text) ||
                                x.SnipShortDesc.Contains(tbSearch.Text) ||
                                x.SnipCode.Contains(tbSearch.Text))
                    .ToList().GroupBy(l => l.SnipLanguage);

                foreach (var data in SnipData)
                {
                    TreeNode node = new TreeNode(data.Key);
                    node.Tag = data;
                    treeView1.Nodes.Add(node);

                    var snipName = data.GroupBy(n => n.SnipName);

                    foreach (var name in snipName)
                    {
                        TreeNode snipNode = new TreeNode(name.Key);
                        snipNode.Tag = name;
                        node.Nodes.Add(snipNode);
                    }
                }
            }
            else
            {
                UpdateTreeView();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            statusLabelDate.Text = DateTime.Now.ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            MongoHelper mongoHelper = new MongoHelper();
            if (snippetId != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this snippet?", "Delete snippet", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    mongoHelper.DropDataById(snippetId);
                    UpdateTreeView();
                    rtbMainCode.Clear();
                    btnDel.Enabled = false;
                }
            }

        }
    }
}
