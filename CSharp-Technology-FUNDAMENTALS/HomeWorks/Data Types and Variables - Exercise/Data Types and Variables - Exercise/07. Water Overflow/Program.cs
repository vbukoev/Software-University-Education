using System;

namespace _07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());
            const int CAPACITY = 255;
            int totalQuantity = CAPACITY;
            for (int i = 0; i < numOfLines; i++)
            {
                int currQuantity = int.Parse(Console.ReadLine());
                if (totalQuantity - currQuantity >= 0)
                {
                    totalQuantity -= currQuantity;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            int totalFilledQuantity = CAPACITY - totalQuantity;
            Console.WriteLine(totalFilledQuantity);
        }
    }
}
