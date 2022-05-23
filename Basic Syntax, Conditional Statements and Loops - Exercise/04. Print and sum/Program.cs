using System;

namespace _04._Print_and_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int sum = 0;
            for (int value = start; value <= end; value++)
            {
                Console.Write($"{value} ");
                sum += value;
            }

            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
