using System;
using System.Text;

namespace Common
{

    public class Data //object to send from the server
    {
        public int Player1; //top
        public int Player2; //top
        public int BallLeft;
        public int BallTop;
        public int Score1;
        public int Score2;
        public DateTime timeStamp;


        public Data(int player1, int player2, int ballLeft, int ballTop, int score1, int score2)
        {
            this.Player1 = player1;
            this.Player2 = player2;
            this.BallLeft = ballLeft;
            this.BallTop = ballTop;
            this.Score1 = score1;
            this.Score2 = score2;
            //this.timeStamp = DateTime.Now; //timestamp

        }
        //constructs using the command string 
        public Data(string s)
        {
            string[] kvPairs = s.Split(new string[] { Protocol.ParameterDelimiter }, StringSplitOptions.None);
            foreach (string kvPair in kvPairs)
            {
                string[] kv = kvPair.Split(new string[] { Protocol.KeyValueDelimiter }, StringSplitOptions.None);
                if(kv.Length != 2)
                {
                    Console.WriteLine("kvPair: " + kvPair);
            ;       continue;
                }
                string value = kv[1];
                switch (kv[0])
                {
                    case Protocol.Player1:
                        this.Player1 = int.Parse(value); break;
                    case Protocol.Player2:
                        this.Player2 = int.Parse(value); break;
                    case Protocol.BallLeft:
                        this.BallLeft = int.Parse(value); break;
                    case Protocol.BallTop:
                        this.BallTop = int.Parse(value); break;
                    case Protocol.Score1:
                        this.Score1 = int.Parse(value); break;
                    case Protocol.Score2:
                        this.Score2 = int.Parse(value); break;
                   // case Protocol.TimeStamp:
                     //   this.timeStamp = new DateTime(long.Parse(value)); break;
                        

                }
            }
        }

        private void Append(StringBuilder sb, string key, long value)
        {
            sb.Append(key);
            sb.Append(Protocol.KeyValueDelimiter);
            sb.Append(value);
            sb.Append(Protocol.ParameterDelimiter);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(64);
            this.Append(sb, Protocol.Player1, this.Player1);
            this.Append(sb, Protocol.Player2, this.Player2);
            this.Append(sb, Protocol.BallLeft, this.BallLeft);
            this.Append(sb, Protocol.BallTop, this.BallTop);
            this.Append(sb, Protocol.Score1, this.Score1);
            this.Append(sb, Protocol.Score2, this.Score2);
           // this.Append(sb, Protocol.TimeStamp, this.timeStamp.Ticks);

            return sb.ToString();
        }


    }
}
