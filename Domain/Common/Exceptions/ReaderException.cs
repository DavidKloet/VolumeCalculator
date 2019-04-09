using System;

namespace Domain.Common.Exceptions
{
    /// <inheritdoc />
    /// <summary>
    /// Provides information about reader exceptions
    /// </summary>
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
