namespace Telephony
{
    using Core;
    using Core.Interfaces;
    using Telephony.IO;
    using Telephony.IO.Interfaces;

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
