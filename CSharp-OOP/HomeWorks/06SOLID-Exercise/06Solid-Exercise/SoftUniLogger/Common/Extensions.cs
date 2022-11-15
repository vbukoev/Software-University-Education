using System.Runtime.CompilerServices;

namespace SoftUniLogger.Common
{
    using SoftUniLogger.Appenders.Interfaces;


    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Extensions
    {
        public static void AddRange(this ICollection<IAppender> appenders, IEnumerable<IAppender> appendersToAdd)
        {
            foreach (var appenderToAdd in appendersToAdd)
            {
                appenders.Add(appenderToAdd);
            }
        }

        public static IReadOnlyCollection<IAppender> AsReadOnly<IAppender>(this ICollection<IAppender> appenders)
            => (IReadOnlyCollection<IAppender>)appenders;
    }
}
