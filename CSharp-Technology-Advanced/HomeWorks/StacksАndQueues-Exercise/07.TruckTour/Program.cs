using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var petrolPumps = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();
            for (int i = 1; i < petrolPumps; i++)
            {
                var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var amountPetrol = tokens[0];
                var distance = tokens[1];
                queue.Enqueue(amountPetrol - distance);
            }
            var index = 0;
            while (true)
            {
                var difference = new Queue<int>(queue);
                var fuel = int.MinValue;
                while (difference.Any())
                {
                    var currentDiff = difference.Peek();
                    if (currentDiff > 0 && fuel == int.MinValue)
                    {
                        fuel = difference.Dequeue();
                        queue.Enqueue(queue.Dequeue());
                    }
                    else if (currentDiff < 0 && fuel == int.MinValue)
                    {
                        difference.Enqueue(difference.Dequeue());
                        queue.Enqueue(queue.Dequeue());
                        index++;   
                    }
                    else
                    {
                        fuel += difference.Dequeue();
                        if (fuel < 0) break;
                    }
                }
                if (fuel >= 0)
                {
                    Console.WriteLine(index);
                    return;
                }
                index++;
            }
        }
    }
}