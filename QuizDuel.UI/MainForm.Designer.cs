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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnCreateGame = new Button();
            btnJoinGame = new Button();
            toolStrip = new ToolStrip();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            // toolStrip
            // 
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(800, 25);
            toolStrip.TabIndex = 3;
            toolStrip.Text = "toolStrip1";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(718, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(70, 70);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += PictureBox1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(toolStrip);
            Controls.Add(btnJoinGame);
            Controls.Add(btnCreateGame);
            Name = "MainForm";
            Text = "MainForm";
            FormClosed += MainForm_FormClosed;
            Shown += MainForm_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreateGame;
        private Button btnJoinGame;
        private ToolStrip toolStrip;
        private PictureBox pictureBox1;
    }
}