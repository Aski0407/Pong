using System.Collections.Generic;
using Common;

namespace PongHost
{
    internal class Stats : FileHandler<UserStats>
    {
        public Stats() : base("stats.csv")
        {
        }

        protected override void RowToEntry(string row) //takes a row from the file and converts it to a value in the dictionary 
        {
            var values = row.Split(',');

            // Assuming the CSV file has three columns: Username, Games Won, Games Lost
            if (values.Length == 3)
            {
                string username = values[0];
                int gamesWon = int.Parse(values[1]);
                int gamesLost = int.Parse(values[2]);

                var userStats = new UserStats(gamesWon, gamesLost);
                data[username] = userStats;
            }
        }

        protected override string EntryToRow(KeyValuePair<string, UserStats> entry)
        {
            return $"{entry.Key},{entry.Value.gamesWon},{entry.Value.gamesLost}";
        }

        internal string GetStructAsString(string username)
        {
            UserStats user = this.data[username];
            return user.gamesWon + "-" + user.gamesLost;
        }

        internal void CreateNewEntry(string username)
        {
            data.Add(username, new UserStats(0, 0)); //defaults at 0
            SerializeData();
        }

        internal void UpdateEntry(string username, int wonChange, int lostChange)
        {
            UserStats userStats = data[username];
            userStats.gamesWon += wonChange;
            userStats.gamesLost += lostChange;
            data[username] = userStats;
            SerializeData();
        }
    }
}


