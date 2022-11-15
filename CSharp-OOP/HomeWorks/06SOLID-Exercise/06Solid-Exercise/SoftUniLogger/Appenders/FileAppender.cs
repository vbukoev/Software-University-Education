using SoftUniLogger.Formatters;
using SoftUniLogger.Formatters.Interfaces;

namespace SoftUniLogger.Appenders
{
    using Interfaces;
    using SoftUniLogger.IO.Interfaces;
    using SoftUniLogger.Layouts.Interfaces;
    using SoftUniLogger.Messages.Interfaces;


    public class FileAppender : IAppender, IFIleAppender
    {
        private readonly IFormatter formatter;
        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.Layout = layout;
            this.LogFile = logFile;
            this.formatter = new MessageFormatter(this.Layout);
        }
        private FileAppender(IFormatter formatter)
        {
            this.Count = 0;
        }
        public int Count { get; }
        public ILayout Layout { get; }
        public ILogFile LogFile { get; }
        public void Append(IMessage message)
        {
            string formattedMessage = formatter.FormatMessage(message);
            LogFile.Write(formattedMessage);
        }

        public void SaveLogFile(string filename)
        {
            this.LogFile.SaveAs(filename);
        }
    }
}
