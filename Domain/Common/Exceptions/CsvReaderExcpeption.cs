using System;

namespace Domain.Common.Exceptions
{
    public class CsvReaderExcpeption : Exception
    {
        public CsvReaderExcpeption(string message) : base(message)
        {

        }
    }
}
