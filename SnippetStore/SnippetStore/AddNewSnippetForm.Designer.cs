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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox1 = new GroupBox();
            cbLanguages = new ComboBox();
            groupBox3 = new GroupBox();
            tbShortDesc = new TextBox();
            groupBox2 = new GroupBox();
            btnRemoveKeyw = new Button();
            btnAddKeyw = new Button();
            lbKeywords = new ListBox();
            tbKeyword = new TextBox();
            gbSnippetName = new GroupBox();
            tbSnippetName = new TextBox();
            tabPage2 = new TabPage();
            groupBox4 = new GroupBox();
            tbCode = new RichTextBox();
            btnAddDatabase = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            gbSnippetName.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // statusBar
            // 
            statusBar.Location = new Point(0, 562);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(768, 22);
            statusBar.TabIndex = 3;
            statusBar.Text = "statusBar";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(745, 489);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(gbSnippetName);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(737, 461);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "General";
            tabPage1.UseVisualStyleBackColor = true;
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
            // groupBox2
            // 
            groupBox2.Controls.Add(btnRemoveKeyw);
            groupBox2.Controls.Add(btnAddKeyw);
            groupBox2.Controls.Add(lbKeywords);
            groupBox2.Controls.Add(tbKeyword);
            groupBox2.FlatStyle = FlatStyle.Popup;
            groupBox2.Location = new Point(6, 77);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(340, 378);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Keywords";
            // 
            // btnRemoveKeyw
            // 
            btnRemoveKeyw.FlatStyle = FlatStyle.Flat;
            btnRemoveKeyw.Location = new Point(234, 80);
            btnRemoveKeyw.Name = "btnRemoveKeyw";
            btnRemoveKeyw.Size = new Size(100, 23);
            btnRemoveKeyw.TabIndex = 3;
            btnRemoveKeyw.Text = "Remove";
            btnRemoveKeyw.UseVisualStyleBackColor = true;
            btnRemoveKeyw.Click += btnRemoveKeyw_Click;
            // 
            // btnAddKeyw
            // 
            btnAddKeyw.FlatStyle = FlatStyle.Flat;
            btnAddKeyw.Location = new Point(234, 51);
            btnAddKeyw.Name = "btnAddKeyw";
            btnAddKeyw.Size = new Size(100, 23);
            btnAddKeyw.TabIndex = 2;
            btnAddKeyw.Text = "Add to list";
            btnAddKeyw.UseVisualStyleBackColor = true;
            btnAddKeyw.Click += btnAddKeyw_Click;
            // 
            // lbKeywords
            // 
            lbKeywords.FormattingEnabled = true;
            lbKeywords.ItemHeight = 15;
            lbKeywords.Location = new Point(6, 51);
            lbKeywords.Name = "lbKeywords";
            lbKeywords.Size = new Size(222, 319);
            lbKeywords.TabIndex = 1;
            // 
            // tbKeyword
            // 
            tbKeyword.Location = new Point(6, 22);
            tbKeyword.Name = "tbKeyword";
            tbKeyword.Size = new Size(328, 23);
            tbKeyword.TabIndex = 0;
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
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(737, 461);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Code";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(tbCode);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.FlatStyle = FlatStyle.Popup;
            groupBox4.Location = new Point(3, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(731, 455);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "Code";
            // 
            // tbCode
            // 
            tbCode.AcceptsTab = true;
            tbCode.Dock = DockStyle.Fill;
            tbCode.Location = new Point(3, 19);
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(725, 433);
            tbCode.TabIndex = 0;
            tbCode.Text = "";
            tbCode.WordWrap = false;
            // 
            // btnAddDatabase
            // 
            btnAddDatabase.FlatStyle = FlatStyle.Flat;
            btnAddDatabase.Location = new Point(12, 507);
            btnAddDatabase.Name = "btnAddDatabase";
            btnAddDatabase.Size = new Size(151, 44);
            btnAddDatabase.TabIndex = 7;
            btnAddDatabase.Text = "Add to database";
            btnAddDatabase.UseVisualStyleBackColor = true;
            btnAddDatabase.Click += btnAddDatabase_Click;
            // 
            // AddNewSnippetForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 584);
            Controls.Add(btnAddDatabase);
            Controls.Add(tabControl1);
            Controls.Add(statusBar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AddNewSnippetForm";
            Text = "Add New Snippet";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            gbSnippetName.ResumeLayout(false);
            gbSnippetName.PerformLayout();
            tabPage2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusBar;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox gbSnippetName;
        private TextBox tbSnippetName;
        private TabPage tabPage2;
        private GroupBox groupBox2;
        private Button btnRemoveKeyw;
        private Button btnAddKeyw;
        private ListBox lbKeywords;
        private TextBox tbKeyword;
        private GroupBox groupBox4;
        private RichTextBox tbCode;
        private Button btnAddDatabase;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private TextBox tbShortDesc;
        private ComboBox cbLanguages;
    }
}