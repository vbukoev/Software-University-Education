namespace Vehicles
{
    using System;
    using Vehicles.Core;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
