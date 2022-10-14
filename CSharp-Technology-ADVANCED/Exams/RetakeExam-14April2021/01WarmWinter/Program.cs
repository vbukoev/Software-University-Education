using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01WarmWinter
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            List<int> list = new List<int>();

            while (true)
            {
                if (!hats.Any() || !scarfs.Any()) break;

                int hat = hats.Peek();
                int scarf = scarfs.Peek();

                if (hat < scarf) hats.Pop();

                else if (hat > scarf)
                {
                    list.Add(hat + scarf);
                    hats.Pop();
                    scarfs.Dequeue();
                }

                else if (hat == scarf)
                {
                    scarfs.Dequeue();
                    hats.Pop();
                    hats.Push(hat + 1);
                }
            }

            var maxPriceSet = list.Max();
            Console.WriteLine($"The most expensive set is: {maxPriceSet}");
            Console.WriteLine(String.Join(" ", list));
        }
    }
}