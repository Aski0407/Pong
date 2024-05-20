using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace PongHost
{
    internal class Stats
    {
        private Dictionary<string, UserStats> stats = new Dictionary<string, UserStats>(); //dictionary of users and their stats
        private HttpServer server;
        string file = "stats.csv";

        public Stats()
        {
            ReadCsvToDictionary(file);
        }
        internal void SerializeData() //used to create and update the file
        {
            if (stats != null)
            {
                WriteDictionaryToCsv(file, stats);
            }
        }

        internal void ReadCsvToDictionary(string file)
        //makes the csv file into a dictionary 
        {
            this.stats = new Dictionary<string, UserStats>();
            if (File.Exists(file))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        // Read each line
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var values = line.Split(',');

                            // Assuming the CSV file has three columns: Username, Games Won, Games Lost
                            if (values.Length == 3)
                            {
                                string username = values[0];
                                int gamesWon = int.Parse(values[1]);
                                int gamesLost = int.Parse(values[2]);

                                var userStats = new UserStats(gamesWon, gamesLost);
                                stats[username] = userStats;
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading user data: {ex.Message}", "Error");
                }


            }
        }
        internal string GetStructAsString(string username)
        {
            UserStats user = this.stats[username];

            return user.gamesWon + "-" + user.gamesLost;
        }
        internal void WriteDictionaryToCsv(string file, Dictionary<string, UserStats> dictionary)
        //receives the file path, the dictionary with the stats struct
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (var pair in dictionary)
                {
                    writer.WriteLine($"{pair.Key},{pair.Value.gamesWon},{pair.Value.gamesLost}");
                }

            }
        }
    }



}


