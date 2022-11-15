using SoftUniLogger.Enums;

namespace SoftUniLogger.Messages.Interfaces
{
    public interface IMessage
    {
        string LogTime { get; }
        string MessageText { get; }
        ReportLevel Level { get; }
    }
}
