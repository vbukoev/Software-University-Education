namespace SoftUniLogger.Loggers.Interfaces
{
    using Enums;
    public interface ILogger
    {
        void Info(string logTime, string message);
        void Warn(string logTime, string message);
        void Error(string logTime, string message);
        void Critical(string logTime, string message);
        void Fatal(string logTime, string message);
    }
}
