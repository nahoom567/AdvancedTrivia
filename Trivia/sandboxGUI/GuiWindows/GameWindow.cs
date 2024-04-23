using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using static sandboxGUI.Serialization;

namespace sandboxGUI.GuiWindows
{
    public partial class GameWindow : sandboxGUI.ResizableForm
    {
        internal GameWindow(ServerConnector client, uint questions, uint timePerQuestion)
        {
            InitializeComponent();
            m_client = client;
            iQuestionsLeft = questions;
            questionTimeout = timePerQuestion;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.timer.Text = timePerQuestion.ToString();
            this.questionsLeft.Text = questions.ToString();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            this.questionTimeUpdate = new System.Timers.Timer(1000); // 1000 milliseconds = 1 second
            questionTimeUpdate.Elapsed += updateQuestionClock;
            questionTimeUpdate.AutoReset = true;
            questionTimeUpdate.Start();

            getTheNextQuestion();

        }
        private void updateQuestionClock(object sender, ElapsedEventArgs e)
        {
            Invoke((MethodInvoker)(() =>
            {
                if (int.TryParse(timer.Text, out int timerValue))
                {
                    timerValue--;
                    timer.Text = timerValue.ToString();
                }

                if (timer.Text == "0")
                {
                    getTheNextQuestion();
                    sendAnswer(1);
                }
            }));
        }

        #region answerClick
        private void answer1_Click(object sender, EventArgs e)
        {
            sendAnswer(1);
        }
        private void answer2_Click(object sender, EventArgs e)
        {
            sendAnswer(2);
        }
        private void answer3_Click(object sender, EventArgs e)
        {
            sendAnswer(3);
        }
        private void answer4_Click(object sender, EventArgs e)
        {
            sendAnswer(4);
        }
        void sendAnswer(int id)
        {
            String jsonMsg = JsonConvert.SerializeObject
               (new
               {
                   answerId = id
               });

            m_client.SendData(Serialization.serialize(jsonMsg, (int)ResponseCode.submitAnswers));
            if (Serialization.deserialize(m_client.reciveData()) is SubmitAnswerResponse subRes)
            {
                if(id == subRes.correctAnswerId)
                {
                    answerCount++;
                    correctAsnwers.Text = answerCount.ToString();
                }
            }

            getTheNextQuestion();

            timer.Text = questionTimeout.ToString();
        }

        void getTheNextQuestion()
        {
            decreaseQuestionsLeft();

            m_client.SendData(Serialization.serialize("", (int)ResponseCode.getQuestions));
            if (Serialization.deserialize(m_client.reciveData()) is GetQuestionResponse res)
            {
                questionLabel.Text = res.question;
                answer1.Text = res.answers[1];
                answer2.Text = res.answers[2];
                answer3.Text = res.answers[3];
                answer4.Text = res.answers[4];
            }
        }
        #endregion

        private void decreaseQuestionsLeft()
        {
            iQuestionsLeft--;
            this.questionsLeft.Text = iQuestionsLeft.ToString();
        }

        private ServerConnector m_client;
        private uint answerCount = 0;
        private uint iQuestionsLeft = 0;
        private uint questionTimeout = 0;
        private System.Timers.Timer questionTimeUpdate;
    }
}
