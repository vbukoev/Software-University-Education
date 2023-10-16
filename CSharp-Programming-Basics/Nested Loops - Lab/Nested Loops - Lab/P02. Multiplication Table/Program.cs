using System;

namespace P02._Multiplication_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //for (int x = 1; x <= 10; x++)
            //{
            //    for (int y = 1; y <= 10; y++)
            //    {
            //        int product = x * y;
            //        Console.WriteLine($"{x} * {y} = {product}");
            //    }
            //}

            for (int  x = 1;  x <= 10 ; x++)
            {
                for (int y = 0; y <= 10; y++)
                {
                    Console.WriteLine($"{x} * {y} = {x * y}");
                }   
            }
        }
    }
}
