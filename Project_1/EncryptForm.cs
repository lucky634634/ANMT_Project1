using System.Diagnostics;
using System.Text.Json;

namespace Project_1
{
    public partial class EncryptForm : Form
    {
        public EncryptForm()
        {
            InitializeComponent();
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sourceTextbox.Text = ofd.FileName;
                metaFileTextbox.Text = ofd.FileName + ".metadata";
            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sourceTextbox.Text) || !File.Exists(sourceTextbox.Text))
                {
                    MessageBox.Show("File không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string filePath = sourceTextbox.Text;

                string key = CryptoModule.GenerateAESKey();
                if (string.IsNullOrWhiteSpace(encryptFileTextbox.Text))
                {
                    var sfd = new SaveFileDialog();
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        encryptFileTextbox.Text = sfd.FileName;
                    }
                }

                CryptoModule.EncryptFileAES(filePath, encryptFileTextbox.Text, key);

                string privateKey, publicKey;

                CryptoModule.GenerateRSAKeyPair(out privateKey, out publicKey);

                privateKeyTextbox.Text = privateKey;
                KeyMeta keyMeta = new KeyMeta(CryptoModule.EncryptStringRSA(key, publicKey), CryptoModule.HashValue(privateKey, "SHA-1"));

                if (string.IsNullOrWhiteSpace(metaFileTextbox.Text))
                {
                    var sfd = new SaveFileDialog();
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        metaFileTextbox.Text = sfd.FileName;
                    }
                }
                File.WriteAllText(metaFileTextbox.Text, JsonSerializer.Serialize(keyMeta));
                if (File.Exists(encryptFileTextbox.Text))
                {
                    MessageBox.Show("Mã hóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        Arguments = "/select," + encryptFileTextbox.Text,
                        FileName = "explorer.exe"
                    };

                    Process.Start(startInfo);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metaFileButton_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                metaFileTextbox.Text = sfd.FileName;
            }
        }

        private void encryptFileButton_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                encryptFileTextbox.Text = sfd.FileName;
            }
        }

        private void sourceTextbox_TextChanged(object sender, EventArgs e)
        {
            encryptFileTextbox.Text = sourceTextbox.Text + ".enc";
            metaFileTextbox.Text = sourceTextbox.Text + ".metadata";
        }

        private void saveKeyButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(privateKeyTextbox.Text))
            {
                MessageBox.Show("Chưa mã hóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var sfd = new SaveFileDialog();
            sfd.FileName = sourceTextbox.Text + ".key";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, privateKeyTextbox.Text);
            }
        }
    }
}
