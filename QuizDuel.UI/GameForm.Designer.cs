namespace QuizDuel.UI
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            categoryPanel = new Panel();
            selectCategoryLabel = new Label();
            btnCategory3 = new Button();
            btnCategory2 = new Button();
            btnCategory1 = new Button();
            gamePanel = new Panel();
            btnAnswer4 = new Button();
            btnAnswer3 = new Button();
            btnAnswer2 = new Button();
            btnAnswer1 = new Button();
            categoryLabel = new Label();
            questionTimer = new ProgressBar();
            roundLabel = new Label();
            questionLabel = new Label();
            categoryPanel.SuspendLayout();
            gamePanel.SuspendLayout();
            SuspendLayout();
            // 
            // categoryPanel
            // 
            categoryPanel.BackColor = Color.Transparent;
            categoryPanel.Controls.Add(selectCategoryLabel);
            categoryPanel.Controls.Add(btnCategory3);
            categoryPanel.Controls.Add(btnCategory2);
            categoryPanel.Controls.Add(btnCategory1);
            categoryPanel.Location = new Point(234, 42);
            categoryPanel.Name = "categoryPanel";
            categoryPanel.Size = new Size(346, 351);
            categoryPanel.TabIndex = 0;
            categoryPanel.Visible = false;
            // 
            // selectCategoryLabel
            // 
            selectCategoryLabel.Font = new Font("Segoe UI", 16F);
            selectCategoryLabel.ForeColor = Color.White;
            selectCategoryLabel.Location = new Point(30, 20);
            selectCategoryLabel.Name = "selectCategoryLabel";
            selectCategoryLabel.Size = new Size(293, 85);
            selectCategoryLabel.TabIndex = 3;
            selectCategoryLabel.Text = "label1";
            selectCategoryLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCategory3
            // 
            btnCategory3.Cursor = Cursors.Hand;
            btnCategory3.FlatAppearance.BorderSize = 3;
            btnCategory3.FlatStyle = FlatStyle.Flat;
            btnCategory3.ForeColor = Color.White;
            btnCategory3.Location = new Point(63, 295);
            btnCategory3.Name = "btnCategory3";
            btnCategory3.Size = new Size(226, 56);
            btnCategory3.TabIndex = 2;
            btnCategory3.Text = "button3";
            btnCategory3.UseVisualStyleBackColor = true;
            btnCategory3.Click += ButtonCategory_Click;
            // 
            // btnCategory2
            // 
            btnCategory2.Cursor = Cursors.Hand;
            btnCategory2.FlatAppearance.BorderSize = 3;
            btnCategory2.FlatStyle = FlatStyle.Flat;
            btnCategory2.ForeColor = Color.White;
            btnCategory2.Location = new Point(63, 207);
            btnCategory2.Name = "btnCategory2";
            btnCategory2.Size = new Size(226, 52);
            btnCategory2.TabIndex = 1;
            btnCategory2.Text = "button2";
            btnCategory2.UseVisualStyleBackColor = true;
            btnCategory2.Click += ButtonCategory_Click;
            // 
            // btnCategory1
            // 
            btnCategory1.Cursor = Cursors.Hand;
            btnCategory1.FlatAppearance.BorderSize = 3;
            btnCategory1.FlatStyle = FlatStyle.Flat;
            btnCategory1.ForeColor = Color.White;
            btnCategory1.Location = new Point(63, 121);
            btnCategory1.Name = "btnCategory1";
            btnCategory1.Size = new Size(226, 54);
            btnCategory1.TabIndex = 0;
            btnCategory1.Text = "button1";
            btnCategory1.UseVisualStyleBackColor = true;
            btnCategory1.Click += ButtonCategory_Click;
            // 
            // gamePanel
            // 
            gamePanel.BackColor = Color.Transparent;
            gamePanel.Controls.Add(btnAnswer4);
            gamePanel.Controls.Add(btnAnswer3);
            gamePanel.Controls.Add(btnAnswer2);
            gamePanel.Controls.Add(btnAnswer1);
            gamePanel.Controls.Add(categoryLabel);
            gamePanel.Controls.Add(questionTimer);
            gamePanel.Controls.Add(roundLabel);
            gamePanel.Controls.Add(questionLabel);
            gamePanel.Location = new Point(1, 0);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(799, 438);
            gamePanel.TabIndex = 1;
            gamePanel.Visible = false;
            // 
            // btnAnswer4
            // 
            btnAnswer4.BackColor = Color.Transparent;
            btnAnswer4.Cursor = Cursors.Hand;
            btnAnswer4.FlatAppearance.BorderSize = 3;
            btnAnswer4.FlatStyle = FlatStyle.Flat;
            btnAnswer4.ForeColor = Color.White;
            btnAnswer4.Location = new Point(430, 323);
            btnAnswer4.Name = "btnAnswer4";
            btnAnswer4.Size = new Size(242, 72);
            btnAnswer4.TabIndex = 7;
            btnAnswer4.Tag = "3";
            btnAnswer4.Text = "button4";
            btnAnswer4.UseVisualStyleBackColor = false;
            btnAnswer4.Click += ButtonAnswer_Click;
            // 
            // btnAnswer3
            // 
            btnAnswer3.BackColor = Color.Transparent;
            btnAnswer3.Cursor = Cursors.Hand;
            btnAnswer3.FlatAppearance.BorderSize = 3;
            btnAnswer3.FlatStyle = FlatStyle.Flat;
            btnAnswer3.ForeColor = Color.White;
            btnAnswer3.Location = new Point(430, 234);
            btnAnswer3.Name = "btnAnswer3";
            btnAnswer3.Size = new Size(242, 72);
            btnAnswer3.TabIndex = 6;
            btnAnswer3.Tag = "2";
            btnAnswer3.Text = "button3";
            btnAnswer3.UseVisualStyleBackColor = false;
            btnAnswer3.Click += ButtonAnswer_Click;
            // 
            // btnAnswer2
            // 
            btnAnswer2.BackColor = Color.Transparent;
            btnAnswer2.Cursor = Cursors.Hand;
            btnAnswer2.FlatAppearance.BorderSize = 3;
            btnAnswer2.FlatStyle = FlatStyle.Flat;
            btnAnswer2.ForeColor = Color.White;
            btnAnswer2.Location = new Point(130, 323);
            btnAnswer2.Name = "btnAnswer2";
            btnAnswer2.Size = new Size(244, 72);
            btnAnswer2.TabIndex = 5;
            btnAnswer2.Tag = "1";
            btnAnswer2.Text = "button2";
            btnAnswer2.UseVisualStyleBackColor = false;
            btnAnswer2.Click += ButtonAnswer_Click;
            // 
            // btnAnswer1
            // 
            btnAnswer1.BackColor = Color.Transparent;
            btnAnswer1.Cursor = Cursors.Hand;
            btnAnswer1.FlatAppearance.BorderSize = 3;
            btnAnswer1.FlatStyle = FlatStyle.Flat;
            btnAnswer1.ForeColor = Color.White;
            btnAnswer1.Location = new Point(130, 234);
            btnAnswer1.Name = "btnAnswer1";
            btnAnswer1.Size = new Size(244, 72);
            btnAnswer1.TabIndex = 4;
            btnAnswer1.Tag = "0";
            btnAnswer1.Text = "button1";
            btnAnswer1.UseVisualStyleBackColor = false;
            btnAnswer1.Click += ButtonAnswer_Click;
            // 
            // categoryLabel
            // 
            categoryLabel.ForeColor = Color.White;
            categoryLabel.Location = new Point(251, 51);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(300, 21);
            categoryLabel.TabIndex = 3;
            categoryLabel.Text = "label1";
            categoryLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // questionTimer
            // 
            questionTimer.ForeColor = Color.Black;
            questionTimer.Location = new Point(131, 208);
            questionTimer.Name = "questionTimer";
            questionTimer.Size = new Size(542, 15);
            questionTimer.TabIndex = 2;
            // 
            // roundLabel
            // 
            roundLabel.Font = new Font("Segoe UI", 12F);
            roundLabel.ForeColor = Color.White;
            roundLabel.Location = new Point(329, 6);
            roundLabel.Name = "roundLabel";
            roundLabel.Size = new Size(145, 36);
            roundLabel.TabIndex = 1;
            roundLabel.Text = "label2";
            roundLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // questionLabel
            // 
            questionLabel.BackColor = Color.Transparent;
            questionLabel.BorderStyle = BorderStyle.FixedSingle;
            questionLabel.Font = new Font("Segoe UI", 15F);
            questionLabel.ForeColor = Color.White;
            questionLabel.Location = new Point(101, 72);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(600, 125);
            questionLabel.TabIndex = 0;
            questionLabel.Text = "label1";
            questionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(gamePanel);
            Controls.Add(categoryPanel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "GameForm";
            Text = "QuizDuel";
            FormClosing += GameForm_FormClosing;
            Load += GameForm_Load;
            categoryPanel.ResumeLayout(false);
            gamePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel categoryPanel;
        private Label selectCategoryLabel;
        private Button btnCategory3;
        private Button btnCategory2;
        private Button btnCategory1;
        private Panel gamePanel;
        private Label questionLabel;
        private Label roundLabel;
        private Label categoryLabel;
        private ProgressBar questionTimer;
        private Button btnAnswer4;
        private Button btnAnswer3;
        private Button btnAnswer2;
        private Button btnAnswer1;
    }
}