namespace sandboxGUI.GuiWindows
{
    partial class TriviaMenu : ResizableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TriviaMenu));
            this.startingPanel = new System.Windows.Forms.Panel();
            this.joinRoomPanel = new System.Windows.Forms.Panel();
            this.showPlayersInRoom = new System.Windows.Forms.Panel();
            this.startGame = new System.Windows.Forms.Button();
            this.close_leaveRoom = new System.Windows.Forms.Button();
            this.timePerQuestion = new System.Windows.Forms.Label();
            this.numOfQuestion = new System.Windows.Forms.Label();
            this.personalStatsPanel = new System.Windows.Forms.Panel();
            this.createRoomPanel = new System.Windows.Forms.Panel();
            this.statisticPanel = new System.Windows.Forms.Panel();
            this.HighScoresStats = new System.Windows.Forms.Button();
            this.personalStats = new System.Windows.Forms.Button();
            this.maxUsersBox = new System.Windows.Forms.TextBox();
            this.maxUsersCount = new System.Windows.Forms.Label();
            this.qustionCountAsker = new System.Windows.Forms.Label();
            this.questionsNumBox = new System.Windows.Forms.TextBox();
            this.answerTimeoutBox = new System.Windows.Forms.TextBox();
            this.answerTimeoutAsker = new System.Windows.Forms.Label();
            this.roomNameAsker = new System.Windows.Forms.Label();
            this.roomNameBox = new System.Windows.Forms.TextBox();
            this.createRoomInServerButton = new System.Windows.Forms.Button();
            this.PlayersList = new System.Windows.Forms.ListBox();
            this.RoomsDisplay = new System.Windows.Forms.DataGridView();
            this.sideBarPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.createRoom = new System.Windows.Forms.Button();
            this.joinRoom = new System.Windows.Forms.Button();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.startingPanel.SuspendLayout();
            this.joinRoomPanel.SuspendLayout();
            this.showPlayersInRoom.SuspendLayout();
            this.personalStatsPanel.SuspendLayout();
            this.createRoomPanel.SuspendLayout();
            this.statisticPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomsDisplay)).BeginInit();
            this.sideBarPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // startingPanel
            // 
            this.startingPanel.Controls.Add(this.joinRoomPanel);
            this.startingPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.startingPanel.Location = new System.Drawing.Point(193, 0);
            this.startingPanel.Name = "startingPanel";
            this.startingPanel.Size = new System.Drawing.Size(607, 450);
            this.startingPanel.TabIndex = 2;
            // 
            // joinRoomPanel
            // 
            this.joinRoomPanel.Controls.Add(this.showPlayersInRoom);
            this.joinRoomPanel.Controls.Add(this.RoomsDisplay);
            this.joinRoomPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.joinRoomPanel.Location = new System.Drawing.Point(3, 0);
            this.joinRoomPanel.Name = "joinRoomPanel";
            this.joinRoomPanel.Size = new System.Drawing.Size(604, 450);
            this.joinRoomPanel.TabIndex = 3;
            // 
            // showPlayersInRoom
            // 
            this.showPlayersInRoom.Controls.Add(this.startGame);
            this.showPlayersInRoom.Controls.Add(this.close_leaveRoom);
            this.showPlayersInRoom.Controls.Add(this.timePerQuestion);
            this.showPlayersInRoom.Controls.Add(this.numOfQuestion);
            this.showPlayersInRoom.Controls.Add(this.personalStatsPanel);
            this.showPlayersInRoom.Controls.Add(this.PlayersList);
            this.showPlayersInRoom.Dock = System.Windows.Forms.DockStyle.Right;
            this.showPlayersInRoom.Location = new System.Drawing.Point(0, 0);
            this.showPlayersInRoom.Name = "showPlayersInRoom";
            this.showPlayersInRoom.Size = new System.Drawing.Size(604, 450);
            this.showPlayersInRoom.TabIndex = 5;
            // 
            // startGame
            // 
            this.startGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.startGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.startGame.Location = new System.Drawing.Point(293, 233);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(181, 66);
            this.startGame.TabIndex = 9;
            this.startGame.Text = "Start Game";
            this.startGame.UseVisualStyleBackColor = false;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // close_leaveRoom
            // 
            this.close_leaveRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.close_leaveRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.close_leaveRoom.Location = new System.Drawing.Point(293, 148);
            this.close_leaveRoom.Name = "close_leaveRoom";
            this.close_leaveRoom.Size = new System.Drawing.Size(181, 66);
            this.close_leaveRoom.TabIndex = 8;
            this.close_leaveRoom.Text = "close/Leave Room";
            this.close_leaveRoom.UseVisualStyleBackColor = false;
            this.close_leaveRoom.Click += new System.EventHandler(this.close_leaveRoom_Click);
            // 
            // timePerQuestion
            // 
            this.timePerQuestion.AutoSize = true;
            this.timePerQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.timePerQuestion.Location = new System.Drawing.Point(290, 67);
            this.timePerQuestion.Name = "timePerQuestion";
            this.timePerQuestion.Size = new System.Drawing.Size(111, 13);
            this.timePerQuestion.TabIndex = 3;
            this.timePerQuestion.Text = "the time per question: ";
            // 
            // numOfQuestion
            // 
            this.numOfQuestion.AutoSize = true;
            this.numOfQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.numOfQuestion.Location = new System.Drawing.Point(290, 26);
            this.numOfQuestion.Name = "numOfQuestion";
            this.numOfQuestion.Size = new System.Drawing.Size(88, 13);
            this.numOfQuestion.TabIndex = 2;
            this.numOfQuestion.Text = "num of question: ";
            // 
            // personalStatsPanel
            // 
            this.personalStatsPanel.Controls.Add(this.createRoomPanel);
            this.personalStatsPanel.Location = new System.Drawing.Point(-3, 1);
            this.personalStatsPanel.Name = "personalStatsPanel";
            this.personalStatsPanel.Size = new System.Drawing.Size(610, 445);
            this.personalStatsPanel.TabIndex = 1;
            // 
            // createRoomPanel
            // 
            this.createRoomPanel.Controls.Add(this.statisticPanel);
            this.createRoomPanel.Controls.Add(this.maxUsersBox);
            this.createRoomPanel.Controls.Add(this.maxUsersCount);
            this.createRoomPanel.Controls.Add(this.qustionCountAsker);
            this.createRoomPanel.Controls.Add(this.questionsNumBox);
            this.createRoomPanel.Controls.Add(this.answerTimeoutBox);
            this.createRoomPanel.Controls.Add(this.answerTimeoutAsker);
            this.createRoomPanel.Controls.Add(this.roomNameAsker);
            this.createRoomPanel.Controls.Add(this.roomNameBox);
            this.createRoomPanel.Controls.Add(this.createRoomInServerButton);
            this.createRoomPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.createRoomPanel.Location = new System.Drawing.Point(0, 0);
            this.createRoomPanel.Name = "createRoomPanel";
            this.createRoomPanel.Size = new System.Drawing.Size(610, 445);
            this.createRoomPanel.TabIndex = 3;
            // 
            // statisticPanel
            // 
            this.statisticPanel.Controls.Add(this.HighScoresStats);
            this.statisticPanel.Controls.Add(this.personalStats);
            this.statisticPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.statisticPanel.Location = new System.Drawing.Point(0, 0);
            this.statisticPanel.Name = "statisticPanel";
            this.statisticPanel.Size = new System.Drawing.Size(610, 445);
            this.statisticPanel.TabIndex = 4;
            // 
            // HighScoresStats
            // 
            this.HighScoresStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.HighScoresStats.Location = new System.Drawing.Point(15, 146);
            this.HighScoresStats.Name = "HighScoresStats";
            this.HighScoresStats.Size = new System.Drawing.Size(361, 119);
            this.HighScoresStats.TabIndex = 7;
            this.HighScoresStats.Text = "HIGH - SCORE";
            this.HighScoresStats.UseVisualStyleBackColor = false;
            // 
            // personalStats
            // 
            this.personalStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.personalStats.Location = new System.Drawing.Point(15, 13);
            this.personalStats.Name = "personalStats";
            this.personalStats.Size = new System.Drawing.Size(361, 119);
            this.personalStats.TabIndex = 6;
            this.personalStats.Text = "PERSONAL";
            this.personalStats.UseVisualStyleBackColor = false;
            // 
            // maxUsersBox
            // 
            this.maxUsersBox.AccessibleDescription = "enter the user name:";
            this.maxUsersBox.AccessibleName = "enter the user name:";
            this.maxUsersBox.Location = new System.Drawing.Point(18, 147);
            this.maxUsersBox.Name = "maxUsersBox";
            this.maxUsersBox.Size = new System.Drawing.Size(249, 20);
            this.maxUsersBox.TabIndex = 14;
            this.maxUsersBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maxUsersBox_KeyPress);
            // 
            // maxUsersCount
            // 
            this.maxUsersCount.AutoSize = true;
            this.maxUsersCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxUsersCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.maxUsersCount.Location = new System.Drawing.Point(15, 126);
            this.maxUsersCount.Name = "maxUsersCount";
            this.maxUsersCount.Size = new System.Drawing.Size(268, 17);
            this.maxUsersCount.TabIndex = 12;
            this.maxUsersCount.Text = "enter the max users in the room(min = 2):";
            // 
            // qustionCountAsker
            // 
            this.qustionCountAsker.AutoSize = true;
            this.qustionCountAsker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qustionCountAsker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.qustionCountAsker.Location = new System.Drawing.Point(15, 87);
            this.qustionCountAsker.Name = "qustionCountAsker";
            this.qustionCountAsker.Size = new System.Drawing.Size(269, 17);
            this.qustionCountAsker.TabIndex = 11;
            this.qustionCountAsker.Text = "enter the number of questions(max = 10):";
            // 
            // questionsNumBox
            // 
            this.questionsNumBox.AccessibleDescription = "enter the user name:";
            this.questionsNumBox.AccessibleName = "enter the user name:";
            this.questionsNumBox.Location = new System.Drawing.Point(18, 103);
            this.questionsNumBox.Name = "questionsNumBox";
            this.questionsNumBox.Size = new System.Drawing.Size(249, 20);
            this.questionsNumBox.TabIndex = 10;
            this.questionsNumBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.questionsNumBox_KeyPress);
            // 
            // answerTimeoutBox
            // 
            this.answerTimeoutBox.AccessibleDescription = "enter the user name:";
            this.answerTimeoutBox.AccessibleName = "enter the user name:";
            this.answerTimeoutBox.Location = new System.Drawing.Point(18, 64);
            this.answerTimeoutBox.Name = "answerTimeoutBox";
            this.answerTimeoutBox.Size = new System.Drawing.Size(249, 20);
            this.answerTimeoutBox.TabIndex = 9;
            this.answerTimeoutBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.answerTimeoutBox_KeyPress);
            // 
            // answerTimeoutAsker
            // 
            this.answerTimeoutAsker.AutoSize = true;
            this.answerTimeoutAsker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerTimeoutAsker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.answerTimeoutAsker.Location = new System.Drawing.Point(15, 48);
            this.answerTimeoutAsker.Name = "answerTimeoutAsker";
            this.answerTimeoutAsker.Size = new System.Drawing.Size(176, 17);
            this.answerTimeoutAsker.TabIndex = 8;
            this.answerTimeoutAsker.Text = "enter your answer timeout:";
            // 
            // roomNameAsker
            // 
            this.roomNameAsker.AutoSize = true;
            this.roomNameAsker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomNameAsker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.roomNameAsker.Location = new System.Drawing.Point(15, 9);
            this.roomNameAsker.Name = "roomNameAsker";
            this.roomNameAsker.Size = new System.Drawing.Size(184, 17);
            this.roomNameAsker.TabIndex = 7;
            this.roomNameAsker.Text = "enter the name of the room:";
            // 
            // roomNameBox
            // 
            this.roomNameBox.AccessibleDescription = "enter the user name:";
            this.roomNameBox.AccessibleName = "enter the user name:";
            this.roomNameBox.Location = new System.Drawing.Point(18, 25);
            this.roomNameBox.Name = "roomNameBox";
            this.roomNameBox.Size = new System.Drawing.Size(249, 20);
            this.roomNameBox.TabIndex = 6;
            this.roomNameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.roomNameBox_KeyPress);
            // 
            // createRoomInServerButton
            // 
            this.createRoomInServerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.createRoomInServerButton.Location = new System.Drawing.Point(18, 173);
            this.createRoomInServerButton.Name = "createRoomInServerButton";
            this.createRoomInServerButton.Size = new System.Drawing.Size(123, 54);
            this.createRoomInServerButton.TabIndex = 5;
            this.createRoomInServerButton.Text = "CREATE";
            this.createRoomInServerButton.UseVisualStyleBackColor = false;
            this.createRoomInServerButton.Click += new System.EventHandler(this.createRoomInServerButton_Click);
            // 
            // PlayersList
            // 
            this.PlayersList.FormattingEnabled = true;
            this.PlayersList.Location = new System.Drawing.Point(10, 1);
            this.PlayersList.Name = "PlayersList";
            this.PlayersList.Size = new System.Drawing.Size(253, 446);
            this.PlayersList.TabIndex = 0;
            // 
            // RoomsDisplay
            // 
            this.RoomsDisplay.AllowUserToOrderColumns = true;
            this.RoomsDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoomsDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoomsDisplay.Location = new System.Drawing.Point(0, 0);
            this.RoomsDisplay.Name = "RoomsDisplay";
            this.RoomsDisplay.Size = new System.Drawing.Size(604, 450);
            this.RoomsDisplay.TabIndex = 5;
            this.RoomsDisplay.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoomsDisplay_CellClick);
            // 
            // sideBarPanel
            // 
            this.sideBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.sideBarPanel.Controls.Add(this.panel2);
            this.sideBarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBarPanel.Location = new System.Drawing.Point(0, 0);
            this.sideBarPanel.Name = "sideBarPanel";
            this.sideBarPanel.Size = new System.Drawing.Size(187, 450);
            this.sideBarPanel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.createRoom);
            this.panel2.Controls.Add(this.joinRoom);
            this.panel2.Controls.Add(this.statisticsButton);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.exitButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(187, 450);
            this.panel2.TabIndex = 2;
            // 
            // createRoom
            // 
            this.createRoom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.createRoom.FlatAppearance.BorderSize = 0;
            this.createRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createRoom.Font = new System.Drawing.Font("Nirmala UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.createRoom.Image = ((System.Drawing.Image)(resources.GetObject("createRoom.Image")));
            this.createRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.createRoom.Location = new System.Drawing.Point(0, 182);
            this.createRoom.Name = "createRoom";
            this.createRoom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.createRoom.Size = new System.Drawing.Size(187, 67);
            this.createRoom.TabIndex = 6;
            this.createRoom.Text = "create room";
            this.createRoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createRoom.UseVisualStyleBackColor = true;
            this.createRoom.Click += new System.EventHandler(this.createRoom_Click);
            // 
            // joinRoom
            // 
            this.joinRoom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.joinRoom.FlatAppearance.BorderSize = 0;
            this.joinRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.joinRoom.Font = new System.Drawing.Font("Nirmala UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.joinRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.joinRoom.Image = ((System.Drawing.Image)(resources.GetObject("joinRoom.Image")));
            this.joinRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.joinRoom.Location = new System.Drawing.Point(0, 249);
            this.joinRoom.Name = "joinRoom";
            this.joinRoom.Size = new System.Drawing.Size(187, 67);
            this.joinRoom.TabIndex = 5;
            this.joinRoom.Text = "join room";
            this.joinRoom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.joinRoom.UseVisualStyleBackColor = true;
            this.joinRoom.Click += new System.EventHandler(this.joinRoom_Click);
            // 
            // statisticsButton
            // 
            this.statisticsButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statisticsButton.FlatAppearance.BorderSize = 0;
            this.statisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statisticsButton.Font = new System.Drawing.Font("Nirmala UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.statisticsButton.Image = ((System.Drawing.Image)(resources.GetObject("statisticsButton.Image")));
            this.statisticsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statisticsButton.Location = new System.Drawing.Point(0, 316);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(187, 67);
            this.statisticsButton.TabIndex = 4;
            this.statisticsButton.Text = "statistics";
            this.statisticsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.statisticsButton.UseVisualStyleBackColor = true;
            this.statisticsButton.Click += new System.EventHandler(this.statistics_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.usernameLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(187, 127);
            this.panel3.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(63, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(249)))));
            this.usernameLabel.Location = new System.Drawing.Point(34, 88);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(115, 25);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "username";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitButton
            // 
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Nirmala UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
            this.exitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitButton.Location = new System.Drawing.Point(0, 383);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(187, 67);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "exit";
            this.exitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // TriviaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startingPanel);
            this.Controls.Add(this.sideBarPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TriviaMenu";
            this.Text = "mainMenu";
            this.Load += new System.EventHandler(this.mainMenu_Load);
            this.startingPanel.ResumeLayout(false);
            this.joinRoomPanel.ResumeLayout(false);
            this.showPlayersInRoom.ResumeLayout(false);
            this.showPlayersInRoom.PerformLayout();
            this.personalStatsPanel.ResumeLayout(false);
            this.createRoomPanel.ResumeLayout(false);
            this.createRoomPanel.PerformLayout();
            this.statisticPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoomsDisplay)).EndInit();
            this.sideBarPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Panel sideBarPanel;
        private System.Windows.Forms.Panel startingPanel;
        private System.Windows.Forms.Panel createRoomPanel;
        protected System.Windows.Forms.TextBox answerTimeoutBox;
        protected System.Windows.Forms.Label answerTimeoutAsker;
        protected System.Windows.Forms.Label roomNameAsker;
        protected System.Windows.Forms.TextBox roomNameBox;
        protected System.Windows.Forms.Button createRoomInServerButton;
        protected System.Windows.Forms.Label maxUsersCount;
        protected System.Windows.Forms.Label qustionCountAsker;
        protected System.Windows.Forms.TextBox questionsNumBox;
        protected System.Windows.Forms.TextBox maxUsersBox;
        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Button createRoom;
        protected System.Windows.Forms.Button joinRoom;
        protected System.Windows.Forms.Button statisticsButton;
        protected System.Windows.Forms.Panel panel3;
        protected System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.Label usernameLabel;
        protected System.Windows.Forms.Button exitButton;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel joinRoomPanel;
        private System.Windows.Forms.Panel statisticPanel;
        private System.Windows.Forms.DataGridView RoomsDisplay;
        private System.Windows.Forms.Panel showPlayersInRoom;
        private System.Windows.Forms.ListBox PlayersList;
        protected System.Windows.Forms.Button HighScoresStats;
        protected System.Windows.Forms.Button personalStats;
        private System.Windows.Forms.Panel personalStatsPanel;
        private System.Windows.Forms.Label numOfQuestion;
        private System.Windows.Forms.Label timePerQuestion;
        protected System.Windows.Forms.Button close_leaveRoom;
        protected System.Windows.Forms.Button startGame;
    }
}