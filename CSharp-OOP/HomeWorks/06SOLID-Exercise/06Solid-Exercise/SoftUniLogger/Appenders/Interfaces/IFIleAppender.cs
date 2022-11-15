namespace SoftUniLogger.Appenders.Interfaces
{
    using SoftUniLogger.IO.Interfaces;
    public interface IFIleAppender : IAppender
    {
        ILogFile LogFile { get; }
        void SaveLogFile(string filename);
    }
}
