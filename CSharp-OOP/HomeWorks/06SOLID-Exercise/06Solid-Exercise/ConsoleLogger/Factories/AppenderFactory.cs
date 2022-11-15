namespace ConsoleLogger.Factories
{
    
    using System;
    
    using SoftUniLogger.IO;
    using Interfaces;
    using SoftUniLogger.Appenders;
    using SoftUniLogger.Appenders.Interfaces;
    using SoftUniLogger.Enums;
    using SoftUniLogger.IO.Interfaces;
    using SoftUniLogger.Layouts.Interfaces;
    internal class AppenderFactory : IAppenderFactory
    {
        private readonly FileWriter fw;
        private readonly ILayoutFactory layoutFactory;
        private readonly ILogFile logFile;

        private AppenderFactory()
        {
            this.fw = new FileWriter("../../../Logs");
            this.logFile = new LogFile(fw);
        }

        public AppenderFactory(ILayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
        }
        public IAppender Create(string type, string layoutType, ReportLevel level, ILogFile logFile = null)
        {
            ILayout layout = this.layoutFactory.Create(layoutType);
            IAppender appender;
            if (type == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout);
            }
            else if (type == "FileAppender")
            {
                appender = new FileAppender(layout, logFile);
            }
            else
            {
                throw new InvalidOperationException("Invalid appender type!");
            }
            return appender;
        }

        public IAppender Create(string type, string layoutType, ReportLevel level = ReportLevel.Info)
        {
            throw new NotImplementedException();
        }
    }
}
