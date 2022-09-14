using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBotique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clothesValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rack = int.Parse(Console.ReadLine());
            var stack = new Stack<int>(clothesValues);
            int sum = 0;
            int rackCnt = 1;
            while (stack.Any())
            {
                int currValue = stack.Peek();
                if (sum + currValue <= rack)
                {
                    sum += currValue;
                    stack.Pop();
                }
                else
                {
                    sum = 0;
                    rackCnt++;
                }
            }
            Console.WriteLine(rackCnt);
        }
    }
}
