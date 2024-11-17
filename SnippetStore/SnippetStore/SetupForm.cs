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
        private List<string> _languages;

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
                var mongoHelper = new MongoHelper();
                mongoHelper.AddLanguages(newLang);
                tbNewLang.Clear();
            }
        }

        private void btnRemoveLang_Click(object sender, EventArgs e)
        {            
            if (lbLanguages.SelectedItem != null)
            {
                MongoHelper mongoHelper = new MongoHelper();
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
            var mongoHelper = new MongoHelper();
            lbLanguages.Items.Clear();
            _languages = mongoHelper.GetLanguages();
            if (_languages.Count != 0)
            {
                foreach (var lang in _languages)
                {
                    lbLanguages.Items.Add(lang);
                }
            }
        }
    }
}
