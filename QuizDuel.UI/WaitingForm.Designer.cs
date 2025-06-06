
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
            btnPlay.Location = new Point(391, 603);
            btnPlay.Margin = new Padding(4, 5, 4, 5);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(367, 87);
            btnPlay.TabIndex = 2;
            btnPlay.Text = "Играть";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += BtnPlay_Click;
            // 
            // player1NameLabel
            // 
            player1NameLabel.AutoSize = true;
            player1NameLabel.Font = new Font("Segoe UI", 12F);
            player1NameLabel.Location = new Point(187, 108);
            player1NameLabel.Margin = new Padding(4, 0, 4, 0);
            player1NameLabel.Name = "player1NameLabel";
            player1NameLabel.Size = new Size(94, 32);
            player1NameLabel.TabIndex = 3;
            player1NameLabel.Text = "Игрок1";
            // 
            // player2NameLabel
            // 
            player2NameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            player2NameLabel.AutoSize = true;
            player2NameLabel.Font = new Font("Segoe UI", 12F);
            player2NameLabel.Location = new Point(901, 108);
            player2NameLabel.Margin = new Padding(4, 0, 4, 0);
            player2NameLabel.Name = "player2NameLabel";
            player2NameLabel.Size = new Size(94, 32);
            player2NameLabel.TabIndex = 4;
            player2NameLabel.Text = "Игрок2";
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Segoe UI", 18F);
            scoreLabel.Location = new Point(537, 80);
            scoreLabel.Margin = new Padding(4, 0, 4, 0);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(72, 48);
            scoreLabel.TabIndex = 5;
            scoreLabel.Text = "0-0";
            // 
            // WaitingForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(scoreLabel);
            Controls.Add(player2NameLabel);
            Controls.Add(player1NameLabel);
            Controls.Add(btnPlay);
            Margin = new Padding(4, 5, 4, 5);
            Name = "WaitingForm";
            Text = "WaitingForm";
            FormClosing += WaitingForm_FormClosing;
            Load += WaitingForm_Load;
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