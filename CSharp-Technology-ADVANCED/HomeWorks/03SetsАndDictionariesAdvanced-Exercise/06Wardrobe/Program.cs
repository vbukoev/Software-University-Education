using System;
using System.Collections.Generic;
using System.Linq;

namespace _06Wardrob
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string color = tokens[0];
                var clothes = tokens[1].Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                foreach (var item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color][item] = 1;
                    }
                    else
                    {
                        wardrobe[color][item]++;
                    }
                }                
            }
            var cloth = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var wantedColor = cloth[0];
            var wantedClothes = cloth[1];
            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var item1 in item.Value)
                {
                    if (item.Key == wantedColor && item1.Key == wantedClothes)
                    {
                        Console.WriteLine($"* {item1.Key} - {item1.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item1.Key} - {item1.Value}");
                    }
                }
            }
        }
    }
}
