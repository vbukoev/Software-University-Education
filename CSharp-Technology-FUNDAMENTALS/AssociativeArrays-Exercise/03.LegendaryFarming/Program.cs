using System;
using System.Linq;
using System.Collections.Generic;

namespace _03LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, int>();
            dictionary["shards"] = 0;
            dictionary["motes"] = 0;
            dictionary["fragments"] = 0;
            var junks = new Dictionary<string, int>();
            bool isThereAWinner = false;

            while (isThereAWinner != true)
            {
                var tokens = Console.ReadLine().ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int i = 0; i < tokens.Length; i += 2)
                {
                    string type = tokens[i + 1];
                    int quantity = int.Parse(tokens[i]);

                    if (dictionary.ContainsKey(type))
                    {
                        dictionary[type] += quantity;

                        if (dictionary["motes"] >= 250)
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                            dictionary["motes"] -= 250;
                            isThereAWinner = true;
                            break;
                        }
                        else if (dictionary["fragments"] >= 250)
                        {
                            Console.WriteLine("Valanyr obtained!");
                            dictionary["fragments"] -= 250;
                            isThereAWinner = true;
                            break;
                        }
                        else if (dictionary["shards"] >= 250)
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                            dictionary["shards"] -= 250;
                            isThereAWinner = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junks.ContainsKey(type)) junks[type] = quantity;
                        else junks[type] += quantity;
                    }
                }
            }
            foreach (var item in dictionary.Where(kvp => kvp.Value == 0).ToList()) dictionary.Remove(item.Key);
            foreach (var item in junks.Where(kvp => kvp.Value == 0).ToList()) junks.Remove(item.Key);
            foreach (var kvp in dictionary) Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            foreach (var kvp in junks) Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}