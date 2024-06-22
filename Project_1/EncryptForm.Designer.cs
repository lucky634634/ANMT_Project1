namespace Project_1
{
    partial class EncryptForm
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
            sourceTextbox = new TextBox();
            selectFileButton = new Button();
            encryptButton = new Button();
            privateKeyTextbox = new RichTextBox();
            saveKeyButton = new Button();
            metaFileTextbox = new TextBox();
            metaFileButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            encryptFileTextbox = new TextBox();
            encryptFileButton = new Button();
            SuspendLayout();
            // 
            // sourceTextbox
            // 
            sourceTextbox.Location = new Point(12, 27);
            sourceTextbox.Name = "sourceTextbox";
            sourceTextbox.Size = new Size(695, 23);
            sourceTextbox.TabIndex = 0;
            sourceTextbox.TextChanged += sourceTextbox_TextChanged;
            // 
            // selectFileButton
            // 
            selectFileButton.Location = new Point(713, 27);
            selectFileButton.Name = "selectFileButton";
            selectFileButton.Size = new Size(75, 23);
            selectFileButton.TabIndex = 1;
            selectFileButton.Text = "Chọn File";
            selectFileButton.UseVisualStyleBackColor = true;
            selectFileButton.Click += selectFileButton_Click;
            // 
            // encryptButton
            // 
            encryptButton.Location = new Point(713, 415);
            encryptButton.Name = "encryptButton";
            encryptButton.Size = new Size(75, 23);
            encryptButton.TabIndex = 3;
            encryptButton.Text = "Mã hóa";
            encryptButton.UseVisualStyleBackColor = true;
            encryptButton.Click += encryptButton_Click;
            // 
            // privateKeyTextbox
            // 
            privateKeyTextbox.DetectUrls = false;
            privateKeyTextbox.Location = new Point(12, 159);
            privateKeyTextbox.Name = "privateKeyTextbox";
            privateKeyTextbox.ReadOnly = true;
            privateKeyTextbox.Size = new Size(695, 279);
            privateKeyTextbox.TabIndex = 4;
            privateKeyTextbox.Text = "";
            // 
            // saveKeyButton
            // 
            saveKeyButton.Location = new Point(713, 159);
            saveKeyButton.Name = "saveKeyButton";
            saveKeyButton.Size = new Size(75, 23);
            saveKeyButton.TabIndex = 5;
            saveKeyButton.Text = "Lưu Key";
            saveKeyButton.UseVisualStyleBackColor = true;
            saveKeyButton.Click += saveKeyButton_Click;
            // 
            // metaFileTextbox
            // 
            metaFileTextbox.Location = new Point(12, 115);
            metaFileTextbox.Name = "metaFileTextbox";
            metaFileTextbox.Size = new Size(695, 23);
            metaFileTextbox.TabIndex = 0;
            // 
            // metaFileButton
            // 
            metaFileButton.Location = new Point(713, 115);
            metaFileButton.Name = "metaFileButton";
            metaFileButton.Size = new Size(75, 23);
            metaFileButton.TabIndex = 1;
            metaFileButton.Text = "Thay đổi";
            metaFileButton.UseVisualStyleBackColor = true;
            metaFileButton.Click += metaFileButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 6;
            label1.Text = "File cần mã hóa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 97);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 6;
            label2.Text = "File metadata";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 141);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 6;
            label3.Text = "Khóa bí mật";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 53);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 6;
            label4.Text = "File mã hóa";
            // 
            // encryptFileTextbox
            // 
            encryptFileTextbox.Location = new Point(12, 71);
            encryptFileTextbox.Name = "encryptFileTextbox";
            encryptFileTextbox.Size = new Size(695, 23);
            encryptFileTextbox.TabIndex = 0;
            // 
            // encryptFileButton
            // 
            encryptFileButton.Location = new Point(713, 71);
            encryptFileButton.Name = "encryptFileButton";
            encryptFileButton.Size = new Size(75, 23);
            encryptFileButton.TabIndex = 7;
            encryptFileButton.Text = "Thay đổi";
            encryptFileButton.UseVisualStyleBackColor = true;
            encryptFileButton.Click += encryptFileButton_Click;
            // 
            // EncryptForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(encryptFileButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(saveKeyButton);
            Controls.Add(privateKeyTextbox);
            Controls.Add(encryptButton);
            Controls.Add(metaFileButton);
            Controls.Add(selectFileButton);
            Controls.Add(metaFileTextbox);
            Controls.Add(encryptFileTextbox);
            Controls.Add(sourceTextbox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "EncryptForm";
            Text = "EncryptForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox sourceTextbox;
        private Button selectFileButton;
        private Button encryptButton;
        private RichTextBox privateKeyTextbox;
        private Button saveKeyButton;
        private TextBox metaFileTextbox;
        private Button metaFileButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox encryptFileTextbox;
        private Button encryptFileButton;
    }
}