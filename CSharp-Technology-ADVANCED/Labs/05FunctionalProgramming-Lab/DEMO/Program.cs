using System;
using System.Linq;

namespace DEMO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<int> action = x => Console.WriteLine($"{x}");
            var x = int.Parse(Console.ReadLine());
            action(x * 5);
            //C# is multi-paradigm language
        }
    }
}
