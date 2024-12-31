namespace SnippetStore
{
    partial class SetupForm
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox8 = new GroupBox();
            pSnipSepColor = new Panel();
            btnSnipSepColor = new Button();
            btnAddSnipSep = new Button();
            tbSnipSep = new TextBox();
            groupBox2 = new GroupBox();
            btnRemoveLang = new Button();
            btnAddLang = new Button();
            lbLanguages = new ListBox();
            tbNewLang = new TextBox();
            groupBox1 = new GroupBox();
            btnRemoveKeyw = new Button();
            btnAddKeyw = new Button();
            lbKeywords = new ListBox();
            tbAddKeyw = new TextBox();
            tabPage2 = new TabPage();
            groupBoxFont = new GroupBox();
            btnChangeFont = new Button();
            lblPreview = new Label();
            btnSyntaxConfigSave = new Button();
            groupBox6 = new GroupBox();
            cbSnipName = new CheckBox();
            cbCodeSnip = new CheckBox();
            cbDesc = new CheckBox();
            cbKeyw = new CheckBox();
            cbUseLocalDb = new CheckBox();
            groupBox7 = new GroupBox();
            tbConStringLocal = new TextBox();
            groupBox5 = new GroupBox();
            tbConString = new TextBox();
            groupBox4 = new GroupBox();
            pSepColor = new Panel();
            btnSetupSeparatorColor = new Button();
            btnRemoveBlockSep = new Button();
            btnAddBlockSep = new Button();
            lbBlockSep = new ListBox();
            tbBlockSep = new TextBox();
            groupBox3 = new GroupBox();
            btnSetupColor = new Button();
            pResWordColor = new Panel();
            btnRemoveReservedWord = new Button();
            btnAddReservedWord = new Button();
            lbResWord = new ListBox();
            tbReservedWords = new TextBox();
            colorDialog1 = new ColorDialog();
            fontDialog1 = new FontDialog();
            lblSnipSepPrev = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBoxFont.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(838, 495);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox8);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(830, 467);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Language and keyword";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(lblSnipSepPrev);
            groupBox8.Controls.Add(pSnipSepColor);
            groupBox8.Controls.Add(btnSnipSepColor);
            groupBox8.Controls.Add(btnAddSnipSep);
            groupBox8.Controls.Add(tbSnipSep);
            groupBox8.FlatStyle = FlatStyle.Popup;
            groupBox8.Location = new Point(556, 6);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(268, 455);
            groupBox8.TabIndex = 10;
            groupBox8.TabStop = false;
            groupBox8.Text = "Snipet separator";
            // 
            // pSnipSepColor
            // 
            pSnipSepColor.Location = new Point(182, 51);
            pSnipSepColor.Name = "pSnipSepColor";
            pSnipSepColor.Size = new Size(76, 23);
            pSnipSepColor.TabIndex = 9;
            // 
            // btnSnipSepColor
            // 
            btnSnipSepColor.FlatStyle = FlatStyle.Flat;
            btnSnipSepColor.Location = new Point(93, 51);
            btnSnipSepColor.Name = "btnSnipSepColor";
            btnSnipSepColor.Size = new Size(76, 23);
            btnSnipSepColor.TabIndex = 8;
            btnSnipSepColor.Text = "Color";
            btnSnipSepColor.UseVisualStyleBackColor = true;
            btnSnipSepColor.Click += btnSnipSepColor_Click;
            // 
            // btnAddSnipSep
            // 
            btnAddSnipSep.FlatStyle = FlatStyle.Flat;
            btnAddSnipSep.Location = new Point(6, 51);
            btnAddSnipSep.Name = "btnAddSnipSep";
            btnAddSnipSep.Size = new Size(76, 23);
            btnAddSnipSep.TabIndex = 2;
            btnAddSnipSep.Text = "Set";
            btnAddSnipSep.UseVisualStyleBackColor = true;
            btnAddSnipSep.Click += btnAddSnipSep_Click;
            // 
            // tbSnipSep
            // 
            tbSnipSep.Location = new Point(6, 22);
            tbSnipSep.Name = "tbSnipSep";
            tbSnipSep.Size = new Size(252, 23);
            tbSnipSep.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnRemoveLang);
            groupBox2.Controls.Add(btnAddLang);
            groupBox2.Controls.Add(lbLanguages);
            groupBox2.Controls.Add(tbNewLang);
            groupBox2.FlatStyle = FlatStyle.Popup;
            groupBox2.Location = new Point(6, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(268, 455);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Add language";
            // 
            // btnRemoveLang
            // 
            btnRemoveLang.FlatStyle = FlatStyle.Flat;
            btnRemoveLang.Location = new Point(158, 80);
            btnRemoveLang.Name = "btnRemoveLang";
            btnRemoveLang.Size = new Size(100, 23);
            btnRemoveLang.TabIndex = 3;
            btnRemoveLang.Text = "Remove";
            btnRemoveLang.UseVisualStyleBackColor = true;
            btnRemoveLang.Click += btnRemoveLang_Click;
            // 
            // btnAddLang
            // 
            btnAddLang.FlatStyle = FlatStyle.Flat;
            btnAddLang.Location = new Point(158, 51);
            btnAddLang.Name = "btnAddLang";
            btnAddLang.Size = new Size(100, 23);
            btnAddLang.TabIndex = 2;
            btnAddLang.Text = "Add";
            btnAddLang.UseVisualStyleBackColor = true;
            btnAddLang.Click += btnAddLang_Click;
            // 
            // lbLanguages
            // 
            lbLanguages.FormattingEnabled = true;
            lbLanguages.ItemHeight = 15;
            lbLanguages.Location = new Point(6, 51);
            lbLanguages.Name = "lbLanguages";
            lbLanguages.Size = new Size(146, 394);
            lbLanguages.TabIndex = 1;
            // 
            // tbNewLang
            // 
            tbNewLang.Location = new Point(6, 22);
            tbNewLang.Name = "tbNewLang";
            tbNewLang.Size = new Size(252, 23);
            tbNewLang.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRemoveKeyw);
            groupBox1.Controls.Add(btnAddKeyw);
            groupBox1.Controls.Add(lbKeywords);
            groupBox1.Controls.Add(tbAddKeyw);
            groupBox1.FlatStyle = FlatStyle.Popup;
            groupBox1.Location = new Point(280, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(268, 455);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add keywords";
            // 
            // btnRemoveKeyw
            // 
            btnRemoveKeyw.FlatStyle = FlatStyle.Flat;
            btnRemoveKeyw.Location = new Point(158, 80);
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
            btnAddKeyw.Location = new Point(158, 51);
            btnAddKeyw.Name = "btnAddKeyw";
            btnAddKeyw.Size = new Size(100, 23);
            btnAddKeyw.TabIndex = 2;
            btnAddKeyw.Text = "Add";
            btnAddKeyw.UseVisualStyleBackColor = true;
            btnAddKeyw.Click += btnAddKeyw_Click;
            // 
            // lbKeywords
            // 
            lbKeywords.FormattingEnabled = true;
            lbKeywords.ItemHeight = 15;
            lbKeywords.Location = new Point(6, 51);
            lbKeywords.Name = "lbKeywords";
            lbKeywords.Size = new Size(146, 394);
            lbKeywords.TabIndex = 1;
            // 
            // tbAddKeyw
            // 
            tbAddKeyw.Location = new Point(6, 22);
            tbAddKeyw.Name = "tbAddKeyw";
            tbAddKeyw.Size = new Size(252, 23);
            tbAddKeyw.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBoxFont);
            tabPage2.Controls.Add(btnSyntaxConfigSave);
            tabPage2.Controls.Add(groupBox6);
            tabPage2.Controls.Add(cbUseLocalDb);
            tabPage2.Controls.Add(groupBox7);
            tabPage2.Controls.Add(groupBox5);
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(830, 467);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Syntax and Connection";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBoxFont
            // 
            groupBoxFont.Controls.Add(btnChangeFont);
            groupBoxFont.Controls.Add(lblPreview);
            groupBoxFont.Location = new Point(554, 314);
            groupBoxFont.Name = "groupBoxFont";
            groupBoxFont.Size = new Size(268, 100);
            groupBoxFont.TabIndex = 16;
            groupBoxFont.TabStop = false;
            groupBoxFont.Text = "Codebox font";
            // 
            // btnChangeFont
            // 
            btnChangeFont.FlatStyle = FlatStyle.Flat;
            btnChangeFont.Location = new Point(71, 62);
            btnChangeFont.Name = "btnChangeFont";
            btnChangeFont.Size = new Size(111, 32);
            btnChangeFont.TabIndex = 1;
            btnChangeFont.Text = "Change font";
            btnChangeFont.UseVisualStyleBackColor = true;
            btnChangeFont.Click += btnChangeFont_Click;
            // 
            // lblPreview
            // 
            lblPreview.AutoSize = true;
            lblPreview.Font = new Font("Cascadia Code", 10F);
            lblPreview.Location = new Point(6, 19);
            lblPreview.Name = "lblPreview";
            lblPreview.Size = new Size(176, 18);
            lblPreview.TabIndex = 0;
            lblPreview.Text = "Selected font preview";
            // 
            // btnSyntaxConfigSave
            // 
            btnSyntaxConfigSave.FlatStyle = FlatStyle.Flat;
            btnSyntaxConfigSave.Location = new Point(554, 420);
            btnSyntaxConfigSave.Name = "btnSyntaxConfigSave";
            btnSyntaxConfigSave.Size = new Size(268, 31);
            btnSyntaxConfigSave.TabIndex = 15;
            btnSyntaxConfigSave.Text = "Test connection and save config";
            btnSyntaxConfigSave.UseVisualStyleBackColor = true;
            btnSyntaxConfigSave.Click += btnSyntaxConfigSave_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(cbSnipName);
            groupBox6.Controls.Add(cbCodeSnip);
            groupBox6.Controls.Add(cbDesc);
            groupBox6.Controls.Add(cbKeyw);
            groupBox6.FlatStyle = FlatStyle.Popup;
            groupBox6.Location = new Point(554, 176);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(268, 132);
            groupBox6.TabIndex = 14;
            groupBox6.TabStop = false;
            groupBox6.Text = "Search in ...";
            // 
            // cbSnipName
            // 
            cbSnipName.AutoSize = true;
            cbSnipName.Checked = true;
            cbSnipName.CheckState = CheckState.Checked;
            cbSnipName.Location = new Point(7, 100);
            cbSnipName.Name = "cbSnipName";
            cbSnipName.Size = new Size(99, 19);
            cbSnipName.TabIndex = 3;
            cbSnipName.Text = "Snippet name";
            cbSnipName.UseVisualStyleBackColor = true;
            // 
            // cbCodeSnip
            // 
            cbCodeSnip.AutoSize = true;
            cbCodeSnip.Checked = true;
            cbCodeSnip.CheckState = CheckState.Checked;
            cbCodeSnip.Location = new Point(6, 75);
            cbCodeSnip.Name = "cbCodeSnip";
            cbCodeSnip.Size = new Size(101, 19);
            cbCodeSnip.TabIndex = 2;
            cbCodeSnip.Text = "Code snippets";
            cbCodeSnip.UseVisualStyleBackColor = true;
            // 
            // cbDesc
            // 
            cbDesc.AutoSize = true;
            cbDesc.Checked = true;
            cbDesc.CheckState = CheckState.Checked;
            cbDesc.Location = new Point(7, 50);
            cbDesc.Name = "cbDesc";
            cbDesc.Size = new Size(121, 19);
            cbDesc.TabIndex = 1;
            cbDesc.Text = "Short descriptions";
            cbDesc.UseVisualStyleBackColor = true;
            // 
            // cbKeyw
            // 
            cbKeyw.AutoSize = true;
            cbKeyw.Checked = true;
            cbKeyw.CheckState = CheckState.Checked;
            cbKeyw.Location = new Point(7, 25);
            cbKeyw.Name = "cbKeyw";
            cbKeyw.Size = new Size(77, 19);
            cbKeyw.TabIndex = 0;
            cbKeyw.Text = "Keywords";
            cbKeyw.UseVisualStyleBackColor = true;
            // 
            // cbUseLocalDb
            // 
            cbUseLocalDb.AutoSize = true;
            cbUseLocalDb.Checked = true;
            cbUseLocalDb.CheckState = CheckState.Checked;
            cbUseLocalDb.Location = new Point(554, 151);
            cbUseLocalDb.Name = "cbUseLocalDb";
            cbUseLocalDb.Size = new Size(220, 19);
            cbUseLocalDb.TabIndex = 13;
            cbUseLocalDb.Text = "Use local database (Restart required!)";
            cbUseLocalDb.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(tbConStringLocal);
            groupBox7.FlatStyle = FlatStyle.Popup;
            groupBox7.Location = new Point(554, 76);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(270, 64);
            groupBox7.TabIndex = 12;
            groupBox7.TabStop = false;
            groupBox7.Text = "Connection string  (Local)";
            // 
            // tbConStringLocal
            // 
            tbConStringLocal.Location = new Point(6, 22);
            tbConStringLocal.Name = "tbConStringLocal";
            tbConStringLocal.Size = new Size(255, 23);
            tbConStringLocal.TabIndex = 0;
            tbConStringLocal.Text = "mongodb://localhost:27017";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(tbConString);
            groupBox5.FlatStyle = FlatStyle.Popup;
            groupBox5.Location = new Point(554, 6);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(270, 64);
            groupBox5.TabIndex = 11;
            groupBox5.TabStop = false;
            groupBox5.Text = "Connection string  (Cloud)";
            // 
            // tbConString
            // 
            tbConString.Location = new Point(6, 22);
            tbConString.Name = "tbConString";
            tbConString.Size = new Size(255, 23);
            tbConString.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(pSepColor);
            groupBox4.Controls.Add(btnSetupSeparatorColor);
            groupBox4.Controls.Add(btnRemoveBlockSep);
            groupBox4.Controls.Add(btnAddBlockSep);
            groupBox4.Controls.Add(lbBlockSep);
            groupBox4.Controls.Add(tbBlockSep);
            groupBox4.FlatStyle = FlatStyle.Popup;
            groupBox4.Location = new Point(280, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(268, 445);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "Add block separator";
            // 
            // pSepColor
            // 
            pSepColor.Location = new Point(158, 138);
            pSepColor.Name = "pSepColor";
            pSepColor.Size = new Size(100, 26);
            pSepColor.TabIndex = 9;
            // 
            // btnSetupSeparatorColor
            // 
            btnSetupSeparatorColor.FlatStyle = FlatStyle.Flat;
            btnSetupSeparatorColor.Location = new Point(158, 109);
            btnSetupSeparatorColor.Name = "btnSetupSeparatorColor";
            btnSetupSeparatorColor.Size = new Size(100, 23);
            btnSetupSeparatorColor.TabIndex = 8;
            btnSetupSeparatorColor.Text = "Color";
            btnSetupSeparatorColor.UseVisualStyleBackColor = true;
            btnSetupSeparatorColor.Click += btnSetupSeparatorColor_Click;
            // 
            // btnRemoveBlockSep
            // 
            btnRemoveBlockSep.FlatStyle = FlatStyle.Flat;
            btnRemoveBlockSep.Location = new Point(158, 80);
            btnRemoveBlockSep.Name = "btnRemoveBlockSep";
            btnRemoveBlockSep.Size = new Size(100, 23);
            btnRemoveBlockSep.TabIndex = 3;
            btnRemoveBlockSep.Text = "Remove";
            btnRemoveBlockSep.UseVisualStyleBackColor = true;
            btnRemoveBlockSep.Click += btnRemoveBlockSep_Click;
            // 
            // btnAddBlockSep
            // 
            btnAddBlockSep.FlatStyle = FlatStyle.Flat;
            btnAddBlockSep.Location = new Point(158, 51);
            btnAddBlockSep.Name = "btnAddBlockSep";
            btnAddBlockSep.Size = new Size(100, 23);
            btnAddBlockSep.TabIndex = 2;
            btnAddBlockSep.Text = "Add";
            btnAddBlockSep.UseVisualStyleBackColor = true;
            btnAddBlockSep.Click += btnAddBlockSep_Click;
            // 
            // lbBlockSep
            // 
            lbBlockSep.FormattingEnabled = true;
            lbBlockSep.ItemHeight = 15;
            lbBlockSep.Location = new Point(6, 51);
            lbBlockSep.Name = "lbBlockSep";
            lbBlockSep.Size = new Size(146, 379);
            lbBlockSep.TabIndex = 1;
            // 
            // tbBlockSep
            // 
            tbBlockSep.Location = new Point(6, 22);
            tbBlockSep.Name = "tbBlockSep";
            tbBlockSep.Size = new Size(252, 23);
            tbBlockSep.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnSetupColor);
            groupBox3.Controls.Add(pResWordColor);
            groupBox3.Controls.Add(btnRemoveReservedWord);
            groupBox3.Controls.Add(btnAddReservedWord);
            groupBox3.Controls.Add(lbResWord);
            groupBox3.Controls.Add(tbReservedWords);
            groupBox3.FlatStyle = FlatStyle.Popup;
            groupBox3.Location = new Point(6, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(268, 445);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Add reserved word";
            // 
            // btnSetupColor
            // 
            btnSetupColor.FlatStyle = FlatStyle.Flat;
            btnSetupColor.Location = new Point(158, 109);
            btnSetupColor.Name = "btnSetupColor";
            btnSetupColor.Size = new Size(100, 23);
            btnSetupColor.TabIndex = 7;
            btnSetupColor.Text = "Color";
            btnSetupColor.UseVisualStyleBackColor = true;
            btnSetupColor.Click += btnSetupColor_Click;
            // 
            // pResWordColor
            // 
            pResWordColor.Location = new Point(158, 138);
            pResWordColor.Name = "pResWordColor";
            pResWordColor.Size = new Size(100, 26);
            pResWordColor.TabIndex = 6;
            // 
            // btnRemoveReservedWord
            // 
            btnRemoveReservedWord.FlatStyle = FlatStyle.Flat;
            btnRemoveReservedWord.Location = new Point(158, 80);
            btnRemoveReservedWord.Name = "btnRemoveReservedWord";
            btnRemoveReservedWord.Size = new Size(100, 23);
            btnRemoveReservedWord.TabIndex = 3;
            btnRemoveReservedWord.Text = "Remove";
            btnRemoveReservedWord.UseVisualStyleBackColor = true;
            btnRemoveReservedWord.Click += btnRemoveReservedWord_Click;
            // 
            // btnAddReservedWord
            // 
            btnAddReservedWord.FlatStyle = FlatStyle.Flat;
            btnAddReservedWord.Location = new Point(158, 51);
            btnAddReservedWord.Name = "btnAddReservedWord";
            btnAddReservedWord.Size = new Size(100, 23);
            btnAddReservedWord.TabIndex = 2;
            btnAddReservedWord.Text = "Add";
            btnAddReservedWord.UseVisualStyleBackColor = true;
            btnAddReservedWord.Click += btnAddReservedWord_Click;
            // 
            // lbResWord
            // 
            lbResWord.FormattingEnabled = true;
            lbResWord.ItemHeight = 15;
            lbResWord.Location = new Point(6, 51);
            lbResWord.Name = "lbResWord";
            lbResWord.Size = new Size(146, 379);
            lbResWord.TabIndex = 1;
            // 
            // tbReservedWords
            // 
            tbReservedWords.Location = new Point(6, 22);
            tbReservedWords.Name = "tbReservedWords";
            tbReservedWords.Size = new Size(252, 23);
            tbReservedWords.TabIndex = 0;
            // 
            // lblSnipSepPrev
            // 
            lblSnipSepPrev.AutoSize = true;
            lblSnipSepPrev.Font = new Font("Cascadia Code", 10F);
            lblSnipSepPrev.Location = new Point(6, 85);
            lblSnipSepPrev.Name = "lblSnipSepPrev";
            lblSnipSepPrev.Size = new Size(176, 18);
            lblSnipSepPrev.TabIndex = 10;
            lblSnipSepPrev.Text = "Selected font preview";
            // 
            // SetupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 519);
            Controls.Add(tabControl1);
            Name = "SetupForm";
            Text = "Setup";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBoxFont.ResumeLayout(false);
            groupBoxFont.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBox2;
        private Button btnRemoveLang;
        private Button btnAddLang;
        private ListBox lbLanguages;
        private TextBox tbNewLang;
        private GroupBox groupBox1;
        private Button btnRemoveKeyw;
        private Button btnAddKeyw;
        private ListBox lbKeywords;
        private TextBox tbAddKeyw;
        private TabPage tabPage2;
        private GroupBox groupBox3;
        private Button btnRemoveReservedWord;
        private Button btnAddReservedWord;
        private ListBox lbResWord;
        private TextBox tbReservedWords;
        private GroupBox groupBox4;
        private Button btnRemoveBlockSep;
        private Button btnAddBlockSep;
        private ListBox lbBlockSep;
        private TextBox tbBlockSep;
        private Button btnSetupColor;
        private Panel pResWordColor;
        private ColorDialog colorDialog1;
        private GroupBox groupBox5;
        private TextBox tbConString;
        private Panel pSepColor;
        private Button btnSetupSeparatorColor;
        private FontDialog fontDialog1;
        private GroupBox groupBox7;
        private TextBox tbConStringLocal;
        private CheckBox cbUseLocalDb;
        private Button btnSyntaxConfigSave;
        private GroupBox groupBox6;
        private CheckBox cbSnipName;
        private CheckBox cbCodeSnip;
        private CheckBox cbDesc;
        private CheckBox cbKeyw;
        private GroupBox groupBoxFont;
        private Label lblPreview;
        private Button btnChangeFont;
        private GroupBox groupBox8;
        private Panel pSnipSepColor;
        private Button btnSnipSepColor;
        private Button btnAddSnipSep;
        private TextBox tbSnipSep;
        private Label lblSnipSepPrev;
    }
}