using System;
using System.Collections.Generic;
using System.Linq;

namespace _01BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Dictionary<string, int> bakedProducts = new Dictionary<string, int>();

            while (true)
            {
                if (water.Count == 0 || flour.Count == 0) break;
                double currWater = water.Dequeue();
                double currFlour = flour.Pop();
                double percentsRatio = ((currWater) / (currWater + currFlour)) * 100;
                switch (percentsRatio)
                {
                    case 50:
                        if (!bakedProducts.ContainsKey("Croissant")) bakedProducts.Add("Croissant", 0);
                       
                        bakedProducts["Croissant"]++;

                        break;
                    case 40:
                        if (!bakedProducts.ContainsKey("Muffin")) bakedProducts.Add("Muffin", 0);

                        bakedProducts["Muffin"]++;

                        break;
                    case 30:
                        if (!bakedProducts.ContainsKey("Baguette")) bakedProducts.Add("Baguette", 0);

                        bakedProducts["Baguette"]++;

                        break;
                    case 20:
                        if (!bakedProducts.ContainsKey("Bagel")) bakedProducts.Add("Bagel", 0);
                        bakedProducts["Bagel"]++;
                        break;

                    default:
                        if (!bakedProducts.ContainsKey("Croissant")) bakedProducts.Add("Croissant", 0); 

                        bakedProducts["Croissant"]++;

                        if (currFlour>currWater) flour.Push(currFlour - currWater);
                        break;
                }                
            }
            foreach (var successfullyBakedProduct in bakedProducts.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key)) //products, successfully baked
            {
                Console.WriteLine($"{successfullyBakedProduct.Key}: {successfullyBakedProduct.Value}");
            }
            if (water.Count<=0) Console.WriteLine("Water left: None");
            else Console.WriteLine($"Water left: {string.Join(", ", water)}");
            if (flour.Count<=0) Console.WriteLine("Flour left: None");
            else Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
        }
    }
}
