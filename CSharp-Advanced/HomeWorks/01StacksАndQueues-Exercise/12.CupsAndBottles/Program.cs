using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cupsCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var filledBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var cups = new Queue<int>(cupsCapacity);
            var bottles = new Stack<int>(filledBottles);
            int waterCnt = 0;
            while (cups.Any() && bottles.Any())
            {
                int currCup = cups.Peek(); 
                int currBottle = bottles.Peek();
                if (currBottle >= currCup)
                {
                    if (currCup - currBottle <= 0) cups.Dequeue();
                    waterCnt = waterCnt + currBottle - currCup;  // sums the water with the difference between currBottle and the currCup Value 
                    bottles.Pop();
                }                
                else
                {
                    while (currCup > 0) currCup = currCup - bottles.Pop();
                    waterCnt = waterCnt + Math.Abs(currCup);
                    cups.Dequeue();
                }
            }
            if (cups.Count == 0) Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            else Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            Console.WriteLine($"Wasted litters of water: {waterCnt}");
        }
    }
}
