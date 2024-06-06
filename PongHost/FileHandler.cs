using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PongHost
{

    internal abstract class FileHandler<T>
    {
        protected Dictionary<string, T> data = new Dictionary<string, T>();
        protected readonly string file;

        protected FileHandler(string file)
        {
            this.file = file;
            if (File.Exists(file))
            {
                Console.WriteLine("started reading " + file);
                //load all data from the file
                using (var stream = File.OpenText(file))
                {
                    string line;
                    while ((line = stream.ReadLine()) != null)
                    {
                        RowToEntry(line);
                    }
                }
            }
            Console.WriteLine("finished reading " + file);
        }

        protected void SerializeData() //used to create and update the file
        {
            lock (this)
            {
                Console.WriteLine("started writing to file " + file);
                File.WriteAllLines(file,
                    data.Select(EntryToRow).ToArray());
                Console.WriteLine("finished writing " + file);
            }
        }

        protected abstract string EntryToRow(KeyValuePair<string, T> entry);

        protected abstract void RowToEntry(string row);
    }
}
