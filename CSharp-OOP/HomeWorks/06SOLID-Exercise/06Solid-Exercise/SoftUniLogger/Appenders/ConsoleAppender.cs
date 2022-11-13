namespace SoftUniLogger.Appenders
{
    using System;

    using SoftUniLogger.Layouts.Interfaces;
    using SoftUniLogger.Messages.Interfaces;
    using Interfaces;
    using Enums;
    using SoftUniLogger.Formatters.Interfaces;
    using Formatters;


    public class ConsoleAppender : IAppender
    {
        private readonly IFormatter formatter;
        private ConsoleAppender()
        {
            this.Count = 0;
        }
        public ConsoleAppender(ILayout layout) 
            : this() // chaining the two constructors 
        {
            this.Layout = layout;
            this.formatter = new MessageFormatter(this.Layout);
        }

        public int Count { get; private set; }
        public ILayout Layout { get; }
        public ReportLevel Level { get; }
        public void Append(IMessage message)
        {
            string formattedMessage = this.formatter.FormatMessage(message);

            Console.WriteLine(formattedMessage);
            this.Count++;
        }

    }
}