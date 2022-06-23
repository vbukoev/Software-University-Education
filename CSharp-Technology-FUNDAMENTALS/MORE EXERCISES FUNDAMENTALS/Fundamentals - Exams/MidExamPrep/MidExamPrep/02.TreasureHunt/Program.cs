using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TreasureHunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> initialLoot = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Yohoho!") break;
                string[] tokens = command.Split();
                string action = tokens[0];
                switch (action)
                {
                    case "Loot":
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            string item = tokens[i];
                            bool isTheItemThere = initialLoot.Contains(tokens[i]);
                            if (!isTheItemThere) initialLoot.Insert(0, item);
                        }
                        break;
                    case "Drop":
                        int index = int.Parse(tokens[1]);
                        if (index >=0 && index < initialLoot.Count)
                        {
                            string removed = initialLoot[index];
                            initialLoot.RemoveAt(index);
                            initialLoot.Add(removed);
                        }
                        break;
                    case "Steal":
                        List<string> stelingList = new List<string>();
                        int count = int.Parse(tokens[1]);
                        count = Math.Min(initialLoot.Count, count);
                        for (int i = initialLoot.Count - count; i < initialLoot.Count; i++) stelingList.Add(initialLoot[i]);
                        Console.WriteLine(string.Join(", ", stelingList));
                        initialLoot.RemoveRange(initialLoot.Count - count, count);
                        break;
                    default:
                        break;
                }                
            }
            if (initialLoot.Count!=0)
            {
                double sum = 0;
                double average = 0;
                foreach (var item in initialLoot) sum += item.Length;
                average = sum / initialLoot.Count;
                Console.WriteLine($"Average treasure gain: {average:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
