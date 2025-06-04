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
            categoryPanel.SuspendLayout();
            SuspendLayout();
            // 
            // categoryPanel
            // 
            categoryPanel.Controls.Add(selectCategoryLabel);
            categoryPanel.Controls.Add(btnCategory3);
            categoryPanel.Controls.Add(btnCategory2);
            categoryPanel.Controls.Add(btnCategory1);
            categoryPanel.Location = new Point(217, 27);
            categoryPanel.Name = "categoryPanel";
            categoryPanel.Size = new Size(346, 351);
            categoryPanel.TabIndex = 0;
            categoryPanel.Visible = false;
            // 
            // selectCategoryLabel
            // 
            selectCategoryLabel.Font = new Font("Segoe UI", 16F);
            selectCategoryLabel.Location = new Point(28, 21);
            selectCategoryLabel.Name = "selectCategoryLabel";
            selectCategoryLabel.Size = new Size(293, 85);
            selectCategoryLabel.TabIndex = 3;
            selectCategoryLabel.Text = "label1";
            selectCategoryLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCategory3
            // 
            btnCategory3.Location = new Point(63, 295);
            btnCategory3.Name = "btnCategory3";
            btnCategory3.Size = new Size(226, 56);
            btnCategory3.TabIndex = 2;
            btnCategory3.Text = "button3";
            btnCategory3.UseVisualStyleBackColor = true;
            // 
            // btnCategory2
            // 
            btnCategory2.Location = new Point(63, 207);
            btnCategory2.Name = "btnCategory2";
            btnCategory2.Size = new Size(226, 52);
            btnCategory2.TabIndex = 1;
            btnCategory2.Text = "button2";
            btnCategory2.UseVisualStyleBackColor = true;
            // 
            // btnCategory1
            // 
            btnCategory1.Location = new Point(63, 121);
            btnCategory1.Name = "btnCategory1";
            btnCategory1.Size = new Size(226, 54);
            btnCategory1.TabIndex = 0;
            btnCategory1.Text = "button1";
            btnCategory1.UseVisualStyleBackColor = true;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(categoryPanel);
            Name = "GameForm";
            Text = "GameForm";
            categoryPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel categoryPanel;
        private Label selectCategoryLabel;
        private Button btnCategory3;
        private Button btnCategory2;
        private Button btnCategory1;
    }
}