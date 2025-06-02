namespace QuizDuel.UI
{
    partial class MainForm
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
            btnCreateGame = new Button();
            btnJoinGame = new Button();
            SuspendLayout();
            // 
            // btnCreateGame
            // 
            btnCreateGame.Location = new Point(255, 295);
            btnCreateGame.Name = "btnCreateGame";
            btnCreateGame.Size = new Size(288, 109);
            btnCreateGame.TabIndex = 0;
            btnCreateGame.Text = "Создать игру";
            btnCreateGame.UseVisualStyleBackColor = true;
            btnCreateGame.Click += BtnCreateGame_Click;
            // 
            // btnJoinGame
            // 
            btnJoinGame.Location = new Point(255, 81);
            btnJoinGame.Name = "btnJoinGame";
            btnJoinGame.Size = new Size(288, 102);
            btnJoinGame.TabIndex = 1;
            btnJoinGame.Text = "присоединиться к игре";
            btnJoinGame.UseVisualStyleBackColor = true;
            btnJoinGame.Click += BtnJoinGame_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnJoinGame);
            Controls.Add(btnCreateGame);
            Name = "MainForm";
            Text = "MainForm";
            FormClosed += MainForm_FormClosed;
            ResumeLayout(false);
        }

        #endregion

        private Button btnCreateGame;
        private Button btnJoinGame;
    }
}