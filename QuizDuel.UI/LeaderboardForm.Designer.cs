namespace QuizDuel.UI
{
    partial class LeaderboardForm
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
            flowLeaders = new FlowLayoutPanel();
            leaderboardLabel = new Label();
            SuspendLayout();
            // 
            // flowLeaders
            // 
            flowLeaders.AutoScroll = true;
            flowLeaders.Location = new Point(12, 61);
            flowLeaders.Name = "flowLeaders";
            flowLeaders.Size = new Size(776, 364);
            flowLeaders.TabIndex = 1;
            // 
            // leaderboardLabel
            // 
            leaderboardLabel.Location = new Point(227, 9);
            leaderboardLabel.Name = "leaderboardLabel";
            leaderboardLabel.Size = new Size(349, 49);
            leaderboardLabel.TabIndex = 2;
            leaderboardLabel.Text = "label1";
            leaderboardLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LeaderboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(leaderboardLabel);
            Controls.Add(flowLeaders);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LeaderboardForm";
            Text = "QuizDuel";
            FormClosing += LeaderboardForm_FormClosing;
            Load += LeaderboardForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLeaders;
        private Label leaderboardLabel;
    }
}