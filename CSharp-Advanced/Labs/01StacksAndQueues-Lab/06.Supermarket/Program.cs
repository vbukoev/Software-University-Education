using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var queue = new Queue<string>();
            int peopleCnt = 0;
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End") break;
                if (input == "Paid")
                {
                    while (queue.Any())
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                    peopleCnt = 0;

                }
                else
                {
                    queue.Enqueue(input);
                    peopleCnt++;
                }                
            }
            Console.WriteLine($"{peopleCnt} people remaining.");
        }
    }
}
