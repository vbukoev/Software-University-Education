using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftUniLogger.Exceptions
{
    public class InvalidDateTimeException : Exception
    {
        private const string DefaultMessage = "Provided DateTime was not in correct format!";

        public InvalidDateTimeException() : base(DefaultMessage)
        {
                
        }
    }
}
