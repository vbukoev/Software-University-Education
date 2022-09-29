using System;
using System.Collections.Generic;
using System.Linq;

namespace _04FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var range = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int start = range[0];
            int end = range[1];
            List<int> nums = new List<int>();
            for (int i = start; i <= end; i++)
            {
                nums.Add(i);
            }
            var cmd = Console.ReadLine();
            Func<int, bool> filter = GetFilter(cmd);
            var res = nums.Where(filter).ToList();
            Console.WriteLine(String.Join(" ", res));
        }

        public static Func<int, bool> GetFilter(string cmd)
        {
            switch (cmd)
            {
                case "odd":
                    return x => x % 2 != 0;

                case "even":
                    return x => x % 2 == 0;

                default:
                    return x => true;                    
            }
        }
    }
}
