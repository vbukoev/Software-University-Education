using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            numbers = numbers.OrderByDescending(x => x).Take(3).ToList();
            int cnt = numbers.Count();
            if (cnt>3) cnt = 3;
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
