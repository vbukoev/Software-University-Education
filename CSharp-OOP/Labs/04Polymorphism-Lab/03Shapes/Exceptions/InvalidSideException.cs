namespace Shapes.Exceptions
{
    using System;
    using System.Reflection;

    public class InvalidSideException : Exception
    {
        public InvalidSideException(string message) : base(message)
        {
        }
    }
}
