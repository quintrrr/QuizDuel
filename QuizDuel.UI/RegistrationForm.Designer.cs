namespace QuizDuel.UI
{
    partial class RegistrationForm
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
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            repeatPasswordTextBox = new TextBox();
            birthdatePicker = new DateTimePicker();
            usernameLabel = new Label();
            birthdateLabel = new Label();
            passwordLabel = new Label();
            repeatPasswordLabel = new Label();
            btnRegister = new Button();
            haveAccountLinkLabel = new LinkLabel();
            SuspendLayout();
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(87, 46);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(287, 23);
            usernameTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(86, 177);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(288, 23);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // repeatPasswordTextBox
            // 
            repeatPasswordTextBox.Location = new Point(86, 242);
            repeatPasswordTextBox.Name = "repeatPasswordTextBox";
            repeatPasswordTextBox.Size = new Size(288, 23);
            repeatPasswordTextBox.TabIndex = 2;
            repeatPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // birthdatePicker
            // 
            birthdatePicker.Location = new Point(86, 112);
            birthdatePicker.Name = "birthdatePicker";
            birthdatePicker.Size = new Size(287, 23);
            birthdatePicker.TabIndex = 3;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(87, 28);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(38, 15);
            usernameLabel.TabIndex = 4;
            usernameLabel.Text = "label1";
            // 
            // birthdateLabel
            // 
            birthdateLabel.AutoSize = true;
            birthdateLabel.Location = new Point(87, 94);
            birthdateLabel.Name = "birthdateLabel";
            birthdateLabel.Size = new Size(38, 15);
            birthdateLabel.TabIndex = 5;
            birthdateLabel.Text = "label2";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(86, 159);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(38, 15);
            passwordLabel.TabIndex = 6;
            passwordLabel.Text = "label3";
            // 
            // repeatPasswordLabel
            // 
            repeatPasswordLabel.AutoSize = true;
            repeatPasswordLabel.Location = new Point(86, 224);
            repeatPasswordLabel.Name = "repeatPasswordLabel";
            repeatPasswordLabel.Size = new Size(38, 15);
            repeatPasswordLabel.TabIndex = 7;
            repeatPasswordLabel.Text = "label4";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(136, 311);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(188, 53);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "button1";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += BtnRegister_Click;
            // 
            // haveAccountLinkLabel
            // 
            haveAccountLinkLabel.LinkColor = Color.Black;
            haveAccountLinkLabel.Location = new Point(136, 404);
            haveAccountLinkLabel.Name = "haveAccountLinkLabel";
            haveAccountLinkLabel.Size = new Size(188, 19);
            haveAccountLinkLabel.TabIndex = 9;
            haveAccountLinkLabel.TabStop = true;
            haveAccountLinkLabel.Text = "Есть аккаунт?";
            haveAccountLinkLabel.TextAlign = ContentAlignment.MiddleCenter;
            haveAccountLinkLabel.LinkClicked += HaveAccountLinkLabel_LinkClicked;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 432);
            Controls.Add(haveAccountLinkLabel);
            Controls.Add(btnRegister);
            Controls.Add(repeatPasswordLabel);
            Controls.Add(passwordLabel);
            Controls.Add(birthdateLabel);
            Controls.Add(usernameLabel);
            Controls.Add(birthdatePicker);
            Controls.Add(repeatPasswordTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "RegistrationForm";
            Text = "RegistrationForm";
            FormClosed += RegistrationForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private TextBox repeatPasswordTextBox;
        private DateTimePicker birthdatePicker;
        private Label usernameLabel;
        private Label birthdateLabel;
        private Label passwordLabel;
        private Label repeatPasswordLabel;
        private Button btnRegister;
        private LinkLabel haveAccountLinkLabel;
    }
}