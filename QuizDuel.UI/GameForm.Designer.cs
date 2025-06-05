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
            categoryPanel.Controls.Add(selectCategoryLabel);
            categoryPanel.Controls.Add(btnCategory3);
            categoryPanel.Controls.Add(btnCategory2);
            categoryPanel.Controls.Add(btnCategory1);
            categoryPanel.Location = new Point(334, 70);
            categoryPanel.Margin = new Padding(4, 5, 4, 5);
            categoryPanel.Name = "categoryPanel";
            categoryPanel.Size = new Size(494, 585);
            categoryPanel.TabIndex = 0;
            categoryPanel.Visible = false;
            // 
            // selectCategoryLabel
            // 
            selectCategoryLabel.Font = new Font("Segoe UI", 16F);
            selectCategoryLabel.Location = new Point(43, 33);
            selectCategoryLabel.Margin = new Padding(4, 0, 4, 0);
            selectCategoryLabel.Name = "selectCategoryLabel";
            selectCategoryLabel.Size = new Size(419, 142);
            selectCategoryLabel.TabIndex = 3;
            selectCategoryLabel.Text = "label1";
            selectCategoryLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCategory3
            // 
            btnCategory3.Location = new Point(90, 492);
            btnCategory3.Margin = new Padding(4, 5, 4, 5);
            btnCategory3.Name = "btnCategory3";
            btnCategory3.Size = new Size(323, 93);
            btnCategory3.TabIndex = 2;
            btnCategory3.Text = "button3";
            btnCategory3.UseVisualStyleBackColor = true;
            btnCategory3.Click += ButtonCategory_Click;
            // 
            // btnCategory2
            // 
            btnCategory2.Location = new Point(90, 345);
            btnCategory2.Margin = new Padding(4, 5, 4, 5);
            btnCategory2.Name = "btnCategory2";
            btnCategory2.Size = new Size(323, 87);
            btnCategory2.TabIndex = 1;
            btnCategory2.Text = "button2";
            btnCategory2.UseVisualStyleBackColor = true;
            btnCategory2.Click += ButtonCategory_Click;
            // 
            // btnCategory1
            // 
            btnCategory1.Location = new Point(90, 202);
            btnCategory1.Margin = new Padding(4, 5, 4, 5);
            btnCategory1.Name = "btnCategory1";
            btnCategory1.Size = new Size(323, 90);
            btnCategory1.TabIndex = 0;
            btnCategory1.Text = "button1";
            btnCategory1.UseVisualStyleBackColor = true;
            btnCategory1.Click += ButtonCategory_Click;
            // 
            // gamePanel
            // 
            gamePanel.Controls.Add(btnAnswer4);
            gamePanel.Controls.Add(btnAnswer3);
            gamePanel.Controls.Add(btnAnswer2);
            gamePanel.Controls.Add(btnAnswer1);
            gamePanel.Controls.Add(categoryLabel);
            gamePanel.Controls.Add(questionTimer);
            gamePanel.Controls.Add(roundLabel);
            gamePanel.Controls.Add(questionLabel);
            gamePanel.Location = new Point(1, 3);
            gamePanel.Margin = new Padding(4, 5, 4, 5);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(1141, 727);
            gamePanel.TabIndex = 1;
            gamePanel.Visible = false;
            // 
            // btnAnswer4
            // 
            btnAnswer4.Location = new Point(623, 538);
            btnAnswer4.Margin = new Padding(4, 5, 4, 5);
            btnAnswer4.Name = "btnAnswer4";
            btnAnswer4.Size = new Size(346, 120);
            btnAnswer4.TabIndex = 7;
            btnAnswer4.Tag = "3";
            btnAnswer4.Text = "button4";
            btnAnswer4.UseVisualStyleBackColor = true;
            btnAnswer4.Click += ButtonAnswer_Click;
            // 
            // btnAnswer3
            // 
            btnAnswer3.Location = new Point(623, 390);
            btnAnswer3.Margin = new Padding(4, 5, 4, 5);
            btnAnswer3.Name = "btnAnswer3";
            btnAnswer3.Size = new Size(346, 120);
            btnAnswer3.TabIndex = 6;
            btnAnswer3.Tag = "2";
            btnAnswer3.Text = "button3";
            btnAnswer3.UseVisualStyleBackColor = true;
            btnAnswer3.Click += ButtonAnswer_Click;
            // 
            // btnAnswer2
            // 
            btnAnswer2.Location = new Point(194, 538);
            btnAnswer2.Margin = new Padding(4, 5, 4, 5);
            btnAnswer2.Name = "btnAnswer2";
            btnAnswer2.Size = new Size(349, 120);
            btnAnswer2.TabIndex = 5;
            btnAnswer2.Tag = "1";
            btnAnswer2.Text = "button2";
            btnAnswer2.UseVisualStyleBackColor = true;
            btnAnswer2.Click += ButtonAnswer_Click;
            // 
            // btnAnswer1
            // 
            btnAnswer1.Location = new Point(194, 390);
            btnAnswer1.Margin = new Padding(4, 5, 4, 5);
            btnAnswer1.Name = "btnAnswer1";
            btnAnswer1.Size = new Size(349, 120);
            btnAnswer1.TabIndex = 4;
            btnAnswer1.Tag = "0";
            btnAnswer1.Text = "button1";
            btnAnswer1.UseVisualStyleBackColor = true;
            btnAnswer1.Click += ButtonAnswer_Click;
            // 
            // categoryLabel
            // 
            categoryLabel.Location = new Point(359, 85);
            categoryLabel.Margin = new Padding(4, 0, 4, 0);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(429, 35);
            categoryLabel.TabIndex = 3;
            categoryLabel.Text = "label1";
            categoryLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // questionTimer
            // 
            questionTimer.ForeColor = Color.FromArgb(255, 255, 128);
            questionTimer.Location = new Point(196, 347);
            questionTimer.Margin = new Padding(4, 5, 4, 5);
            questionTimer.Name = "questionTimer";
            questionTimer.Size = new Size(774, 25);
            questionTimer.TabIndex = 2;
            // 
            // roundLabel
            // 
            roundLabel.Font = new Font("Segoe UI", 12F);
            roundLabel.Location = new Point(470, 10);
            roundLabel.Margin = new Padding(4, 0, 4, 0);
            roundLabel.Name = "roundLabel";
            roundLabel.Size = new Size(207, 60);
            roundLabel.TabIndex = 1;
            roundLabel.Text = "label2";
            roundLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // questionLabel
            // 
            questionLabel.BackColor = SystemColors.Control;
            questionLabel.BorderStyle = BorderStyle.FixedSingle;
            questionLabel.Font = new Font("Segoe UI", 15F);
            questionLabel.Location = new Point(153, 120);
            questionLabel.Margin = new Padding(4, 0, 4, 0);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(856, 207);
            questionLabel.TabIndex = 0;
            questionLabel.Text = "label1";
            questionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(gamePanel);
            Controls.Add(categoryPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            Name = "GameForm";
            Text = "GameForm";
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