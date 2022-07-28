using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var infoAboutCities = new Dictionary<string, (int population, int gold)>();
            var input = "";
            var command = "";
            while (true)
            {
                input = Console.ReadLine();
                if (input == "Sail") break;
                var cmd = input.Split("||");
                var cities = cmd[0];
                int population = int.Parse(cmd[1]);
                int gold = int.Parse(cmd[2]);
                if (infoAboutCities.ContainsKey(cities))
                {
                    int newPopp = infoAboutCities[cities].population + population;
                    int newGold = infoAboutCities[cities].gold + gold;
                    infoAboutCities[cities] = (newPopp, newGold);
                }
                else infoAboutCities.Add(cities, (population, gold));
            }

            while (true)
            {
                command = Console.ReadLine();
                if (command == "End") break;
                var cmd = command.Split("=>");
                var action = cmd[0];
                var town = cmd[1];
                int goldOrPeople = int.Parse(cmd[2]);
                switch (action)
                {
                    case "Plunder":
                        if (infoAboutCities.ContainsKey(town))
                        {
                            int gold = int.Parse(cmd[3]);
                            int newPop = infoAboutCities[town].population - goldOrPeople;
                            int newGold = infoAboutCities[town].gold - gold;
                            if (newGold <= 0 || newPop <= 0)
                            {
                                Console.WriteLine($"{town} plundered! {gold} gold stolen, {goldOrPeople} citizens killed.");
                                Console.WriteLine($"{town} has been wiped off the map!");
                                infoAboutCities.Remove(town);   
                            }
                            else
                            {
                                Console.WriteLine($"{town} plundered! {gold} gold stolen, {goldOrPeople} citizens killed.");
                                infoAboutCities[town] = (newPop, newGold);
                            }
                        }
                        break;
                    case "Prosper":
                        if (infoAboutCities.ContainsKey(town))
                        {
                            int newGold = infoAboutCities[town].gold + goldOrPeople;
                            if (goldOrPeople < 0) Console.WriteLine($"Gold added cannot be a negative number!");
                            else
                            {
                                Console.WriteLine($"{goldOrPeople} gold added to the city treasury. {town} now has {newGold} gold.");
                                infoAboutCities[town] = (infoAboutCities[town].population, newGold);
                            }
                        }
                            break;
                    default:
                        break;
                }
            }
            var cnt = infoAboutCities.Count;
            Console.WriteLine($"Ahoy, Captain! There are {cnt} wealthy settlements to go to:");
            foreach (var item in infoAboutCities)
                Console.WriteLine($"{item.Key} -> Population: {item.Value.population} citizens, Gold: {item.Value.gold} kg");
        }
    }
}
