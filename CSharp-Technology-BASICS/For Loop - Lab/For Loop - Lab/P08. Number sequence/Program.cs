using System;

namespace P08._Number_sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int smallest = int.MaxValue;
            int biggest  = int.MinValue;
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i<n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < smallest) smallest = num;
                if (num>biggest) biggest = num;
            }
            Console.WriteLine($"Max number: {biggest}");
            Console.WriteLine($"Min number: {smallest}");
        }
    }
}
