using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End") break;
                string[] tokens = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                switch (action)
                {
                    case "Add":
                        string phone = tokens[1];
                        if (!list.Contains(phone)) list.Add(phone);                        
                        break;
                    case "Remove":
                        phone = tokens[1];
                        if (list.Contains(phone)) list.Remove(phone);                        
                        break;
                    case "Bonus phone":
                        string[] splitted = tokens[1].Split(":");
                        string oldOne = splitted[0];
                        string newOne = splitted[1];
                        int index = list.IndexOf(oldOne);
                        if (list.Contains(oldOne)) list.Insert(index + 1, newOne);
                        break;
                    case "Last":
                        phone = tokens[1];
                        index = list.IndexOf(phone);
                        if (list.Contains(phone))
                        {
                            list.Add(phone);
                            list.RemoveAt(index);
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
// 100 / 100