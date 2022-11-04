using System;
using System.Linq;

namespace _07CustomComparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var even = numbers.Where(x => x % 2 == 0).OrderBy(x=>x).ToArray();
            var oods = numbers.Where(x => x % 2 != 0).OrderBy(x => x).ToArray();
            var nums = even.Concat(oods).ToArray(); 
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
