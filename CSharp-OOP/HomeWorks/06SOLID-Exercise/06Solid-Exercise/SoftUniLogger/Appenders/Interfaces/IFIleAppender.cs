namespace SoftUniLogger.Appenders.Interfaces
{
    using SoftUniLogger.IO.Interfaces;
    public interface IFIleAppender 
    {
        ILogFile LogFile { get; }
        void SaveLogFile(string filename);
    }
}
