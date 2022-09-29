using System;
using System.Linq;

namespace _07PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[], Predicate<string>> printNames = (names, match) =>
            {
                foreach (var name in names)
                {
                    if (match(name)) Console.WriteLine(name);
                }
            };
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            printNames(names, n => n.Length <= length);

            //int n = int.Parse(Console.ReadLine());
            //Func<string, bool> filter = x=>x.Length<=n;
            //var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(filter).ToList();
            //foreach (var name in names) Console.WriteLine(name);            
        }
    }
}
