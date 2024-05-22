using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        protected void SerializeData() //used to create and update the file
        {
            File.WriteAllLines(file,
                data.Select(EntryToRow).ToArray());
        }

        protected abstract string EntryToRow(KeyValuePair<string, T> entry);

        protected abstract void RowToEntry(string row);
    }
}
