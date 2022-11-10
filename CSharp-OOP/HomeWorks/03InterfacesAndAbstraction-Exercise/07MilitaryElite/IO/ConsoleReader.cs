namespace MilitaryElite.IO
{
    using System; 

    using IO.Interfaces;

    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
