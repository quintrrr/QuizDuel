namespace QuizDuel.UI.UserControls
{
    partial class GameCardControl
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
            btnJoin = new Button();
            hostUsernameLabel = new Label();
            SuspendLayout();
            // 
            // btnJoin
            // 
            btnJoin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnJoin.AutoSize = true;
            btnJoin.Location = new Point(641, 18);
            btnJoin.Name = "btnJoin";
            btnJoin.Size = new Size(107, 39);
            btnJoin.TabIndex = 0;
            btnJoin.Text = "button1";
            btnJoin.UseVisualStyleBackColor = true;
            // 
            // hostUsernameLabel
            // 
            hostUsernameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            hostUsernameLabel.Location = new Point(18, 24);
            hostUsernameLabel.Name = "hostUsernameLabel";
            hostUsernameLabel.Size = new Size(221, 25);
            hostUsernameLabel.TabIndex = 1;
            hostUsernameLabel.Text = "label1";
            hostUsernameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // GameCardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(hostUsernameLabel);
            Controls.Add(btnJoin);
            Name = "GameCardControl";
            Size = new Size(766, 73);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnJoin;
        private Label hostUsernameLabel;
    }
}
