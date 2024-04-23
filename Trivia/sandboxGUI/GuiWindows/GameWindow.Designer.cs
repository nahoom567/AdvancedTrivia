namespace sandboxGUI.GuiWindows
{
    partial class GameWindow
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
            this.answer3 = new System.Windows.Forms.Button();
            this.questionLabel = new System.Windows.Forms.Label();
            this.answer4 = new System.Windows.Forms.Button();
            this.answer1 = new System.Windows.Forms.Button();
            this.answer2 = new System.Windows.Forms.Button();
            this.answerCorrect = new System.Windows.Forms.Label();
            this.numQuestionLeft = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Label();
            this.questionsLeft = new System.Windows.Forms.Label();
            this.correctAsnwers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // answer3
            // 
            this.answer3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.answer3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.answer3.Location = new System.Drawing.Point(38, 264);
            this.answer3.Name = "answer3";
            this.answer3.Size = new System.Drawing.Size(413, 66);
            this.answer3.TabIndex = 9;
            this.answer3.Text = "answer3";
            this.answer3.UseVisualStyleBackColor = false;
            this.answer3.Click += new System.EventHandler(this.answer3_Click);
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.questionLabel.Location = new System.Drawing.Point(33, 25);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(115, 25);
            this.questionLabel.TabIndex = 10;
            this.questionLabel.Text = "question?";
            this.questionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // answer4
            // 
            this.answer4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.answer4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.answer4.Location = new System.Drawing.Point(38, 349);
            this.answer4.Name = "answer4";
            this.answer4.Size = new System.Drawing.Size(413, 66);
            this.answer4.TabIndex = 11;
            this.answer4.Text = "answer4";
            this.answer4.UseVisualStyleBackColor = false;
            this.answer4.Click += new System.EventHandler(this.answer4_Click);
            // 
            // answer1
            // 
            this.answer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.answer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.answer1.Location = new System.Drawing.Point(38, 101);
            this.answer1.Name = "answer1";
            this.answer1.Size = new System.Drawing.Size(413, 66);
            this.answer1.TabIndex = 12;
            this.answer1.Text = "answer1";
            this.answer1.UseVisualStyleBackColor = false;
            this.answer1.Click += new System.EventHandler(this.answer1_Click);
            // 
            // answer2
            // 
            this.answer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.answer2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.answer2.Location = new System.Drawing.Point(38, 182);
            this.answer2.Name = "answer2";
            this.answer2.Size = new System.Drawing.Size(413, 66);
            this.answer2.TabIndex = 13;
            this.answer2.Text = "answer2";
            this.answer2.UseVisualStyleBackColor = false;
            this.answer2.Click += new System.EventHandler(this.answer2_Click);
            // 
            // answerCorrect
            // 
            this.answerCorrect.AutoSize = true;
            this.answerCorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerCorrect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.answerCorrect.Location = new System.Drawing.Point(472, 142);
            this.answerCorrect.Name = "answerCorrect";
            this.answerCorrect.Size = new System.Drawing.Size(186, 25);
            this.answerCorrect.TabIndex = 14;
            this.answerCorrect.Text = "correct answers:";
            this.answerCorrect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numQuestionLeft
            // 
            this.numQuestionLeft.AutoSize = true;
            this.numQuestionLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.numQuestionLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQuestionLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.numQuestionLeft.Location = new System.Drawing.Point(472, 101);
            this.numQuestionLeft.Name = "numQuestionLeft";
            this.numQuestionLeft.Size = new System.Drawing.Size(273, 25);
            this.numQuestionLeft.TabIndex = 15;
            this.numQuestionLeft.Text = "number of questions left:";
            this.numQuestionLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.AutoSize = true;
            this.timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.timer.Location = new System.Drawing.Point(712, 9);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(64, 25);
            this.timer.TabIndex = 16;
            this.timer.Text = "timer";
            this.timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // questionsLeft
            // 
            this.questionsLeft.AutoSize = true;
            this.questionsLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.questionsLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionsLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.questionsLeft.Location = new System.Drawing.Point(751, 101);
            this.questionsLeft.Name = "questionsLeft";
            this.questionsLeft.Size = new System.Drawing.Size(25, 25);
            this.questionsLeft.TabIndex = 17;
            this.questionsLeft.Text = "0";
            this.questionsLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // correctAsnwers
            // 
            this.correctAsnwers.AutoSize = true;
            this.correctAsnwers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.correctAsnwers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correctAsnwers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.correctAsnwers.Location = new System.Drawing.Point(686, 142);
            this.correctAsnwers.Name = "correctAsnwers";
            this.correctAsnwers.Size = new System.Drawing.Size(25, 25);
            this.correctAsnwers.TabIndex = 18;
            this.correctAsnwers.Text = "0";
            this.correctAsnwers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.correctAsnwers);
            this.Controls.Add(this.questionsLeft);
            this.Controls.Add(this.timer);
            this.Controls.Add(this.numQuestionLeft);
            this.Controls.Add(this.answerCorrect);
            this.Controls.Add(this.answer2);
            this.Controls.Add(this.answer1);
            this.Controls.Add(this.answer4);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.answer3);
            this.Name = "GameWindow";
            this.Load += new System.EventHandler(this.GameWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button answer3;
        protected System.Windows.Forms.Label questionLabel;
        protected System.Windows.Forms.Button answer4;
        protected System.Windows.Forms.Button answer1;
        protected System.Windows.Forms.Button answer2;
        protected System.Windows.Forms.Label answerCorrect;
        protected System.Windows.Forms.Label numQuestionLeft;
        protected System.Windows.Forms.Label timer;
        protected System.Windows.Forms.Label questionsLeft;
        protected System.Windows.Forms.Label correctAsnwers;
    }
}
