using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnippetStore
{
    public partial class AddNewSnippetForm : Form
    {

        public AddNewSnippetForm()
        {
            InitializeComponent();
            UpdateLanguages();
        }
        private void UpdateLanguages()
        {
            MongoHelper mongoHelper = new MongoHelper();
            var languages = mongoHelper.GetLanguages();
            cbLanguages.Items.Clear();
            foreach (var lang in languages)
            {
                cbLanguages.Items.Add(lang);
            }
        }

        private void btnAddKeyw_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbKeyword.Text) && !lbKeywords.Items.Contains(tbKeyword.Text))
            {
                lbKeywords.Items.Add(tbKeyword.Text);
                tbKeyword.Clear();
            }
        }

        private void btnRemoveKeyw_Click(object sender, EventArgs e)
        {
            var selectedItem = lbKeywords.SelectedItem;
            if (lbKeywords.SelectedItem != null && selectedItem != null)
            {
                lbKeywords.Items.Remove(selectedItem);
                lbKeywords.Update();
            }
        }

        private void btnAddDatabase_Click(object sender, EventArgs e)
        {
            MongoHelper mongoHelper = new MongoHelper();
            SnippetDatabase snippet = new SnippetDatabase();
            if (tbSnippetName.Text != "")
            {
                snippet.SnipName = tbSnippetName.Text;
            }
            else
            {
                MessageBox.Show("Snippet name is required");
                return;
            }

            if (lbKeywords.Items.Count != 0)
            {
                foreach (var item in lbKeywords.Items)
                {
                    snippet.SnipKeywords.Add(item.ToString()!);
                }
            }
            else
            {
                MessageBox.Show("Keywords are required");
                return;
            }

            if (tbShortDesc.Text != "")
            {
                snippet.SnipShortDesc = tbShortDesc.Text;
            }
            else
            {
                MessageBox.Show("Short description is required");
                return;
            }

            if (cbLanguages.SelectedItem != null)
            {
                snippet.SnipLanguage = cbLanguages.SelectedItem.ToString()!;
            }
            else
            {
                MessageBox.Show("Programming language is required");
                return;
            }

            if (tbCode.Text != "")
            {
                snippet.SnipCode = tbCode.Rtf!;
            }
            else
            {
                MessageBox.Show("Code snippet is required");
                return;
            }

            snippet.SnipCreatedDate = DateTime.Now;
            mongoHelper.AddSnippet(snippet);
            ClearFields();
        }

        public void ClearFields()
        {
            tbSnippetName.Clear();
            lbKeywords.Items.Clear();
            tbShortDesc.Clear();
            cbLanguages.SelectedItem = null;
            tbCode.Clear();
        }
    }
}
