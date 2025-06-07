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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
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
            usernameTextBox.Location = new Point(240, 153);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(247, 23);
            usernameTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(240, 233);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(247, 23);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameLabel
            // 
            usernameLabel.BackColor = Color.Transparent;
            usernameLabel.ForeColor = Color.White;
            usernameLabel.Location = new Point(240, 126);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(247, 19);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "имя пользователя";
            usernameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // passwordLabel
            // 
            passwordLabel.BackColor = Color.Transparent;
            passwordLabel.ForeColor = Color.White;
            passwordLabel.Location = new Point(241, 207);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(246, 19);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "пароль";
            passwordLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // regLabel
            // 
            regLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            regLabel.BackColor = Color.Transparent;
            regLabel.ForeColor = Color.White;
            regLabel.LinkColor = Color.Silver;
            regLabel.Location = new Point(155, 405);
            regLabel.Name = "regLabel";
            regLabel.Size = new Size(420, 18);
            regLabel.TabIndex = 4;
            regLabel.TabStop = true;
            regLabel.Text = "Нет аккаунта?";
            regLabel.TextAlign = ContentAlignment.MiddleCenter;
            regLabel.LinkClicked += RegLabel_LinkClicked;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Transparent;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 3;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(282, 314);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(162, 45);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_ClickAsync;
            // 
            // toolStrip
            // 
            toolStrip.BackColor = Color.Transparent;
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(732, 25);
            toolStrip.TabIndex = 6;
            toolStrip.Text = "toolStrip1";
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Segoe UI", 30F);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(182, 25);
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
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(732, 432);
            Controls.Add(titleLabel);
            Controls.Add(toolStrip);
            Controls.Add(btnLogin);
            Controls.Add(regLabel);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            DoubleBuffered = true;
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
