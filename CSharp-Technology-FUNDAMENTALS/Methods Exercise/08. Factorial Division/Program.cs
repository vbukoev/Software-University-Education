using System;

namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            double result1 = Factoriel(firstNum);
            double result2 = Factoriel(secondNum);
            Console.WriteLine($"{result1/result2:f2}");
        }

        private static double Factoriel(int firstNum)
        {
            double result = 1;
            while (firstNum!=1)
            {
                result *= firstNum;
                firstNum--; 
            }
            return result;
        }
    }
}
