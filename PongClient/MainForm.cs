using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongClient
{
    public partial class MainForm : Form
    {
        NetworkClient NetworkClient;
        //private const int FasterRefreshRate = 15;
        //private const int EmptyQueueRefreshRate = 10;
        //private const int QueueLengthThreshold = 2;
        int counter = 250;
        private bool GameStarted = false;
        private bool SentKeyDown = false;

        public MainForm()
        {
            InitializeComponent();
            Protocol class1 = new Protocol();
            gameTimer.Interval = 5;
            this.NetworkClient = new NetworkClient(System.Configuration.ConfigurationManager.AppSettings["IP"], int.Parse(System.Configuration.ConfigurationManager.AppSettings["Port"]));
            gameTimer.Enabled = true;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // if player leaves the up key
                // send command None
                NetworkClient.Send("NONE");
                SentKeyDown = false;

            }

        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (SentKeyDown)
            {
                return;
            }
            if (e.KeyCode == Keys.Up)
            {
                // if player presses the up key
                // send command Up
                NetworkClient.Send("UP");
                SentKeyDown = true;

            }
            if (e.KeyCode == Keys.Down)
            {
                // if player presses the down key
                // send command Down
                NetworkClient.Send("DOWN");
                SentKeyDown = true;

            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (GameStarted)
            {
                waitingMsg.Visible = false;
                //before game starts, 5 second timer for both players
                if (counter > 0)
                {
                    countdownLabel.Text = (counter / 5).ToString();
                    counter--;
                    if (this.NetworkClient.QueueLength > 0) { Data frame = this.NetworkClient.NextFrame; frame = null; }
                    if (counter == 0)
                    {
                        countdownLabel.Visible = false;
                    }
                    return;
                }
                //return interval to normal game interval
                //this.gameTimer.Interval = 30;

                if (this.NetworkClient.QueueLength == 0)
                {
                    //this.gameTimer.Interval = EmptyQueueRefreshRate;
                    return;
                }
                /* if (this.NetworkClient.QueueLength > QueueLengthThreshold)
                 {
                     this.gameTimer.Interval = FasterRefreshRate;
                 }
                 else
                 {
                     this.gameTimer.Interval = Protocol.RefreshRate;
                 }
                */
                Data currentFrame = this.NetworkClient.NextFrame; //gets the Data 
                                                                  // this is the main timer event, this event will trigger every 40 milliseconds
                player1Score.Text = "" + currentFrame.Score1; // show player score on label 1
                player2Score.Text = "" + currentFrame.Score2; // show player score on label 2


                ball.Top = currentFrame.BallTop; // assign the ball TOP to ballTop from data
                ball.Left = currentFrame.BallLeft; // assign the ball LEFT to ballLeft from data

                player1.Top = currentFrame.Player1; //assigns the players top value to player1 (top) from data
                player2.Top = currentFrame.Player2; //assigns the players top value to player2 (top) from data

                delayLabel.Text = "" + (DateTime.Now.Ticks - currentFrame.timeStamp.Ticks) / TimeSpan.TicksPerMillisecond; //shows the delay in milliseconds 
                queueLengthLabel.Text = "" + this.NetworkClient.QueueLength;
                intervalLabel.Text = "" + this.gameTimer.Interval;

                //game ends when one of the players has score of 10
                if (currentFrame.Score1 == 10)
                {
                    gameTimer.Stop();
                    MessageBox.Show("player1 wins, player2 lost");
                }

                if (currentFrame.Score2 == 10)
                {
                    gameTimer.Stop();
                    MessageBox.Show("player2 wins, player1 lost");
                }
            }
            else
            {
                if (this.NetworkClient.QueueLength > 0)
                {
                    GameStarted = true;
                }
            }
        }
    }
}
