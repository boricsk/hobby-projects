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
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnRemoveLang);
            groupBox2.Controls.Add(btnAddLang);
            groupBox2.Controls.Add(lbLanguages);
            groupBox2.Controls.Add(tbNewLang);
            groupBox2.FlatStyle = FlatStyle.Popup;
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(268, 378);
            groupBox2.TabIndex = 4;
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
            groupBox1.Location = new Point(286, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(268, 378);
            groupBox1.TabIndex = 5;
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
            // SetupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1146, 450);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "SetupForm";
            Text = "Setup";
            Activated += SetupForm_Activated;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

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
    }
}