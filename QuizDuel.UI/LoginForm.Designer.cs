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
            toolStrip = new ToolStrip();
            titleLabel = new Label();
            SuspendLayout();
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(113, 153);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(247, 23);
            usernameTextBox.TabIndex = 0;
            usernameTextBox.Text = "qwertyZXC123!";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(113, 233);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(247, 23);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.Text = "qwertyZXC123!";
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameLabel
            // 
            usernameLabel.Location = new Point(113, 126);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(247, 19);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "имя пользователя";
            usernameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // passwordLabel
            // 
            passwordLabel.Location = new Point(114, 207);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(246, 19);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "пароль";
            passwordLabel.TextAlign = ContentAlignment.MiddleCenter;
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
            btnLogin.Location = new Point(155, 314);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(162, 45);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += BtnLogin_ClickAsync;
            // 
            // toolStrip
            // 
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(474, 25);
            toolStrip.TabIndex = 6;
            toolStrip.Text = "toolStrip1";
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Segoe UI", 30F);
            titleLabel.Location = new Point(55, 25);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(358, 63);
            titleLabel.TabIndex = 7;
            titleLabel.Text = "label1";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 432);
            Controls.Add(titleLabel);
            Controls.Add(toolStrip);
            Controls.Add(btnLogin);
            Controls.Add(regLabel);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LoginForm";
            Text = "QuizDuel";
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
        private ToolStrip toolStrip;
        private Label titleLabel;
    }
}