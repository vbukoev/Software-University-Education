using System;
using System.Collections.Generic;
using System.Linq;

namespace _03CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, int> minFunc = nums =>
            {
                int minNum = int.MaxValue; // min Value which is going to be printed on the console
                foreach (var num in nums)
                {
                    if (num < minNum)
                    {
                        minNum = num;
                    }
                }
                return minNum; // this is the value that has been => (returned) from the Func 
            };
            Console.WriteLine(minFunc(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList()));

        }
    }
}
