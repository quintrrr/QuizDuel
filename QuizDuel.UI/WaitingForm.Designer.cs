
namespace QuizDuel.UI
{
    partial class WaitingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitingForm));
            btnPlay = new Button();
            player1NameLabel = new Label();
            player2NameLabel = new Label();
            scoreLabel = new Label();
            titleLabel = new Label();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.Transparent;
            btnPlay.Cursor = Cursors.Hand;
            btnPlay.FlatAppearance.BorderSize = 2;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.ForeColor = Color.White;
            btnPlay.Location = new Point(274, 362);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(257, 52);
            btnPlay.TabIndex = 2;
            btnPlay.Text = "Играть";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += BtnPlay_Click;
            // 
            // player1NameLabel
            // 
            player1NameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            player1NameLabel.BackColor = Color.Transparent;
            player1NameLabel.Font = new Font("Segoe UI", 12F);
            player1NameLabel.ForeColor = Color.White;
            player1NameLabel.Location = new Point(43, 105);
            player1NameLabel.Name = "player1NameLabel";
            player1NameLabel.Size = new Size(250, 32);
            player1NameLabel.TabIndex = 3;
            player1NameLabel.Text = "Игрок1";
            player1NameLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // player2NameLabel
            // 
            player2NameLabel.BackColor = Color.Transparent;
            player2NameLabel.Font = new Font("Segoe UI", 12F);
            player2NameLabel.ForeColor = Color.White;
            player2NameLabel.Location = new Point(510, 105);
            player2NameLabel.Name = "player2NameLabel";
            player2NameLabel.Size = new Size(263, 32);
            player2NameLabel.TabIndex = 4;
            player2NameLabel.Text = "Игрок2";
            player2NameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // scoreLabel
            // 
            scoreLabel.BackColor = Color.Transparent;
            scoreLabel.Font = new Font("Segoe UI", 18F);
            scoreLabel.ForeColor = Color.White;
            scoreLabel.Location = new Point(357, 100);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(87, 42);
            scoreLabel.TabIndex = 5;
            scoreLabel.Text = "0-0";
            scoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.Transparent;
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(274, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(253, 61);
            titleLabel.TabIndex = 6;
            titleLabel.Text = "QuizDuel";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WaitingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(800, 450);
            Controls.Add(titleLabel);
            Controls.Add(scoreLabel);
            Controls.Add(player2NameLabel);
            Controls.Add(player1NameLabel);
            Controls.Add(btnPlay);
            DoubleBuffered = true;
            Name = "WaitingForm";
            Text = "QuizDuel";
            FormClosing += WaitingForm_FormClosing;
            Load += WaitingForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button btnPlay;
        private Label player1NameLabel;
        private Label player2NameLabel;
        private Label scoreLabel;
        private Label titleLabel;
    }
}