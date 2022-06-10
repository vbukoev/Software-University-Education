using System;

namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int addedResult = Add(num1, num2);
            int finalResult=Substract(addedResult, num3);
            PrintResult(finalResult);
        }
        private static int Add(int num1, int num2) => num1 + num2;

        private static int Substract(int result, int num3) => result-num3;

        private static void PrintResult(int number) => Console.WriteLine(number);
    }
}
