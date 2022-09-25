using System;
using System.Linq;

namespace _07PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Func<string, bool> filter = x=>x.Length<=n;
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(filter).ToList();
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
