namespace SoftUniLogger.Appenders.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface IAppenderCollection
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void AddAppender(IAppender appender);
        bool RemoveAppender(IAppender appender);
        void Clear();
    }
}
