using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            var ordersQuantity = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var queue = new Queue<int>(ordersQuantity);
            int biggest = queue.Max(); //this represents the biggest order 
            while (queue.Any()) // while there are left in the queue
            {
                int currOrder = queue.Peek(); // currentOrder
                if (quantity - currOrder >= 0) 
                {
                    quantity -= currOrder; // from the whole quantity of the food we remove the currOrder
                    queue.Dequeue(); // and then dequeue the queue 
                }
                else
                {
                    break; // if quantity - currOrder < 0 (there are no more left in the queue)-> we continue with the printing on the console 
                }
            }
            
            Console.WriteLine(biggest);
            if (queue.Count==0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
