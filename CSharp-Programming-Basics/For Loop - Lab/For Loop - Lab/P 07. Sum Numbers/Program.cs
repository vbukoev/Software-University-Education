using System;

namespace P_07._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfInputs = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int counter = 0; counter < countOfInputs; counter++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                sum += currentNumber; 
            }
            Console.WriteLine(sum);
        }
    }
}
