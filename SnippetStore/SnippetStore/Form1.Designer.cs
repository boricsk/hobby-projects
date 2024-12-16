namespace SnippetStore
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            statusStrip1 = new StatusStrip();
            toolStrip1 = new ToolStrip();
            btnAddNewSnippet = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnSetup = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnDel = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnSaveModify = new ToolStripButton();
            btnCancelModify = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            btnExpandAll = new ToolStripButton();
            btnCloseAll = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            btnCopySnippet = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            btnSync = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            btnSchClear = new ToolStripButton();
            splitContainerMain = new SplitContainer();
            treeView1 = new TreeView();
            button1 = new Button();
            tbSearch2 = new TextBox();
            splitContainer2 = new SplitContainer();
            rtbMainCode = new RichTextBox();
            toolStrip2 = new ToolStrip();
            btnMainFont = new ToolStripButton();
            btnMainColor = new ToolStripButton();
            splitContainerDescAndChart = new SplitContainer();
            groupBox1 = new GroupBox();
            splitContainerDesc = new SplitContainer();
            tbMainCodeDesc = new TextBox();
            infoPanel = new Panel();
            lblTotalSize = new Label();
            lblIndexSize = new Label();
            lblStorageSize = new Label();
            lblDatabaseSize = new Label();
            lblNoColls = new Label();
            lblDbName = new Label();
            splitContainerCharts = new SplitContainer();
            gbChartLang = new GroupBox();
            chartSnippetNum = new System.Windows.Forms.DataVisualization.Charting.Chart();
            contextMenuViewChart = new ContextMenuStrip(components);
            cmUpdateCharts = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            cmResetView = new ToolStripMenuItem();
            gbChartView = new GroupBox();
            chartNumOfWiew = new System.Windows.Forms.DataVisualization.Charting.Chart();
            timer = new System.Windows.Forms.Timer(components);
            mainCodeFontDialog = new FontDialog();
            mainCodeColorDialog = new ColorDialog();
            notifyIcon = new NotifyIcon(components);
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerDescAndChart).BeginInit();
            splitContainerDescAndChart.Panel1.SuspendLayout();
            splitContainerDescAndChart.Panel2.SuspendLayout();
            splitContainerDescAndChart.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerDesc).BeginInit();
            splitContainerDesc.Panel1.SuspendLayout();
            splitContainerDesc.Panel2.SuspendLayout();
            splitContainerDesc.SuspendLayout();
            infoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerCharts).BeginInit();
            splitContainerCharts.Panel1.SuspendLayout();
            splitContainerCharts.Panel2.SuspendLayout();
            splitContainerCharts.SuspendLayout();
            gbChartLang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartSnippetNum).BeginInit();
            contextMenuViewChart.SuspendLayout();
            gbChartView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartNumOfWiew).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 723);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1340, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(48, 48);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnAddNewSnippet, toolStripSeparator1, btnSetup, toolStripSeparator2, btnDel, toolStripSeparator3, btnSaveModify, btnCancelModify, toolStripSeparator4, btnExpandAll, btnCloseAll, toolStripSeparator5, btnCopySnippet, toolStripSeparator6, btnSync, toolStripSeparator7, btnSchClear });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.MinimumSize = new Size(48, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1340, 55);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAddNewSnippet
            // 
            btnAddNewSnippet.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAddNewSnippet.Image = (Image)resources.GetObject("btnAddNewSnippet.Image");
            btnAddNewSnippet.ImageTransparentColor = Color.Magenta;
            btnAddNewSnippet.Name = "btnAddNewSnippet";
            btnAddNewSnippet.Size = new Size(52, 52);
            btnAddNewSnippet.Text = "Add New Snippet";
            btnAddNewSnippet.Click += btnAddNewClick;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 55);
            // 
            // btnSetup
            // 
            btnSetup.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSetup.Image = (Image)resources.GetObject("btnSetup.Image");
            btnSetup.ImageTransparentColor = Color.Magenta;
            btnSetup.Name = "btnSetup";
            btnSetup.Size = new Size(52, 52);
            btnSetup.Text = "Setup";
            btnSetup.Click += btnSetup_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 55);
            // 
            // btnDel
            // 
            btnDel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDel.Enabled = false;
            btnDel.Image = (Image)resources.GetObject("btnDel.Image");
            btnDel.ImageTransparentColor = Color.Magenta;
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(52, 52);
            btnDel.Text = "Drop snippet";
            btnDel.Click += btnDel_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 55);
            // 
            // btnSaveModify
            // 
            btnSaveModify.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSaveModify.Enabled = false;
            btnSaveModify.Image = (Image)resources.GetObject("btnSaveModify.Image");
            btnSaveModify.ImageTransparentColor = Color.Magenta;
            btnSaveModify.Name = "btnSaveModify";
            btnSaveModify.Size = new Size(52, 52);
            btnSaveModify.Text = "Save changes";
            btnSaveModify.Click += btnSaveModify_Click;
            // 
            // btnCancelModify
            // 
            btnCancelModify.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCancelModify.Enabled = false;
            btnCancelModify.Image = (Image)resources.GetObject("btnCancelModify.Image");
            btnCancelModify.ImageTransparentColor = Color.Magenta;
            btnCancelModify.Name = "btnCancelModify";
            btnCancelModify.Size = new Size(52, 52);
            btnCancelModify.Text = "Cancel changes";
            btnCancelModify.Click += btnCancelModify_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 55);
            // 
            // btnExpandAll
            // 
            btnExpandAll.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExpandAll.Image = (Image)resources.GetObject("btnExpandAll.Image");
            btnExpandAll.ImageTransparentColor = Color.Magenta;
            btnExpandAll.Name = "btnExpandAll";
            btnExpandAll.Size = new Size(52, 52);
            btnExpandAll.Text = "Expand all";
            btnExpandAll.Click += btnExpandAll_Click;
            // 
            // btnCloseAll
            // 
            btnCloseAll.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCloseAll.Image = (Image)resources.GetObject("btnCloseAll.Image");
            btnCloseAll.ImageTransparentColor = Color.Magenta;
            btnCloseAll.Name = "btnCloseAll";
            btnCloseAll.Size = new Size(52, 52);
            btnCloseAll.Text = "Collapse all";
            btnCloseAll.Click += btnCloseAll_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 55);
            // 
            // btnCopySnippet
            // 
            btnCopySnippet.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCopySnippet.Enabled = false;
            btnCopySnippet.Image = (Image)resources.GetObject("btnCopySnippet.Image");
            btnCopySnippet.ImageTransparentColor = Color.Magenta;
            btnCopySnippet.Name = "btnCopySnippet";
            btnCopySnippet.Size = new Size(52, 52);
            btnCopySnippet.Text = "Copy snippet";
            btnCopySnippet.Click += btnCopySnippet_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 55);
            // 
            // btnSync
            // 
            btnSync.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSync.Image = (Image)resources.GetObject("btnSync.Image");
            btnSync.ImageTransparentColor = Color.Magenta;
            btnSync.Name = "btnSync";
            btnSync.Size = new Size(52, 52);
            btnSync.Text = "Sync from cloud";
            btnSync.Click += btnSync_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 55);
            // 
            // btnSchClear
            // 
            btnSchClear.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSchClear.Image = (Image)resources.GetObject("btnSchClear.Image");
            btnSchClear.ImageTransparentColor = Color.Magenta;
            btnSchClear.Name = "btnSchClear";
            btnSchClear.Size = new Size(52, 52);
            btnSchClear.Text = "Clear search";
            btnSchClear.Click += btnClearSearch_Click;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 55);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(treeView1);
            splitContainerMain.Panel1.Controls.Add(button1);
            splitContainerMain.Panel1.Controls.Add(tbSearch2);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(splitContainer2);
            splitContainerMain.Size = new Size(1340, 668);
            splitContainerMain.SplitterDistance = 253;
            splitContainerMain.TabIndex = 2;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 23);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(253, 645);
            treeView1.TabIndex = 5;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            // 
            // button1
            // 
            button1.Location = new Point(154, 149);
            button1.Name = "button1";
            button1.Size = new Size(8, 8);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // tbSearch2
            // 
            tbSearch2.Dock = DockStyle.Top;
            tbSearch2.Location = new Point(0, 0);
            tbSearch2.Name = "tbSearch2";
            tbSearch2.Size = new Size(253, 23);
            tbSearch2.TabIndex = 0;
            tbSearch2.TextChanged += OnTypeSearch;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(rtbMainCode);
            splitContainer2.Panel1.Controls.Add(toolStrip2);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainerDescAndChart);
            splitContainer2.Size = new Size(1083, 668);
            splitContainer2.SplitterDistance = 335;
            splitContainer2.TabIndex = 0;
            // 
            // rtbMainCode
            // 
            rtbMainCode.AcceptsTab = true;
            rtbMainCode.BackColor = SystemColors.Window;
            rtbMainCode.BorderStyle = BorderStyle.FixedSingle;
            rtbMainCode.Dock = DockStyle.Fill;
            rtbMainCode.Font = new Font("Cascadia Code", 10F);
            rtbMainCode.Location = new Point(0, 25);
            rtbMainCode.Name = "rtbMainCode";
            rtbMainCode.ReadOnly = true;
            rtbMainCode.Size = new Size(1083, 310);
            rtbMainCode.TabIndex = 2;
            rtbMainCode.Text = "";
            rtbMainCode.WordWrap = false;
            rtbMainCode.LinkClicked += rtbMainCode_LinkClicked;
            rtbMainCode.TextChanged += rtbMainCode_TextChanged;
            rtbMainCode.DoubleClick += rtbMainCode_DoubleClick;
            // 
            // toolStrip2
            // 
            toolStrip2.Enabled = false;
            toolStrip2.Items.AddRange(new ToolStripItem[] { btnMainFont, btnMainColor });
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(1083, 25);
            toolStrip2.TabIndex = 0;
            toolStrip2.Text = "toolStrip2";
            // 
            // btnMainFont
            // 
            btnMainFont.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnMainFont.Image = (Image)resources.GetObject("btnMainFont.Image");
            btnMainFont.ImageTransparentColor = Color.Magenta;
            btnMainFont.Name = "btnMainFont";
            btnMainFont.Size = new Size(23, 22);
            btnMainFont.Text = "Font";
            btnMainFont.Click += btnMainFont_Click;
            // 
            // btnMainColor
            // 
            btnMainColor.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnMainColor.Image = (Image)resources.GetObject("btnMainColor.Image");
            btnMainColor.ImageTransparentColor = Color.Magenta;
            btnMainColor.Name = "btnMainColor";
            btnMainColor.Size = new Size(23, 22);
            btnMainColor.Text = "Font color";
            btnMainColor.Click += btnMainColor_Click;
            // 
            // splitContainerDescAndChart
            // 
            splitContainerDescAndChart.Dock = DockStyle.Fill;
            splitContainerDescAndChart.Location = new Point(0, 0);
            splitContainerDescAndChart.Name = "splitContainerDescAndChart";
            // 
            // splitContainerDescAndChart.Panel1
            // 
            splitContainerDescAndChart.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainerDescAndChart.Panel2
            // 
            splitContainerDescAndChart.Panel2.Controls.Add(splitContainerCharts);
            splitContainerDescAndChart.Size = new Size(1083, 329);
            splitContainerDescAndChart.SplitterDistance = 274;
            splitContainerDescAndChart.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(splitContainerDesc);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(274, 329);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Description";
            // 
            // splitContainerDesc
            // 
            splitContainerDesc.Dock = DockStyle.Fill;
            splitContainerDesc.Location = new Point(3, 19);
            splitContainerDesc.Name = "splitContainerDesc";
            splitContainerDesc.Orientation = Orientation.Horizontal;
            // 
            // splitContainerDesc.Panel1
            // 
            splitContainerDesc.Panel1.Controls.Add(tbMainCodeDesc);
            // 
            // splitContainerDesc.Panel2
            // 
            splitContainerDesc.Panel2.Controls.Add(infoPanel);
            splitContainerDesc.Size = new Size(268, 307);
            splitContainerDesc.SplitterDistance = 153;
            splitContainerDesc.TabIndex = 3;
            // 
            // tbMainCodeDesc
            // 
            tbMainCodeDesc.Dock = DockStyle.Fill;
            tbMainCodeDesc.Enabled = false;
            tbMainCodeDesc.Location = new Point(0, 0);
            tbMainCodeDesc.Multiline = true;
            tbMainCodeDesc.Name = "tbMainCodeDesc";
            tbMainCodeDesc.Size = new Size(268, 153);
            tbMainCodeDesc.TabIndex = 1;
            // 
            // infoPanel
            // 
            infoPanel.AutoScroll = true;
            infoPanel.BorderStyle = BorderStyle.FixedSingle;
            infoPanel.Controls.Add(lblTotalSize);
            infoPanel.Controls.Add(lblIndexSize);
            infoPanel.Controls.Add(lblStorageSize);
            infoPanel.Controls.Add(lblDatabaseSize);
            infoPanel.Controls.Add(lblNoColls);
            infoPanel.Controls.Add(lblDbName);
            infoPanel.Dock = DockStyle.Fill;
            infoPanel.Location = new Point(0, 0);
            infoPanel.Name = "infoPanel";
            infoPanel.Size = new Size(268, 150);
            infoPanel.TabIndex = 3;
            // 
            // lblTotalSize
            // 
            lblTotalSize.AutoSize = true;
            lblTotalSize.Location = new Point(3, 77);
            lblTotalSize.Name = "lblTotalSize";
            lblTotalSize.Size = new Size(64, 15);
            lblTotalSize.TabIndex = 5;
            lblTotalSize.Text = "Total size : ";
            // 
            // lblIndexSize
            // 
            lblIndexSize.AutoSize = true;
            lblIndexSize.Location = new Point(3, 62);
            lblIndexSize.Name = "lblIndexSize";
            lblIndexSize.Size = new Size(66, 15);
            lblIndexSize.TabIndex = 4;
            lblIndexSize.Text = "Index size : ";
            // 
            // lblStorageSize
            // 
            lblStorageSize.AutoSize = true;
            lblStorageSize.Location = new Point(3, 47);
            lblStorageSize.Name = "lblStorageSize";
            lblStorageSize.Size = new Size(78, 15);
            lblStorageSize.TabIndex = 3;
            lblStorageSize.Text = "Storage size : ";
            // 
            // lblDatabaseSize
            // 
            lblDatabaseSize.AutoSize = true;
            lblDatabaseSize.Location = new Point(3, 32);
            lblDatabaseSize.Name = "lblDatabaseSize";
            lblDatabaseSize.Size = new Size(86, 15);
            lblDatabaseSize.TabIndex = 2;
            lblDatabaseSize.Text = "Database size : ";
            // 
            // lblNoColls
            // 
            lblNoColls.AutoSize = true;
            lblNoColls.Location = new Point(3, 17);
            lblNoColls.Name = "lblNoColls";
            lblNoColls.Size = new Size(134, 15);
            lblNoColls.TabIndex = 1;
            lblNoColls.Text = "Number of collections : ";
            // 
            // lblDbName
            // 
            lblDbName.AutoSize = true;
            lblDbName.Location = new Point(3, 2);
            lblDbName.Name = "lblDbName";
            lblDbName.Size = new Size(97, 15);
            lblDbName.TabIndex = 0;
            lblDbName.Text = "Database name : ";
            // 
            // splitContainerCharts
            // 
            splitContainerCharts.Dock = DockStyle.Fill;
            splitContainerCharts.IsSplitterFixed = true;
            splitContainerCharts.Location = new Point(0, 0);
            splitContainerCharts.Name = "splitContainerCharts";
            // 
            // splitContainerCharts.Panel1
            // 
            splitContainerCharts.Panel1.Controls.Add(gbChartLang);
            // 
            // splitContainerCharts.Panel2
            // 
            splitContainerCharts.Panel2.Controls.Add(gbChartView);
            splitContainerCharts.Size = new Size(805, 329);
            splitContainerCharts.SplitterDistance = 402;
            splitContainerCharts.TabIndex = 0;
            // 
            // gbChartLang
            // 
            gbChartLang.Controls.Add(chartSnippetNum);
            gbChartLang.Dock = DockStyle.Fill;
            gbChartLang.Location = new Point(0, 0);
            gbChartLang.Name = "gbChartLang";
            gbChartLang.Size = new Size(402, 329);
            gbChartLang.TabIndex = 0;
            gbChartLang.TabStop = false;
            gbChartLang.Text = "Chart - Snippets by language";
            // 
            // chartSnippetNum
            // 
            chartArea1.Name = "ChartArea1";
            chartSnippetNum.ChartAreas.Add(chartArea1);
            chartSnippetNum.ContextMenuStrip = contextMenuViewChart;
            chartSnippetNum.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartSnippetNum.Legends.Add(legend1);
            chartSnippetNum.Location = new Point(3, 19);
            chartSnippetNum.Name = "chartSnippetNum";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartSnippetNum.Series.Add(series1);
            chartSnippetNum.Size = new Size(396, 307);
            chartSnippetNum.TabIndex = 0;
            chartSnippetNum.Text = "chart1";
            // 
            // contextMenuViewChart
            // 
            contextMenuViewChart.Items.AddRange(new ToolStripItem[] { cmUpdateCharts, toolStripSeparator8, cmResetView });
            contextMenuViewChart.Name = "contextMenuViewChart";
            contextMenuViewChart.Size = new Size(189, 54);
            // 
            // cmUpdateCharts
            // 
            cmUpdateCharts.Name = "cmUpdateCharts";
            cmUpdateCharts.Size = new Size(188, 22);
            cmUpdateCharts.Text = "Update charts";
            cmUpdateCharts.Click += cmUpdateCharts_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(185, 6);
            // 
            // cmResetView
            // 
            cmResetView.Name = "cmResetView";
            cmResetView.Size = new Size(188, 22);
            cmResetView.Text = "Reset number of view";
            cmResetView.Click += cmResetView_Click;
            // 
            // gbChartView
            // 
            gbChartView.Controls.Add(chartNumOfWiew);
            gbChartView.Dock = DockStyle.Fill;
            gbChartView.Location = new Point(0, 0);
            gbChartView.Name = "gbChartView";
            gbChartView.Size = new Size(399, 329);
            gbChartView.TabIndex = 0;
            gbChartView.TabStop = false;
            gbChartView.Text = "Chart - Top 5 views";
            // 
            // chartNumOfWiew
            // 
            chartArea2.Name = "ChartArea1";
            chartNumOfWiew.ChartAreas.Add(chartArea2);
            chartNumOfWiew.ContextMenuStrip = contextMenuViewChart;
            chartNumOfWiew.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            chartNumOfWiew.Legends.Add(legend2);
            chartNumOfWiew.Location = new Point(3, 19);
            chartNumOfWiew.Name = "chartNumOfWiew";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartNumOfWiew.Series.Add(series2);
            chartNumOfWiew.Size = new Size(393, 307);
            chartNumOfWiew.TabIndex = 0;
            chartNumOfWiew.Text = "chart1";
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "notifyIcon1";
            notifyIcon.Visible = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1340, 745);
            Controls.Add(splitContainerMain);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Name = "MainForm";
            Text = "Snippet Store";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel1.PerformLayout();
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            splitContainerDescAndChart.Panel1.ResumeLayout(false);
            splitContainerDescAndChart.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerDescAndChart).EndInit();
            splitContainerDescAndChart.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            splitContainerDesc.Panel1.ResumeLayout(false);
            splitContainerDesc.Panel1.PerformLayout();
            splitContainerDesc.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerDesc).EndInit();
            splitContainerDesc.ResumeLayout(false);
            infoPanel.ResumeLayout(false);
            infoPanel.PerformLayout();
            splitContainerCharts.Panel1.ResumeLayout(false);
            splitContainerCharts.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerCharts).EndInit();
            splitContainerCharts.ResumeLayout(false);
            gbChartLang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartSnippetNum).EndInit();
            contextMenuViewChart.ResumeLayout(false);
            gbChartView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartNumOfWiew).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStrip toolStrip1;
        private SplitContainer splitContainerMain;
        private ToolStripButton btnAddNewSnippet;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnSetup;
        private ToolStripSeparator toolStripSeparator2;
        //private ToolStripTextBox tbSearch;
        private SplitContainer splitContainer2;
        private System.Windows.Forms.Timer timer;
        //private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton btnDel;
        private TextBox tbSearch2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnSaveModify;
        private ToolStripButton btnCancelModify;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton btnExpandAll;
        private ToolStripButton btnCloseAll;
        private ToolStripSeparator toolStripSeparator5;
        private RichTextBox rtbMainCode;
        private ToolStrip toolStrip2;
        private ToolStripButton btnMainFont;
        private FontDialog mainCodeFontDialog;
        private ToolStripButton btnMainColor;
        private ColorDialog mainCodeColorDialog;
        private SplitContainer splitContainerDescAndChart;
        private GroupBox groupBox1;
        private SplitContainer splitContainerCharts;
        private GroupBox gbChartLang;
        private GroupBox gbChartView;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSnippetNum;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNumOfWiew;
        private ToolStripButton btnCopySnippet;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton btnSync;
        private Button button1;
        private TreeView treeView1;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton btnClearSearch;
        private ToolStripButton btnSchClear;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenuViewChart;
        private ToolStripMenuItem cmUpdateCharts;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem cmResetView;
        private SplitContainer splitContainerDesc;
        private TextBox tbMainCodeDesc;
        private Panel infoPanel;
        private Label lblTotalSize;
        private Label lblIndexSize;
        private Label lblStorageSize;
        private Label lblDatabaseSize;
        private Label lblNoColls;
        private Label lblDbName;
    }
}
