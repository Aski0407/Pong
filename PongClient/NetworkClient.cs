using System.Text;
using System.Net.Sockets;
using Common;
using System.Windows.Forms;
using System.Diagnostics;

namespace PongClient
{
    //type of commands that can be sent


    public class NetworkClient
    {
        private NetworkStream stream;
        private TcpClient client;
        private bool connected = true;
        private Queue<Data> queue = new Queue<Data>();
        private BinaryReader reader;
        private BinaryWriter writer;

        //network client constructor 
        public NetworkClient(string serverIP, int port)
        {
            client = new TcpClient(serverIP, port); //connects client
            stream = this.client.GetStream();
            reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
            StartReceiving();
        }

        public int QueueLength { get { return queue.Count; } }


        public Data NextFrame { get { return queue.Dequeue(); } }


        void StartReceiving()
        {
            Console.WriteLine("Connected to server!");
            new Thread(() => //opens new thread to manage reading the info from the server
            {
                Thread.CurrentThread.IsBackground = true;
                while (connected)
                {
                    try
                    {
                        string response = this.reader.ReadString();
                        Data frame = new Data(response);
                        Debug.WriteLine("delay reading from server = " + ((DateTime.Now.Ticks - frame.timeStamp.Ticks) / TimeSpan.TicksPerMillisecond));
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
            this.writer.Write(message);
        }
    }
}



