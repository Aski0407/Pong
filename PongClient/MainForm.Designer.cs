namespace PongClient
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            tabs = new TablessControl();
            tabPage1 = new TabPage();
            RepeatPasswordLabel = new Label();
            RepeatPassword = new TextBox();
            dontHaveAcc = new Label();
            PasswordLabel = new Label();
            UsernameLabel = new Label();
            Password = new TextBox();
            Username = new TextBox();
            RegisterButton = new Button();
            LoginButton = new Button();
            label1 = new Label();
            tabPage2 = new TabPage();
            player2 = new PictureBox();
            player1 = new PictureBox();
            queueLengthLabel = new Label();
            intervalLabel = new Label();
            delayLabel = new Label();
            waitingMsg = new Label();
            countdownLabel = new Label();
            player2Score = new Label();
            player1Score = new Label();
            ball = new PictureBox();
            tabPage3 = new TabPage();
            statsPanel = new Panel();
            ratioText = new Label();
            ratioLabel = new Label();
            lossesText = new Label();
            lossesLabel = new Label();
            winText = new Label();
            winLabel = new Label();
            statsButton = new Button();
            welcomeMessage = new Label();
            startButton = new Button();
            gameTimer = new System.Windows.Forms.Timer(components);
            timer1 = new System.Windows.Forms.Timer(components);
            tabs.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)player2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ball).BeginInit();
            tabPage3.SuspendLayout();
            statsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tabs
            // 
            tabs.Controls.Add(tabPage1);
            tabs.Controls.Add(tabPage2);
            tabs.Controls.Add(tabPage3);
            tabs.Dock = DockStyle.Fill;
            tabs.Location = new Point(0, 0);
            tabs.Name = "tabs";
            tabs.SelectedIndex = 0;
            tabs.Size = new Size(984, 561);
            tabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(RepeatPasswordLabel);
            tabPage1.Controls.Add(RepeatPassword);
            tabPage1.Controls.Add(dontHaveAcc);
            tabPage1.Controls.Add(PasswordLabel);
            tabPage1.Controls.Add(UsernameLabel);
            tabPage1.Controls.Add(Password);
            tabPage1.Controls.Add(Username);
            tabPage1.Controls.Add(RegisterButton);
            tabPage1.Controls.Add(LoginButton);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(976, 533);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // RepeatPasswordLabel
            // 
            RepeatPasswordLabel.AutoSize = true;
            RepeatPasswordLabel.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RepeatPasswordLabel.Location = new Point(379, 253);
            RepeatPasswordLabel.Name = "RepeatPasswordLabel";
            RepeatPasswordLabel.Size = new Size(113, 17);
            RepeatPasswordLabel.TabIndex = 39;
            RepeatPasswordLabel.Text = "Repeat password:";
            // 
            // RepeatPassword
            // 
            RepeatPassword.BackColor = Color.Silver;
            RepeatPassword.BorderStyle = BorderStyle.None;
            RepeatPassword.Location = new Point(379, 273);
            RepeatPassword.Name = "RepeatPassword";
            RepeatPassword.PasswordChar = '*';
            RepeatPassword.Size = new Size(219, 16);
            RepeatPassword.TabIndex = 2;
            RepeatPassword.TextChanged += RepeatPassword_TextChanged;
            RepeatPassword.KeyPress += RepeatPassword_KeyPress;
            // 
            // dontHaveAcc
            // 
            dontHaveAcc.AutoSize = true;
            dontHaveAcc.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dontHaveAcc.Location = new Point(418, 441);
            dontHaveAcc.Name = "dontHaveAcc";
            dontHaveAcc.Size = new Size(143, 17);
            dontHaveAcc.TabIndex = 38;
            dontHaveAcc.Text = "Don't have an account?";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasswordLabel.Location = new Point(379, 192);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(67, 17);
            PasswordLabel.TabIndex = 37;
            PasswordLabel.Text = "Password:";
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UsernameLabel.ForeColor = Color.Black;
            UsernameLabel.Location = new Point(379, 125);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(70, 17);
            UsernameLabel.TabIndex = 36;
            UsernameLabel.Text = "Username:";
            // 
            // Password
            // 
            Password.BackColor = Color.Silver;
            Password.BorderStyle = BorderStyle.None;
            Password.Location = new Point(379, 212);
            Password.Name = "Password";
            Password.PasswordChar = '*';
            Password.Size = new Size(219, 16);
            Password.TabIndex = 1;
            Password.TextChanged += Password_TextChanged;
            Password.KeyPress += Password_KeyPress;
            // 
            // Username
            // 
            Username.BackColor = Color.Silver;
            Username.BorderStyle = BorderStyle.None;
            Username.Location = new Point(379, 146);
            Username.Name = "Username";
            Username.Size = new Size(219, 16);
            Username.TabIndex = 0;
            Username.TextChanged += loginUsername_TextChanged;
            Username.KeyPress += Username_KeyPress;
            // 
            // RegisterButton
            // 
            RegisterButton.BackColor = Color.FromArgb(116, 86, 174);
            RegisterButton.Cursor = Cursors.Hand;
            RegisterButton.FlatAppearance.BorderSize = 0;
            RegisterButton.FlatStyle = FlatStyle.Flat;
            RegisterButton.Font = new Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RegisterButton.ForeColor = Color.White;
            RegisterButton.Location = new Point(418, 461);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(138, 35);
            RegisterButton.TabIndex = 4;
            RegisterButton.Text = "REGISTER";
            RegisterButton.UseVisualStyleBackColor = false;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // LoginButton
            // 
            LoginButton.BackColor = Color.FromArgb(116, 86, 174);
            LoginButton.Cursor = Cursors.Hand;
            LoginButton.FlatAppearance.BorderSize = 0;
            LoginButton.FlatStyle = FlatStyle.Flat;
            LoginButton.Font = new Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginButton.ForeColor = Color.White;
            LoginButton.Location = new Point(418, 333);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(138, 35);
            LoginButton.TabIndex = 3;
            LoginButton.Text = "LOGIN";
            LoginButton.UseVisualStyleBackColor = false;
            LoginButton.Click += LoginButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Yu Gothic UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(116, 86, 174);
            label1.Location = new Point(379, 37);
            label1.Name = "label1";
            label1.Size = new Size(164, 40);
            label1.TabIndex = 30;
            label1.Text = "Get Started";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Black;
            tabPage2.Controls.Add(player2);
            tabPage2.Controls.Add(player1);
            tabPage2.Controls.Add(queueLengthLabel);
            tabPage2.Controls.Add(intervalLabel);
            tabPage2.Controls.Add(delayLabel);
            tabPage2.Controls.Add(waitingMsg);
            tabPage2.Controls.Add(countdownLabel);
            tabPage2.Controls.Add(player2Score);
            tabPage2.Controls.Add(player1Score);
            tabPage2.Controls.Add(ball);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(976, 533);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            // 
            // player2
            // 
            player2.BackColor = Color.Plum;
            player2.Location = new Point(1, 197);
            player2.Name = "player2";
            player2.Size = new Size(15, 100);
            player2.TabIndex = 13;
            player2.TabStop = false;
            // 
            // player1
            // 
            player1.BackColor = SystemColors.Desktop;
            player1.Location = new Point(961, 197);
            player1.Name = "player1";
            player1.Size = new Size(15, 100);
            player1.TabIndex = 1;
            player1.TabStop = false;
            // 
            // queueLengthLabel
            // 
            queueLengthLabel.AutoSize = true;
            queueLengthLabel.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            queueLengthLabel.ForeColor = Color.DarkViolet;
            queueLengthLabel.Location = new Point(939, 25);
            queueLengthLabel.Name = "queueLengthLabel";
            queueLengthLabel.Size = new Size(22, 25);
            queueLengthLabel.TabIndex = 21;
            queueLengthLabel.Text = "0";
            // 
            // intervalLabel
            // 
            intervalLabel.AutoSize = true;
            intervalLabel.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            intervalLabel.ForeColor = Color.ForestGreen;
            intervalLabel.Location = new Point(44, 25);
            intervalLabel.Name = "intervalLabel";
            intervalLabel.Size = new Size(22, 25);
            intervalLabel.TabIndex = 20;
            intervalLabel.Text = "0";
            // 
            // delayLabel
            // 
            delayLabel.AutoSize = true;
            delayLabel.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            delayLabel.ForeColor = Color.White;
            delayLabel.Location = new Point(465, 15);
            delayLabel.Name = "delayLabel";
            delayLabel.Size = new Size(32, 37);
            delayLabel.TabIndex = 19;
            delayLabel.Text = "0";
            // 
            // waitingMsg
            // 
            waitingMsg.AutoSize = true;
            waitingMsg.Font = new Font("Yu Gothic UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            waitingMsg.ForeColor = Color.White;
            waitingMsg.Location = new Point(3, 231);
            waitingMsg.Name = "waitingMsg";
            waitingMsg.Size = new Size(961, 86);
            waitingMsg.TabIndex = 18;
            waitingMsg.Text = "Waiting for player 2 to connect...";
            // 
            // countdownLabel
            // 
            countdownLabel.AutoSize = true;
            countdownLabel.Font = new Font("Yu Gothic UI", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            countdownLabel.ForeColor = Color.White;
            countdownLabel.Location = new Point(433, 197);
            countdownLabel.Name = "countdownLabel";
            countdownLabel.Size = new Size(106, 128);
            countdownLabel.TabIndex = 17;
            countdownLabel.Text = "5";
            // 
            // player2Score
            // 
            player2Score.AutoSize = true;
            player2Score.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            player2Score.ForeColor = Color.Magenta;
            player2Score.Location = new Point(274, 25);
            player2Score.Name = "player2Score";
            player2Score.Size = new Size(25, 30);
            player2Score.TabIndex = 16;
            player2Score.Text = "0";
            // 
            // player1Score
            // 
            player1Score.AutoSize = true;
            player1Score.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            player1Score.ForeColor = Color.Blue;
            player1Score.Location = new Point(663, 25);
            player1Score.Name = "player1Score";
            player1Score.Size = new Size(25, 30);
            player1Score.TabIndex = 15;
            player1Score.Text = "0";
            // 
            // ball
            // 
            ball.BackColor = Color.White;
            ball.Location = new Point(493, 255);
            ball.Name = "ball";
            ball.Size = new Size(15, 15);
            ball.TabIndex = 14;
            ball.TabStop = false;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(statsPanel);
            tabPage3.Controls.Add(statsButton);
            tabPage3.Controls.Add(welcomeMessage);
            tabPage3.Controls.Add(startButton);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(976, 533);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // statsPanel
            // 
            statsPanel.Controls.Add(ratioText);
            statsPanel.Controls.Add(ratioLabel);
            statsPanel.Controls.Add(lossesText);
            statsPanel.Controls.Add(lossesLabel);
            statsPanel.Controls.Add(winText);
            statsPanel.Controls.Add(winLabel);
            statsPanel.Location = new Point(776, 3);
            statsPanel.Name = "statsPanel";
            statsPanel.Size = new Size(200, 530);
            statsPanel.TabIndex = 6;
            statsPanel.Visible = false;
            // 
            // ratioText
            // 
            ratioText.AutoSize = true;
            ratioText.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ratioText.Location = new Point(81, 371);
            ratioText.Name = "ratioText";
            ratioText.Size = new Size(43, 21);
            ratioText.TabIndex = 7;
            ratioText.Text = "0 / 0";
            ratioText.Visible = false;
            // 
            // ratioLabel
            // 
            ratioLabel.AutoSize = true;
            ratioLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ratioLabel.Location = new Point(40, 327);
            ratioLabel.Name = "ratioLabel";
            ratioLabel.Size = new Size(132, 21);
            ratioLabel.TabIndex = 8;
            ratioLabel.Text = "Win to loss ratio:";
            ratioLabel.Visible = false;
            // 
            // lossesText
            // 
            lossesText.AutoSize = true;
            lossesText.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lossesText.Location = new Point(92, 240);
            lossesText.Name = "lossesText";
            lossesText.Size = new Size(19, 21);
            lossesText.TabIndex = 9;
            lossesText.Text = "0";
            lossesText.Visible = false;
            // 
            // lossesLabel
            // 
            lossesLabel.AutoSize = true;
            lossesLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lossesLabel.Location = new Point(40, 195);
            lossesLabel.Name = "lossesLabel";
            lossesLabel.Size = new Size(142, 21);
            lossesLabel.TabIndex = 10;
            lossesLabel.Text = "Number of losses:";
            lossesLabel.Visible = false;
            // 
            // winText
            // 
            winText.AutoSize = true;
            winText.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            winText.Location = new Point(92, 125);
            winText.Name = "winText";
            winText.Size = new Size(19, 21);
            winText.TabIndex = 11;
            winText.Text = "0";
            winText.Visible = false;
            // 
            // winLabel
            // 
            winLabel.AutoSize = true;
            winLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            winLabel.Location = new Point(40, 92);
            winLabel.Name = "winLabel";
            winLabel.Size = new Size(130, 21);
            winLabel.TabIndex = 0;
            winLabel.Text = "Number of wins:";
            winLabel.Visible = false;
            // 
            // statsButton
            // 
            statsButton.ForeColor = Color.Black;
            statsButton.Location = new Point(424, 300);
            statsButton.Name = "statsButton";
            statsButton.Size = new Size(75, 23);
            statsButton.TabIndex = 5;
            statsButton.Text = "view stats";
            statsButton.UseVisualStyleBackColor = true;
            statsButton.Click += statsButton_Click;
            // 
            // welcomeMessage
            // 
            welcomeMessage.AutoSize = true;
            welcomeMessage.Font = new Font("Yu Gothic UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            welcomeMessage.ForeColor = Color.Black;
            welcomeMessage.Location = new Point(326, 198);
            welcomeMessage.Name = "welcomeMessage";
            welcomeMessage.Size = new Size(291, 40);
            welcomeMessage.TabIndex = 4;
            welcomeMessage.Text = "WELCOME TO PONG";
            // 
            // startButton
            // 
            startButton.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            startButton.ForeColor = SystemColors.ControlText;
            startButton.Location = new Point(372, 241);
            startButton.Name = "startButton";
            startButton.Size = new Size(178, 53);
            startButton.TabIndex = 3;
            startButton.Text = "start game";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 1000;
            gameTimer.Tick += timerTick;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(tabs);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "MainForm";
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
            tabs.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)player2).EndInit();
            ((System.ComponentModel.ISupportInitialize)player1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ball).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            statsPanel.ResumeLayout(false);
            statsPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TablessControl tabs;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private PictureBox ball;
        private PictureBox player2;
        private PictureBox player1;
        private Label queueLengthLabel;
        private Label intervalLabel;
        private Label delayLabel;
        private Label waitingMsg;
        private Label countdownLabel;
        private Label player2Score;
        private Label player1Score;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer timer1;
        private Label RepeatPasswordLabel;
        private TextBox RepeatPassword;
        private Label dontHaveAcc;
        private Label PasswordLabel;
        private Label UsernameLabel;
        private TextBox Password;
        private TextBox Username;
        private Button RegisterButton;
        private Button LoginButton;
        private Label label1;
        private TabPage tabPage3;
        private Button statsButton;
        private Label welcomeMessage;
        private Button startButton;
        private Label lossesLabel;
        private Label lossesText;
        private Label ratioLabel;
        private Label ratioText;
        private Panel statsPanel;
        private Label winText;
        private Label winLabel;
    }
}