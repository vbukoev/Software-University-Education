namespace BirthdayCelebrations
{
    using BirthdayCelebrations.Commands;
    using BorderControl.Core;
    using System;
    public class StartUp
    {
        static void Main()
        {
            var commandParser = new CommandParser();
            var engine = new Engine(commandParser);
            engine.Run();
        }
    }
}
