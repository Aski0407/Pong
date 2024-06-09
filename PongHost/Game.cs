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

        internal Game(PongServer server)
        {
            this.server = server;
            // attach tick method to elapsed event
            timer.Elapsed += Tick;
        }

        public void AddPlayer(Player player)
        {
            if (player1 == null)
            {
                player1 = player;
            }
            else
            {
                player2 = player;
            }
            player.game = this;
        }


        private void StartGame()
        {
            field = new Field();
            //enable timer
            timer.Enabled = true;
        }

        internal void TryStart()
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
        private void Tick(object sender, EventArgs e)
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


        public void GoUp(PlayerSide side)
        {
            this.GetPlayerBySide(side).movement = Movement.Up;
        }

        public void GoDown(PlayerSide side)
        {
            this.GetPlayerBySide(side).movement = Movement.Down;
        }

        public void Stop(PlayerSide side)
        {
            this.GetPlayerBySide(side).movement = Movement.None;
        }

        public void OnClientDisconnect(PlayerSide side)
        {
            if (side == PlayerSide.One)
            {
                server.users.connectedUsers.Remove(this.player1.username);
                this.player1 = null;
            }
            else
            {
                server.users.connectedUsers.Remove(this.player2.username);
                this.player2 = null;
            }
        }

        internal void UpdateStats(Player playerWin, Player playerLose)
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
