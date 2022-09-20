using System;
using System.Collections.Generic;
using System.Linq;

namespace _01CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            var numbersTime = new Dictionary<double, int>();
            foreach (var number in numbers)
            {
                if (!numbersTime.ContainsKey(number))
                {
                    numbersTime.Add(number, 0);
                }
                numbersTime[number]++;
            }
            foreach (var item in numbersTime)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }            
        }
    }
}
