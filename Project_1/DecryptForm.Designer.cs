namespace Project_1
{
    partial class DecryptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            encryptFileTextbox = new TextBox();
            encryptFileButton = new Button();
            label1 = new Label();
            label2 = new Label();
            metadataButton = new Button();
            metadataTextbox = new TextBox();
            decryptFileTextbox = new TextBox();
            decryptFileButton = new Button();
            label3 = new Label();
            decryptButton = new Button();
            keyTextbox = new RichTextBox();
            label4 = new Label();
            keyFileButton = new Button();
            SuspendLayout();
            // 
            // encryptFileTextbox
            // 
            encryptFileTextbox.Location = new Point(12, 27);
            encryptFileTextbox.Name = "encryptFileTextbox";
            encryptFileTextbox.Size = new Size(695, 23);
            encryptFileTextbox.TabIndex = 0;
            // 
            // encryptFileButton
            // 
            encryptFileButton.Location = new Point(713, 27);
            encryptFileButton.Name = "encryptFileButton";
            encryptFileButton.Size = new Size(75, 23);
            encryptFileButton.TabIndex = 1;
            encryptFileButton.Text = "Chọn file";
            encryptFileButton.UseVisualStyleBackColor = true;
            encryptFileButton.Click += encryptFileButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 2;
            label1.Text = "File cần giải mã";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 5;
            label2.Text = "File metadata";
            // 
            // metadataButton
            // 
            metadataButton.Location = new Point(713, 71);
            metadataButton.Name = "metadataButton";
            metadataButton.Size = new Size(75, 23);
            metadataButton.TabIndex = 4;
            metadataButton.Text = "Chọn File";
            metadataButton.UseVisualStyleBackColor = true;
            metadataButton.Click += metadataButton_Click;
            // 
            // metadataTextbox
            // 
            metadataTextbox.Location = new Point(12, 71);
            metadataTextbox.Name = "metadataTextbox";
            metadataTextbox.Size = new Size(695, 23);
            metadataTextbox.TabIndex = 3;
            // 
            // decryptFileTextbox
            // 
            decryptFileTextbox.Location = new Point(12, 115);
            decryptFileTextbox.Name = "decryptFileTextbox";
            decryptFileTextbox.Size = new Size(695, 23);
            decryptFileTextbox.TabIndex = 3;
            // 
            // decryptFileButton
            // 
            decryptFileButton.Location = new Point(713, 115);
            decryptFileButton.Name = "decryptFileButton";
            decryptFileButton.Size = new Size(75, 23);
            decryptFileButton.TabIndex = 4;
            decryptFileButton.Text = "Thay đổi";
            decryptFileButton.UseVisualStyleBackColor = true;
            decryptFileButton.Click += decryptFileButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 97);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 5;
            label3.Text = "File giải mã";
            // 
            // decryptButton
            // 
            decryptButton.Location = new Point(713, 415);
            decryptButton.Name = "decryptButton";
            decryptButton.Size = new Size(75, 23);
            decryptButton.TabIndex = 7;
            decryptButton.Text = "Giải mã";
            decryptButton.UseVisualStyleBackColor = true;
            decryptButton.Click += decryptButton_Click;
            // 
            // keyTextbox
            // 
            keyTextbox.DetectUrls = false;
            keyTextbox.Location = new Point(12, 159);
            keyTextbox.Name = "keyTextbox";
            keyTextbox.Size = new Size(695, 279);
            keyTextbox.TabIndex = 8;
            keyTextbox.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 141);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 5;
            label4.Text = "Khóa bí mật";
            // 
            // keyFileButton
            // 
            keyFileButton.Location = new Point(713, 159);
            keyFileButton.Name = "keyFileButton";
            keyFileButton.Size = new Size(75, 23);
            keyFileButton.TabIndex = 9;
            keyFileButton.Text = "Mở file";
            keyFileButton.UseVisualStyleBackColor = true;
            keyFileButton.Click += keyFileButton_Click;
            // 
            // DecryptForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(keyFileButton);
            Controls.Add(keyTextbox);
            Controls.Add(decryptButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(decryptFileButton);
            Controls.Add(metadataButton);
            Controls.Add(decryptFileTextbox);
            Controls.Add(metadataTextbox);
            Controls.Add(label1);
            Controls.Add(encryptFileButton);
            Controls.Add(encryptFileTextbox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "DecryptForm";
            Text = "DecryptForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox encryptFileTextbox;
        private Button encryptFileButton;
        private Label label1;
        private Label label2;
        private Button metadataButton;
        private TextBox metadataTextbox;
        private TextBox decryptFileTextbox;
        private Button decryptFileButton;
        private Label label3;
        private Button decryptButton;
        private RichTextBox keyTextbox;
        private Label label4;
        private Button keyFileButton;
    }
}