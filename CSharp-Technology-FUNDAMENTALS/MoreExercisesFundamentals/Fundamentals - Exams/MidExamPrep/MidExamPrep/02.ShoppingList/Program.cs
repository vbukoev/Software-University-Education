using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> initialList = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Go Shopping!") break;
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];

                switch (action)
                {
                    case "Urgent":
                        string item = tokens[1];
                        if (!initialList.Contains(item)) initialList.Insert(0, item);                      
                        break;
                    case "Unnecessary":
                        string unnecessary = tokens[1];
                        if (initialList.Contains(unnecessary)) initialList.Remove(unnecessary);                    
                        break;
                    case "Correct":
                        string oldItem = tokens[1];
                        string newItem = tokens[2];
                        
                        for (int i = 0; i < tokens.Length; i++)
                        {
                            bool isTheItemThere = initialList.Contains(oldItem);
                            if (isTheItemThere)
                            {
                                int indexOfTheOldItem = initialList.IndexOf(oldItem);
                                initialList.Insert(indexOfTheOldItem, newItem);
                                initialList.Remove(oldItem);
                            }
                        }
                        break;
                    case "Rearrange":
                        string rearange = tokens[1];
                        if (initialList.Contains(rearange))
                        {
                            initialList.Remove(rearange);
                            initialList.Add(rearange);
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", initialList));
        }
    }
}
