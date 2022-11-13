namespace SoftUniLogger.Formatters
{
    using Interfaces;
    using SoftUniLogger.Layouts.Interfaces;
    using SoftUniLogger.Messages.Interfaces;


    public class MessageFormatter : IFormatter  
    {
        public MessageFormatter(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; }
        public string FormatMessage(IMessage message)
        {
            return string.Format(this.Layout.Format,
                message.LogTime, message.Level.ToString(), message.MessageText);
        }
    }
}
