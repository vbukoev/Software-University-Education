using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string regex = @">>(?<name>[A-Za-z\s]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";
            var list = new List<string>();
            double total = 0;
            while (input != "Purchase")
            {
                Match matches = Regex.Match(input, regex, RegexOptions.IgnoreCase);
                if (matches.Success)
                {
                    var name = matches.Groups["name"].Value;
                    var price = double.Parse(matches.Groups["price"].Value);
                    var quantity = int.Parse(matches.Groups["quantity"].Value);
                    list.Add(name);
                    total += price*quantity;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            list.ForEach(Console.WriteLine);
            Console.WriteLine($"Total money spend: {total:f2}");
        }
    }
}
