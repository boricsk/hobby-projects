﻿using System;
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
        MongoHelper mongoHelper = new MongoHelper();
        public AddNewSnippetForm()
        {
            InitializeComponent();
            UpdateLanguages();
            UpdateKeywords();
        }
        private void UpdateLanguages()
        {            
            var languages = mongoHelper.GetLanguages();
            cbLanguages.Items.Clear();
            foreach (var lang in languages)
            {
                if (lang != null) { cbLanguages.Items.Add(lang); }               
            }
        }

        private void UpdateKeywords()
        {            
            var keywords = mongoHelper.GetKeywords();
            lbAvailKeyw.Items.Clear();
            foreach (var keyw in keywords)
            {
                if (keyw != null) { lbAvailKeyw.Items.Add(keyw); }
            }
        }

        private void btnAddKeyw_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbAvailKeyw.Text) && !lbKeywords.Items.Contains(lbAvailKeyw.Text))
            {
                lbKeywords.Items.Add(lbAvailKeyw.Text);
                //tbKeyword.Selected = null;
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

        private void btnFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                if (tbCode.SelectedText != "")
                {
                    tbCode.SelectionFont = fontDialog.Font;
                }
                else
                {
                    tbCode.Font = fontDialog.Font;
                }
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if (tbCode.SelectedText != "")
                {
                    tbCode.SelectionColor = colorDialog.Color;
                }
                else
                {
                    tbCode.ForeColor = colorDialog.Color;
                }
            }
        }

        private void tbSearchKeyw_TextChanged(object sender, EventArgs e)
        {
            if (tbSearchKeyw.Text != "")
            {
                string filterText = tbSearchKeyw.Text.ToLower();
                var filteredItems = lbAvailKeyw.Items.Cast<string>().Where(item => item.ToLower().Contains(filterText)).ToArray();

                lbAvailKeyw.Items.Clear();
                lbAvailKeyw.Items.AddRange(filteredItems);
            } else
            {
                UpdateKeywords();
            }
        }
    }
}
