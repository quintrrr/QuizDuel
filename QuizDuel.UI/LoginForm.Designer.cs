namespace QuizDuel.UI
{
    partial class LoginForm
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
            usernameLabel = new Label();
            passwordLabel = new Label();
            regLabel = new LinkLabel();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(113, 119);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(247, 23);
            usernameTextBox.TabIndex = 0;
            usernameTextBox.Text = "qwertyZXC123!";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(113, 199);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(247, 23);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.Text = "qwertyZXC123!";
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(113, 101);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(107, 15);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "имя пользователя";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(114, 182);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(47, 15);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "пароль";
            // 
            // regLabel
            // 
            regLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            regLabel.LinkColor = Color.Black;
            regLabel.Location = new Point(155, 405);
            regLabel.Name = "regLabel";
            regLabel.Size = new Size(162, 18);
            regLabel.TabIndex = 4;
            regLabel.TabStop = true;
            regLabel.Text = "Нет аккаунта?";
            regLabel.TextAlign = ContentAlignment.MiddleCenter;
            regLabel.LinkClicked += RegLabel_LinkClicked;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(155, 287);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(162, 45);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += BtnLogin_ClickAsync;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 432);
            Controls.Add(btnLogin);
            Controls.Add(regLabel);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LoginForm";
            Text = "LoginForm";
            FormClosed += LoginForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Label usernameLabel;
        private Label passwordLabel;
        private LinkLabel regLabel;
        private Button btnLogin;
    }
}