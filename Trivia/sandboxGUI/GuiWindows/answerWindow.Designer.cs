namespace sandboxGUI.GuiWindows
{
    partial class answerWindow
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
            this.whoWon = new System.Windows.Forms.Label();
            this.numCorrectAnswers = new System.Windows.Forms.Label();
            this.avgTime = new System.Windows.Forms.Label();
            this.namesPlayers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // whoWon
            // 
            this.whoWon.AutoSize = true;
            this.whoWon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whoWon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.whoWon.Location = new System.Drawing.Point(52, 257);
            this.whoWon.Name = "whoWon";
            this.whoWon.Size = new System.Drawing.Size(110, 25);
            this.whoWon.TabIndex = 24;
            this.whoWon.Text = "who won:";
            this.whoWon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numCorrectAnswers
            // 
            this.numCorrectAnswers.AutoSize = true;
            this.numCorrectAnswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCorrectAnswers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.numCorrectAnswers.Location = new System.Drawing.Point(373, 77);
            this.numCorrectAnswers.Name = "numCorrectAnswers";
            this.numCorrectAnswers.Size = new System.Drawing.Size(298, 25);
            this.numCorrectAnswers.TabIndex = 23;
            this.numCorrectAnswers.Text = "number of correct answers:";
            this.numCorrectAnswers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // avgTime
            // 
            this.avgTime.AutoSize = true;
            this.avgTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.avgTime.Location = new System.Drawing.Point(373, 257);
            this.avgTime.Name = "avgTime";
            this.avgTime.Size = new System.Drawing.Size(287, 25);
            this.avgTime.TabIndex = 22;
            this.avgTime.Text = "average time for question:";
            this.avgTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // namesPlayers
            // 
            this.namesPlayers.AutoSize = true;
            this.namesPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namesPlayers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.namesPlayers.Location = new System.Drawing.Point(52, 77);
            this.namesPlayers.Name = "namesPlayers";
            this.namesPlayers.Size = new System.Drawing.Size(199, 25);
            this.namesPlayers.TabIndex = 18;
            this.namesPlayers.Text = "names of players:";
            this.namesPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // answerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.whoWon);
            this.Controls.Add(this.numCorrectAnswers);
            this.Controls.Add(this.avgTime);
            this.Controls.Add(this.namesPlayers);
            this.Name = "answerWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label whoWon;
        protected System.Windows.Forms.Label numCorrectAnswers;
        protected System.Windows.Forms.Label avgTime;
        protected System.Windows.Forms.Label namesPlayers;
    }
}
