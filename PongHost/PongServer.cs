using System;
using System.Net.Sockets;
using System.Net;
using Common;
using System.Timers;
using System.Configuration;

namespace PongHost
{
    enum PlayerSide //enum of the players 
    {
        One = 1,
        Two = 2
    }


    internal class PongServer
    {
        private Player player1, player2;
        private TcpListener listener;
        private int port = int.Parse(ConfigurationManager.AppSettings["Port"]);
        private Field field = new Field();
        private bool debug = bool.Parse(ConfigurationManager.AppSettings["Debug"]);
        private HttpServer httpServer;

        public PongServer()
        {
            httpServer = new HttpServer();
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            while (true)
            {
                TcpClient tcpClient = listener.AcceptTcpClient();
                Console.WriteLine("A client connected");
                this.HandleConnection(tcpClient);
            }
        }

        private void HandleConnection(TcpClient client)
        {
            if (this.player1 == null)
            {
                this.player1 = new Player(this, client, PlayerSide.One); //player class instance
                Console.WriteLine("Player 1 connected");
                if (this.debug)
                {
                    StartGame();
                }
            }
            else if (this.player2 == null)
            {
                this.player2 = new Player(this, client, PlayerSide.Two);
                Console.WriteLine("Player 2 connected, starting game");
                StartGame();
            }
            else { }
            //add what happens if there are 2 clients connected already
        }


        public void StartGame()
        {
            //creates timer that ticks every 20 milliseconds 
            Timer timer = new System.Timers.Timer(20);

            // attach tick method to elapsed event
            timer.Elapsed += Tick;

            //enable timer
            timer.Enabled = true;

        }

        //happens every tick - 20 milliseconds 
        private void Tick(object sender, EventArgs e)
        {
            Data board = this.field.GetNextFrame();

            if (this.player1 != null && (this.player2 != null || debug))
            {
                this.player1.Send(board);
                if (this.player2 != null)
                {
                    this.player2.Send(board);
                }
            }
            else if (this.player1 == null)
            {
                OnClientDisconnect(PlayerSide.One);
            }
            if (this.player2 == null)
            {
                OnClientDisconnect(PlayerSide.Two);
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
        
        public void UpdateStats(string username, int wonChange, int lostChange)
        {
            httpServer.stats.UpdateEntry(username, wonChange, lostChange);
        }

        public void OnClientDisconnect(PlayerSide side)
        {
            if (side == PlayerSide.One)
            {
                this.player1 = null;
            }
            else
            {
                this.player2 = null;
            }
        }

        public static void Main(String[] args)
        {
            new PongServer();
        }

    }
}
