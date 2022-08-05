using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<string>>();
            while (true)
            {
                var comand = Console.ReadLine();
                if (comand == "End") break;
                var tokens = comand.Split(" -> ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = tokens[0];
                string id = tokens[1];
                if (!dictionary.ContainsKey(name)) dictionary.Add(name, new List<string>());
                if (!dictionary[name].Contains(id)) dictionary[name].Add(id);
            }
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key);
                foreach (var emp in item.Value)
                {
                    Console.WriteLine($"-- {emp}");
                }
            }
        }
    }
}
