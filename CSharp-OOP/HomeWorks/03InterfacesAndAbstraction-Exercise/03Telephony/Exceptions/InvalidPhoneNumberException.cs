namespace Telephony.Exceptions
{
    using System;

    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;
    public class InvalidPhoneNumberException : Exception
    {
        private const string DEFAULT_EXCEPTION_MESSAGE = "Invalid number!";
        public InvalidPhoneNumberException() : base (DEFAULT_EXCEPTION_MESSAGE)
        {

        }
        public InvalidPhoneNumberException(string message) : base(message)
        {

        }
    }
}
