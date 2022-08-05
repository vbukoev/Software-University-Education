using System;
using System.Collections.Generic;

namespace _03.PlantDiscovery
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var info = new Dictionary<string, (int rarity, List<double> rating)>();
            for (int i = 0; i < n; i++)
            {
                var cmd = Console.ReadLine().Split("<->");
                var plant = cmd[0];
                var rarity = int.Parse(cmd[1]);
                if (info.ContainsKey(plant))
                {
                    var newRarity = info[plant].rarity + rarity;
                    info[plant] = (newRarity, new List<double>());
                    continue;
                }
                info.Add(plant, (rarity, new List<double>()));
            }            
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "Exhibition") break;

            }
        }
    }
}
