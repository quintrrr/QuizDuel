namespace QuizDuel.UI
{
    partial class JoinGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoinGameForm));
            flowGames = new FlowLayoutPanel();
            btnUpdateGames = new Button();
            titleLabel = new Label();
            SuspendLayout();
            // 
            // flowGames
            // 
            flowGames.AutoScroll = true;
            flowGames.BackColor = Color.Transparent;
            flowGames.ForeColor = Color.White;
            flowGames.Location = new Point(12, 73);
            flowGames.Name = "flowGames";
            flowGames.Size = new Size(776, 365);
            flowGames.TabIndex = 0;
            // 
            // btnUpdateGames
            // 
            btnUpdateGames.BackColor = Color.Transparent;
            btnUpdateGames.Cursor = Cursors.Hand;
            btnUpdateGames.FlatAppearance.BorderSize = 3;
            btnUpdateGames.FlatStyle = FlatStyle.Flat;
            btnUpdateGames.ForeColor = Color.White;
            btnUpdateGames.Location = new Point(12, 16);
            btnUpdateGames.Name = "btnUpdateGames";
            btnUpdateGames.Size = new Size(125, 39);
            btnUpdateGames.TabIndex = 1;
            btnUpdateGames.Text = "button1";
            btnUpdateGames.UseVisualStyleBackColor = false;
            btnUpdateGames.Click += BtnUpdateGames_Click;
            // 
            // titleLabel
            // 
            titleLabel.BackColor = Color.Transparent;
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(275, 4);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(253, 61);
            titleLabel.TabIndex = 7;
            titleLabel.Text = "QuizDuel";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // JoinGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(titleLabel);
            Controls.Add(btnUpdateGames);
            Controls.Add(flowGames);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "JoinGameForm";
            Text = "QuizDuel";
            FormClosing += JoinGameForm_FormClosing;
            Load += JoinGameForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowGames;
        private Button btnUpdateGames;
        private Label titleLabel;
    }
}