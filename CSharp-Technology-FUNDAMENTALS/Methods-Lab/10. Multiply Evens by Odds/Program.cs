using System;

namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);

            int evenSum = GetSumOfEvenDigits(number);
            int oddSum = GetSumOfOddDigits(number);
            int result = GetMultipleOfEvenAndOddSum(evenSum, oddSum);
            Console.WriteLine(result);
        }
        static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;
            int digit = number;
            while (digit > 0)
            {
                int currDigit = digit % 10;
                if (currDigit % 2 == 0)
                {
                    sum += currDigit;
                }

                digit /= 10;
            }
            return sum;
        }
        static int GetSumOfOddDigits(int number)
        {
            int sum = 0;
            int digit = number;
            while (digit > 0)
            {
                int currDigit = digit % 10;
                if (currDigit % 2 != 0)
                {
                    sum += currDigit;
                }

                digit /= 10;
            }
            return sum;
        }
        static int GetMultipleOfEvenAndOddSum(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }
    }
}
