using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _09PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Party!")
                {
                    break;
                }
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string cmd = tokens[0];
                string criteria = tokens[1];
                string value = tokens[2];
                switch (cmd)
                {
                    case "Double":
                        Func<string, bool> filter = GetFilter(criteria, value);
                        var filtered = names.Where(filter).ToList();
                        names.InsertRange(0, filtered);
                        break;
                    case "Remove":
                        Predicate<string> predicate = GetPredicate(criteria, value);
                        names.RemoveAll(predicate);
                        break;
                    default:
                        break;
                }
            }
            if (names.Any()) Console.WriteLine($"{String.Join(", ", names)} are going to the party!");
            else Console.WriteLine("Nobody is going to the party!");
        }

        static Predicate<string> GetPredicate(string criteria, string filter)
        {
            switch (criteria)
            {
                case "StartsWith": return x => x.StartsWith(filter);
                case "EndsWith": return x => x.EndsWith(filter);
                case "Length": return x => x.Length == int.Parse(filter);
                default: return x => true;
            }
        }

        static Func<string, bool> GetFilter(string criteria, string filter)
        {
            switch (criteria)
            {
                case "StartsWith": return x => x.StartsWith(filter);
                case "EndsWith": return x => x.EndsWith(filter);
                case "Length": return x => x.Length == int.Parse(filter);
                default: return x => true;
            }
        }
    }
}

