using System;
using System.Collections.Generic;
using ConsoleLogger.Factories.Interfaces;
using SoftUniLogger.Appenders.Interfaces;
using SoftUniLogger.Enums;

namespace ConsoleLogger.Core
{
    using ConsoleLogger.Core.Interfaces;
    using SoftUniLogger.Loggers;
    using SoftUniLogger.Loggers.Interfaces;


    internal class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly ILayoutFactory layoutFactory;
        private readonly IAppenderFactory appenderFactory;
        private Engine()
        {
            this.logger = new Logger();
        }
        public Engine(ILayoutFactory layoutFactory, IAppenderFactory appenderFactory) : this()
        {
            this.layoutFactory = layoutFactory;
            this.appenderFactory = appenderFactory;
        }

        public void Start()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] appenderArgs = Console.ReadLine().Split();
                    string appenderType = appenderArgs[0];
                    string layoutType = appenderArgs[1];
                    IAppender appender;
                    if (appenderArgs.Length == 2)
                    {
                        appender = this.appenderFactory.Create(appenderType, layoutType);
                    }
                    else
                    {
                        ReportLevel level = Enum.Parse<ReportLevel>(appenderArgs[2], true);
                        appender = appenderFactory.Create(appenderType, layoutType, level);
                    }
                    ((IAppenderCollection)this.logger).AddAppender(appender);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); 
                }
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmdStrings = cmd.Split("|");
                    string reportLevel = cmdStrings[0].ToUpper();
                    string time = cmdStrings[1];
                    string message = cmdStrings[2];
                    if (reportLevel == "INFO")
                    {
                        logger.Info(time, message);
                    }
                    else if (reportLevel == "WARNING")
                    {
                        logger.Warning(time, message);
                    }
                    else if (reportLevel == "ERROR")
                    {
                        logger.Error(time, message);
                    }
                    else if (reportLevel == "CRITICAL")
                    {
                        logger.Critical(time, message);
                    }
                    else if (reportLevel == "FATAL")
                    {
                        logger.Fatal(time, message);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e); 
                }
            }
        }
    }
}
