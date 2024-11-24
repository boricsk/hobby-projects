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
            gbCode = new GroupBox();
            tbCode = new RichTextBox();
            gbLanguage = new GroupBox();
            cbLanguages = new ComboBox();
            gbDesc = new GroupBox();
            tbShortDesc = new TextBox();
            gbKeyword = new GroupBox();
            tbSearchKeyw = new TextBox();
            lbAvailKeyw = new ListBox();
            btnRemoveKeyw = new Button();
            btnAddKeyw = new Button();
            lbKeywords = new ListBox();
            gbSnippetName = new GroupBox();
            tbSnippetName = new TextBox();
            tabControl1 = new TabControl();
            tabPage1.SuspendLayout();
            gbCode.SuspendLayout();
            gbLanguage.SuspendLayout();
            gbDesc.SuspendLayout();
            gbKeyword.SuspendLayout();
            gbSnippetName.SuspendLayout();
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
            tabPage1.Controls.Add(gbCode);
            tabPage1.Controls.Add(gbLanguage);
            tabPage1.Controls.Add(gbDesc);
            tabPage1.Controls.Add(gbKeyword);
            tabPage1.Controls.Add(gbSnippetName);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1455, 461);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Add code";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbCode
            // 
            gbCode.Controls.Add(tbCode);
            gbCode.FlatStyle = FlatStyle.Popup;
            gbCode.Location = new Point(733, 7);
            gbCode.Name = "gbCode";
            gbCode.Size = new Size(716, 445);
            gbCode.TabIndex = 9;
            gbCode.TabStop = false;
            gbCode.Text = "Code";
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
            // gbLanguage
            // 
            gbLanguage.AutoSize = true;
            gbLanguage.Controls.Add(cbLanguages);
            gbLanguage.Location = new Point(12, 7);
            gbLanguage.Name = "gbLanguage";
            gbLanguage.Size = new Size(334, 66);
            gbLanguage.TabIndex = 8;
            gbLanguage.TabStop = false;
            gbLanguage.Text = "Programming language";
            // 
            // cbLanguages
            // 
            cbLanguages.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLanguages.FlatStyle = FlatStyle.Flat;
            cbLanguages.FormattingEnabled = true;
            cbLanguages.Location = new Point(6, 21);
            cbLanguages.Name = "cbLanguages";
            cbLanguages.Size = new Size(322, 23);
            cbLanguages.TabIndex = 0;
            cbLanguages.SelectedValueChanged += cbLanguages_SelectedValueChanged;
            cbLanguages.Leave += cbLanguages_Leave;
            // 
            // gbDesc
            // 
            gbDesc.Controls.Add(tbShortDesc);
            gbDesc.FlatStyle = FlatStyle.Flat;
            gbDesc.Location = new Point(355, 77);
            gbDesc.Name = "gbDesc";
            gbDesc.Size = new Size(369, 378);
            gbDesc.TabIndex = 7;
            gbDesc.TabStop = false;
            gbDesc.Text = "Short description";
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
            // gbKeyword
            // 
            gbKeyword.Controls.Add(tbSearchKeyw);
            gbKeyword.Controls.Add(lbAvailKeyw);
            gbKeyword.Controls.Add(btnRemoveKeyw);
            gbKeyword.Controls.Add(btnAddKeyw);
            gbKeyword.Controls.Add(lbKeywords);
            gbKeyword.FlatStyle = FlatStyle.Popup;
            gbKeyword.Location = new Point(6, 77);
            gbKeyword.Name = "gbKeyword";
            gbKeyword.Size = new Size(340, 378);
            gbKeyword.TabIndex = 3;
            gbKeyword.TabStop = false;
            gbKeyword.Text = "Keywords";
            // 
            // tbSearchKeyw
            // 
            tbSearchKeyw.Location = new Point(6, 22);
            tbSearchKeyw.Name = "tbSearchKeyw";
            tbSearchKeyw.Size = new Size(135, 23);
            tbSearchKeyw.TabIndex = 6;
            tbSearchKeyw.TextChanged += tbSearchKeyw_TextChanged;
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
            // lbKeywords
            // 
            lbKeywords.FormattingEnabled = true;
            lbKeywords.ItemHeight = 15;
            lbKeywords.Location = new Point(199, 18);
            lbKeywords.Name = "lbKeywords";
            lbKeywords.Size = new Size(135, 349);
            lbKeywords.TabIndex = 1;
            // 
            // gbSnippetName
            // 
            gbSnippetName.Controls.Add(tbSnippetName);
            gbSnippetName.Location = new Point(355, 6);
            gbSnippetName.Name = "gbSnippetName";
            gbSnippetName.Size = new Size(369, 67);
            gbSnippetName.TabIndex = 1;
            gbSnippetName.TabStop = false;
            gbSnippetName.Text = "Snippet name";
            // 
            // tbSnippetName
            // 
            tbSnippetName.Enabled = false;
            tbSnippetName.Location = new Point(6, 25);
            tbSnippetName.Name = "tbSnippetName";
            tbSnippetName.Size = new Size(354, 23);
            tbSnippetName.TabIndex = 0;
            tbSnippetName.TextChanged += tbSnippetName_TextChanged;
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
            gbCode.ResumeLayout(false);
            gbLanguage.ResumeLayout(false);
            gbDesc.ResumeLayout(false);
            gbDesc.PerformLayout();
            gbKeyword.ResumeLayout(false);
            gbKeyword.PerformLayout();
            gbSnippetName.ResumeLayout(false);
            gbSnippetName.PerformLayout();
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
        private GroupBox gbCode;
        private RichTextBox tbCode;
        private GroupBox gbLanguage;
        private ComboBox cbLanguages;
        private GroupBox gbDesc;
        private TextBox tbShortDesc;
        private GroupBox gbKeyword;
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