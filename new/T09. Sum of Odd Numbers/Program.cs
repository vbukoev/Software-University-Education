using System;

namespace T09._Sum_of_Odd_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfOddNumbers = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < countOfOddNumbers; i++)
            {
                int currOddNumber = 1 + (i * 2);
                Console.WriteLine(currOddNumber);
                sum += currOddNumber;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
