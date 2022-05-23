using System;

namespace T11._Multiplication_Table_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
           while (true)
            {
               int num = int.Parse(Console.ReadLine());
                if (num % 2 == 0)
                {
                    Console.WriteLine($"The number is: {Math.Abs(num)}");
                    break;
                }
                else
                {
                    Console.WriteLine("Please write an even number.");
                }
            }
        }
    }
}