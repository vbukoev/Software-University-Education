namespace _01Vehicles.Exceptions
{
    using System;
    public class LowFuelException : Exception
    {
        public LowFuelException(string message) : base(message)
        {

        }
    }
}
