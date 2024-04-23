using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sandboxGUI
{
    public partial class StartingPage : ResizableForm
    {
        public StartingPage()
        {
            InitializeComponent();
        }

        private void StartingPage_Load(object sender, EventArgs e)
        {
            
        }
        private void StartingPage_Resize(object sender, EventArgs e)
        {
            
        }

        private void signup_Click(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();

            // keeping the same window measurements:
            loginForm.Size = this.Size; 
            loginForm.StartPosition = FormStartPosition.Manual; 
            loginForm.Location = this.Location; 
            
            // hiding the current window and showing the new one:
            this.Hide(); 
            ///loginForm.Show();

            loginForm.ShowDialog();
            this.Close();
        }


        protected override void SetLocation()
        {
            signupPage.Location = new Point((this.Width - signupPage.Width) / 2, (this.Height / 2));
            loginPage.Location = new Point((this.Width - loginPage.Width) / 2, (this.Height - loginPage.Height) / 2 - (loginPage.Height / 2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signup loginForm = new Signup();

            // keeping the same window measurements:
            loginForm.Size = this.Size;
            loginForm.StartPosition = FormStartPosition.Manual;
            loginForm.Location = this.Location;

            // hiding the current window and showing the new one:
            this.Hide();
            ///loginForm.Show();

            loginForm.ShowDialog();
            this.Close();
        }
    }
}
