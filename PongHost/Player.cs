using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Common;

namespace PongHost
{

    internal class Player
    {
        private NetworkStream stream;
        private PongServer server;
        private bool connected = true;
        private PlayerSide p;
        private BinaryReader reader;
        private BinaryWriter writer;
        private BlockingCollection<Data> outputQueue = new BlockingCollection<Data>();

        public Player(PongServer server, TcpClient client, PlayerSide p)
        {
            // Get the network stream for reading and writing
            this.stream = client.GetStream();
            this.server = server;
            this.p = p;
            reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
            Thread receiver = new Thread(new ThreadStart(Receive));
            receiver.Name = "Receiver";
            receiver.Start(); //dedicated thread for receiving information
            Thread sender = new Thread(new ThreadStart(() => //dedicated thread for sending information. prevents delays between clients
            {
                while (true)
                {
                    try
                    {
                        Data message = outputQueue.Take();
                        long delay = (DateTime.Now.Ticks - message.timeStamp.Ticks) / TimeSpan.TicksPerMillisecond;
                        if (delay > 200)
                        {
                            Console.WriteLine("DELAY: " + delay);
                        }
                        writer.Write(message.ToString());

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
            while (connected)
            {
                try
                {
                    string command = this.reader.ReadString();
                    // Process the received data (parse commands)
                    Console.WriteLine("Received command: {0}", command);
                    ProcessCommand(command);

                }
                catch (Exception e)
                {
                    if (e.InnerException is SocketException && ((SocketException)e.InnerException).SocketErrorCode == SocketError.ConnectionReset) //if client disconnects
                    {
                        connected = false;
                        this.server.OnClientDisconnect(this.p);
                    }
                    Console.WriteLine("Exception: {0}", e);
                }

            }

        }




        void ProcessCommand(string command)
        {
            // Implement logic to parse and process the received command
            Console.WriteLine("Processing command: " + command);
            if (command.Equals("UP"))
            {
                server.GoUp(this.p);
            }
            if (command.Equals("DOWN"))
            {
                server.GoDown(this.p);
            }
            if (command.Equals("NONE"))
            {
                server.Stop(this.p);
            }

        }

        public void Send(Data message)
        {
            outputQueue.Add(message);
        }

    }

   
}


