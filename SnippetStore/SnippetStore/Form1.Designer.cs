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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            statusStrip1 = new StatusStrip();
            toolStrip1 = new ToolStrip();
            btnAddNewSnippet = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnSetup = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            splitContainer1 = new SplitContainer();
            treeView1 = new TreeView();
            rtbMainCode = new RichTextBox();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnAddNewSnippet, toolStripSeparator1, btnSetup, toolStripSeparator2 });
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
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 55);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(rtbMainCode);
            splitContainer1.Size = new Size(1340, 668);
            splitContainer1.SplitterDistance = 614;
            splitContainer1.TabIndex = 2;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(614, 668);
            treeView1.TabIndex = 0;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            // 
            // rtbMainCode
            // 
            rtbMainCode.AcceptsTab = true;
            rtbMainCode.Dock = DockStyle.Fill;
            rtbMainCode.Font = new Font("Cascadia Code", 10F);
            rtbMainCode.Location = new Point(0, 0);
            rtbMainCode.Name = "rtbMainCode";
            rtbMainCode.ReadOnly = true;
            rtbMainCode.Size = new Size(722, 668);
            rtbMainCode.TabIndex = 0;
            rtbMainCode.Text = "";
            rtbMainCode.WordWrap = false;
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
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStrip toolStrip1;
        private SplitContainer splitContainer1;
        private TreeView treeView1;
        private RichTextBox rtbMainCode;
        private ToolStripButton btnAddNewSnippet;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnSetup;
        private ToolStripSeparator toolStripSeparator2;
    }
}
