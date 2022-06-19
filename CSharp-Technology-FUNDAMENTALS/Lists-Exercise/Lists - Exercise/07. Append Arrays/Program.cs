using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numsAsStrings = Console.ReadLine().Split('|').Reverse().ToList();
            
            var numbers = new List<int>();

            foreach (var number in numsAsStrings)
            {
                numbers.AddRange(number.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
