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
using SnippetStore.SearchClass;
using SnippetStore.ConvertClass;
using SnippetStore.NotifyClass;

namespace SnippetStore
{
    public partial class MainForm : Form
    {
        private ToolStripStatusLabel statusLabelDate;
        private ToolStripStatusLabel statusLabelConnected;
        private ToolStripStatusLabel statusLabelSnipName;

        private ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
        private string? snippetId;
        private MongoConnectionManagement connectionManagement = new MongoConnectionManagement(RegistryOps.ReadConString());
        private SearchManagement sm = new SearchManagement();

        private HighlightWord hw = new HighlightWord();
        private HighlightSearch hs = new HighlightSearch();
        private UpdateChart uc = new UpdateChart();
        private string separator = "";
        private string pageLink = "https://devnullsec.hu/snippet-store.html";
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
            separator = RegistryOps.ReadSnipSep();
        }

        private void PrepOptions()
        {
            btnSync.Enabled = !RegistryOps.ReadDatabaseOption();
            if (RegistryOps.ReadFontType() != null)
            {
                rtbMainCode.Font = RegistryOps.ReadFontType();
            }
        }

        private void PrepStatusBar()
        {
            statusLabelDate = new ToolStripStatusLabel { Text = DateTime.Now.ToString() };
            statusLabelConnected = new ToolStripStatusLabel { Text = $"Connected to {connectionManagement.ConnectedTo} database." };
            statusLabelSnipName = new ToolStripStatusLabel { Text = string.Empty };
            statusStrip1.Items.Add(statusLabelDate);
            statusStrip1.Items.Add(toolStripSeparator);
            statusStrip1.Items.Add(statusLabelConnected);
            statusStrip1.Items.Add(toolStripSeparator2);
            statusStrip1.Items.Add(statusLabelSnipName);
        }

        private void btnAddNewClick(object sender, EventArgs e)
        {
            AddNewSnippetForm addNewSnippetForm = new AddNewSnippetForm();
            addNewSnippetForm.ShowDialog();
            UpdateTreeView();
        }

        private async void btnSetup_Click(object sender, EventArgs e)
        {
            SetupForm setupForm = new SetupForm();
            setupForm.ShowDialog();
            PrepOptions();
            rtbMainCode = await hw.WordHighlight(rtbMainCode);
        }

        public void UpdateTreeView()
        {
            var snip_coll = connectionManagement.GetCollection<SnippetDatabase>("SnippetStore");
            MongoSnipStore snipStore = new(snip_coll);
            treeView1.Nodes.Clear();
            //Timeout exception, ha nincs adatb�zis
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
            catch (Exception)
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
                rtbMainCode.Text = await snipStore.GetCodeSnipetByIdAsync(snippetId);
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
            statusLabelSnipName.Text = e.Node.Text;
        }

        private void OnTypeSearch(object sender, EventArgs e)
        {
            if (tbSearch2.Text != "")
            {
                treeView1.Nodes.Clear();

                var SnipData = sm.MainScreenSearch(tbSearch2.Text);
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
                    statusLabelSnipName.Text = string.Empty;
                }
            }
        }

        private void btnCancelModify_Click(object sender, EventArgs e)
        {
            btnCancelModify.Enabled = false;
            btnSaveModify.Enabled = false;
            rtbMainCode.ReadOnly = true;
            treeView1.Enabled = true;
            rtbMainCode.Clear();
            UpdateTreeView();
            statusLabelSnipName.Text = string.Empty;
        }

        private async void btnSaveModify_Click(object sender, EventArgs e)
        {
            if (snippetId != null && rtbMainCode.Text != null)
            {
                var snip_coll = connectionManagement.GetCollection<SnippetDatabase>("SnippetStore");
                MongoSnipStore snipStore = new(snip_coll);

                btnCancelModify.Enabled = false;
                btnSaveModify.Enabled = false;
                await snipStore.SaveModifyAsync(snippetId, rtbMainCode.Text);
                treeView1.Enabled = true;
                contextMenuCodeEdit.Enabled = false;
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
                contextMenuCodeEdit.Enabled = true;
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

        private void btnCopySnippet_Click(object sender, EventArgs e)
        {
            rtbMainCode.Copy();
        }

        private async void btnSync_Click(object sender, EventArgs e)
        {
            //toolStripProgressBar1.Visible = true;
            MongoSyncManagement syncMgmnt = new MongoSyncManagement();
            await syncMgmnt.SyncCloudToLocalDatabaseAsync();
            //_ = mongoHelper.SyncLocalDatabase();
            NotifyManagement.ShowNotifyMessage("Database sync!", "Database sync has been completed!", 3000, ToolTipIcon.Info);
            //toolStripProgressBar1.Visible=false;
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            tbSearch2.Clear();
            rtbMainCode.Clear();
            UpdateTreeView();
            statusLabelSnipName.Text = string.Empty;
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

        private void addSeparatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Lek�rdezz�k a kurzor aktu�lis poz�ci�j�t
            int cursorPosition = rtbMainCode.SelectionStart;

            // Lek�rdezz�k, hogy a kurzor melyik sorban van
            int currentLine = rtbMainCode.GetLineFromCharIndex(cursorPosition);

            // Lek�rj�k az adott sor els� karakter�nek index�t
            int firstCharIndexInLine = rtbMainCode.GetFirstCharIndexFromLine(currentLine);

            // Ellen�rizz�k, hogy a kurzor az els� oszlopban van-e
            bool isCursorInFirstColumn = cursorPosition == firstCharIndexInLine;

            if (isCursorInFirstColumn)
            {
                // Az aktu�lis kurzor sor�nak indexe
                int currLine = rtbMainCode.GetLineFromCharIndex(rtbMainCode.SelectionStart);

                // Az aktu�lis sor els� karakter�nek indexe
                int lineStartPosition = rtbMainCode.GetFirstCharIndexFromLine(currLine);

                // A sz�veg besz�r�sa a sor elej�re
                rtbMainCode.Text = rtbMainCode.Text.Insert(lineStartPosition, separator);

                // Az �j kurzorpoz�ci� be�ll�t�sa a besz�rt sz�veg ut�n
                rtbMainCode.SelectionStart = lineStartPosition + separator.Length;

            }
        }

        private async void rtbMainCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                {
                    rtbMainCode.Font = new Font(rtbMainCode.Font.FontFamily, rtbMainCode.Font.Size + 1, rtbMainCode.Font.Style);
                    rtbMainCode = await hw.WordHighlight(rtbMainCode);
                }
                else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
                {
                    rtbMainCode.Font = new Font(rtbMainCode.Font.FontFamily, rtbMainCode.Font.Size - 1, rtbMainCode.Font.Style);
                    rtbMainCode = await hw.WordHighlight(rtbMainCode);
                }
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = pageLink,
                UseShellExecute = true
            });
        }
    }
}