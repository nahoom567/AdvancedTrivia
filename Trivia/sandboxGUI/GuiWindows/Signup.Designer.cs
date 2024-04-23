namespace sandboxGUI
{
    partial class Signup
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
            this.mailBox = new System.Windows.Forms.TextBox();
            this.mailAsker = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(233, 224);
            this.loginButton.Text = "SIGNUP";
            // 
            // userNameBox
            // 
            this.userNameBox.Location = new System.Drawing.Point(233, 110);
            // 
            // userNameAsker
            // 
            this.userNameAsker.Location = new System.Drawing.Point(233, 97);
            // 
            // passwordAsker
            // 
            this.passwordAsker.Location = new System.Drawing.Point(233, 130);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(233, 143);
            // 
            // mailBox
            // 
            this.mailBox.AccessibleDescription = "enter the user name:";
            this.mailBox.AccessibleName = "enter the user name:";
            this.mailBox.Location = new System.Drawing.Point(233, 182);
            this.mailBox.Multiline = true;
            this.mailBox.Name = "mailBox";
            this.mailBox.Size = new System.Drawing.Size(249, 20);
            this.mailBox.TabIndex = 11;
            // 
            // mailAsker
            // 
            this.mailAsker.AutoSize = true;
            this.mailAsker.Location = new System.Drawing.Point(230, 166);
            this.mailAsker.Name = "mailAsker";
            this.mailAsker.Size = new System.Drawing.Size(78, 13);
            this.mailAsker.TabIndex = 10;
            this.mailAsker.Text = "enter your mail:";
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mailBox);
            this.Controls.Add(this.mailAsker);
            this.Name = "Signup";
            this.Text = "TRIVIA GAME - Signup";
            this.Load += new System.EventHandler(this.Signup_Load);
            this.Controls.SetChildIndex(this.loginButton, 0);
            this.Controls.SetChildIndex(this.userNameBox, 0);
            this.Controls.SetChildIndex(this.userNameAsker, 0);
            this.Controls.SetChildIndex(this.passwordAsker, 0);
            this.Controls.SetChildIndex(this.passwordBox, 0);
            this.Controls.SetChildIndex(this.mailAsker, 0);
            this.Controls.SetChildIndex(this.mailBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mailBox;
        private System.Windows.Forms.Label mailAsker;
    }
}