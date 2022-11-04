using System;
using System.Linq;

namespace _01ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = n => Console.WriteLine(n);
            var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
