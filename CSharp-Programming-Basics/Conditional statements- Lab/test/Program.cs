using System;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double ceilingNumber = Math.Ceiling(45.65);
            double flooredNumber = Math.Floor(44.3);
            int absoluteValueOfNumber = Math.Abs(-100);
            Console.WriteLine(ceilingNumber);
            Console.WriteLine(flooredNumber);
            Console.WriteLine(absoluteValueOfNumber);
            absoluteValueOfNumber = Math.Abs(100);
            Console.WriteLine(absoluteValueOfNumber);
            double roudn = Math.Round(123.67852, 2);
            Console.WriteLine(roudn);
            Console.WriteLine($"{123.456:F2}");
        }
    }
}
