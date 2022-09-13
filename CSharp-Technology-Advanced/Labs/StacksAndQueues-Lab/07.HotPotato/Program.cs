using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(kids);
            int tosses = 1;
            while (queue.Count > 1)
            {
                string currKid = queue.Dequeue();
                if (tosses == n)
                {
                    Console.WriteLine($"Removed {currKid}");
                    tosses = 1;
                    continue;
                }
                tosses++;
                queue.Enqueue(currKid);
                
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
