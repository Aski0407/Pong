using Common;
using System;
using System.Configuration;
using System.Timers;

namespace PongHost
{
    internal class Game
    {
        private Field field;
        private bool debug = bool.Parse(ConfigurationManager.AppSettings["Debug"]);
        private bool pressedStart = false;
        private PongServer server;
        internal Player player1, player2;
        private Timer timer = new Timer(20);
        private string user1;
        private string user2;

        internal Game(PongServer server) //constructor. receives the server
        {
            this.server = server;
            // attach tick method to elapsed event
            timer.Elapsed += Tick;
        }

        public void AddPlayer(Player player) //assigns the value of the player and assigns the game property of the player.
        {
            if (player1 == null)
            {
                player1 = player;
                user1 = player.username;
            }
            else
            {
                player2 = player;
                user2 = player.username;
            }
            player.game = this;
        }


        private void StartGame() //creates a new field, sends the players the board along with the usernames and starts the timer
        {
            field = new Field();
            Data board = this.field.GetNextFrame();
            board.user1 = player1.username;
            board.user2 = player2.username;
            this.player1.Send(board);
            this.player2.Send(board);
            //enable timer
            timer.Enabled = true;
        }

        internal void TryStart() //tries to start the game. if one player pressed start, sets the boolean value to true. if its true starts the game (when the second player presses start)
        {
            if (debug)
            {
                StartGame();
            }
            else if (!pressedStart)
            {
                pressedStart = true;
            }
            else
            {
                pressedStart = false;
                StartGame();
            }
        }


        //happens every tick - 20 milliseconds 
        private void Tick(object sender, EventArgs e) //sends the board and checks the scores (if the game needs to end) then updates the scores of the players.
        {
            Data board = this.field.GetNextFrame();
            int score1 = board.Score1;
            int score2 = board.Score2;
            if (this.player1 != null && (this.player2 != null || debug))
            {
                this.player1.Send(board);
                if (this.player2 != null)
                {
                    this.player2.Send(board);
                }
            }
            else if (this.player1 == null || this.player2 == null)
            {
                ((Timer)sender).Stop();
                if (this.player1 == null)
                {
                    OnClientDisconnect(PlayerSide.One);
                    this.player2.Send(new Data(0, 0, 0, 0, 0, 0));
                    this.player2 = null;
                }
                else
                {
                    OnClientDisconnect(PlayerSide.Two);
                    this.player1.Send(new Data(0, 0, 0, 0, 0, 0));
                    this.player1 = null;
                }
            }
            if (score1 == 10 || score2 == 10)
            {
                ((Timer)sender).Stop();
                PlayerSide winSide = score1 > score2 ? PlayerSide.One : PlayerSide.Two;
                FinishGame(winSide);
            }
        }

        private Racket GetPlayerBySide(PlayerSide side)
        {
            return side == PlayerSide.One ? this.field.player1 : this.field.player2; //checks if the side is One, if true - first clause, if false second
        }


        public void GoUp(PlayerSide side) //sets the movement of the player to up
        {
            this.GetPlayerBySide(side).movement = Movement.Up;
        }

        public void GoDown(PlayerSide side)//sets the movement of the player to down
        {
            this.GetPlayerBySide(side).movement = Movement.Down;
        }

        public void Stop(PlayerSide side)//sets the movement of the player to none
        {
            this.GetPlayerBySide(side).movement = Movement.None;
        }

        public void OnClientDisconnect(PlayerSide side) //disconnects the players
        {
            if (side == PlayerSide.One)
            {
                server.users.connectedUsers.Remove(this.user1);
            }
            else
            {
                server.users.connectedUsers.Remove(this.user2);
            }
        }

        internal void UpdateStats(Player playerWin, Player playerLose) //updates the stats for the players
        {
            server.stats.UpdateEntry(playerWin.username, 1, 0);
            server.stats.UpdateEntry(playerLose.username, 0, 1);
        }

        internal void FinishGame(PlayerSide side) //receives playerside of the player who won
        {
            if (side == PlayerSide.One)
            {
                UpdateStats(player1, player2);
            }
            else
            {
                UpdateStats(player2, player1);
            }
        }

    }
}
