using System;
using System.IO;

namespace DataReaderService
{
    public class DataReaderService : IDataReaderService
    {
        public string ReadFile(string filepath)
        {
            using (StreamReader r = new StreamReader(filepath))
            {
                string data = r.ReadToEnd();
                return data;
            };
        }
    }
}
