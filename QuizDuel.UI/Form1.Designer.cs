namespace QuizDuel.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 29);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 91);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 1;
            label2.Text = "дата рождения";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 156);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 2;
            label3.Text = "пароль";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 224);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 3;
            label4.Text = "повторите пароль";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(109, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(241, 23);
            textBox1.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(136, 88);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(133, 23);
            dateTimePicker1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(95, 151);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(246, 23);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(154, 222);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(233, 23);
            textBox3.TabIndex = 7;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 52F);
            button1.Location = new Point(41, 273);
            button1.Name = "button1";
            button1.Size = new Size(713, 136);
            button1.TabIndex = 8;
            button1.Text = "зарегистрироваться";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
    }
}
