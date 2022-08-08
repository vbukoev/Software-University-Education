using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> journalList = Console.ReadLine().Split(", ").ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Craft!") break;
                string[] tokens = command.Split(" - ").ToArray();//split with the " - " because we receive actions from the console with the dash sign and interval before and after the dash -> (" - ").
                string item = tokens[1];
                string action = tokens[0];
                switch (action)
                {
                    case "Collect":
                        if (!journalList.Contains(item)) journalList.Add(item);                        
                        break;
                    case "Drop":
                        if (journalList.Contains(item)) journalList.Remove(item);
                        break;
                    case "Combine Items":
                        string[] splitted = item.Split(":");//splitted[0] gets the oldNum and splitted[1] gets the newNum and after that we end up with an index of the (Num(splitted[0]+1)->oldNum + 1 position to the right) 
                        int indexOld = journalList.IndexOf(splitted[0])+1;
                        if (journalList.Contains(splitted[0])) journalList.Insert(indexOld, splitted[1]);
                        break;
                    case "Renew":
                        if (journalList.Contains(item))
                        {
                            journalList.Remove(item);
                            journalList.Add(item);
                        }
                        break;
                }                
            }
            Console.WriteLine(String.Join(", ", journalList));
        }
    }
}
