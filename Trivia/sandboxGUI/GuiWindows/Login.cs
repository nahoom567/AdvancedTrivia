using Newtonsoft.Json;
using sandboxGUI.GuiWindows;
using System;
using System.Drawing;
using System.Windows.Forms;
using static sandboxGUI.Serialization;

namespace sandboxGUI
{
    public partial class Login : ResizableForm
    {
        public Login()
        {
            InitializeComponent();
        }   
        private void Login_Load(object sender, EventArgs e)
        {
            passwordBox.PasswordChar = '*';
        }
        private void Login_Resize(object sender, EventArgs e)
        {
            
        }
        private void login_Click(object sender, EventArgs e)
        {
            String json = makeJsonMsg();

            m_client.SendData(Serialization.serialize(json, getCode()));
            
            if(CheckResponse(Serialization.deserialize(m_client.reciveData())))
            {
                TriviaMenu mainMenu = new TriviaMenu(m_client, userNameBox.Text);

                mainMenu.Size = this.Size;
                mainMenu.StartPosition = FormStartPosition.Manual;
                mainMenu.Location = this.Location;

                this.Hide();
                mainMenu.ShowDialog();
                this.Show();
            }

        }

        protected virtual int getCode()
        {
            return ((int)ResponseCode.login);
        }
        protected virtual String makeJsonMsg()
        {
            return JsonConvert.SerializeObject
                (new
                {
                    username = userNameBox.Text,
                    password = passwordBox.Text
                });
        }

        protected virtual bool CheckResponse(object response)
        {
            // checking if the response is a loginResponse to know if the gui can move to the next form the menu form:
            if (response is LoginResponse loginResponse)
            {
                if (loginResponse.status == s_legalLoginResponse)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// this function is setting the locations for the buttons labels an so an to make them aligned 
        /// </summary>
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
            currHeight += passwordBox.Height + (this.Height / 8);
            
            loginButton.Location = new Point(widthPoint, currHeight);
        }

        private const uint s_legalLoginResponse = 1;
        private static ServerConnector m_client = new ServerConnector();
    }
}
