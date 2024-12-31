using MongoDB.Driver;
using SnippetStore.MongoClass;
using SnippetStore.NotifyClass;
using SnippetStore.RegistryClass;
using SnippetStore.SearchClass;
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
        SearchManagement sm = new SearchManagement();
        string separator = string.Empty;
        public AddNewSnippetForm()
        {
            InitializeComponent();
            _ = UpdateLanguages();
            _ = UpdateKeywords();
            SetFont();
            separator = RegistryOps.ReadSnipSep();
        }
        private void SetFont()
        {
            if (RegistryOps.ReadFontType() != null)
            {
                tbCode.Font = RegistryOps.ReadFontType();
            }
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
                NotifyManagement.ShowNotifyMessage("Data error", "Snippet name is required!", 3000, ToolTipIcon.Error);
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
                NotifyManagement.ShowNotifyMessage("Data error", "Keywords are required!", 3000, ToolTipIcon.Error);
                return;
            }

            if (tbShortDesc.Text != "")
            {
                snippet.SnipShortDesc = tbShortDesc.Text;
            }
            else
            {

                return;
            }

            if (cbLanguages.SelectedItem != null)
            {
                snippet.SnipLanguage = cbLanguages.SelectedItem.ToString()!;
            }
            else
            {
                NotifyManagement.ShowNotifyMessage("Data error", "Programming language is required!", 3000, ToolTipIcon.Error);
                return;
            }

            if (tbCode.Text != "")
            {
                snippet.SnipCode = tbCode.Text!;
            }
            else
            {
                NotifyManagement.ShowNotifyMessage("Data error", "Code snippet is required!", 3000, ToolTipIcon.Error);
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
            if (sm.isNameInDatabase(tbSnippetName.Text))
            {
                tbSnippetName.BackColor = Color.Red;
                btnAddDatabase.Enabled = false;
            }
            else
            {
                tbSnippetName.BackColor = Color.White;
                btnAddDatabase.Enabled = true;
            }

            tbShortDesc.Text = tbSnippetName.Text;

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

        private void tsAddSeparator_Click(object sender, EventArgs e)
        {
            // Lekérdezzük a kurzor aktuális pozícióját
            int cursorPosition = tbCode.SelectionStart;

            // Lekérdezzük, hogy a kurzor melyik sorban van
            int currentLine = tbCode.GetLineFromCharIndex(cursorPosition);

            // Lekérjük az adott sor első karakterének indexét
            int firstCharIndexInLine = tbCode.GetFirstCharIndexFromLine(currentLine);

            // Ellenőrizzük, hogy a kurzor az első oszlopban van-e
            bool isCursorInFirstColumn = cursorPosition == firstCharIndexInLine;

            if (isCursorInFirstColumn)
            {
                // Az aktuális kurzor sorának indexe
                int currLine = tbCode.GetLineFromCharIndex(tbCode.SelectionStart);

                // Az aktuális sor első karakterének indexe
                int lineStartPosition = tbCode.GetFirstCharIndexFromLine(currLine);

                // A szöveg beszúrása a sor elejére
                tbCode.Text = tbCode.Text.Insert(lineStartPosition, separator);

                // Az új kurzorpozíció beállítása a beszúrt szöveg után
                tbCode.SelectionStart = lineStartPosition + separator.Length;

            }
        }
    }
}
