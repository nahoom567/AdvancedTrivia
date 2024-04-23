namespace sandboxGUI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.loginButton = new System.Windows.Forms.Button();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.userNameAsker = new System.Windows.Forms.Label();
            this.passwordAsker = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(219, 208);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(123, 54);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "LOGIN";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.login_Click);
            // 
            // userNameBox
            // 
            this.userNameBox.AccessibleDescription = "enter the user name:";
            this.userNameBox.AccessibleName = "enter the user name:";
            this.userNameBox.Location = new System.Drawing.Point(219, 130);
            this.userNameBox.Multiline = true;
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(249, 20);
            this.userNameBox.TabIndex = 1;
            // 
            // userNameAsker
            // 
            this.userNameAsker.AutoSize = true;
            this.userNameAsker.Location = new System.Drawing.Point(216, 114);
            this.userNameAsker.Name = "userNameAsker";
            this.userNameAsker.Size = new System.Drawing.Size(106, 13);
            this.userNameAsker.TabIndex = 2;
            this.userNameAsker.Text = "enter your username:";
            // 
            // passwordAsker
            // 
            this.passwordAsker.AutoSize = true;
            this.passwordAsker.Location = new System.Drawing.Point(216, 153);
            this.passwordAsker.Name = "passwordAsker";
            this.passwordAsker.Size = new System.Drawing.Size(105, 13);
            this.passwordAsker.TabIndex = 3;
            this.passwordAsker.Text = "enter your password:";
            // 
            // passwordBox
            // 
            this.passwordBox.AccessibleDescription = "enter the user name:";
            this.passwordBox.AccessibleName = "enter the user name:";
            this.passwordBox.Location = new System.Drawing.Point(219, 169);
            this.passwordBox.Multiline = true;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(249, 20);
            this.passwordBox.TabIndex = 4;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.passwordAsker);
            this.Controls.Add(this.userNameAsker);
            this.Controls.Add(this.userNameBox);
            this.Controls.Add(this.loginButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Text = "TRIVIA GAME - Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.Resize += new System.EventHandler(this.Login_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button loginButton;
        protected System.Windows.Forms.TextBox userNameBox;
        protected System.Windows.Forms.Label userNameAsker;
        protected System.Windows.Forms.Label passwordAsker;
        protected System.Windows.Forms.TextBox passwordBox;
    }
}