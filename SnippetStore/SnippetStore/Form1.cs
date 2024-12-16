using MongoDB.Bson;
using MongoDB.Driver;
using SnippetStore.MongoClass;
using SnippetStore.RegistryClass;
using SnippetStore.HighlightClass;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SnippetStore.ChartClass;

namespace SnippetStore
{
    public partial class MainForm : Form
    {
        private ToolStripStatusLabel statusLabelDate;
        private ToolStripStatusLabel statusLabelConnected;
        private ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
        private string? snippetId;
        private MongoConnectionManagement connectionManagement = new MongoConnectionManagement(RegistryOps.ReadConString());

        private HighlightWord hw = new HighlightWord();
        private HighlightSearch hs = new HighlightSearch();
        private UpdateChart uc = new UpdateChart();

        public MainForm()
        {
            InitializeComponent();
            UpdateTreeView();
            chartNumOfWiew = uc.UpdateTopViewChart(chartNumOfWiew);
            chartSnippetNum = uc.UpdateSnipNumChart(chartSnippetNum);
            PrepStatusBar();
            PrepOptions();
            UpdateDbStats();
            Text += $" - {connectionManagement.ConnectedTo}";
        }

        private void PrepOptions()
        {
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
            chartNumOfWiew = uc.UpdateTopViewChart(chartNumOfWiew);
            chartSnippetNum = uc.UpdateSnipNumChart(chartSnippetNum);
            rtbMainCode = await hw.WordHighlight(rtbMainCode);
            rtbMainCode = hs.HighlightSearchResult(tbSearch2.Text, rtbMainCode);

            Debug.WriteLine(e.Node.Text);
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
            if (rtbMainCode.SelectionFont != null)
            {
                mainCodeFontDialog.Font = rtbMainCode.SelectionFont;
            }
            else
            {
                mainCodeFontDialog.Font = rtbMainCode.Font;
            }
            
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
            lblDatabaseSize.Text += $"{stats[2].ToInt64() / 1024:N0} KBytes";
            lblStorageSize.Text += $"{stats[3].ToInt64() / 1024:N0} KBytes";
            lblIndexSize.Text += $"{stats[4].ToInt64() / 1024:N0} KBytes";
            lblTotalSize.Text += $"{stats[5].ToInt64() / 1024:N0} KBytes";
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
            chartNumOfWiew = uc.UpdateTopViewChart(chartNumOfWiew);
            chartSnippetNum = uc.UpdateSnipNumChart(chartSnippetNum);
            //_ = UpdateCharts();
        }

        private void cmResetView_Click(object sender, EventArgs e)
        {
            var snip_coll = connectionManagement.GetCollection<SnippetDatabase>("SnippetStore");
            MongoSnipStore snipStore = new(snip_coll);
            _ = snipStore.ResetView();
        }

        private void rtbMainCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
