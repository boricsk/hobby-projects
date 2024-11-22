namespace SnippetStore
{
    partial class AddNewSnippetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusBar = new StatusStrip();
            btnAddDatabase = new Button();
            fontDialog = new FontDialog();
            colorDialog = new ColorDialog();
            tabPage1 = new TabPage();
            gbSnippetName = new GroupBox();
            tbSnippetName = new TextBox();
            groupBox2 = new GroupBox();
            lbKeywords = new ListBox();
            btnAddKeyw = new Button();
            btnRemoveKeyw = new Button();
            lbAvailKeyw = new ListBox();
            tbSearchKeyw = new TextBox();
            groupBox3 = new GroupBox();
            tbShortDesc = new TextBox();
            groupBox1 = new GroupBox();
            cbLanguages = new ComboBox();
            groupBox4 = new GroupBox();
            tbCode = new RichTextBox();
            tabControl1 = new TabControl();
            tabPage1.SuspendLayout();
            gbSnippetName.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // statusBar
            // 
            statusBar.Location = new Point(0, 562);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(1487, 22);
            statusBar.TabIndex = 3;
            statusBar.Text = "statusBar";
            // 
            // btnAddDatabase
            // 
            btnAddDatabase.FlatStyle = FlatStyle.Flat;
            btnAddDatabase.Location = new Point(1320, 503);
            btnAddDatabase.Name = "btnAddDatabase";
            btnAddDatabase.Size = new Size(151, 44);
            btnAddDatabase.TabIndex = 7;
            btnAddDatabase.Text = "Add to database";
            btnAddDatabase.UseVisualStyleBackColor = true;
            btnAddDatabase.Click += btnAddDatabase_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox4);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(gbSnippetName);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1455, 461);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Add code";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbSnippetName
            // 
            gbSnippetName.Controls.Add(tbSnippetName);
            gbSnippetName.Location = new Point(6, 6);
            gbSnippetName.Name = "gbSnippetName";
            gbSnippetName.Size = new Size(340, 65);
            gbSnippetName.TabIndex = 1;
            gbSnippetName.TabStop = false;
            gbSnippetName.Text = "Snippet name";
            // 
            // tbSnippetName
            // 
            tbSnippetName.Location = new Point(6, 22);
            tbSnippetName.Name = "tbSnippetName";
            tbSnippetName.Size = new Size(328, 23);
            tbSnippetName.TabIndex = 0;
            tbSnippetName.TextChanged += tbSnippetName_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tbSearchKeyw);
            groupBox2.Controls.Add(lbAvailKeyw);
            groupBox2.Controls.Add(btnRemoveKeyw);
            groupBox2.Controls.Add(btnAddKeyw);
            groupBox2.Controls.Add(lbKeywords);
            groupBox2.FlatStyle = FlatStyle.Popup;
            groupBox2.Location = new Point(6, 77);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(340, 378);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Keywords";
            // 
            // lbKeywords
            // 
            lbKeywords.FormattingEnabled = true;
            lbKeywords.ItemHeight = 15;
            lbKeywords.Location = new Point(199, 18);
            lbKeywords.Name = "lbKeywords";
            lbKeywords.Size = new Size(135, 349);
            lbKeywords.TabIndex = 1;
            // 
            // btnAddKeyw
            // 
            btnAddKeyw.FlatStyle = FlatStyle.Flat;
            btnAddKeyw.Location = new Point(147, 19);
            btnAddKeyw.Name = "btnAddKeyw";
            btnAddKeyw.Size = new Size(46, 23);
            btnAddKeyw.TabIndex = 2;
            btnAddKeyw.Text = ">>";
            btnAddKeyw.UseVisualStyleBackColor = true;
            btnAddKeyw.Click += btnAddKeyw_Click;
            // 
            // btnRemoveKeyw
            // 
            btnRemoveKeyw.FlatStyle = FlatStyle.Flat;
            btnRemoveKeyw.Location = new Point(147, 48);
            btnRemoveKeyw.Name = "btnRemoveKeyw";
            btnRemoveKeyw.Size = new Size(46, 23);
            btnRemoveKeyw.TabIndex = 3;
            btnRemoveKeyw.Text = "-";
            btnRemoveKeyw.UseVisualStyleBackColor = true;
            btnRemoveKeyw.Click += btnRemoveKeyw_Click;
            // 
            // lbAvailKeyw
            // 
            lbAvailKeyw.FormattingEnabled = true;
            lbAvailKeyw.ItemHeight = 15;
            lbAvailKeyw.Location = new Point(6, 48);
            lbAvailKeyw.Name = "lbAvailKeyw";
            lbAvailKeyw.Size = new Size(135, 319);
            lbAvailKeyw.TabIndex = 5;
            // 
            // tbSearchKeyw
            // 
            tbSearchKeyw.Location = new Point(6, 22);
            tbSearchKeyw.Name = "tbSearchKeyw";
            tbSearchKeyw.Size = new Size(135, 23);
            tbSearchKeyw.TabIndex = 6;
            tbSearchKeyw.TextChanged += tbSearchKeyw_TextChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(tbShortDesc);
            groupBox3.FlatStyle = FlatStyle.Flat;
            groupBox3.Location = new Point(355, 77);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(369, 378);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Short description";
            // 
            // tbShortDesc
            // 
            tbShortDesc.Dock = DockStyle.Fill;
            tbShortDesc.Location = new Point(3, 19);
            tbShortDesc.Multiline = true;
            tbShortDesc.Name = "tbShortDesc";
            tbShortDesc.Size = new Size(363, 356);
            tbShortDesc.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(cbLanguages);
            groupBox1.Location = new Point(352, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(375, 66);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Programming language";
            // 
            // cbLanguages
            // 
            cbLanguages.FormattingEnabled = true;
            cbLanguages.Location = new Point(6, 21);
            cbLanguages.Name = "cbLanguages";
            cbLanguages.Size = new Size(363, 23);
            cbLanguages.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(tbCode);
            groupBox4.FlatStyle = FlatStyle.Popup;
            groupBox4.Location = new Point(733, 7);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(716, 445);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "Code";
            // 
            // tbCode
            // 
            tbCode.AcceptsTab = true;
            tbCode.Dock = DockStyle.Fill;
            tbCode.Font = new Font("Cascadia Code", 10F, FontStyle.Regular, GraphicsUnit.Point, 238);
            tbCode.Location = new Point(3, 19);
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(710, 423);
            tbCode.TabIndex = 0;
            tbCode.Text = "";
            tbCode.WordWrap = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1463, 489);
            tabControl1.TabIndex = 6;
            // 
            // AddNewSnippetForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1487, 584);
            Controls.Add(btnAddDatabase);
            Controls.Add(tabControl1);
            Controls.Add(statusBar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AddNewSnippetForm";
            Text = "Add New Snippet";
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            gbSnippetName.ResumeLayout(false);
            gbSnippetName.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusBar;
        private Button btnAddDatabase;
        private FontDialog fontDialog;
        private ColorDialog colorDialog;
        private TabPage tabPage1;
        private GroupBox groupBox4;
        private RichTextBox tbCode;
        private GroupBox groupBox1;
        private ComboBox cbLanguages;
        private GroupBox groupBox3;
        private TextBox tbShortDesc;
        private GroupBox groupBox2;
        private TextBox tbSearchKeyw;
        private ListBox lbAvailKeyw;
        private Button btnRemoveKeyw;
        private Button btnAddKeyw;
        private ListBox lbKeywords;
        private GroupBox gbSnippetName;
        private TextBox tbSnippetName;
        private TabControl tabControl1;
    }
}