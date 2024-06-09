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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            gameTimer = new System.Windows.Forms.Timer(components);
            timer1 = new System.Windows.Forms.Timer(components);
            tabPage3 = new TabPage();
            statsButton = new Button();
            statsPanel = new Panel();
            closeButton = new Button();
            lossesLabel = new Label();
            ratioText = new Label();
            winLabel = new Label();
            ratioLabel = new Label();
            winText = new Label();
            lossesText = new Label();
            welcomeMessage = new Label();
            startButton = new Button();
            tabPage2 = new TabPage();
            panel1 = new Panel();
            player1 = new PictureBox();
            waitingMsg = new Label();
            player2 = new PictureBox();
            countdownLabel = new Label();
            player2Score = new Label();
            player1Score = new Label();
            ball = new PictureBox();
            tabPage1 = new TabPage();
            Username = new TextBox();
            Password = new TextBox();
            RepeatPasswordLabel = new Label();
            RepeatPassword = new TextBox();
            dontHaveAcc = new Label();
            PasswordLabel = new Label();
            UsernameLabel = new Label();
            RegisterButton = new Button();
            LoginButton = new Button();
            label1 = new Label();
            tabs = new TablessControl();
            countdownTimer = new System.Windows.Forms.Timer(components);
            tabPage3.SuspendLayout();
            statsPanel.SuspendLayout();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)player1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ball).BeginInit();
            tabPage1.SuspendLayout();
            tabs.SuspendLayout();
            SuspendLayout();
            // 
            // gameTimer
            // 
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            // 
            // tabPage3
            // 
            tabPage3.BackgroundImage = (Image)resources.GetObject("tabPage3.BackgroundImage");
            tabPage3.Controls.Add(statsButton);
            tabPage3.Controls.Add(statsPanel);
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
            // statsButton
            // 
            statsButton.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            statsButton.Location = new Point(372, 336);
            statsButton.Name = "statsButton";
            statsButton.Size = new Size(178, 53);
            statsButton.TabIndex = 13;
            statsButton.Text = "view stats";
            statsButton.UseVisualStyleBackColor = true;
            statsButton.Click += StatsButton_Click;
            // 
            // statsPanel
            // 
            statsPanel.Controls.Add(closeButton);
            statsPanel.Controls.Add(lossesLabel);
            statsPanel.Controls.Add(ratioText);
            statsPanel.Controls.Add(winLabel);
            statsPanel.Controls.Add(ratioLabel);
            statsPanel.Controls.Add(winText);
            statsPanel.Controls.Add(lossesText);
            statsPanel.Dock = DockStyle.Right;
            statsPanel.Location = new Point(773, 3);
            statsPanel.Name = "statsPanel";
            statsPanel.Size = new Size(200, 527);
            statsPanel.TabIndex = 12;
            statsPanel.Visible = false;
            // 
            // closeButton
            // 
            closeButton.Image = (Image)resources.GetObject("closeButton.Image");
            closeButton.Location = new Point(10, 9);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(22, 22);
            closeButton.TabIndex = 12;
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += CloseButton_Click;
            // 
            // lossesLabel
            // 
            lossesLabel.AutoSize = true;
            lossesLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lossesLabel.ForeColor = Color.FromArgb(64, 0, 64);
            lossesLabel.Location = new Point(37, 214);
            lossesLabel.Name = "lossesLabel";
            lossesLabel.Size = new Size(142, 21);
            lossesLabel.TabIndex = 10;
            lossesLabel.Text = "Number of losses:";
            // 
            // ratioText
            // 
            ratioText.AutoSize = true;
            ratioText.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ratioText.ForeColor = Color.FromArgb(64, 0, 64);
            ratioText.Location = new Point(78, 409);
            ratioText.Name = "ratioText";
            ratioText.Size = new Size(43, 21);
            ratioText.TabIndex = 7;
            ratioText.Text = "0 / 0";
            // 
            // winLabel
            // 
            winLabel.AutoSize = true;
            winLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            winLabel.ForeColor = Color.FromArgb(64, 0, 64);
            winLabel.Location = new Point(37, 73);
            winLabel.Name = "winLabel";
            winLabel.Size = new Size(130, 21);
            winLabel.TabIndex = 0;
            winLabel.Text = "Number of wins:";
            // 
            // ratioLabel
            // 
            ratioLabel.AutoSize = true;
            ratioLabel.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ratioLabel.ForeColor = Color.FromArgb(64, 0, 64);
            ratioLabel.Location = new Point(37, 365);
            ratioLabel.Name = "ratioLabel";
            ratioLabel.Size = new Size(132, 21);
            ratioLabel.TabIndex = 8;
            ratioLabel.Text = "Win to loss ratio:";
            // 
            // winText
            // 
            winText.AutoSize = true;
            winText.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            winText.ForeColor = Color.FromArgb(64, 0, 64);
            winText.Location = new Point(89, 106);
            winText.Name = "winText";
            winText.Size = new Size(19, 21);
            winText.TabIndex = 11;
            winText.Text = "0";
            // 
            // lossesText
            // 
            lossesText.AutoSize = true;
            lossesText.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lossesText.ForeColor = Color.FromArgb(64, 0, 64);
            lossesText.Location = new Point(89, 252);
            lossesText.Name = "lossesText";
            lossesText.Size = new Size(19, 21);
            lossesText.TabIndex = 9;
            lossesText.Text = "0";
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
            startButton.Click += StartButton_Click;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Black;
            tabPage2.Controls.Add(panel1);
            tabPage2.Controls.Add(waitingMsg);
            tabPage2.Controls.Add(player2);
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
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(player1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(957, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(16, 527);
            panel1.TabIndex = 23;
            // 
            // player1
            // 
            player1.BackColor = Color.SlateBlue;
            player1.Location = new Point(0, 194);
            player1.Name = "player1";
            player1.Size = new Size(15, 100);
            player1.TabIndex = 1;
            player1.TabStop = false;
            // 
            // waitingMsg
            // 
            waitingMsg.AutoSize = true;
            waitingMsg.BackColor = Color.Black;
            waitingMsg.Font = new Font("Yu Gothic UI", 47F, FontStyle.Regular, GraphicsUnit.Point, 0);
            waitingMsg.ForeColor = Color.DarkMagenta;
            waitingMsg.Location = new Point(22, 221);
            waitingMsg.Name = "waitingMsg";
            waitingMsg.Size = new Size(938, 85);
            waitingMsg.TabIndex = 22;
            waitingMsg.Text = "Waiting for player 2 to connect...";
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
            player2Score.ForeColor = Color.Plum;
            player2Score.Location = new Point(93, 39);
            player2Score.Name = "player2Score";
            player2Score.Size = new Size(25, 30);
            player2Score.TabIndex = 16;
            player2Score.Text = "0";
            // 
            // player1Score
            // 
            player1Score.AutoSize = true;
            player1Score.BackColor = Color.Black;
            player1Score.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            player1Score.ForeColor = Color.SlateBlue;
            player1Score.Location = new Point(860, 39);
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
            // tabPage1
            // 
            tabPage1.BackgroundImage = (Image)resources.GetObject("tabPage1.BackgroundImage");
            tabPage1.Controls.Add(Username);
            tabPage1.Controls.Add(Password);
            tabPage1.Controls.Add(RepeatPasswordLabel);
            tabPage1.Controls.Add(RepeatPassword);
            tabPage1.Controls.Add(dontHaveAcc);
            tabPage1.Controls.Add(PasswordLabel);
            tabPage1.Controls.Add(UsernameLabel);
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
            // Username
            // 
            Username.BackColor = Color.White;
            Username.BorderStyle = BorderStyle.None;
            Username.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Username.Location = new Point(379, 145);
            Username.Name = "Username";
            Username.Size = new Size(219, 16);
            Username.TabIndex = 0;
            Username.TextChanged += Username_TextChanged;
            Username.KeyPress += Username_KeyPress;
            // 
            // Password
            // 
            Password.BackColor = Color.White;
            Password.BorderStyle = BorderStyle.None;
            Password.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Password.Location = new Point(379, 212);
            Password.Name = "Password";
            Password.PasswordChar = '*';
            Password.Size = new Size(219, 16);
            Password.TabIndex = 1;
            Password.TextChanged += Password_TextChanged;
            Password.KeyPress += Password_KeyPress;
            // 
            // RepeatPasswordLabel
            // 
            RepeatPasswordLabel.AutoSize = true;
            RepeatPasswordLabel.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Bold);
            RepeatPasswordLabel.Location = new Point(379, 253);
            RepeatPasswordLabel.Name = "RepeatPasswordLabel";
            RepeatPasswordLabel.Size = new Size(98, 13);
            RepeatPasswordLabel.TabIndex = 39;
            RepeatPasswordLabel.Text = "Repeat password:";
            // 
            // RepeatPassword
            // 
            RepeatPassword.BackColor = Color.White;
            RepeatPassword.BorderStyle = BorderStyle.None;
            RepeatPassword.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            PasswordLabel.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Bold);
            PasswordLabel.Location = new Point(379, 192);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(58, 13);
            PasswordLabel.TabIndex = 37;
            PasswordLabel.Text = "Password:";
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Bold);
            UsernameLabel.ForeColor = Color.Black;
            UsernameLabel.Location = new Point(379, 125);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(61, 13);
            UsernameLabel.TabIndex = 36;
            UsernameLabel.Text = "Username:";
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
            tabs.KeyDown += Tabs_KeyDown;
            // 
            // countdownTimer
            // 
            countdownTimer.Enabled = true;
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += CountdownTimer_Tick;
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
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            statsPanel.ResumeLayout(false);
            statsPanel.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)player1).EndInit();
            ((System.ComponentModel.ISupportInitialize)player2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ball).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabs.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer timer1;
        private TabPage tabPage3;
        private Label ratioText;
        private Label ratioLabel;
        private Label lossesText;
        private Label lossesLabel;
        private Label winText;
        private Label winLabel;
        private Label welcomeMessage;
        private Button startButton;
        private TabPage tabPage2;
        private PictureBox player2;
        private PictureBox player1;
        private Label countdownLabel;
        private Label player2Score;
        private Label player1Score;
        private PictureBox ball;
        private TabPage tabPage1;
        private Label RepeatPasswordLabel;
        private TextBox RepeatPassword;
        private Label dontHaveAcc;
        private Label PasswordLabel;
        private Label UsernameLabel;
        private Button RegisterButton;
        private Button LoginButton;
        private Label label1;
        private TablessControl tabs;
        private Label waitingMsg;
        private TextBox Password;
        private TextBox Username;
        private Button statsButton;
        private Panel statsPanel;
        private Button closeButton;
        private System.Windows.Forms.Timer countdownTimer;
        private Panel panel1;
    }
}