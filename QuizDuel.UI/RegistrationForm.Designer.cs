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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
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
            usernameTextBox.Location = new Point(230, 127);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(287, 23);
            usernameTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(229, 258);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(288, 23);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // repeatPasswordTextBox
            // 
            repeatPasswordTextBox.Location = new Point(229, 323);
            repeatPasswordTextBox.Name = "repeatPasswordTextBox";
            repeatPasswordTextBox.Size = new Size(288, 23);
            repeatPasswordTextBox.TabIndex = 2;
            repeatPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // birthdatePicker
            // 
            birthdatePicker.Location = new Point(229, 193);
            birthdatePicker.Name = "birthdatePicker";
            birthdatePicker.Size = new Size(287, 23);
            birthdatePicker.TabIndex = 3;
            // 
            // usernameLabel
            // 
            usernameLabel.BackColor = Color.Transparent;
            usernameLabel.ForeColor = Color.White;
            usernameLabel.Location = new Point(230, 106);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(287, 20);
            usernameLabel.TabIndex = 4;
            usernameLabel.Text = "label1";
            usernameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // birthdateLabel
            // 
            birthdateLabel.BackColor = Color.Transparent;
            birthdateLabel.ForeColor = Color.White;
            birthdateLabel.Location = new Point(230, 172);
            birthdateLabel.Name = "birthdateLabel";
            birthdateLabel.Size = new Size(287, 20);
            birthdateLabel.TabIndex = 5;
            birthdateLabel.Text = "label2";
            birthdateLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // passwordLabel
            // 
            passwordLabel.BackColor = Color.Transparent;
            passwordLabel.ForeColor = Color.White;
            passwordLabel.Location = new Point(229, 237);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(287, 20);
            passwordLabel.TabIndex = 6;
            passwordLabel.Text = "label3";
            passwordLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // repeatPasswordLabel
            // 
            repeatPasswordLabel.BackColor = Color.Transparent;
            repeatPasswordLabel.ForeColor = Color.White;
            repeatPasswordLabel.Location = new Point(229, 301);
            repeatPasswordLabel.Name = "repeatPasswordLabel";
            repeatPasswordLabel.Size = new Size(287, 20);
            repeatPasswordLabel.TabIndex = 7;
            repeatPasswordLabel.Text = "label4";
            repeatPasswordLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Transparent;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 3;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(264, 377);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(214, 53);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "button1";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += BtnRegister_Click;
            // 
            // haveAccountLinkLabel
            // 
            haveAccountLinkLabel.BackColor = Color.Transparent;
            haveAccountLinkLabel.ForeColor = Color.White;
            haveAccountLinkLabel.LinkColor = Color.Silver;
            haveAccountLinkLabel.Location = new Point(214, 450);
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
            toolStrip.BackColor = Color.Transparent;
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(756, 25);
            toolStrip.TabIndex = 10;
            toolStrip.Text = "toolStrip1";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Segoe UI", 30F);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(253, 27);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(249, 54);
            titleLabel.TabIndex = 11;
            titleLabel.Text = "Регистрация";
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(756, 478);
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
            DoubleBuffered = true;
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