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

namespace SnippetStore
{
    public partial class SetupForm : Form
    {
        private List<string?>? _parameters;
        private bool[] _searchOptions = new bool[4];
        //MongoHelper mongoHelper = new MongoHelper();
        
        MongoConnectionManagement connMgmnt = new(RegistryOps.ReadConString());
        
        public SetupForm()
        {
            InitializeComponent();
            _ = UpdateList();
            GetConfiguration();           
           
        }
        private async Task UpdateList()
        {
            var lang_coll = connMgmnt.GetCollection<Languages>("Languages");
            var keyw_coll = connMgmnt.GetCollection<Keywords>("Keywords");
            var resw_coll = connMgmnt.GetCollection<ResWords>("Reserved words");
            var blck_coll = connMgmnt.GetCollection<BlockSeparators>("Block separators");
            MongoLanguage mongoLanguage = new(lang_coll);
            MongoKeyword mongoKeyword = new(keyw_coll);
            MongoResWord mongoResword = new(resw_coll);
            MongoBlockSep mongoBlockSep = new(blck_coll);

            ClearListBoxes();

            UpdateLists(_parameters = await mongoLanguage.GetLanguagesAsync() , () =>
                {
                    foreach (var lang in _parameters)
                    {
                        if (lang != null) { lbLanguages.Items.Add(lang); }
                    }
                });

            UpdateLists(_parameters = await mongoKeyword.GetKeywordsAsync(), () =>
                {
                    foreach (var keyword in _parameters)
                    {
                        if (keyword != null) { lbKeywords.Items.Add(keyword); }
                    }
                });

            UpdateLists(_parameters = await mongoResword.GetReswordsAsync(), () =>
                {
                    foreach (var resword in _parameters)
                    {
                        if (resword != null) { lbResWord.Items.Add(resword); }
                    }
                });

            UpdateLists(_parameters = await mongoBlockSep.GetBlockSepAsync(), () =>
            {
                foreach (var block in _parameters)
                {
                    if (block != null) { lbBlockSep.Items.Add(block); }
                }
            });
        }
        private void GetConfiguration()
        {
            tbConString.Text = RegistryOps.ReadConString();
            tbConStringLocal.Text = RegistryOps.ReadConStringLocal();
            pResWordColor.BackColor = RegistryOps.ReadResWordColor();
            pSepColor.BackColor = RegistryOps.ReadBlockSepColor();
            _searchOptions = RegistryOps.ReadSearchOptions();
            cbUseLocalDb.Checked = RegistryOps.ReadDatabaseOption();
            cbCodeSnip.Checked = _searchOptions[0];
            cbDesc.Checked = _searchOptions[1];
            cbKeyw.Checked = _searchOptions[2];
            cbSnipName.Checked = _searchOptions[3];
            
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

        private async void btnAddLang_Click(object sender, EventArgs e)
        {
            var lang_coll = connMgmnt.GetCollection<Languages>("Languages");
            MongoLanguage mongoLanguage = new(lang_coll);

            string newLang = tbNewLang.Text;
            if (!string.IsNullOrEmpty(newLang) && !lbLanguages.Items.Contains(newLang))
            {
                lbLanguages.Items.Add(newLang);
                await mongoLanguage.AddLanguagesAsync(newLang);
                tbNewLang.Clear();
            }
        }

        private async void btnRemoveLang_Click(object sender, EventArgs e)
        {
            if (lbLanguages.SelectedItem != null)
            {
                string? selectedLang = lbLanguages.SelectedItem.ToString();
                if (selectedLang != null)
                {
                    var lang_coll = connMgmnt.GetCollection<Languages>("Languages");
                    MongoLanguage mongoLanguage = new(lang_coll);
                    await mongoLanguage.DeleteLanguageAsync(selectedLang);
                    _ = UpdateList();
                }
            }
        }

        private async void btnAddKeyw_Click(object sender, EventArgs e)
        {
            string newKeyw = tbAddKeyw.Text;
            if (!string.IsNullOrEmpty(newKeyw) && !lbKeywords.Items.Contains(newKeyw))
            {
                var keyw_coll = connMgmnt.GetCollection<Keywords>("Keywords");
                MongoKeyword mongoKeyword = new(keyw_coll);
                lbKeywords.Items.Add(newKeyw);
                await mongoKeyword.AddKeywordAsync(newKeyw);
                tbAddKeyw.Clear();
            }
        }

        private async void btnRemoveKeyw_Click(object sender, EventArgs e)
        {
            if (lbKeywords.SelectedItem != null)
            {
                string? selectedKeyw = lbKeywords.SelectedItem.ToString();
                if (selectedKeyw != null)
                {
                    var keyw_coll = connMgmnt.GetCollection<Keywords>("Keywords");
                    MongoKeyword mongoKeyword = new(keyw_coll);
                    await mongoKeyword.DeleteKeywAsync(selectedKeyw);
                    _ = UpdateList();
                }
            }
        }

        private async void btnAddReservedWord_Click(object sender, EventArgs e)
        {
            string newWord = tbReservedWords.Text;
            if (!string.IsNullOrEmpty(newWord) && !lbResWord.Items.Contains(newWord))
            {
                lbResWord.Items.Add(newWord);
                var resw_coll = connMgmnt.GetCollection<ResWords>("Reserved words");
                MongoResWord mongoResWord = new(resw_coll);                
                await mongoResWord.AddReservedWordAsync(newWord);
                tbReservedWords.Clear();
            }

        }

        private async void btnRemoveReservedWord_Click(object sender, EventArgs e)
        {
            if (lbResWord.SelectedItem != null)
            {
                string? selectedWord = lbResWord.SelectedItem.ToString();
                if (selectedWord != null)
                {
                    var resw_coll = connMgmnt.GetCollection<ResWords>("Reserved words");
                    MongoResWord mongoResWord = new(resw_coll);
                    await mongoResWord.DeleteReswAsync(selectedWord);
                    _ = UpdateList();
                }
            }
        }

        private async void btnAddBlockSep_Click(object sender, EventArgs e)
        {
            string newBlockSep = tbBlockSep.Text;
            if (!string.IsNullOrEmpty(newBlockSep) && !lbBlockSep.Items.Contains(newBlockSep))
            {
                var blck_coll = connMgmnt.GetCollection<BlockSeparators>("Block separators");
                MongoBlockSep blck = new(blck_coll);
                lbBlockSep.Items.Add(newBlockSep);
                await blck.AddBlockSepAync(newBlockSep);
                tbBlockSep.Clear();
            }
        }

        private async void btnRemoveBlockSep_Click(object sender, EventArgs e)
        {
            if (lbBlockSep.SelectedItem != null)
            {
                string? selectedBlockSep = lbBlockSep.SelectedItem.ToString();
                if (selectedBlockSep != null)
                {
                    var blck_coll = connMgmnt.GetCollection<BlockSeparators>("Block separators");
                    MongoBlockSep blck = new(blck_coll);
                    await blck.DeleteBlockSepAsync(selectedBlockSep);
                    _ = UpdateList();
                }
            }
        }

        private void btnSetupColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pResWordColor.BackColor = colorDialog1.Color;
            }
        }
        private void btnSetupSeparatorColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pSepColor.BackColor = colorDialog1.Color;
            }
        }

        private void btnSyntaxConfigSave_Click(object sender, EventArgs e)
        {
            RegistryOps.WriteConString(tbConString.Text);
            RegistryOps.WriteConStringLocal(tbConStringLocal.Text);
            RegistryOps.WriteResWordColor(pResWordColor.BackColor);
            RegistryOps.WriteBlockSepColor(pSepColor.BackColor);
            RegistryOps.WriteDatabaseOption(cbUseLocalDb.Checked);
            _searchOptions[0] = cbCodeSnip.Checked;
            _searchOptions[1] = cbDesc.Checked;
            _searchOptions[2] = cbKeyw.Checked;
            _searchOptions[3] = cbSnipName.Checked;
            RegistryOps.WriteSearchOptions(_searchOptions);
            this.Close();
        }
    }
}
