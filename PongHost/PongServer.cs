using System;
using System.Net.Sockets;
using System.Net;
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
        private TcpListener listener;
        private int port = int.Parse(ConfigurationManager.AppSettings["Port"]);
        internal Users users = new Users();
        internal Stats stats = new Stats();
        Game pendingGame;

        public PongServer() //constructor. listens for connections and handles them
        {
            listener = new TcpListener(IPAddress.Any, port);
            HttpConnection connection = new HttpConnection(this);
            listener.Start();
            while (true)
            {
                TcpClient tcpClient = listener.AcceptTcpClient();
                Console.WriteLine("A client connected");
                this.HandleConnection(tcpClient);
            }
        }

        private void HandleConnection(TcpClient client) //receives the client who connected and assigns it to a game
        {
            if (this.pendingGame == null) //if there is no game, creates it and assigns the client as player1
            {
                pendingGame = new Game(this);
                Player player1 = new Player(this, client, PlayerSide.One); //player class instance
                pendingGame.AddPlayer(player1);
                Console.WriteLine("First player connected");
                return;
            }
            if (pendingGame != null && pendingGame.player1 == null) //if there is a game and player1 is null, assigns the client as player 1
            {
                Player player1 = new Player(this, client, PlayerSide.One); //player class instance
                pendingGame.AddPlayer(player1);
                Console.WriteLine("First player connected");
                return;
            }
            if (pendingGame != null && pendingGame.player1 != null) //if there is a game and player 1 isnt null, assigns the client as player2
            {
                pendingGame.AddPlayer(new Player(this, client, PlayerSide.Two));
                Console.WriteLine("Second player connected");
                pendingGame = null;
                return;
            }
        }


        public static void Main(String[] args) //main method. creates a new server
        {
            new PongServer();
        }

    }
}
