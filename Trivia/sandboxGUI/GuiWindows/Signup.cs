using Newtonsoft.Json;
using sandboxGUI.GuiWindows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static sandboxGUI.Serialization;

namespace sandboxGUI
{
    public partial class Signup : Login
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        protected override int getCode()
        {
            return ((int)ResponseCode.signup);
        }
        protected override String makeJsonMsg()
        {
            return JsonConvert.SerializeObject
                (new
                {
                    username = userNameBox.Text,
                    password = passwordBox.Text,
                    mail = mailBox.Text
                });
        }

        protected override bool CheckResponse(object response)
        {
            // checking if the response is a loginResponse to know if the gui can move to the next form the menu form:
            if (response is SignupResponse loginResponse)
            {
                if (loginResponse.status == s_legalSignupResponse)
                {
                    return true;
                }
            }

            return false;
        }

        protected override void SetLocation()
        {
            int widthPoint = (this.Width * 2) / 7;
            int currHeight = (this.Height / 5);

            userNameAsker.Location = new Point(widthPoint, currHeight);
            currHeight += userNameAsker.Height;
            userNameBox.Location = new Point(widthPoint, currHeight);
            currHeight += userNameBox.Height;
            passwordAsker.Location = new Point(widthPoint, currHeight);
            currHeight += passwordAsker.Height;
            passwordBox.Location = new Point(widthPoint, currHeight);
            currHeight += passwordBox.Height;
            mailAsker.Location = new Point(widthPoint, currHeight);
            currHeight += mailAsker.Height;
            mailBox.Location = new Point(widthPoint, currHeight);
            currHeight += mailBox.Height + (this.Height / 8);

            loginButton.Location = new Point(widthPoint, currHeight);
        }

        private const uint s_legalSignupResponse = 1;
    }


}
