using ConsoleLogger.Core;
using ConsoleLogger.Core.Interfaces;
using ConsoleLogger.Factories;
using ConsoleLogger.Factories.Interfaces;

namespace ConsoleLogger
{
    using System;
    using SoftUniLogger.Appenders;
    using SoftUniLogger.IO;
    using SoftUniLogger.Layouts;
    using SoftUniLogger.Loggers;
    using SoftUniLogger.Appenders.Interfaces;
    using SoftUniLogger.IO.Interfaces;
    using SoftUniLogger.Layouts.Interfaces;
    using SoftUniLogger.Loggers.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
           ILayoutFactory layoutFactory = new LayoutFactory();
           IAppenderFactory appenderFactory = new AppenderFactory(layoutFactory);
           IEngine engine = new Engine(layoutFactory, appenderFactory);
           engine.Start();

        }
    }
}
