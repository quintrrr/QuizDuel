namespace QuizDuel.UI.UserControls
{
    partial class GameHistoryItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            timeAgoLabel = new Label();
            resultLabel = new Label();
            opponentLabel = new Label();
            SuspendLayout();
            // 
            // timeAgoLabel
            // 
            timeAgoLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            timeAgoLabel.AutoSize = true;
            timeAgoLabel.Location = new Point(57, 0);
            timeAgoLabel.Name = "timeAgoLabel";
            timeAgoLabel.Size = new Size(38, 15);
            timeAgoLabel.TabIndex = 0;
            timeAgoLabel.Text = "label1";
            timeAgoLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // resultLabel
            // 
            resultLabel.Font = new Font("Segoe UI", 11F);
            resultLabel.Location = new Point(3, 37);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(92, 23);
            resultLabel.TabIndex = 1;
            resultLabel.Text = "Поражение";
            resultLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // opponentLabel
            // 
            opponentLabel.Location = new Point(-1, 75);
            opponentLabel.Name = "opponentLabel";
            opponentLabel.Size = new Size(100, 23);
            opponentLabel.TabIndex = 2;
            opponentLabel.Text = "label2";
            opponentLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GameHistoryItemControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(opponentLabel);
            Controls.Add(resultLabel);
            Controls.Add(timeAgoLabel);
            Name = "GameHistoryItemControl";
            Size = new Size(98, 98);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label timeAgoLabel;
        private Label resultLabel;
        private Label opponentLabel;
    }
}
