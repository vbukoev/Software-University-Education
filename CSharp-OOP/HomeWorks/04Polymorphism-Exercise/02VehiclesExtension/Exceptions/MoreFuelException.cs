namespace Vehicles.Exceptions
{
    using System;

    public class MoreFuelException :Exception
    {
        public MoreFuelException(string message) : base (message)
        {
        }
    }
}
