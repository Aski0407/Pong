using Common;
using System.Configuration;

namespace PongClient
{
    public partial class MainForm : Form
    {
        NetworkClient NetworkClient;
        private MyHttpClient client = new MyHttpClient("http://" + ConfigurationManager.AppSettings["IP"] + ":8080/");
        private int counter = 5;
        private bool GameStarted = false;
        private bool SentKeyDown = false;
        private bool isLogin = true; //changes to false if the user presses on register
        private string username;
        private string password;

        enum Tab
        {
            login = 0, game = 1, stats = 2
        }

        public MainForm()
        {
            InitializeComponent();
            RepeatPassword.Hide(); //defaults login
            RepeatPasswordLabel.Hide();
            tabs.SelectedIndex = (int)Tab.login;
            gameTimer.Interval = 5;
            try
            {
                this.NetworkClient = new NetworkClient(ConfigurationManager.AppSettings["IP"], int.Parse(ConfigurationManager.AppSettings["TcpPort"]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            gameTimer.Enabled = false;
            countdownTimer.Enabled = false;
            this.KeyPreview = true;
        }

        //LOGIN/REGISTER    
        private async void LoginButton_Click(object sender, EventArgs e) //what happens when the user clicks the login button (top one)
        {
            username = Username.Text;
            password = Password.Text;
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
                    MessageBox.Show("passwords have to be identical");
                    return;
                }
                else
                {
                    try
                    {
                        await this.client.Register(this.username, this.password);
                        tabs.SelectedIndex = (int)Tab.stats;
                        NetworkClient.Send("username=" + username);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Registration failed, please try again\n" + ex.Message);
                    }
                }

            }
            else
            {

                try
                {
                    await client.Login(this.username, this.password);
                    tabs.SelectedIndex = (int)Tab.stats;
                    NetworkClient.Send("username=" + username);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Login failed, please try again\n" + ex.Message);
                }
            }

        }

        private void RegisterButton_Click(object sender, EventArgs e) //what happens when the user clicks the register button (bottom one)
        {
            if (this.isLogin)
            {
                this.isLogin = false;
                RepeatPassword.Show();
                RepeatPasswordLabel.Show();
                RegisterButton.Text = "LOGIN";
                LoginButton.Text = "REGISTER";
                dontHaveAcc.Text = "Don't have an account?";
            }
            else
            {
                this.isLogin = true;
                RepeatPassword.Hide();
                RepeatPasswordLabel.Hide();
                LoginButton.Text = "LOGIN";
                RegisterButton.Text = "REGISTER";
                dontHaveAcc.Text = "Already have an account?";
            }

        }
        private void Tabs_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(this.ActiveControl is TextBox))
            {
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                {
                    e.Handled = true;
                }
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
        private void Username_TextChanged(object sender, EventArgs e)
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

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (GameStarted)
            {
                waitingMsg.Visible = false;
                //before game starts, 5 second timer for both players
                if (counter > 0)
                {
                    countdownTimer.Enabled = true;
                    return;
                }
                if (this.NetworkClient.QueueLength == 0)
                {
                    return;
                }

                Data currentFrame = this.NetworkClient.NextFrame; //gets the Data 
                                                                  // this is the main timer event, this event will trigger every 5 milliseconds
                player1Score.Text = "" + currentFrame.Score1; // show player score on label 1
                player2Score.Text = "" + currentFrame.Score2; // show player score on label 2


                ball.Top = currentFrame.BallTop; // assign the ball TOP to ballTop from data
                ball.Left = currentFrame.BallLeft; // assign the ball LEFT to ballLeft from data

                player1.Top = currentFrame.Player1; //assigns the players top value to player1 (top) from data
                player2.Top = currentFrame.Player2; //assigns the players top value to player2 (top) from data

                // delayLabel.Text = "" + (DateTime.Now.Ticks - currentFrame.timeStamp.Ticks) / TimeSpan.TicksPerMillisecond; //shows the delay in milliseconds 
                queueLengthLabel.Text = "" + this.NetworkClient.QueueLength;
                intervalLabel.Text = "" + this.gameTimer.Interval;

                //game ends when one of the players has score of 10
                if (player1Score.Text == "10")
                {
                    gameTimer.Stop();
                    MessageBox.Show("player 1 won, player 2 lost");
                    tabs.SelectedIndex = (int)Tab.stats;
                }

                if (player2Score.Text == "10")
                {
                    gameTimer.Stop();
                    MessageBox.Show("player 2 won, player 1 lost");
                    tabs.SelectedIndex = (int)Tab.stats;
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
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (counter-- == 0)
            {
                countdownLabel.Visible = false;
                countdownTimer.Enabled = false;
            }
            while (this.NetworkClient.QueueLength > 0)
            {
                Data frame = this.NetworkClient.NextFrame;
            }
            countdownLabel.Text = counter.ToString();
        }
        private void ResetBoard()
        {
            while (this.NetworkClient.QueueLength > 0)
            {
                Data frame = this.NetworkClient.NextFrame;
            }
            GameStarted = false;
            player1Score.Text = "0";
            player2Score.Text = "0";
            player1.Top = 197;
            player2.Top = 197;
            ball.Top = 255;
            ball.Left = 493;
            counter = 5;
            waitingMsg.Visible = true;
            countdownLabel.Visible = true;
            countdownLabel.Text = "5";
        }

        //STATS

        internal UserStats GetStruct(string message)
        {
            int wins = 0; int losses = 0;
            if (message != null)
            {
                string[] parts = message.Split('-');
                wins = int.Parse(parts[0]);
                losses = int.Parse(parts[1]);
            }
            return new UserStats(wins, losses);
        }


        internal async void ShowStats()
        {
            string message = await this.client.GetStats(this.username);
            UserStats stats = GetStruct(message);
            winText.Text = stats.gamesWon.ToString();
            lossesText.Text = stats.gamesLost.ToString();
            ratioText.Text = winText.Text + "/" + lossesText.Text;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            tabs.SelectedIndex = (int)Tab.game;
            NetworkClient.Send("START");
            ResetBoard();
            gameTimer.Start();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            statsPanel.Visible = false;
        }

        private void StatsButton_Click(object sender, EventArgs e)
        {
            ShowStats();
            statsPanel.Visible = true;
        }


    }
}
