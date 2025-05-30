namespace QuizDuel.UI
{
    partial class StartGameForm
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
            player1Id = new TextBox();
            player2Id = new TextBox();
            btn_startGame = new Button();
            SuspendLayout();
            // 
            // player1Id
            // 
            player1Id.Location = new Point(52, 61);
            player1Id.Name = "player1Id";
            player1Id.Size = new Size(224, 23);
            player1Id.TabIndex = 0;
            player1Id.Text = "cca5c637-1d16-4330-9cc5-de40cb3600c6";
            // 
            // player2Id
            // 
            player2Id.Location = new Point(497, 61);
            player2Id.Name = "player2Id";
            player2Id.Size = new Size(223, 23);
            player2Id.TabIndex = 1;
            player2Id.Text = "e231b035-3160-47c9-bc7a-425f2dc9d2a7";
            // 
            // btn_startGame
            // 
            btn_startGame.Location = new Point(274, 362);
            btn_startGame.Name = "btn_startGame";
            btn_startGame.Size = new Size(257, 52);
            btn_startGame.TabIndex = 2;
            btn_startGame.Text = "Начать игру";
            btn_startGame.UseVisualStyleBackColor = true;
            btn_startGame.Click += BtnStartGame_Click;
            // 
            // StartGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_startGame);
            Controls.Add(player2Id);
            Controls.Add(player1Id);
            Name = "StartGameForm";
            Text = "StartGameForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox player1Id;
        private TextBox player2Id;
        private Button btn_startGame;
    }
}