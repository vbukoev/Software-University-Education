using System;
using System.Collections.Generic;
using System.Linq;

namespace _10ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            var removedNames = new List<string>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Print") break;
                var tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var cmd = tokens[0];
                var filterType = tokens[1];
                var filterParameter = tokens[2];
                switch (cmd)
                {
                    case "Add filter":
                        Predicate<string> predicate = GetPredicate(filterType, filterParameter);
                        removedNames.AddRange(names.Where(x => predicate(x)));
                        names.RemoveAll(predicate);
                        break;
                    case "Remove filter":
                        Func<string, bool> func = GetFunc(filterType, filterParameter);    
                        names.AddRange(removedNames.Where(func));
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(String.Join(" ", names));
        }

        private static Func<string, bool> GetFunc(string filterType, string filterParameter)
        {
            switch (filterType)
            {
                case "Starts with": return x => x.StartsWith(filterParameter);
                case "Ends with": return x => x.EndsWith(filterParameter);
                case "Length": return x => x.Length == int.Parse(filterParameter);
                case "Contains": return x => x.Contains(filterParameter);
                default: return x => true;
            }
        }

        static Predicate<string> GetPredicate(string filterType, string filterParameter)
        {
            switch (filterType)
            {
                case "Starts with": return x => x.StartsWith(filterParameter);
                case "Ends with": return x => x.EndsWith(filterParameter);
                case "Length": return x => x.Length == int.Parse(filterParameter);
                case "Contains": return x => x.Contains(filterParameter);
                default: return x => true;
            }
        }
    }
}
