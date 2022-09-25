using System;
using System.Linq;

namespace _02KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> sir = n => Console.WriteLine($"Sir {n}");
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var name in names)
            {
                sir(name); 
            }
        }
    }
}
