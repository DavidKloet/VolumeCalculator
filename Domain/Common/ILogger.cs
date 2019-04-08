namespace Domain.Common
{
    public interface ILogger
    {
        void Info(string message);

        void Error(string error);
    }
}
