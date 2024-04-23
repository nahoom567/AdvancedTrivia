namespace sandboxGUI
{
    partial class StartingPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartingPage));
            this.loginPage = new System.Windows.Forms.Button();
            this.signupPage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginPage
            // 
            this.loginPage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.loginPage.AutoSize = true;
            this.loginPage.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.loginPage.Location = new System.Drawing.Point(296, 245);
            this.loginPage.Name = "loginPage";
            this.loginPage.Size = new System.Drawing.Size(207, 113);
            this.loginPage.TabIndex = 0;
            this.loginPage.Text = "LOGIN";
            this.loginPage.UseVisualStyleBackColor = true;
            this.loginPage.Click += new System.EventHandler(this.login_Click);
            // 
            // signupPage
            // 
            this.signupPage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.signupPage.AutoSize = true;
            this.signupPage.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.signupPage.Location = new System.Drawing.Point(296, 126);
            this.signupPage.Name = "signupPage";
            this.signupPage.Size = new System.Drawing.Size(207, 113);
            this.signupPage.TabIndex = 1;
            this.signupPage.Text = "SIGNUP";
            this.signupPage.UseVisualStyleBackColor = true;
            this.signupPage.Click += new System.EventHandler(this.button1_Click);
            // 
            // StartingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.signupPage);
            this.Controls.Add(this.loginPage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartingPage";
            this.Text = "TRIVIA GAME - StartingPage";
            this.Load += new System.EventHandler(this.StartingPage_Load);
            this.Resize += new System.EventHandler(this.StartingPage_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginPage;
        private System.Windows.Forms.Button signupPage;
    }
}

