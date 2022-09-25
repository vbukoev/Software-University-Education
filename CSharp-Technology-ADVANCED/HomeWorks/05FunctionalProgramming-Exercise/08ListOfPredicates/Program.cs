using System;
using System.Collections.Generic;
using System.Linq;

namespace _08ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var nums = new List<int>();
            for (int i = 1; i <= range; i++)
            {
                nums.Add(i);

            }
            foreach (var item in dividers)
            {
                Func<int, bool> filter = x => x % item == 0;
                nums = nums.Where(filter).ToList();
            }
            Console.WriteLine(String.Join(" ", nums));
        }
    }
}
