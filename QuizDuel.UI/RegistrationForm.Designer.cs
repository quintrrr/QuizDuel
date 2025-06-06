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
            toolStrip = new ToolStrip();
            titleLabel = new Label();
            SuspendLayout();
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(87, 127);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(287, 23);
            usernameTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(86, 258);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(288, 23);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // repeatPasswordTextBox
            // 
            repeatPasswordTextBox.Location = new Point(86, 323);
            repeatPasswordTextBox.Name = "repeatPasswordTextBox";
            repeatPasswordTextBox.Size = new Size(288, 23);
            repeatPasswordTextBox.TabIndex = 2;
            repeatPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // birthdatePicker
            // 
            birthdatePicker.Location = new Point(86, 193);
            birthdatePicker.Name = "birthdatePicker";
            birthdatePicker.Size = new Size(287, 23);
            birthdatePicker.TabIndex = 3;
            // 
            // usernameLabel
            // 
            usernameLabel.Location = new Point(87, 106);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(287, 20);
            usernameLabel.TabIndex = 4;
            usernameLabel.Text = "label1";
            usernameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // birthdateLabel
            // 
            birthdateLabel.Location = new Point(87, 172);
            birthdateLabel.Name = "birthdateLabel";
            birthdateLabel.Size = new Size(287, 20);
            birthdateLabel.TabIndex = 5;
            birthdateLabel.Text = "label2";
            birthdateLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // passwordLabel
            // 
            passwordLabel.Location = new Point(86, 237);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(287, 20);
            passwordLabel.TabIndex = 6;
            passwordLabel.Text = "label3";
            passwordLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // repeatPasswordLabel
            // 
            repeatPasswordLabel.Location = new Point(86, 301);
            repeatPasswordLabel.Name = "repeatPasswordLabel";
            repeatPasswordLabel.Size = new Size(287, 20);
            repeatPasswordLabel.TabIndex = 7;
            repeatPasswordLabel.Text = "label4";
            repeatPasswordLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(136, 377);
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
            haveAccountLinkLabel.Location = new Point(71, 450);
            haveAccountLinkLabel.Name = "haveAccountLinkLabel";
            haveAccountLinkLabel.Size = new Size(319, 23);
            haveAccountLinkLabel.TabIndex = 9;
            haveAccountLinkLabel.TabStop = true;
            haveAccountLinkLabel.Text = "Есть аккаунт?";
            haveAccountLinkLabel.TextAlign = ContentAlignment.MiddleCenter;
            haveAccountLinkLabel.LinkClicked += HaveAccountLinkLabel_LinkClicked;
            // 
            // toolStrip
            // 
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(474, 25);
            toolStrip.TabIndex = 10;
            toolStrip.Text = "toolStrip1";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 30F);
            titleLabel.Location = new Point(110, 27);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(249, 54);
            titleLabel.TabIndex = 11;
            titleLabel.Text = "Регистрация";
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 478);
            Controls.Add(titleLabel);
            Controls.Add(toolStrip);
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
            Text = "QuizDuel";
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
        private ToolStrip toolStrip;
        private Label titleLabel;
    }
}