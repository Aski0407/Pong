using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Protocol
    {
        public static readonly string KeyValueDelimiter = "="; 
        public static readonly string ParameterDelimiter = ";"; 
        public static readonly string UserPassDelimiter = "\r\n";
        public const string Player1 = "P1";
        public const string Player2 = "P2";
        public const string BallLeft = "BL";
        public const string BallTop = "BT";
        public const string Score1 = "S1";
        public const string Score2 = "S2";
        public const string TimeStamp = "TS";
        public const int RefreshRate = 20;
    }
}
