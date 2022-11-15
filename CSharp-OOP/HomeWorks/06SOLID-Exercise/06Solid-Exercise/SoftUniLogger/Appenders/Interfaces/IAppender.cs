namespace SoftUniLogger.Appenders.Interfaces
{
    using SoftUniLogger.Messages.Interfaces;
    using SoftUniLogger.Layouts.Interfaces;
    using Enums;

    public interface IAppender
    {
        int Count { get; }
        ILayout Layout { get; }
        void Append(IMessage message);
    }
}
