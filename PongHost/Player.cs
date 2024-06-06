using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using Common;

namespace PongHost
{

    internal class Player
    {
        private NetworkStream stream;
        private bool connected = true;
        private PlayerSide p;
        private BlockingCollection<Data> outputQueue = new BlockingCollection<Data>();
        internal string username;
        internal Game game;
        private BinaryWriter writer;
        private BinaryReader reader;
        private RSACryptoServiceProvider encryptProvider;

        public Player(PongServer server, TcpClient client, PlayerSide p)
        {
            // Get the network stream for reading and writing
            this.stream = client.GetStream();
            this.p = p;
            writer = new BinaryWriter(stream);
            reader = new BinaryReader(stream);
            writer.Write(Cryptography.PublicKey); //sends the public key to the client

            Thread receiver = new Thread(new ThreadStart(Receive));
            receiver.Name = "Receiver";
            receiver.Start(); //dedicated thread for receiving information
            Thread sender = new Thread(new ThreadStart(() => //dedicated thread for sending information. prevents delays between clients
            {
                while (true)
                {
                    try
                    {
                        Data board = outputQueue.Take();
                        string message = board.ToString();
                        byte[] encrypted = Cryptography.Encrypt(message, encryptProvider);
                        Console.WriteLine(message);
                        //long delay = (DateTime.Now.Ticks - board.timeStamp.Ticks) / TimeSpan.TicksPerMillisecond;
                        //if (delay > 200)
                        //{
                        //  Console.WriteLine("DELAY: " + delay);
                        //}
                        writer.Write(encrypted.Length);
                        writer.Write(encrypted);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception in sender: {0}", ex);
                    }
                }
            }))
            {
                IsBackground = true,
                Name = "Sender"
            };
            sender.Start();
        }

        private void Receive()
        {
            string cKey = reader.ReadString();
            encryptProvider = Cryptography.CreateProvider(cKey);
            //reads the stream and processes commands
            while (connected)
            {
                try
                {
                    int length = reader.ReadInt32(); //reads the length of the message
                    byte[] message = reader.ReadBytes(length);
                    string command = Cryptography.Decrypt(message);

                    //Console.WriteLine("Received command: {0}", command);
                    ProcessCommand(command);
                }
                catch (Exception e)
                {
                    if (e.InnerException is SocketException && ((SocketException)e.InnerException).SocketErrorCode == SocketError.ConnectionReset) //if client disconnects
                    {
                        connected = false;
                        this.game.OnClientDisconnect(this.p);
                    }
                    Console.WriteLine("Exception: {0}", e);
                }
            }
        }

        private void ProcessCommand(string command)
        {
            // processes the commands, receives the command
            //Console.WriteLine("Processing command: " + command);
            switch (command)
            {
                case "UP":
                    this.game.GoUp(this.p);
                    break;

                case "DOWN":
                    this.game.GoDown(this.p);
                    break;

                case "NONE":
                    this.game.Stop(this.p);
                    break;

                case "START":
                    this.game.TryStart();
                    break;

                default:
                    //"username="))
                    string[] parts = command.Split('=');
                    this.username = parts[1];
                    break;

            }


        }

        internal void Send(Data message)
        {
            //puts the frames in the queue
            outputQueue.Add(message);
        }
    }
}


