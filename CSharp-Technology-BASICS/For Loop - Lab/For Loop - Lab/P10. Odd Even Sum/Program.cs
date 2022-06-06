using System;

namespace P10._Odd_Even_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfInputs = int.Parse(Console.ReadLine());
            int evenSum = 0;
            int oddSum = 0;

            for (int counter = 1; counter <= countOfInputs; counter++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (counter % 2 == 0)
                {
                    evenSum += currentNumber;
                }
                else
                {
                    oddSum += currentNumber;
                }
            }
            if (evenSum == oddSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {evenSum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(evenSum - oddSum)}");
            }









            //int n = int.Parse(Console.ReadLine());
            //int oddSum = 0;
            //int evenSum = 0;
            //for (int i = 0; i <= n; i++)
            //{
            //    int element = int.Parse(Console.ReadLine());
            //    if (i % 2 == 0) evenSum += element;
            //    else oddSum += element;
            //}
            //if (evenSum == oddSum)
            //{
            //    Console.WriteLine("Yes");
            //    Console.WriteLine($"Sum = {evenSum + oddSum}");
            //}
            //else
            //{
            //    Console.WriteLine("No");
            //    Console.WriteLine($"Diff = {Math.Abs(evenSum - oddSum)}");
            //}
        }
    }
}
