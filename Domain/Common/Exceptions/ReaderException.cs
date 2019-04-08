using System;

namespace Domain.Common.Exceptions
{
    public class ReaderException : Exception
    {
        public ReaderException()
        {
        }

        public ReaderException(string message) : base(message)
        {
        }

        public ReaderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
