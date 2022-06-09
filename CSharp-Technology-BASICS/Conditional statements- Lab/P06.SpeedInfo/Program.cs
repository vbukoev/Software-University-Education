using System;

namespace P06.SpeedInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            double v = double.Parse(Console.ReadLine());
            //act
            if (v <= 10)
            {
                Console.WriteLine("slow");
            }
            if ((v > 10) && (v <= 50))
            {
                Console.WriteLine("average");
            }
            if ((v > 50) && (v <= 150))
            {
                Console.WriteLine("fast");
            }
            if ((v > 150) && (v <= 1000))
            {
                Console.WriteLine("ultra fast");
            }
            if (v > 1000)
            {
                Console.WriteLine("extremely fast");
            }
        }
    }
}
