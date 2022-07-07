using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = tokens[0];
                switch (action)
                {
                    case "register":
                        string username = tokens[1];
                        string license = tokens[2];
                        if ((!dictionary.ContainsKey(username)) || (!dictionary.ContainsValue(license)))
                        {
                            dictionary.Add(username, license);
                            Console.WriteLine($"{username} registered {license} successfully");
                        }
                        else Console.WriteLine($"ERROR: already registered with plate number {license}");  
                    break; 
                    case "unregister":
                        username = tokens[1];
                        if (!dictionary.ContainsKey(username)) Console.WriteLine($"ERROR: user {username} not found");
                        else
                        {
                            dictionary.Remove(username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }
                    break;
                    default:
                        break;
                }
            }
            foreach (var item in dictionary) Console.WriteLine($"{item.Key} => {item.Value}");
        }
    }
}
