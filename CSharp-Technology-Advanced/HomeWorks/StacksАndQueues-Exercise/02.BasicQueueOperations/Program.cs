using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cmdNums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int elementToEnqueue = cmdNums[0];
            int elementToDequeue = cmdNums[1];
            int elementToLookFor = cmdNums[2];

            var queue = new Queue<int>();

            for (int i = 0; i < elementToEnqueue; i++)
            {
                queue.Enqueue(input[i]);
            }
            for (int i = 0; i < elementToDequeue; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(elementToLookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Any())
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
