
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
            btnPlay = new Button();
            player1NameLabel = new Label();
            player2NameLabel = new Label();
            scoreLabel = new Label();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(274, 362);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(257, 52);
            btnPlay.TabIndex = 2;
            btnPlay.Text = "Играть";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += BtnPlay_Click;
            // 
            // player1NameLabel
            // 
            player1NameLabel.AutoSize = true;
            player1NameLabel.Font = new Font("Segoe UI", 12F);
            player1NameLabel.Location = new Point(131, 65);
            player1NameLabel.Name = "player1NameLabel";
            player1NameLabel.Size = new Size(63, 21);
            player1NameLabel.TabIndex = 3;
            player1NameLabel.Text = "Игрок1";
            // 
            // player2NameLabel
            // 
            player2NameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            player2NameLabel.AutoSize = true;
            player2NameLabel.Font = new Font("Segoe UI", 12F);
            player2NameLabel.Location = new Point(631, 65);
            player2NameLabel.Name = "player2NameLabel";
            player2NameLabel.Size = new Size(63, 21);
            player2NameLabel.TabIndex = 4;
            player2NameLabel.Text = "Игрок2";
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Segoe UI", 18F);
            scoreLabel.Location = new Point(376, 48);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(50, 32);
            scoreLabel.TabIndex = 5;
            scoreLabel.Text = "0-0";
            // 
            // WaitingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(scoreLabel);
            Controls.Add(player2NameLabel);
            Controls.Add(player1NameLabel);
            Controls.Add(btnPlay);
            Name = "WaitingForm";
            Text = "WaitingForm";
            FormClosing += WaitingForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnPlay;
        private Label player1NameLabel;
        private Label player2NameLabel;
        private Label scoreLabel;
    }
}