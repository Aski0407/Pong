namespace PongClient
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            player1 = new PictureBox();
            player2 = new PictureBox();
            ball = new PictureBox();
            gameTimer = new System.Windows.Forms.Timer(components);
            player1Score = new Label();
            player2Score = new Label();
            countdownLabel = new Label();
            waitingMsg = new Label();
            delayLabel = new Label();
            intervalLabel = new Label();
            queueLengthLabel = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)player1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ball).BeginInit();
            SuspendLayout();
            // 
            // player1
            // 
            player1.BackColor = SystemColors.Desktop;
            player1.Location = new Point(966, 197);
            player1.Name = "player1";
            player1.Size = new Size(15, 100);
            player1.TabIndex = 1;
            player1.TabStop = false;
            // 
            // player2
            // 
            player2.BackColor = Color.Plum;
            player2.Location = new Point(1, 197);
            player2.Name = "player2";
            player2.Size = new Size(15, 100);
            player2.TabIndex = 2;
            player2.TabStop = false;
            player2.Click += player2_Click;
            // 
            // ball
            // 
            ball.BackColor = Color.White;
            ball.Location = new Point(493, 255);
            ball.Name = "ball";
            ball.Size = new Size(15, 15);
            ball.TabIndex = 3;
            ball.TabStop = false;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 1000;
            gameTimer.Tick += timerTick;
            // 
            // player1Score
            // 
            player1Score.AutoSize = true;
            player1Score.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            player1Score.ForeColor = Color.Blue;
            player1Score.Location = new Point(663, 25);
            player1Score.Name = "player1Score";
            player1Score.Size = new Size(25, 30);
            player1Score.TabIndex = 4;
            player1Score.Text = "0";
            // 
            // player2Score
            // 
            player2Score.AutoSize = true;
            player2Score.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            player2Score.ForeColor = Color.Magenta;
            player2Score.Location = new Point(274, 25);
            player2Score.Name = "player2Score";
            player2Score.Size = new Size(25, 30);
            player2Score.TabIndex = 5;
            player2Score.Text = "0";
            // 
            // countdownLabel
            // 
            countdownLabel.AutoSize = true;
            countdownLabel.Font = new Font("Yu Gothic UI", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            countdownLabel.ForeColor = Color.White;
            countdownLabel.Location = new Point(433, 197);
            countdownLabel.Name = "countdownLabel";
            countdownLabel.Size = new Size(106, 128);
            countdownLabel.TabIndex = 7;
            countdownLabel.Text = "5";
            // 
            // waitingMsg
            // 
            waitingMsg.AutoSize = true;
            waitingMsg.Font = new Font("Yu Gothic UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            waitingMsg.ForeColor = Color.White;
            waitingMsg.Location = new Point(12, 231);
            waitingMsg.Name = "waitingMsg";
            waitingMsg.Size = new Size(961, 86);
            waitingMsg.TabIndex = 8;
            waitingMsg.Text = "Waiting for player 2 to connect...";
            // 
            // delayLabel
            // 
            delayLabel.AutoSize = true;
            delayLabel.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            delayLabel.ForeColor = Color.White;
            delayLabel.Location = new Point(465, 15);
            delayLabel.Name = "delayLabel";
            delayLabel.Size = new Size(32, 37);
            delayLabel.TabIndex = 9;
            delayLabel.Text = "0";
            // 
            // intervalLabel
            // 
            intervalLabel.AutoSize = true;
            intervalLabel.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            intervalLabel.ForeColor = Color.ForestGreen;
            intervalLabel.Location = new Point(44, 25);
            intervalLabel.Name = "intervalLabel";
            intervalLabel.Size = new Size(22, 25);
            intervalLabel.TabIndex = 10;
            intervalLabel.Text = "0";
            // 
            // queueLengthLabel
            // 
            queueLengthLabel.AutoSize = true;
            queueLengthLabel.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            queueLengthLabel.ForeColor = Color.DarkViolet;
            queueLengthLabel.Location = new Point(939, 25);
            queueLengthLabel.Name = "queueLengthLabel";
            queueLengthLabel.Size = new Size(22, 25);
            queueLengthLabel.TabIndex = 11;
            queueLengthLabel.Text = "0";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(984, 561);
            Controls.Add(queueLengthLabel);
            Controls.Add(intervalLabel);
            Controls.Add(delayLabel);
            Controls.Add(waitingMsg);
            Controls.Add(countdownLabel);
            Controls.Add(player2Score);
            Controls.Add(player1Score);
            Controls.Add(ball);
            Controls.Add(player2);
            Controls.Add(player1);
            ForeColor = SystemColors.ControlText;
            Name = "GameForm";
            Text = "PongGame";
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
            ((System.ComponentModel.ISupportInitialize)player1).EndInit();
            ((System.ComponentModel.ISupportInitialize)player2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ball).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox player1;
        private PictureBox player2;
        private PictureBox ball;
        private System.Windows.Forms.Timer gameTimer;
        private Label player1Score;
        private Label player2Score;
        private Label countdownLabel;
        private Label waitingMsg;
        private Label delayLabel;
        private Label intervalLabel;
        private Label queueLengthLabel;
        private System.Windows.Forms.Timer timer1;
    }
}
