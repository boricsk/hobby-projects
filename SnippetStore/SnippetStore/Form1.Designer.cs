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
            splitContainer1 = new SplitContainer();
            treeView1 = new TreeView();
            button1 = new Button();
            tbSearch2 = new TextBox();
            splitContainer2 = new SplitContainer();
            rtbMainCode = new RichTextBox();
            toolStrip2 = new ToolStrip();
            btnMainFont = new ToolStripButton();
            btnMainColor = new ToolStripButton();
            splitContainer3 = new SplitContainer();
            groupBox1 = new GroupBox();
            infoPanel = new Panel();
            lblTotalSize = new Label();
            lblIndexSize = new Label();
            lblStorageSize = new Label();
            lblDatabaseSize = new Label();
            lblNoColls = new Label();
            lblDbName = new Label();
            splitter1 = new Splitter();
            tbMainCodeDesc = new TextBox();
            splitContainer4 = new SplitContainer();
            groupBox2 = new GroupBox();
            chartSnippetNum = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupBox3 = new GroupBox();
            chartNumOfWiew = new System.Windows.Forms.DataVisualization.Charting.Chart();
            timer = new System.Windows.Forms.Timer(components);
            mainCodeFontDialog = new FontDialog();
            mainCodeColorDialog = new ColorDialog();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            groupBox1.SuspendLayout();
            infoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartSnippetNum).BeginInit();
            groupBox3.SuspendLayout();
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
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 55);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView1);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(tbSearch2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1340, 668);
            splitContainer1.SplitterDistance = 253;
            splitContainer1.TabIndex = 2;
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
            splitContainer2.Panel2.Controls.Add(splitContainer3);
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
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(splitContainer4);
            splitContainer3.Size = new Size(1083, 329);
            splitContainer3.SplitterDistance = 274;
            splitContainer3.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(infoPanel);
            groupBox1.Controls.Add(splitter1);
            groupBox1.Controls.Add(tbMainCodeDesc);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(274, 329);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Description";
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
            infoPanel.Location = new Point(3, 183);
            infoPanel.Name = "infoPanel";
            infoPanel.Size = new Size(268, 143);
            infoPanel.TabIndex = 2;
            // 
            // lblTotalSize
            // 
            lblTotalSize.AutoSize = true;
            lblTotalSize.Location = new Point(3, 77);
            lblTotalSize.Name = "lblTotalSize";
            lblTotalSize.Size = new Size(63, 15);
            lblTotalSize.TabIndex = 5;
            lblTotalSize.Text = "Total size : ";
            // 
            // lblIndexSize
            // 
            lblIndexSize.AutoSize = true;
            lblIndexSize.Location = new Point(3, 62);
            lblIndexSize.Name = "lblIndexSize";
            lblIndexSize.Size = new Size(67, 15);
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
            // splitter1
            // 
            splitter1.Dock = DockStyle.Top;
            splitter1.Location = new Point(3, 178);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(268, 5);
            splitter1.TabIndex = 1;
            splitter1.TabStop = false;
            // 
            // tbMainCodeDesc
            // 
            tbMainCodeDesc.Dock = DockStyle.Top;
            tbMainCodeDesc.Enabled = false;
            tbMainCodeDesc.Location = new Point(3, 19);
            tbMainCodeDesc.Multiline = true;
            tbMainCodeDesc.Name = "tbMainCodeDesc";
            tbMainCodeDesc.Size = new Size(268, 159);
            tbMainCodeDesc.TabIndex = 0;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(groupBox2);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(groupBox3);
            splitContainer4.Size = new Size(805, 329);
            splitContainer4.SplitterDistance = 352;
            splitContainer4.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chartSnippetNum);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(352, 329);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chart - Snippets by language";
            // 
            // chartSnippetNum
            // 
            chartArea1.Name = "ChartArea1";
            chartSnippetNum.ChartAreas.Add(chartArea1);
            chartSnippetNum.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartSnippetNum.Legends.Add(legend1);
            chartSnippetNum.Location = new Point(3, 19);
            chartSnippetNum.Name = "chartSnippetNum";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartSnippetNum.Series.Add(series1);
            chartSnippetNum.Size = new Size(346, 307);
            chartSnippetNum.TabIndex = 0;
            chartSnippetNum.Text = "chart1";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(chartNumOfWiew);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(449, 329);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Chart - Top 5 views";
            // 
            // chartNumOfWiew
            // 
            chartArea2.Name = "ChartArea1";
            chartNumOfWiew.ChartAreas.Add(chartArea2);
            chartNumOfWiew.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            chartNumOfWiew.Legends.Add(legend2);
            chartNumOfWiew.Location = new Point(3, 19);
            chartNumOfWiew.Name = "chartNumOfWiew";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartNumOfWiew.Series.Add(series2);
            chartNumOfWiew.Size = new Size(443, 307);
            chartNumOfWiew.TabIndex = 0;
            chartNumOfWiew.Text = "chart1";
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1340, 745);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Name = "MainForm";
            Text = "Snippet Store";
            Activated += MainForm_Activated;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            infoPanel.ResumeLayout(false);
            infoPanel.PerformLayout();
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartSnippetNum).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartNumOfWiew).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStrip toolStrip1;
        private SplitContainer splitContainer1;
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
        private SplitContainer splitContainer3;
        private GroupBox groupBox1;
        private SplitContainer splitContainer4;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox tbMainCodeDesc;
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
        private Splitter splitter1;
        private Panel infoPanel;
        private Label lblDbName;
        private Label lblNoColls;
        private Label lblDatabaseSize;
        private Label lblStorageSize;
        private Label lblIndexSize;
        private Label lblTotalSize;
    }
}
