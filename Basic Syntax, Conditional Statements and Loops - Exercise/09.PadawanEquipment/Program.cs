using System;

namespace _09.PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int studentsCnt = int.Parse(Console.ReadLine());
            double priceOfSaber = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            double totalNumOfSabers = Math.Ceiling(studentsCnt * 1.1);
            double numberOfFreeBelts = Math.Floor(studentsCnt / 6.0);

            double finalPriceForSabers = totalNumOfSabers * priceOfSaber;
            double finalPriceForRobes = studentsCnt * priceOfRobes;
            double finalPriceForBelts = (studentsCnt - numberOfFreeBelts)*priceOfBelts;
            double totalFinalPrice = finalPriceForSabers + finalPriceForRobes + finalPriceForBelts;

            if (budget >= totalFinalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalFinalPrice:f2}lv.");
            }
            else
            {
                double moneyNeeded = Math.Abs(totalFinalPrice - budget);
                
               Console.WriteLine($"John will need {moneyNeeded:f2}lv more.");
            }
        }
    }
}
