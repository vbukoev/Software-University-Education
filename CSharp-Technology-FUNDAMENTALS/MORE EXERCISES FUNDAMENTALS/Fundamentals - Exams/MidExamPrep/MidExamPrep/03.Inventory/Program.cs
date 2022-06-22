using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();
            while (command != "Craft!")
            {
                string[] tokens = command.Split(" - ").ToArray();
                string action = tokens[0];
                string item = tokens[1];
                switch (action)
                {
                    case "Collect":
                        if (!journal.Contains(item)) journal.Add(item);
                        break;
                    case "Drop":
                        if (journal.Contains(item)) journal.Remove(item);
                        break;
                    case "Combine Items":
                        string[] splitted = item.Split(":", StringSplitOptions.RemoveEmptyEntries);
                        int index = journal.IndexOf(splitted[0]) + 1;
                        if (journal.Contains(splitted[0])) journal.Insert(index, splitted[1]);
                        break;
                    case "Renew":
                        if (journal.Contains(item))
                        {
                            index = journal.IndexOf(item);
                            journal.Remove(item);
                            journal.Add(item);
                        }
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", journal));
        }
    }
}
