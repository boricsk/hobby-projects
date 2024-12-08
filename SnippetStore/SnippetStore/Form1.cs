using MongoDB.Bson;
using MongoDB.Driver;
using SnippetStore.MongoClass;
using SnippetStore.RegistryClass;
using System.Diagnostics;
using System.Net.Sockets;
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
        private MongoConnectionManagement connectionManagement = new MongoConnectionManagement(RegistryOps.ReadConString());
        private List<string?>? wordsToHighlight = new List<string?>();
        private List<string?>? separatorToHighlight = new List<string?>();
        private Color ResWordColor = new Color();
        private Color SepColor = new Color();

        public MainForm()
        {
            InitializeComponent();
            UpdateTreeView();
            _ = UpdateCharts();
            PrepStatusBar();
            PrepOptions();
            UpdateDbStats();
            Text += $" - {connectionManagement.ConnectedTo}";
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
            statusLabelConnected = new ToolStripStatusLabel { Text = $"Connected to {connectionManagement.ConnectedTo} database." };

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
            var snip_coll = connectionManagement.GetCollection<SnippetDatabase>("SnippetStore");
            MongoSnipStore snipStore = new(snip_coll);
            treeView1.Nodes.Clear();
            //Timeout exception, ha nincs adatbázis
            try
            {
                var SnipData = snipStore.GetSnipets().AsQueryable().ToList().GroupBy(l => l.SnipLanguage);

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
            catch (Exception e)
            {
                MessageBox.Show($"Connection error! Check your MongoDb connection / service! ");
                Environment.Exit(1);
            }
        }

        private async void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var snip_coll = connectionManagement.GetCollection<SnippetDatabase>("SnippetStore");
            MongoSnipStore snipStore = new(snip_coll);

            rtbMainCode.Clear();
            snippetId = await snipStore.GetMongoIdFromSnipetNameAsync(e.Node.Text);

            if (snippetId != null)
            {
                rtbMainCode.Rtf = await snipStore.GetCodeSnipetByIdAsync(snippetId);
                tbMainCodeDesc.Text = await snipStore.GetCodeDescByIdAsync(snippetId);
                await snipStore.IncreaseViewAsync(snippetId);
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
            _ = UpdateCharts();
            _ = WordHighlight();
        }

        private void OnTypeSearch(object sender, EventArgs e)
        {
            var snip_coll = connectionManagement.GetCollection<SnippetDatabase>("SnippetStore");
            MongoSnipStore snipStore = new(snip_coll);

            bool[] op = new bool[3];
            op = RegistryOps.ReadSearchOptions();
            if (tbSearch2.Text != "")
            {
                treeView1.Nodes.Clear();
                var SnipData = snipStore.GetSnipets().AsQueryable()
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
            if (statusLabelDate != null)
            {
                statusLabelDate.Text = DateTime.Now.ToString();
            }
        }

        private async void btnDel_Click(object sender, EventArgs e)
        {
            if (snippetId != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this snippet?", "Delete snippet", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var snip_coll = connectionManagement.GetCollection<SnippetDatabase>("SnippetStore");
                    MongoSnipStore snipStore = new(snip_coll);

                    await snipStore.DropDataByIdAsync(snippetId);
                    rtbMainCode.Clear();
                    btnDel.Enabled = false;
                    UpdateTreeView();
                }
            }
        }

        private async Task WordHighlight()
        {
            var keyw_coll = connectionManagement.GetCollection<Keywords>("Keywords");
            var resw_coll = connectionManagement.GetCollection<ResWords>("Reserved words");
            var blck_coll = connectionManagement.GetCollection<BlockSeparators>("Block separators");
            MongoKeyword mongoKeyword = new(keyw_coll);
            MongoResWord mongoResword = new(resw_coll);
            MongoBlockSep mongoBlockSep = new(blck_coll);

            wordsToHighlight = await mongoResword.GetReswordsAsync();
            separatorToHighlight = await mongoBlockSep.GetBlockSepAsync();
            ResWordColor = RegistryOps.ReadResWordColor();
            SepColor = RegistryOps.ReadBlockSepColor();

            foreach (var word in wordsToHighlight)
            {
                string pattern = $@"\b{Regex.Escape(word)}\b";
                MatchCollection matches = Regex.Matches(rtbMainCode.Text, pattern, RegexOptions.IgnoreCase);

                foreach (Match match in matches)
                {
                    rtbMainCode.Select(match.Index, match.Length);
                    rtbMainCode.SelectionColor = ResWordColor;
                }
            }
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

        private async void btnSaveModify_Click(object sender, EventArgs e)
        {
            if (snippetId != null && rtbMainCode.Rtf != null)
            {
                var snip_coll = connectionManagement.GetCollection<SnippetDatabase>("SnippetStore");
                MongoSnipStore snipStore = new(snip_coll);

                btnCancelModify.Enabled = false;
                btnSaveModify.Enabled = false;
                await snipStore.SaveModifyAsync(snippetId, rtbMainCode.Rtf);
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

        private async Task UpdateCharts()
        {
            var snip_coll = connectionManagement.GetCollection<SnippetDatabase>("SnippetStore");
            var lang_coll = connectionManagement.GetCollection<Languages>("Languages");
            MongoSnipStore snipStore = new(snip_coll);
            MongoLanguage mongoLanguage = new(lang_coll);

            chartSnippetNum.Series.Clear();
            chartNumOfWiew.Series.Clear();

            var seriesSnipNum = new Series("Snippet number by lang.");
            var seriesViewNum = new Series("Top 5 view");

            seriesSnipNum.ChartType = SeriesChartType.Doughnut;
            seriesViewNum.ChartType = SeriesChartType.Doughnut;

            List<string?> snipNum = await mongoLanguage.GetLanguagesAsync();

            foreach (var snip in snipNum)
            {
                if (snip != null)
                {
                    seriesSnipNum.Points.AddXY(snip, await snipStore.GetSnipNumByLanguageAsync(snip));
                }
            }
            chartSnippetNum.Series.Add(seriesSnipNum);
            chartSnippetNum.Series[0].IsValueShownAsLabel = true;


            foreach (var v in snipStore.GetTop5Wiew())
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

        private async void btnSync_Click(object sender, EventArgs e)
        {
            MongoSyncManagement syncMgmnt = new MongoSyncManagement();
            await syncMgmnt.SyncCloudToLocalDatabaseAsync();
            //_ = mongoHelper.SyncLocalDatabase();
            notifyIcon.BalloonTipTitle = $"Database sync!";
            notifyIcon.BalloonTipText = $"Database sync has been completed!";
            notifyIcon.ShowBalloonTip(3000);
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            tbSearch2.Clear();
            rtbMainCode.Clear();
            UpdateTreeView();
        }

        private void UpdateDbStats()
        {
            MongoStatistic dbStat = new MongoStatistic(connectionManagement.GetDatabase());

            var stats = dbStat.DatabaseStat();
            lblDbName.Text += stats[0];
            lblNoColls.Text += $"{stats[1].ToInt64():N0}";
            lblDatabaseSize.Text += $"{stats[2].ToInt64():N0} Bytes";
            lblStorageSize.Text += $"{stats[3].ToInt64():N0} Bytes";
            lblIndexSize.Text += $"{stats[4].ToInt64():N0} Bytes";
            lblTotalSize.Text += $"{stats[5].ToInt64():N0} Bytes";
        }

        private void rtbMainCode_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = e.LinkText,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening link: {ex.Message}");
            }
        }

        private void cmUpdateCharts_Click(object sender, EventArgs e)
        {
            _ = UpdateCharts();
        }

        private void cmResetView_Click(object sender, EventArgs e)
        {
            var snip_coll = connectionManagement.GetCollection<SnippetDatabase>("SnippetStore");
            MongoSnipStore snipStore = new(snip_coll);
            _ = snipStore.ResetView();
        }
    }
}
