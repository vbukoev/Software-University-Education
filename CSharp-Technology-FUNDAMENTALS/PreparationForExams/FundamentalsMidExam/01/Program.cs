using System;

namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfCities = int.Parse(Console.ReadLine());
            double profit = 0;
            double totalProfit = 0;
            int tripCnt = 0;


            for (int i = 0; i < numOfCities; i++)
            {
                string nameOfTheCity = Console.ReadLine();
                double ownerIncome = double.Parse(Console.ReadLine());
                double ownerExpenses = double.Parse(Console.ReadLine());
                tripCnt++;
                if (tripCnt % 15 == 0 || tripCnt % 5 == 0) ownerIncome -= 0.1 * ownerIncome;
                else if (tripCnt % 3 == 0) ownerExpenses += 0.5 * ownerExpenses;
                profit = ownerIncome - ownerExpenses;
                totalProfit = profit + totalProfit;
                Console.WriteLine($"In {nameOfTheCity} Burger Bus earned {profit:f2} leva.");
            }
                
            
            Console.WriteLine($"Burger Bus total profit: {totalProfit:f2} leva.");
        }
    }
}
//              100/100