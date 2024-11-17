using MongoDB.Driver;

namespace SnippetStore
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            UpdateTreeView();
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

        private void UpdateTreeView()
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
    }
}
