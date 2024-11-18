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
    public partial class SetupForm : Form
    {
        private List<string?>? _parameters;
        MongoHelper mongoHelper = new MongoHelper();
        public SetupForm()
        {
            InitializeComponent();
        }

        private void SetupForm_Activated(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void btnAddLang_Click(object sender, EventArgs e)
        {
            string newLang = tbNewLang.Text;
            if (!string.IsNullOrEmpty(newLang) && !lbLanguages.Items.Contains(newLang))
            {
                lbLanguages.Items.Add(newLang);
                mongoHelper.AddLanguages(newLang);
                tbNewLang.Clear();
            }
        }

        private void btnRemoveLang_Click(object sender, EventArgs e)
        {
            if (lbLanguages.SelectedItem != null)
            {
                string? selectedLang = lbLanguages.SelectedItem.ToString();
                if (selectedLang != null)
                {
                    mongoHelper.DeleteLanguage(selectedLang);
                    UpdateList();
                }
            }
        }

        private void UpdateList()
        {
            ClearListBoxes();

            UpdateLists(_parameters = mongoHelper.GetLanguages(), () =>
                {
                    foreach (var lang in _parameters)
                    {
                        if (lang != null) { lbLanguages.Items.Add(lang); }
                    }
                });

            UpdateLists(_parameters = mongoHelper.GetKeywords(), () =>
                {
                    foreach (var keyword in _parameters)
                    {
                        if (keyword != null) { lbKeywords.Items.Add(keyword); }
                    }
                });

            UpdateLists(_parameters = mongoHelper.GetReswords(), () =>
                {
                    foreach (var resword in _parameters)
                    {
                        if (resword != null) { lbResWord.Items.Add(resword); }
                    }
                });

            UpdateLists(_parameters = mongoHelper.GetBlockSep(), () =>
            {
                foreach (var block in _parameters)
                {
                    if (block != null) { lbBlockSep.Items.Add(block); }
                }
            });
        }
        private void ClearListBoxes()
        {
            lbLanguages.Items.Clear();
            lbKeywords.Items.Clear();
            lbResWord.Items.Clear();
            lbBlockSep.Items.Clear();
        }
        private void UpdateLists(List<string?> updateList, Action action)
        {
            if (updateList.Count != 0)
            {
                action();
            }
        }

        private void btnAddKeyw_Click(object sender, EventArgs e)
        {
            string newKeyw = tbAddKeyw.Text;
            if (!string.IsNullOrEmpty(newKeyw) && !lbKeywords.Items.Contains(newKeyw))
            {
                lbKeywords.Items.Add(newKeyw);
                mongoHelper.AddKeyword(newKeyw);
                tbAddKeyw.Clear();
            }
        }

        private void btnRemoveKeyw_Click(object sender, EventArgs e)
        {
            if (lbKeywords.SelectedItem != null)
            {
                string? selectedKeyw = lbKeywords.SelectedItem.ToString();
                if (selectedKeyw != null)
                {
                    mongoHelper.DeleteKeyw(selectedKeyw);
                    UpdateList();
                }
            }
        }

        private void btnAddReservedWord_Click(object sender, EventArgs e)
        {
            string newWord = tbReservedWords.Text;
            if (!string.IsNullOrEmpty(newWord) && !lbResWord.Items.Contains(newWord))
            {
                lbResWord.Items.Add(newWord);
                var mongoHelper = new MongoHelper();
                mongoHelper.AddReservedWord(newWord);
                tbReservedWords.Clear();
            }

        }

        private void btnRemoveReservedWord_Click(object sender, EventArgs e)
        {
            if (lbResWord.SelectedItem != null)
            {
                string? selectedWord = lbResWord.SelectedItem.ToString();
                if (selectedWord != null)
                {
                    mongoHelper.DeleteResw(selectedWord);
                    UpdateList();
                }
            }
        }

        private void btnAddBlockSep_Click(object sender, EventArgs e)
        {
            string newBlockSep = tbBlockSep.Text;
            if (!string.IsNullOrEmpty(newBlockSep) && !lbBlockSep.Items.Contains(newBlockSep))
            {
                lbBlockSep.Items.Add(newBlockSep);
                mongoHelper.AddBlockSep(newBlockSep);
                tbBlockSep.Clear();
            }
        }

        private void btnRemoveBlockSep_Click(object sender, EventArgs e)
        {
            if (lbBlockSep.SelectedItem != null)
            {
                string? selectedBlockSep = lbBlockSep.SelectedItem.ToString();
                if (selectedBlockSep != null)
                {
                    mongoHelper.DeleteBlockSep(selectedBlockSep);
                    UpdateList();
                }
            }
        }
    }
}
