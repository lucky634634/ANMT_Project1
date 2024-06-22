using System.Diagnostics;
using System.Text.Json;

namespace Project_1
{
    public partial class DecryptForm : Form
    {
        public DecryptForm()
        {
            InitializeComponent();
        }

        private void encryptFileButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                encryptFileTextbox.Text = ofd.FileName;
                if (encryptFileTextbox.Text.EndsWith(".enc"))
                {
                    metadataTextbox.Text = encryptFileTextbox.Text.Substring(0, encryptFileTextbox.Text.Length - 4) + ".metadata";
                    decryptFileTextbox.Text = encryptFileTextbox.Text.Substring(0, encryptFileTextbox.Text.Length - 4);
                }
                else
                {
                    metadataTextbox.Text = ofd.FileName + ".metadata";
                    decryptFileTextbox.Text = ofd.FileName + ".dec";
                }
            }
        }

        private void metadataButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                metadataTextbox.Text = ofd.FileName;
            }
        }

        private void decryptFileButton_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                decryptFileTextbox.Text = sfd.FileName;
            }
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(encryptFileTextbox.Text) || !File.Exists(encryptFileTextbox.Text))
                {
                    MessageBox.Show("File không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(metadataTextbox.Text) || !File.Exists(metadataTextbox.Text))
                {
                    MessageBox.Show("File không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(decryptFileTextbox.Text))
                {
                    MessageBox.Show("File không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string filePath = encryptFileTextbox.Text;
                string metadataPath = metadataTextbox.Text;

                KeyMeta? keyMeta = JsonSerializer.Deserialize<KeyMeta>(File.ReadAllText(metadataPath));
                if (keyMeta == null)
                {
                    MessageBox.Show("File metadata không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string privateKey = keyTextbox.Text;

                if (CryptoModule.HashValue(privateKey, "SHA-1") != keyMeta.hash)
                {
                    MessageBox.Show("Khóa không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string key = CryptoModule.DecryptStringRSA(keyMeta.key, privateKey);
                CryptoModule.DecryptFileAES(filePath, decryptFileTextbox.Text, key);

                if (File.Exists(decryptFileTextbox.Text))
                {
                    MessageBox.Show("Giải mã thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        Arguments = "/select," + decryptFileTextbox.Text,
                        FileName = "explorer.exe"
                    };

                    Process.Start(startInfo);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void keyFileButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                keyTextbox.Text = File.ReadAllText(ofd.FileName);
            }
        }
    }
}
