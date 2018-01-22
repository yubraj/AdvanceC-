using System;

namespace DataReaderService
{
    public interface IDataReaderService
    {
        string ReadFile(string filePath);
    }
}
