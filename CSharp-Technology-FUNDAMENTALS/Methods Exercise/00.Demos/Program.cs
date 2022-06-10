using System;

namespace _00.Demos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print(message: "Heist People");
            int a = 5;
            int b = 5;
            int result = SumNumbers(a,b);
            Console.WriteLine(result);
        }
        static void Print(string message)
        {
            Console.WriteLine($"{message}");
        }
        static int SumNumbers(int a, int b)
        {
            int sum = a + b;
            return sum;
        }
    }
}
