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

        // Event handler for the encrypt file button click
        private void encryptFileButton_Click(object sender, EventArgs e)
        {
            // Create a new OpenFileDialog instance
            var ofd = new OpenFileDialog();

            // Check if the dialog result is OK after the user selects a file
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Set the text of the encrypt file textbox to the selected file name
                encryptFileTextbox.Text = ofd.FileName;

                // Check if the file name ends with ".enc"
                if (encryptFileTextbox.Text.EndsWith(".enc"))
                {
                    // If the file name ends with ".enc", set metadata textbox to the corresponding metadata file name
                    metadataTextbox.Text = encryptFileTextbox.Text.Substring(0, encryptFileTextbox.Text.Length - 4) + ".metadata";

                    // Set decrypt file textbox to the corresponding decrypted file name
                    decryptFileTextbox.Text = encryptFileTextbox.Text.Substring(0, encryptFileTextbox.Text.Length - 4);
                }
                else
                {
                    // If the file name does not end with ".enc", set metadata textbox to the default metadata file name
                    metadataTextbox.Text = ofd.FileName + ".metadata";

                    // Set decrypt file textbox to the default decrypted file name
                    decryptFileTextbox.Text = ofd.FileName + ".dec";
                }
            }
        }

        // This method is triggered when the metadataButton is clicked
        private void metadataButton_Click(object sender, EventArgs e)
        {
            // Create a new instance of OpenFileDialog
            var ofd = new OpenFileDialog();

            // Display the OpenFileDialog and proceed if the user selects a file
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Set the text of metadataTextbox to the path of the selected file
                metadataTextbox.Text = ofd.FileName;
            }
        }

        // This method is the event handler for the click event of the decryptFileButton
        private void decryptFileButton_Click(object sender, EventArgs e)
        {
            // Create a new SaveFileDialog instance to prompt the user to save a file
            var sfd = new SaveFileDialog();

            // Check if the user clicked the OK button in the SaveFileDialog
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Set the text of the decryptFileTextbox to the selected file's name
                decryptFileTextbox.Text = sfd.FileName;
            }
        }

        // Event handler for decrypt button click
        private void decryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the file path in the encryptFileTextbox is empty or the file does not exist
                if (string.IsNullOrWhiteSpace(encryptFileTextbox.Text) || !File.Exists(encryptFileTextbox.Text))
                {
                    // Show error message if the file does not exist
                    MessageBox.Show("File không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the metadata path in the metadataTextbox is empty or the file does not exist
                if (string.IsNullOrWhiteSpace(metadataTextbox.Text) || !File.Exists(metadataTextbox.Text))
                {
                    // Show error message if the file does not exist
                    MessageBox.Show("File không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the decrypt file path in the decryptFileTextbox is empty
                if (string.IsNullOrWhiteSpace(decryptFileTextbox.Text))
                {
                    // Show error message if the file path is empty
                    MessageBox.Show("File không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get the file paths from the textboxes
                string filePath = encryptFileTextbox.Text;
                string metadataPath = metadataTextbox.Text;

                // Deserialize the key metadata from the file
                KeyMeta? keyMeta = JsonSerializer.Deserialize<KeyMeta>(File.ReadAllText(metadataPath));
                if (keyMeta == null)
                {
                    // Show error message if the metadata file does not exist
                    MessageBox.Show("File metadata không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get the private key from the keyTextbox
                string privateKey = keyTextbox.Text;

                // Check if the hash of the private key matches the hash in the key metadata
                if (CryptoModule.HashValue(privateKey, "SHA-1") != keyMeta.hash)
                {
                    // Show error message if the key is incorrect
                    MessageBox.Show("Khóa không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Decrypt the key using RSA
                string key = CryptoModule.DecryptStringRSA(keyMeta.key, privateKey);

                // Decrypt the file using the decrypted key
                CryptoModule.DecryptFileAES(filePath, decryptFileTextbox.Text, key);

                // Check if the decrypted file exists
                if (File.Exists(decryptFileTextbox.Text))
                {
                    // Show success message
                    MessageBox.Show("Giải mã thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Open the folder containing the decrypted file
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
                // Show any exceptions that occur during decryption
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // This method is an event handler for the click event of the keyFileButton
        private void keyFileButton_Click(object sender, EventArgs e)
        {
            // Create a new instance of OpenFileDialog
            var ofd = new OpenFileDialog();

            // Show the file dialog and check if the OK button was clicked
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Read the contents of the selected file and set it as the text of the keyTextbox
                keyTextbox.Text = File.ReadAllText(ofd.FileName);
            }
        }
    }
}
