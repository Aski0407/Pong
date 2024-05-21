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
using Common;

namespace PongClient
{
    public partial class MainForm : Form
    {
        NetworkClient NetworkClient;
        private MyHttpClient client;
        int counter = 200;
        private bool GameStarted = false;
        private bool SentKeyDown = false;
        private bool isLogin = true; //changes to false if the user presses on register
        private string password;
        private string username;
        private int wins;
        private int losses;
        private UserStats userStats;

        enum tab
        {
            login = 0, game = 1, stats = 2
        }
        public MainForm()
        {
            InitializeComponent();
            RepeatPassword.Hide(); //defaults login
            RepeatPasswordLabel.Hide();
            Protocol class1 = new Protocol();
            tabs.SelectedIndex = (int)tab.login;
            gameTimer.Interval = 5;
            this.NetworkClient = new NetworkClient(System.Configuration.ConfigurationManager.AppSettings["IP"], int.Parse(System.Configuration.ConfigurationManager.AppSettings["Port"]));
            gameTimer.Enabled = true;
        }

        //LOGIN/REGISTER    
        private void LoginButton_Click(object sender, EventArgs e) //what happens when the user clicks the login button (top one)
        {
            //describes what happens when the user presses the login button. if its set to login, sends the username and password to be checked. if its set to register
            if (Username.Text == null || Password.Text == null)
            {
                MessageBox.Show("username or password cannot be blank");
                return;
            }
            if (!this.isLogin)
            {
                if (this.Password.Text != this.RepeatPassword.Text)
                {
                    MessageBox.Show("password have to be identical");
                    return;
                }
                else { this.client.Register(Username.Text, Password.Text); }

            }
            else
            {
                this.username = Username.Text;
                this.password = Password.Text;
                client.Login(this.username, this.password);
                tabs.SelectedIndex = (int)tab.stats;
            }

        }

        private void RegisterButton_Click(object sender, EventArgs e) //what happens when the user clicks the register button (bottom one)
        {
            if (this.isLogin)
            {
                this.isLogin = false;
                RepeatPassword.Show();
                RepeatPasswordLabel.Show();
                RegisterButton.Text = "Login";
                dontHaveAcc.Text = "Don't have an account?";
            }
            else
            {
                this.isLogin = true;
                LoginButton.Text = "Register";
                dontHaveAcc.Text = "Already have an account?";
            }

        }

        private void Username_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space); //makes sure spaces aren't registered
            e.Handled = (e.KeyChar == ','); //makes sure commas aren't registered (because of csv)
        }
        private void Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
            e.Handled = (e.KeyChar == ','); //makes sure commas aren't registered (because of csv)
        }
        private void RepeatPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
            e.Handled = (e.KeyChar == ','); //makes sure commas aren't registered (because of csv)
        }
        private void Password_TextChanged(object sender, EventArgs e)
        {
            this.FieldsValidation();
        }
        private void loginUsername_TextChanged(object sender, EventArgs e)
        {
            this.FieldsValidation();
        }

        private void RepeatPassword_TextChanged(object sender, EventArgs e)
        {
            this.FieldsValidation();
        }

        private void FieldsValidation() //checks if the login button should be enabled based on password parameters
        {
            LoginButton.Enabled = !(RepeatPassword.Visible && RepeatPassword.Text.Length < 8) && Username.Text.Length > 0 && Password.Text.Length > 0;
        }

        //GAME
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
                    countdownLabel.Text = counter.ToString();
                    counter--;
                    if (this.NetworkClient.QueueLength > 0) { Data frame = this.NetworkClient.NextFrame; frame = null; }
                    if (counter == 0)
                    {
                        countdownLabel.Visible = false;
                    }
                    return;
                }


                if (this.NetworkClient.QueueLength == 0)
                {
                    return;
                }

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


        //STATS
        private void statsButton_Click(object sender, EventArgs e)
        {
            ShowStats();
            winLabel.Visible = !winLabel.Visible;
            winText.Visible = !winText.Visible;
            lossesLabel.Visible = !lossesLabel.Visible;
            lossesText.Visible = !lossesText.Visible;
            ratioLabel.Visible = !ratioLabel.Visible;
            ratioText.Visible = !ratioText.Visible;
        }
        internal UserStats GetStruct(string message)
        {
            int wins = 0; int losses = 0;
            if (message != null)
            {
                string[] parts = message.Split('-');
                foreach (string part in parts)
                {
                    wins = part[0];
                    wins = part[1];
                }
            }
            return new UserStats(wins, losses);
        }


        internal async void ShowStats()
        {
            UserStats stats = GetStruct(await this.client.GetStats(this.username));

            winText.Text = stats.gamesWon.ToString();
            lossesText.Text = stats.gamesLost.ToString();
            ratioText.Text = winText.Text + "/" + lossesText.Text;
        }

        
    }
}
