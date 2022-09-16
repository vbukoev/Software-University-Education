using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}
