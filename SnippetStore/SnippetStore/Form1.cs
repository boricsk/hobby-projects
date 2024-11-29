using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SnippetStore
{
    public partial class MainForm : Form
    {
        private ToolStripStatusLabel statusLabelDate;
        private ToolStripStatusLabel statusLabelConnected;
        private ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
        private string? snippetId;
        private string? oldName;
        MongoHelper mongoHelper = new MongoHelper();
        private List<string?>? wordsToHighlight = new List<string?>();
        private List<string?>? separatorToHighlight = new List<string?>();
        private Color ResWordColor = new Color();
        private Color SepColor = new Color();
        private bool isSnippetModified = false;

        public MainForm()
        {
            InitializeComponent();
            UpdateTreeView();
            UpdateCharts();
            PrepStatusBar();
            PrepOptions();
            Text += $" - {mongoHelper.ConnectedTo}";
        }

        private void PrepOptions()
        {
            ResWordColor = RegistryOps.ReadResWordColor();
            SepColor = RegistryOps.ReadBlockSepColor();
            btnSync.Enabled = !RegistryOps.ReadDatabaseOption();
        }

        private void PrepStatusBar()
        {
            statusLabelDate = new ToolStripStatusLabel { Text = DateTime.Now.ToString() };
            statusLabelConnected = new ToolStripStatusLabel { Text = $"Connected to {mongoHelper.ConnectedTo} database." };
            statusStrip1.Items.Add(statusLabelDate);
            statusStrip1.Items.Add(toolStripSeparator);
            statusStrip1.Items.Add(statusLabelConnected);
        }

        private void btnAddNewClick(object sender, EventArgs e)
        {
            AddNewSnippetForm addNewSnippetForm = new AddNewSnippetForm();
            addNewSnippetForm.ShowDialog();
            UpdateTreeView();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            SetupForm setupForm = new SetupForm();
            setupForm.ShowDialog();
        }

        public void UpdateTreeView()
        {
            treeView1.Nodes.Clear();
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
            //UpdateTreeView();
            UpdateCharts();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            rtbMainCode.Clear();
            snippetId = mongoHelper.GetMongoIdFromSnipetName(e.Node.Text);

            if (snippetId != null)
            {
                rtbMainCode.Rtf = mongoHelper.GetCodeSnipetById(snippetId);
                tbMainCodeDesc.Text = mongoHelper.GetCodeDescById(snippetId);
                mongoHelper.IncreaseView(snippetId);
            }

            if (rtbMainCode.Text == "")
            {
                btnDel.Enabled = false;
                btnCopySnippet.Enabled = false;
                //btnEdit.Enabled = false;
            }
            else
            {
                btnDel.Enabled = true;
                btnCopySnippet.Enabled = true;
                //btnEdit.Enabled = true;
            }

            WordHighlight();
            UpdateCharts();
            //Debug.WriteLine(mongoHelper.GedMongoIdFromSnipetName(e.Node.Text));            
        }

        private void OnTypeSearch(object sender, EventArgs e)
        {
            bool[] op = new bool[3];
            op = RegistryOps.ReadSearchOptions();
            if (tbSearch2.Text != "")
            {
                treeView1.Nodes.Clear();
                var SnipData = mongoHelper.GetSnipets().AsQueryable()
                    .Where(x => (op[2] && x.SnipKeywords.Contains(tbSearch2.Text)) ||
                                (op[3] && x.SnipName != null && x.SnipName.Contains(tbSearch2.Text)) ||
                                (op[1] && x.SnipShortDesc != null && x.SnipShortDesc.Contains(tbSearch2.Text)) ||
                                (op[0] && x.SnipCode != null && x.SnipCode.Contains(tbSearch2.Text)))
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
            if (snippetId != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this snippet?", "Delete snippet", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    mongoHelper.DropDataById(snippetId);
                    UpdateTreeView();
                    rtbMainCode.Clear();
                    btnDel.Enabled = false;
                    UpdateTreeView();
                }
            }
        }

        private void WordHighlight()
        {
            wordsToHighlight = mongoHelper.GetReswords();
            separatorToHighlight = mongoHelper.GetBlockSep();
            ResWordColor = RegistryOps.ReadResWordColor();
            SepColor = RegistryOps.ReadBlockSepColor();

            foreach (var word in wordsToHighlight)
            {
                // Regex a teljes szavak kereséséhez
                string pattern = $@"\b{Regex.Escape(word)}\b";
                MatchCollection matches = Regex.Matches(rtbMainCode.Text, pattern, RegexOptions.IgnoreCase);

                foreach (Match match in matches)
                {
                    rtbMainCode.Select(match.Index, match.Length);
                    rtbMainCode.SelectionColor = ResWordColor;
                }
            }
            // Kijelölés eltávolítása
            rtbMainCode.Select(0, 0);

            foreach (var word in separatorToHighlight)
            {
                int startIndex = 0;
                while ((startIndex = rtbMainCode.Text.IndexOf(word, startIndex, StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    rtbMainCode.Select(startIndex, word.Length);
                    rtbMainCode.SelectionColor = SepColor;
                    startIndex += word.Length; // Továbblépés a következõ elõfordulásra
                }
            }

            // Kijelölés eltávolítása
            rtbMainCode.Select(0, 0);
        }

        private void btnCancelModify_Click(object sender, EventArgs e)
        {
            btnCancelModify.Enabled = false;
            btnSaveModify.Enabled = false;
            rtbMainCode.ReadOnly = true;
            treeView1.Enabled = true;
            toolStrip2.Enabled = false;
            rtbMainCode.Clear();
            UpdateTreeView();
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            if (snippetId != null && rtbMainCode.Rtf != null)
            {
                btnCancelModify.Enabled = false;
                btnSaveModify.Enabled = false;
                mongoHelper.SaveModify(snippetId, rtbMainCode.Rtf);
                treeView1.Enabled = true;
                toolStrip2.Enabled = false;

            }
        }

        private void rtbMainCode_DoubleClick(object sender, EventArgs e)
        {
            if (rtbMainCode.Text != "")
            {
                btnSaveModify.Enabled = true;
                btnCancelModify.Enabled = true;
                rtbMainCode.ReadOnly = false;
                treeView1.Enabled = false;
                toolStrip2.Enabled = true;
            }
        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void btnMainFont_Click(object sender, EventArgs e)
        {
            if (mainCodeFontDialog.ShowDialog() == DialogResult.OK)
            {
                rtbMainCode.SelectionFont = mainCodeFontDialog.Font;
            }
        }

        private void btnMainColor_Click(object sender, EventArgs e)
        {
            if (mainCodeColorDialog.ShowDialog() == DialogResult.OK)
            {
                rtbMainCode.SelectionColor = mainCodeColorDialog.Color;
            }
        }

        private void UpdateCharts()
        {
            chartSnippetNum.Series.Clear();
            chartNumOfWiew.Series.Clear();

            var seriesSnipNum = new Series("Snippet number by lang.");
            var seriesViewNum = new Series("Top 5 view");

            seriesSnipNum.ChartType = SeriesChartType.Doughnut;
            seriesViewNum.ChartType = SeriesChartType.Doughnut;

            List<string?> snipNum = mongoHelper.GetLanguages();

            foreach (var snip in snipNum)
            {
                seriesSnipNum.Points.AddXY(snip, mongoHelper.GetSnipNumByLanguage(snip));
            }
            chartSnippetNum.Series.Add(seriesSnipNum);
            chartSnippetNum.Series[0].IsValueShownAsLabel = true;


            foreach (var v in mongoHelper.GetTop5Wiew())
            {
                seriesViewNum.Points.AddXY(v.Key, v.Value);
            }

            chartNumOfWiew.Series.Add(seriesViewNum);
            chartNumOfWiew.Series[0].IsValueShownAsLabel = true;
        }

        private void btnCopySnippet_Click(object sender, EventArgs e)
        {
            rtbMainCode.Copy();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            _ = mongoHelper.SyncLocalDatabase();
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node != null && e.Label != null && e.Label != "" && e.Node.Parent != null && e.Node.Parent.Parent == null)
            {
                mongoHelper.RenameNodeName(e.Label, snippetId);
                UpdateTreeView();
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            tbSearch2.Clear();
            UpdateTreeView();
        }
    }
}
