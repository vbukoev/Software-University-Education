namespace IteratorsAndComparators

{
using System;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var lake = new Lake(input);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
