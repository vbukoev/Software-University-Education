using System;

namespace P01._Numbers_Ending_in_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //for (int num = 1; num <= 1000; num++)
            //{
            //    if(num % 10 == 7) //the num is ending in 7||Example: 17 / 10 = 1 (mod.7)
            //    {
            //        Console.WriteLine(num);
            //    }
            //}
            for (int i = 7; i <= 997; i += 10)
            {
                Console.WriteLine(i);
            }
            //for (int i = 7; i<=997; i++)
            //{
            //    if (i % 10 == 7)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}
        }
    }
}
