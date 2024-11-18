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
            groupBox4 = new GroupBox();
            btnRemoveBlockSep = new Button();
            btnAddBlockSep = new Button();
            lbBlockSep = new ListBox();
            tbBlockSep = new TextBox();
            groupBox3 = new GroupBox();
            btnRemoveReservedWord = new Button();
            btnAddReservedWord = new Button();
            lbResWord = new ListBox();
            tbReservedWords = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
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
            tabControl1.Size = new Size(874, 427);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(866, 399);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Parameters";
            tabPage1.UseVisualStyleBackColor = true;
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
            groupBox2.Size = new Size(268, 378);
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
            // 
            // lbLanguages
            // 
            lbLanguages.FormattingEnabled = true;
            lbLanguages.ItemHeight = 15;
            lbLanguages.Location = new Point(6, 51);
            lbLanguages.Name = "lbLanguages";
            lbLanguages.Size = new Size(146, 319);
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
            groupBox1.Size = new Size(268, 378);
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
            // 
            // lbKeywords
            // 
            lbKeywords.FormattingEnabled = true;
            lbKeywords.ItemHeight = 15;
            lbKeywords.Location = new Point(6, 51);
            lbKeywords.Name = "lbKeywords";
            lbKeywords.Size = new Size(146, 319);
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
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(866, 399);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Syntax";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnRemoveBlockSep);
            groupBox4.Controls.Add(btnAddBlockSep);
            groupBox4.Controls.Add(lbBlockSep);
            groupBox4.Controls.Add(tbBlockSep);
            groupBox4.FlatStyle = FlatStyle.Popup;
            groupBox4.Location = new Point(280, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(268, 378);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "Add block separator";
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
            lbBlockSep.Size = new Size(146, 319);
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
            groupBox3.Controls.Add(btnRemoveReservedWord);
            groupBox3.Controls.Add(btnAddReservedWord);
            groupBox3.Controls.Add(lbResWord);
            groupBox3.Controls.Add(tbReservedWords);
            groupBox3.FlatStyle = FlatStyle.Popup;
            groupBox3.Location = new Point(6, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(268, 378);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Add reserved word";
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
            lbResWord.Size = new Size(146, 319);
            lbResWord.TabIndex = 1;
            // 
            // tbReservedWords
            // 
            tbReservedWords.Location = new Point(6, 22);
            tbReservedWords.Name = "tbReservedWords";
            tbReservedWords.Size = new Size(252, 23);
            tbReservedWords.TabIndex = 0;
            // 
            // SetupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 556);
            Controls.Add(tabControl1);
            Name = "SetupForm";
            Text = "Setup";
            Activated += SetupForm_Activated;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
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
    }
}