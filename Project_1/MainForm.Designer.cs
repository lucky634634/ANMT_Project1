namespace Project_1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            encryptButton = new Button();
            decryptButton = new Button();
            SuspendLayout();
            // 
            // encryptButton
            // 
            encryptButton.Location = new Point(173, 71);
            encryptButton.Name = "encryptButton";
            encryptButton.Size = new Size(75, 23);
            encryptButton.TabIndex = 0;
            encryptButton.Text = "Mã hóa";
            encryptButton.UseVisualStyleBackColor = true;
            encryptButton.Click += encryptButton_Click;
            // 
            // decryptButton
            // 
            decryptButton.Location = new Point(173, 139);
            decryptButton.Name = "decryptButton";
            decryptButton.Size = new Size(75, 23);
            decryptButton.TabIndex = 1;
            decryptButton.Text = "Giải mã";
            decryptButton.UseVisualStyleBackColor = true;
            decryptButton.Click += decryptButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 271);
            Controls.Add(decryptButton);
            Controls.Add(encryptButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button encryptButton;
        private Button decryptButton;
    }
}
