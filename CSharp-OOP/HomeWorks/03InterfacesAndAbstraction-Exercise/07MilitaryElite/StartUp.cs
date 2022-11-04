namespace MilitaryElite
{
    using MilitaryElite.Core;
    using MilitaryElite.Core.Interfaces;
    using MilitaryElite.IO;
    using MilitaryElite.IO.Interfaces;
    using MilitaryElite.Models;
    using MilitaryElite.Models.Interfaces;
    using System;
    public class StartUp
    {
        static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
