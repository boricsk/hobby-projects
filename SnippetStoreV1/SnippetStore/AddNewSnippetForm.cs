using MongoDB.Driver;
using SnippetStore.MongoClass;
using SnippetStore.RegistryClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SnippetStore
{
    public partial class AddNewSnippetForm : Form
    {
        //MongoHelper mongoHelper = new MongoHelper();
        MongoConnectionManagement connMgmnt = new(RegistryOps.ReadConString());
        public AddNewSnippetForm()
        {
            InitializeComponent();
            _ = UpdateLanguages();
            _ = UpdateKeywords();
        }
        private async Task UpdateLanguages()
        {
            var lang_coll = connMgmnt.GetCollection<Languages>("Languages");
            MongoLanguage mongoLanguage = new(lang_coll);
            
            var languages = await mongoLanguage.GetLanguagesAsync();
            cbLanguages.Items.Clear();
            foreach (var lang in languages)
            {
                if (lang != null) { cbLanguages.Items.Add(lang); }
            }
        }

        private async Task UpdateKeywords()
        {
            var keyw_coll = connMgmnt.GetCollection<Keywords>("Keywords");
            MongoKeyword mongoKeyword = new(keyw_coll);

            var keywords = await mongoKeyword.GetKeywordsAsync();
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
        private void ShowNotify(int duration, string title, string message)
        {
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = message;
            notifyIcon.ShowBalloonTip(duration);
        }
        private async void btnAddDatabase_Click(object sender, EventArgs e)
        {
            var snip_coll = connMgmnt.GetCollection<SnippetDatabase>("SnippetStore");
            MongoSnipStore snipStore = new(snip_coll);
            SnippetDatabase snippet = new SnippetDatabase();

            if (tbSnippetName.Text != "")
            {
                snippet.SnipName = tbSnippetName.Text;
            }
            else
            {
                ShowNotify(3000, "Data error.", "Snippet name is required!");
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
                ShowNotify(3000, "Data error.", "Keywords are required!");
                return;
            }

            if (tbShortDesc.Text != "")
            {
                snippet.SnipShortDesc = tbShortDesc.Text;
            }
            else
            {
                ShowNotify(3000, "Data error.", "Short description is required!");                
                return;
            }

            if (cbLanguages.SelectedItem != null)
            {
                snippet.SnipLanguage = cbLanguages.SelectedItem.ToString()!;
            }
            else
            {
                ShowNotify(3000, "Data error.", "Programming language is required!");                
                return;
            }

            if (tbCode.Text != "")
            {
                snippet.SnipCode = tbCode.Rtf!;
            }
            else
            {
                ShowNotify(3000, "Data error.", "Code snippet is required!");                
                return;
            }

            snippet.SnipCreatedDate = DateTime.Now;
            await snipStore.AddSnippetAsync(snippet);
            ClearFields();
        }

        public void ClearFields()
        {
            tbSnippetName.Clear();
            //lbKeywords.Items.Clear();
            tbShortDesc.Clear();
            //cbLanguages.SelectedItem = null;
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
            }
            else
            {
                _ = UpdateKeywords();
            }
        }

        private void tbSnippetName_TextChanged(object sender, EventArgs e)
        {
            var snip_coll = connMgmnt.GetCollection<SnippetDatabase>("SnippetStore");
            MongoSnipStore snipStore = new(snip_coll);
            var SnipData = snipStore.GetSnipets().AsQueryable().ToList().Where(l => l.SnipLanguage == cbLanguages.Text).GroupBy(l => l.SnipName);
            foreach (var data in SnipData)
            {
                if (data.Key != null)
                {
                    if (tbSnippetName.Text == data.Key)
                    {
                        tbSnippetName.BackColor = Color.Red;
                        btnAddDatabase.Enabled = false;
                        break;
                    }
                    else
                    {
                        tbSnippetName.BackColor = Color.White;
                        btnAddDatabase.Enabled = true;
                    }
                }
            }
            tbShortDesc.Text = tbSnippetName.Text;

        }

        private void cbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbLanguages.SelectedIndex == -1)
            //{
            //    tbSnippetName.Enabled = false;
            //}
            //else
            //{
            //    tbSnippetName.Enabled = true;
            //}
        }

        private void cbLanguages_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbLanguages.SelectedIndex == -1)
            {
                tbSnippetName.Enabled = false;
            }
            else
            {
                tbSnippetName.Enabled = true;
            }
        }

        private void cbLanguages_Leave(object sender, EventArgs e)
        {
            if (cbLanguages.SelectedIndex == -1)
            {
                tbSnippetName.Enabled = false;
            }
            else
            {
                tbSnippetName.Enabled = true;
            }
        }
    }
}
