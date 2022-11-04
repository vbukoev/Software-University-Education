using System;

namespace P05.Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            while (destination != "End")
            {
                double budget= double.Parse(Console.ReadLine());
                double savedMoney = 0;
                while(savedMoney<budget)
                {
                    savedMoney+=double.Parse(Console.ReadLine());
                }
                Console.WriteLine($"Going to {destination}!");
                destination = Console.ReadLine();
            }            
        }
    }
}
