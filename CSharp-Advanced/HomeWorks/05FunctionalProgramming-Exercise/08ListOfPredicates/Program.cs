using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _08ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Predicate<int>> predicates = new List<Predicate<int>>();
            int range = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int[] nums = Enumerable.Range(1, range).ToArray();

            foreach (var divider in dividers)
            {
                predicates.Add(p => p % divider == 0);
            }
            foreach (var num in nums)
            {
                bool isDivisable = true;
                foreach (var predicate in predicates)
                {
                    if (!predicate(num))
                    {
                        isDivisable = false;
                        break;
                    }
                }
                if (isDivisable)
                {
                    Console.Write(num + " ");
                }
            }


            //int range = int.Parse(Console.ReadLine());
            //var dividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            //var nums = new List<int>();
            //for (int i = 1; i <= range; i++)
            //{
            //    nums.Add(i);

            //}
            //foreach (var item in dividers)
            //{
            //    Func<int, bool> filter = x => x % item == 0;
            //    nums = nums.Where(filter).ToList();
            //}
            //Console.WriteLine(String.Join(" ", nums));
        }
    }
}
