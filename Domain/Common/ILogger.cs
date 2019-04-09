namespace Domain.Common
{
    /// <summary>
    /// Log sink
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes an informational message to the sink
        /// </summary>
        void Info(string message);

        /// <summary>
        /// Writes an error message to the sink
        /// </summary>
        void Error(string error);
    }
}
