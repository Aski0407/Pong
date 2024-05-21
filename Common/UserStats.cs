using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public struct UserStats
    {
        public int gamesWon;
        public int gamesLost;

        public UserStats(int gamesWon, int gamesLost)
        {
            this.gamesWon = gamesWon;
            this.gamesLost = gamesLost;
        }

        
    }
}
