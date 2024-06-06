using System.Net.Sockets;
using Common;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace PongClient
{

    public class NetworkClient
    {
        private NetworkStream stream;
        private TcpClient client;
        private bool connected = true;
        private Queue<Data> queue = new Queue<Data>();
        private BinaryReader reader;
        private BinaryWriter writer;

        public NetworkClient(string serverIP, int port)
        {
            client = new TcpClient(serverIP, port); //connects client
            stream = this.client.GetStream();
            reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
            writer.Write(Cryptography.PublicKey);
            StartReceiving();
        }

        public int QueueLength { get { return queue.Count; } }


        public Data NextFrame { get { return queue.Dequeue(); } }


        void StartReceiving()
        {
            string sKey = reader.ReadString();
            Cryptography.InitializeEncryption(sKey);
            new Thread(() => //opens new thread to manage reading the info from the server
            {
                Thread.CurrentThread.IsBackground = true;
                while (connected)
                {
                    try
                    {
                        int length = reader.ReadInt32();
                        byte[] message = reader.ReadBytes(length);
                        string decrypted = Cryptography.Decrypt(message);
                        Data frame = new Data(decrypted);
                        //Debug.WriteLine("delay reading from server = " + ((DateTime.Now.Ticks - frame.timeStamp.Ticks) / TimeSpan.TicksPerMillisecond));
                        queue.Enqueue(frame);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: {0}", e);
                    }

                }
            }).Start();
        }
        
        public void Send(string message)
        {
            byte[] encrypted = Cryptography.Encrypt(message);
            writer.Write(encrypted.Length); //sends the length of the array 
            writer.Write(encrypted);
        }
    }
}



