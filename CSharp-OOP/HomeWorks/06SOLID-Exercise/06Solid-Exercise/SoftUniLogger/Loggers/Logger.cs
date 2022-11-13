namespace SoftUniLogger.Loggers
{
    using System.Collections.Generic;
    using SoftUniLogger.Appenders.Interfaces;
    using Common;
    using Enums;
    using Interfaces;

    using Messages;
    using SoftUniLogger.Messages.Interfaces;
    public class Logger : IAppenderCollection, ILogger
    {
        private readonly ICollection<IAppender> appenders;

        private Logger()
        {
            this.appenders = new HashSet<IAppender>();
        }
        public Logger(params IAppender[] appenders) : this()
        {
            this.appenders.AddRange(appenders);
        }

        public IReadOnlyCollection<IAppender> Appenders
            => this.appenders.AsReadOnly();
        public void AddAppender(IAppender appender)
        {
            this.appenders.Add(appender);
        }

        public bool RemoveAppender(IAppender appender)
        
            => this.appenders.Remove(appender);
        

        public void Clear()
        => this.appenders.Clear();

        public void Info(string logTime, string message)
        {
            LogMessage(logTime, message, ReportLevel.Info);
        }
        

        public void Warning(string logTime, string message)
        {
            LogMessage(logTime, message, ReportLevel.Warning);
        }

        public void Error(string logTime, string message)
        {
            LogMessage(logTime, message, ReportLevel.Error);
        }

        public void Critical(string logTime, string message)
        {
            LogMessage(logTime, message, ReportLevel.Critical);
        }

        public void Fatal(string logTime, string message)
        {
            LogMessage(logTime, message, ReportLevel.Fatal);
        }

        private void LogMessage(string logTime, string messageText, ReportLevel level)
        {
            IMessage message = new Message(logTime, messageText, level);
            foreach (var appender in appenders)
            {
                appender.Append(message);
            }
        }
    }
}
