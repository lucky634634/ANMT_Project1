namespace Project_1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            var encryptForm = new EncryptForm();
            encryptForm.ShowDialog();
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            var decryptForm = new DecryptForm();
            decryptForm.ShowDialog();
        }
    }
}
