namespace IteratorsAndComparators

{
using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Split(new string[] { "Create", " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();// I have created the Create string array in Split() method
            var iterator = new ListyIterator<string>(command);
            while (true)
            {
            var input = Console.ReadLine();
                if (input == "END") break;
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string cmd = tokens[0];
                switch (cmd)
                {
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "Print":
                        Console.WriteLine(iterator.Print());
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
