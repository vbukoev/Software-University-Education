namespace SoftUniLogger.Formatters.Interfaces
{
    
    using SoftUniLogger.Layouts.Interfaces;
    using SoftUniLogger.Messages.Interfaces; 
    internal interface IFormatter
    {
        ILayout Layout { get; }
        string FormatMessage(IMessage message);
    }
}
