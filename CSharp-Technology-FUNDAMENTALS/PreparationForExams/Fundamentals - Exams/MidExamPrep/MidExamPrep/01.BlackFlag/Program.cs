using System;

namespace _01.BlackFlag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysOfPlunder = int.Parse(Console.ReadLine());
            double dailyPlunder = double.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());
            double totalPlunder = 0;
            for (int day = 1; day <= daysOfPlunder; day++)
            {
                totalPlunder += dailyPlunder;
                if (day % 3 == 0)
                {
                    totalPlunder += dailyPlunder / 2;
                }
                if (day % 5 == 0)
                {
                    totalPlunder *= 0.7;
                }
            }
            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                double left = totalPlunder/expectedPlunder;
                double percentageLeft = left * 100;
                Console.WriteLine($"Collected only {percentageLeft:f2}% of the plunder.");
            }
        }
    }
}
