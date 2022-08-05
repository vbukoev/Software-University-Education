using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var info = new Dictionary<string, (int rarity, List<double> rating)>();
            char[] newCharArray = { ':', '-', ' ' };
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
                var cmd = command.Split(newCharArray, StringSplitOptions.RemoveEmptyEntries);
                var action = cmd[0];
                var plant = cmd[1];
                switch (action)
                {
                    case "Rate":
                        Rate(info, cmd, plant);
                        break;
                    case "Update":
                        Update(info, cmd, plant);
                        break;
                    case "Reset":
                        Reset(info, plant);
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in info)
            {
                if (item.Value.rating.Count == 0 || item.Value.rating.Sum()==0)
                {
                    Console.WriteLine($"- {item.Key}; Rarity: {item.Value.rarity}; Rating: 0.00");

                    continue;
                }
                var sumOfTheRatings = item.Value.rating.Sum();
                var countOfTheRatings = item.Value.rating.Count;
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value.rarity}; Rating: {(sumOfTheRatings / countOfTheRatings):f2}"); // total = item.Value.rating.Sum()/item.Value.rating.Count
                // item.Value.rating.Sum => Sum of the ratings
                //item.Value.rating.Count => Count of the ratings
            }
        }

        private static void Reset(Dictionary<string, (int rarity, List<double> rating)> info, string plant)
        {
            if (info.ContainsKey(plant)) info[plant].rating.Clear();
            else Console.WriteLine("error");
        }

        private static void Update(Dictionary<string, (int rarity, List<double> rating)> info, string[] cmd, string plant)
        {
            if (info.ContainsKey(plant))
            {
                var newRarity = int.Parse(cmd[2]);
                info[plant] = (newRarity, info[plant].rating);
            }
            else Console.WriteLine("error");
        }

        private static void Rate(Dictionary<string, (int rarity, List<double> rating)> info, string[] cmd, string plant)
        {
            if (info.ContainsKey(plant))
            {
                var rating = double.Parse(cmd[2]); //Example for why rating is a double number: rating = 1.22; rating = 9.54
                info[plant].rating.Add(rating);
            }
            else Console.WriteLine("error");
        }
    }
}
