using System;

namespace _01.Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double quantityFoodInKg = double.Parse(Console.ReadLine()) * 1000;
            double quantityHayInKg = double.Parse(Console.ReadLine()) * 1000;
            double quantityCoverInKg = double.Parse(Console.ReadLine()) * 1000;
            double weightOfPigInKg = double.Parse(Console.ReadLine()) * 1000;

            for (int i = 1; i <= 30; i++)
            {
                quantityFoodInKg -= 300;
                if (i % 2 == 0)
                {
                    quantityHayInKg -= 0.05 * quantityFoodInKg;
                }
                if (i % 3 == 0)
                {
                    quantityCoverInKg -=  weightOfPigInKg/3;
                }
                if (quantityFoodInKg <= 0 || quantityCoverInKg <= 0 || quantityHayInKg <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }
            }
            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {(quantityFoodInKg/1000):f2}, Hay: {(quantityHayInKg/1000):f2}, Cover: {(quantityCoverInKg/1000):f2}.");
        }
    }
}
