namespace SnippetStore
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void btnAddNewClick(object sender, EventArgs e)
        {
            AddNewSnippetForm addNewSnippetForm = new AddNewSnippetForm();
            addNewSnippetForm.Show();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            SetupForm setupForm = new SetupForm();
            setupForm.Show();
        }
    }
}
