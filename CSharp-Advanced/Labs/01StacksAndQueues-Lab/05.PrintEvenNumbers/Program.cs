using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var evenQueue = new Queue<int>();
            foreach (var item in arr)
            {
                if (item % 2 == 0)
                {
                    evenQueue.Enqueue(item);
                }
            }
            Console.WriteLine(string.Join(", ", evenQueue));
        }
    }
}
