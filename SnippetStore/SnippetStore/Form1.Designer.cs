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
            splitContainer1 = new SplitContainer();
            treeView1 = new TreeView();
            tbSearch2 = new TextBox();
            splitContainer2 = new SplitContainer();
            rtbMainCode = new RichTextBox();
            timer = new System.Windows.Forms.Timer(components);
            toolStripSeparator5 = new ToolStripSeparator();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.SuspendLayout();
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
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnAddNewSnippet, toolStripSeparator1, btnSetup, toolStripSeparator2, btnDel, toolStripSeparator3, btnSaveModify, btnCancelModify, toolStripSeparator4, btnExpandAll, btnCloseAll, toolStripSeparator5 });
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
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 55);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView1);
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
            treeView1.TabIndex = 2;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
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
            splitContainer2.Size = new Size(1083, 668);
            splitContainer2.SplitterDistance = 335;
            splitContainer2.TabIndex = 0;
            // 
            // rtbMainCode
            // 
            rtbMainCode.AcceptsTab = true;
            rtbMainCode.BackColor = SystemColors.Window;
            rtbMainCode.Dock = DockStyle.Fill;
            rtbMainCode.Font = new Font("Cascadia Code", 10F);
            rtbMainCode.Location = new Point(0, 0);
            rtbMainCode.Name = "rtbMainCode";
            rtbMainCode.ReadOnly = true;
            rtbMainCode.Size = new Size(1083, 335);
            rtbMainCode.TabIndex = 1;
            rtbMainCode.Text = "";
            rtbMainCode.WordWrap = false;
            rtbMainCode.DoubleClick += rtbMainCode_DoubleClick;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 55);
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
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
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
        private RichTextBox rtbMainCode;
        private System.Windows.Forms.Timer timer;
        //private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton btnDel;
        private TreeView treeView1;
        private TextBox tbSearch2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnSaveModify;
        private ToolStripButton btnCancelModify;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton btnExpandAll;
        private ToolStripButton btnCloseAll;
        private ToolStripSeparator toolStripSeparator5;
    }
}
