using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {             
            string newText = Console.ReadLine();
            string pattern = @"(=|\/)(?<locationm>[A-Z][A-Za-z]{2,})\1";
            int count = 0;
            Regex regex = new Regex(pattern, RegexOptions.Compiled);
            List<string> sequence = new List<string>();
            foreach (Match item in regex.Matches(newText))
            {
                count += item.Groups[2].Length;
                string currDest = item.Groups[2].Value;
                sequence.Add(currDest);
            }
            string dests = string.Join(", ", sequence);
            Console.WriteLine($"Destinations: {dests}");
            Console.WriteLine($"Travel Points: {count}");
        }
    }
}