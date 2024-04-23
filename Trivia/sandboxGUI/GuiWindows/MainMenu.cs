using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Windows.Forms;
using static sandboxGUI.Serialization;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using sandboxGUI.Data;
using System.Xml.Linq;
using System.Collections;
using System.Threading;

namespace sandboxGUI.GuiWindows
{
    public partial class TriviaMenu : ResizableForm
    {
        internal TriviaMenu(ServerConnector client, string username)
        {
            InitializeComponent();
            usernameLabel.Text = username;
            usernameLabel.TextAlign = ContentAlignment.MiddleCenter;
            m_userName = username;
            m_client = client;

            // not letting the window to resize to not break anything:
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // making the objects that are being used to look good:
            formatTable(RoomsDisplay);
            formatList(PlayersList, "Players: ");
            PlayersList.DrawMode = DrawMode.OwnerDrawFixed;
            PlayersList.DrawItem += PlayersList_DrawItem;
        }
        private void mainMenu_Load(object sender, EventArgs e)
        {
            // Create a TableLayoutPanel to hold the side bar and content panels
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;

            // Add the side bar panel to the first column of the TableLayoutPanel
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200)); // Adjust the width as needed
            tableLayoutPanel.Controls.Add(sideBarPanel, 0, 0);


            // Add the content panels to the second column of the TableLayoutPanel
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayoutPanel.Controls.Add(startingPanel, 1, 0);
            tableLayoutPanel.Controls.Add(createRoomPanel, 1, 0);     // Initially hidden
            tableLayoutPanel.Controls.Add(joinRoomPanel, 1, 0);      // Initially hidden
            tableLayoutPanel.Controls.Add(statisticPanel, 1, 0);    // Initially hidden
            tableLayoutPanel.Controls.Add(showPlayersInRoom, 1, 0);// Initially hidden

            // Set the visibility of the content panels as needed
            setPanelsToInvisible();
            startingPanel.Visible = true;
            startingPanel.BringToFront();

            // Add the TableLayoutPanel to the form
            Controls.Add(tableLayoutPanel);
        }
        protected override void SetLocation()
        {
            Image originalImage = createRoom.Image;
            Image resizedImage = originalImage.GetThumbnailImage(50, 50, null, IntPtr.Zero);
            createRoom.Image = resizedImage;

            originalImage = joinRoom.Image;
            resizedImage = originalImage.GetThumbnailImage(50, 50, null, IntPtr.Zero);
            joinRoom.Image = resizedImage;

            originalImage = statisticsButton.Image;
            resizedImage = originalImage.GetThumbnailImage(50, 50, null, IntPtr.Zero);
            statisticsButton.Image = resizedImage;

            originalImage = exitButton.Image;
            resizedImage = originalImage.GetThumbnailImage(50, 50, null, IntPtr.Zero);
            exitButton.Image = resizedImage;
        }

        #region sideBarButtons
        private void createRoom_Click(object sender, EventArgs e)
        {
            if(lockedSideBar)
            {
                return;
            }
            m_checkingForRooms = false;
            m_checkingForNewPlayers = false;
            
            // chaining the page that is displayed:
            setPanelsToInvisible();
            createRoomPanel.BringToFront();
            createRoomPanel.Visible = true;

            // changing the color in the sideBar
            ResetButtonsColors();
            createRoom.BackColor = Color.FromArgb(46, 51, 73);
        }
        private void joinRoom_Click(object sender, EventArgs e)
        {
            if(lockedSideBar)
            {
                return;
            }
            m_checkingForRooms = false;
            m_checkingForNewPlayers = false;

            setPanelsToInvisible();
            joinRoomPanel.BringToFront();
            joinRoomPanel.Visible = true;

            // changing the color in the sideBar
            ResetButtonsColors();
            joinRoom.BackColor = Color.FromArgb(46, 51, 73);

            m_checkingForRooms = true;
            refreshRooms();
        }
        private void statistics_Click(object sender, EventArgs e)
        {
            if(lockedSideBar)
            {
                return;
            }
            m_checkingForRooms = false;
            m_checkingForNewPlayers = false;

            setPanelsToInvisible();
            statisticPanel.BringToFront();
            statisticPanel.Visible = true;

            ResetButtonsColors();
            statisticsButton.BackColor = Color.FromArgb(46, 51, 73);
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            if(lockedSideBar)
            {
                return;
            }
            m_checkingForRooms = false;
            m_checkingForNewPlayers = false;

            ResetButtonsColors();
            exitButton.BackColor = Color.FromArgb(46, 51, 73);
            sendLogoutRequest();
            this.Close();
        }

        private void sendLogoutRequest()
        {
            m_client.SendData(Serialization.serialize("", (int)ResponseCode.logout));
        }
        private void ResetButtonsColors()
        {
            exitButton.BackColor = Color.FromArgb(24, 30, 54);
            statisticsButton.BackColor = Color.FromArgb(24, 30, 54);
            joinRoom.BackColor = Color.FromArgb(24, 30, 54);
            createRoom.BackColor = Color.FromArgb(24, 30, 54);
        }
        #endregion

        #region createRoomWindow
        private void roomNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        private void answerTimeoutBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allowing only digits:
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignore the input
            }
        }
        private void questionsNumBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allowing only digits:
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignore the input
            }
        }
        private void maxUsersBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allowing only digits:
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignore the input
            }
        }
        private void createRoomInServerButton_Click(object sender, EventArgs e)
        {
            creatorOrJoiner = true;
            uint roomId = 0;

            // checking if all fields were filled
            if (!(string.IsNullOrEmpty(roomNameBox.Text) || string.IsNullOrEmpty(answerTimeoutBox.Text) ||
                string.IsNullOrEmpty(questionsNumBox.Text) || string.IsNullOrEmpty(maxUsersBox.Text)))
            {
                String jsonMsg = JsonConvert.SerializeObject
                (new
                {
                    roomName = roomNameBox.Text,
                    maxUsers = int.Parse(maxUsersBox.Text),
                    questionCount = int.Parse(questionsNumBox.Text),
                    answerTimeout = int.Parse(answerTimeoutBox.Text),
                });

                m_client.SendData(Serialization.serialize(jsonMsg, (int)ResponseCode.createRoom));

                // checking if the response is CreateRoomResponse and what is the status
                // because the status is the room id if it is not 0
                if (Serialization.deserialize(m_client.reciveData()) is CreateRoomResponse createRoomResponse)
                {
                    if(createRoomResponse.status != 0)
                    {
                        setPanelsToInvisible();
                        showPlayersInRoom.Visible = true;
                        showPlayersInRoom.BringToFront();

                        m_checkingForNewPlayers = true;
                        refreshPlayers((int)createRoomResponse.status);
                    }
                }
            }
            
        }
        private void displayPlayersInRoom(int roomId)
        {
            while (m_checkingForNewPlayers)
            {
                m_client.SendData(Serialization.serialize("", (int)ResponseCode.getRoomState));

                if (Serialization.deserialize(m_client.reciveData()) is GetRoomStateResponse res)
                {
                    if (InvokeRequired)
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            useResponse(res);
                        }));
                    }
                    else
                    {
                        useResponse(res);
                    }

                }

                Thread.Sleep(3000);
            }
        }
        
        private void useResponse(GetRoomStateResponse res)
        {
            questions = res.questionsCount;
            TimePerQuestions = res.answerTimeout;
            this.numOfQuestion.Text = "the num of questions: " + res.questionsCount;
            this.timePerQuestion.Text = "the time per question: " + res.answerTimeout;
            
            if(!creatorOrJoiner && res.status == 0)
            {
                setPanelsToInvisible();
                startingPanel.Visible = true;
                startingPanel.BringToFront();
                m_checkingForNewPlayers = false;
                lockedSideBar = false;
                return;
            }

            if(res.hasGameBegun)
            {
                this.Invoke((MethodInvoker)switchGameView);
                lockedSideBar = false;
                return;
            }

            updatePlayerList(res.players);

        }

        private void switchGameView()
        {
            m_checkingForNewPlayers = false;
            GameWindow gameWin = new GameWindow(m_client, questions, TimePerQuestions);

            gameWin.Size = this.Size;
            gameWin.StartPosition = FormStartPosition.Manual;
            gameWin.Location = this.Location;

            this.Hide();
            gameWin.ShowDialog();
            this.Show();
        }

        private void updatePlayerList(List<string> players)
        {
            if (PlayersList.Items.Count > 1)
            {
                List<object> items = PlayersList.Items.Cast<object>().ToList();
                items.RemoveRange(1, items.Count - 1);
                PlayersList.Items.Clear();
                PlayersList.Items.AddRange(items.ToArray());
            }

            PlayersList.Items.AddRange(players.ToArray());
        }
        #endregion

        #region tabelOfRooms
        private void displayRooms()
        {
            while (m_checkingForRooms)
            {
                m_client.SendData(Serialization.serialize("", (int)ResponseCode.getRooms));
                if (Serialization.deserialize(m_client.reciveData()) is GetRoomsResponse roomsData)
                {
                    if (roomsData.status == 1)
                    {
                        // Invoke the control's method to access it from the UI thread
                        RoomsDisplay.Invoke(new Action(() =>
                        {
                            // Update the control's DataSource property
                            RoomsDisplay.DataSource = roomsData.rooms;
                        }));
                    }
                    else
                    {
                        throw new Exception("Error with the get rooms");
                    }
                }
                Thread.Sleep(3000);
            }
        }

        private void RoomsDisplay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            creatorOrJoiner = false;
            if (!(e.RowIndex >= 0 && e.ColumnIndex >= 0))
            {
                return;
            }
            DataGridViewRow clickedRow = RoomsDisplay.Rows[e.RowIndex];
            DataGridViewCell idCell = clickedRow.Cells[1]; // getting the id

            if (idCell.Value != null && int.TryParse(idCell.Value.ToString(), out int id))
            {
                String json = JsonConvert.SerializeObject
                    (new
                    {
                        roomId = id,
                    });

                m_client.SendData(Serialization.serialize(json, (int)ResponseCode.joinRoom));
                if(Serialization.deserialize(m_client.reciveData()) is JoinRoomResponse res)
                {
                    if(res.status == 1)
                    {
                        setPanelsToInvisible();
                        showPlayersInRoom.Visible = true;
                        showPlayersInRoom.BringToFront();

                        m_checkingForNewPlayers = true;
                        refreshPlayers(id);
                    }
                }

            }
            
        }
        #endregion

        #region design
        private void setPanelsToInvisible()
        { 
           joinRoomPanel.Visible = false;
           startingPanel.Visible = false;
           createRoomPanel.Visible = false;
           statisticPanel.Visible = false;
           showPlayersInRoom.Visible = false;
           personalStatsPanel.Visible = false;
        }
        /// <summary>
        /// formatting the table of all of that is being sent to color theme of the mainMenu
        /// </summary>
        /// <param name="dataGrid"></param>
        private void formatTable(DataGridView dataGrid)
        {
            dataGrid.ReadOnly = true;
            dataGrid.RowHeadersVisible = false;

            // Set the background color
            dataGrid.BackgroundColor = Color.FromArgb(46, 51, 73);

            // Set the font and foreground color of the cells
            dataGrid.DefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            dataGrid.DefaultCellStyle.ForeColor = Color.FromArgb(0, 128, 249);

            // Customize the appearance of the header cells
            dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(46, 51, 73);

            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;

            // Handle the CellFormatting event to customize the appearance of individual cells
            dataGrid.CellFormatting += (sender, e) =>
            {
                if (e.ColumnIndex == 0)
                {
                    // Customize the appearance of cells in a specific column
                    e.CellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
                    e.CellStyle.ForeColor = Color.DarkBlue;
                }
            };
        }
        private void formatList(ListBox list, String title)
        {
            list.BackColor = Color.FromArgb(46, 51, 73);
            list.ForeColor = Color.FromArgb(0, 128, 249);

            list.Font = new Font("Arial", 13, FontStyle.Regular);
            list.SelectionMode = SelectionMode.None;
            list.Padding = new Padding(5);
            list.ItemHeight = 30;

            list.Items.Add(title);
        }

        private void PlayersList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                e.DrawBackground();

                // Get the item
                object item = PlayersList.Items[e.Index];

                if (item is TitleItem titleItem)
                {
                    // For the title item, apply unique properties
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };

                    e.Graphics.DrawString(titleItem.Text, titleItem.Font, new SolidBrush(titleItem.ForeColor),
                        e.Bounds, sf);
                    e.Graphics.FillRectangle(new SolidBrush(titleItem.BackColor), e.Bounds);
                }
                else
                {
                    // For other items, use default properties
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };

                    e.Graphics.DrawString(item.ToString(), e.Font, new SolidBrush(e.ForeColor),
                        e.Bounds, sf);
                }

                e.DrawFocusRectangle();
            }
        }
        #endregion

        #region autoRefresh
        /// <summary>
        /// updating the display of the rooms in the joinRoom screen
        /// </summary>
        private void refreshRooms()
        {
            m_updateRoomsThread = new Thread(displayRooms);
            m_updateRoomsThread.IsBackground = true;
            
            m_updateRoomsThread.Start();
        }

        private void refreshPlayers(int id)
        {
            lockedSideBar = true;
            if (creatorOrJoiner)
            {
                close_leaveRoom.Text = "Close Room";
            }
            else
            {
                close_leaveRoom.Text = "Leave Room";
                this.startGame.Hide();
            }

            m_updatePlayers = new Thread(() => displayPlayersInRoom(id)); ;
            m_updatePlayers.IsBackground = true;

            m_updatePlayers.Start();
        }
        #endregion

        private void close_leaveRoom_Click(object sender, EventArgs e)
        {
            int responseCode = 0;
            if (creatorOrJoiner)
            {
                responseCode = (int)ResponseCode.closeRoom;
            }
            else
            {
                responseCode = (int)ResponseCode.leaveRoom;
            }

            m_client.SendData(Serialization.serialize("", responseCode));
            if (Serialization.deserialize(m_client.reciveData()) is LeaveRoomResponse res)
            {
                if (res.status == 1)
                {
                    setPanelsToInvisible();
                    startingPanel.Visible = true;
                    startingPanel.BringToFront();
                    m_checkingForNewPlayers = false;
                }
            }
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            m_client.SendData(Serialization.serialize("", (int)ResponseCode.startGame));

            if (Serialization.deserialize(m_client.reciveData()) is StartGameResponse createRoomResponse)
            {
                if (createRoomResponse.status != 0)
                {
                    switchGameView();
                }
            }

        }




        private String m_userName;
        private static ServerConnector m_client;
        
        private bool creatorOrJoiner = false;

        // updating the rooms that are displayed in the joinRoom screen:
        private static Thread m_updateRoomsThread;
        private static bool m_checkingForRooms = false;

        // updating the the users that are being shown inside when creating or joining room:
        private static Thread m_updatePlayers;
        private static bool m_checkingForNewPlayers = false;

        private static int s_adminConnection = 1;

        private uint questions = 0;
        private uint TimePerQuestions = 0;

        private bool lockedSideBar = false;
    }

    public class TitleItem
    {
        public string Text { get; set; }
        public Font Font { get; set; }
        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }

        public TitleItem(string text, Font font, Color foreColor, Color backColor)
        {
            Text = text;
            Font = font;
            ForeColor = foreColor;
            BackColor = backColor;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
