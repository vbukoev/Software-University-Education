namespace Shapes.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class InvalidRadiusException : Exception
    {
        private const string DEFAULT_MESSAGE = "Radius must be a positive number!";
        public InvalidRadiusException() : base(DEFAULT_MESSAGE) 
        { 
        }
    }
}
