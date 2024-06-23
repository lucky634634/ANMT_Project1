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

        // Event handler for the select file button click
        private void selectFileButton_Click(object sender, EventArgs e)
        {
            // Open a file dialog to select a file
            OpenFileDialog ofd = new OpenFileDialog();

            // Check if the file dialog result is OK (i.e., user selected a file)
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Set the source textbox to the selected file's path
                sourceTextbox.Text = ofd.FileName;

                // Set the meta file textbox to the selected file's path with a ".metadata" extension
                metaFileTextbox.Text = ofd.FileName + ".metadata";
            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the source file path is empty or does not exist
                if (string.IsNullOrWhiteSpace(sourceTextbox.Text) || !File.Exists(sourceTextbox.Text))
                {
                    // Show an error message if the source file is missing
                    MessageBox.Show("File không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string filePath = sourceTextbox.Text;

                // Generate a new AES key
                string key = CryptoModule.GenerateAESKey();

                // Check if the target file path is empty
                if (string.IsNullOrWhiteSpace(encryptFileTextbox.Text))
                {
                    // Prompt the user to select a target file path
                    var sfd = new SaveFileDialog();
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        encryptFileTextbox.Text = sfd.FileName;
                    }
                }

                // Encrypt the source file using AES encryption with the generated key
                CryptoModule.EncryptFileAES(filePath, encryptFileTextbox.Text, key);

                string privateKey, publicKey;

                // Generate a new RSA key pair
                CryptoModule.GenerateRSAKeyPair(out privateKey, out publicKey);

                // Display the private key
                privateKeyTextbox.Text = privateKey;

                // Create a KeyMeta object containing the encrypted AES key and its hash value
                KeyMeta keyMeta = new KeyMeta(CryptoModule.EncryptStringRSA(key, publicKey), CryptoModule.HashValue(privateKey, "SHA-1"));

                // Check if the meta file path is empty
                if (string.IsNullOrWhiteSpace(metaFileTextbox.Text))
                {
                    // Prompt the user to select a meta file path
                    var sfd = new SaveFileDialog();
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        metaFileTextbox.Text = sfd.FileName;
                    }
                }

                // Save the KeyMeta object to a file as JSON
                File.WriteAllText(metaFileTextbox.Text, JsonSerializer.Serialize(keyMeta));

                if (File.Exists(encryptFileTextbox.Text))
                {
                    // Show a success message if encryption is successful
                    MessageBox.Show("Mã hóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Open the containing folder of the encrypted file
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
                // Display any exceptions that occur during the encryption process
                MessageBox.Show(ex.Message);
            }
        }

        // This method is an event handler for the click event of the metaFileButton.
        // It allows the user to select a file location to save metadata using a SaveFileDialog.
        private void metaFileButton_Click(object sender, EventArgs e)
        {
            // Create a new SaveFileDialog instance to prompt the user to select a file location
            var sfd = new SaveFileDialog();

            // Display the SaveFileDialog to the user and check if the user clicked OK
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // If the user selected a file location and clicked OK, set the text of metaFileTextbox to the selected file path
                metaFileTextbox.Text = sfd.FileName;
            }
        }

        // This method is the event handler for the "Encrypt File" button click
        private void encryptFileButton_Click(object sender, EventArgs e)
        {
            // Create a new instance of SaveFileDialog to prompt the user for a file save location
            var sfd = new SaveFileDialog();

            // If the user chooses a file location and clicks OK in the SaveFileDialog
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Set the text of the "encryptFileTextbox" to the selected file's name
                encryptFileTextbox.Text = sfd.FileName;
            }
        }

        // This event handler is triggered when the text in the sourceTextbox changes
        private void sourceTextbox_TextChanged(object sender, EventArgs e)
        {
            // Update the text in the encryptFileTextbox by concatenating ".enc" to the text in sourceTextbox
            encryptFileTextbox.Text = sourceTextbox.Text + ".enc";

            // Update the text in the metaFileTextbox by concatenating ".metadata" to the text in sourceTextbox
            metaFileTextbox.Text = sourceTextbox.Text + ".metadata";
        }

        // Event handler for the save key button click
        private void saveKeyButton_Click(object sender, EventArgs e)
        {
            // Check if the private key textbox is empty or contains only white space
            if (string.IsNullOrWhiteSpace(privateKeyTextbox.Text))
            {
                // Display an error message if the private key textbox is empty
                MessageBox.Show("Chưa mã hóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the function
            }

            // Create a new Save File Dialog instance
            var sfd = new SaveFileDialog();

            // Set the default file name in the Save File Dialog to the source textbox text + ".key"
            sfd.FileName = sourceTextbox.Text + ".key";

            // Show the Save File Dialog and check if the user clicked OK
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Write the content of the private key textbox to the selected file
                File.WriteAllText(sfd.FileName, privateKeyTextbox.Text);
            }
        }
    }
}
