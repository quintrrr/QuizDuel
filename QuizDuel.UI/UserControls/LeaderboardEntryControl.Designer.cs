namespace QuizDuel.UI.UserControls
{
    partial class LeaderboardEntryControl
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
            tableLayoutPanel1 = new TableLayoutPanel();
            placeLabel = new Label();
            usernameLabel = new Label();
            answersLabel = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.4511871F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.6543541F));
            tableLayoutPanel1.Controls.Add(placeLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(usernameLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(answersLabel, 2, 0);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(758, 65);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // placeLabel
            // 
            placeLabel.Font = new Font("Segoe UI", 15F);
            placeLabel.Location = new Point(3, 0);
            placeLabel.Name = "placeLabel";
            placeLabel.Size = new Size(69, 65);
            placeLabel.TabIndex = 0;
            placeLabel.Text = "label1";
            placeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // usernameLabel
            // 
            usernameLabel.Font = new Font("Segoe UI", 15F);
            usernameLabel.Location = new Point(78, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Padding = new Padding(50, 0, 0, 0);
            usernameLabel.Size = new Size(383, 65);
            usernameLabel.TabIndex = 1;
            usernameLabel.Text = "label1";
            usernameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // answersLabel
            // 
            answersLabel.Font = new Font("Segoe UI", 15F);
            answersLabel.Location = new Point(467, 0);
            answersLabel.Name = "answersLabel";
            answersLabel.Size = new Size(284, 65);
            answersLabel.TabIndex = 2;
            answersLabel.Text = "label1";
            answersLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LeaderboardEntryControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tableLayoutPanel1);
            Name = "LeaderboardEntryControl";
            Size = new Size(764, 71);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label placeLabel;
        private Label usernameLabel;
        private Label answersLabel;
    }
}
