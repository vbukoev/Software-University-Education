using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patternNamesOfPeople = new Regex(@"(?<name>[A-Za-z]+)(?<numbers>\d+)");
            string patternDigits = new Regex(@"?<digits>\d+");
            int sumDigits = 0;
            var people = new Dictionary<string, int>();
            var names = Console.ReadLine().Split(", ").ToList();
            string input = Console.ReadLine();
            while (input !=  "end of race")
            {
                MatchCollection matchedNames = patternNamesOfPeople.Matches(input);
                MatchCollection matchedDigits = Regex.Matches(input, patternDigits);
                string currName = string.Join("", matchedNames);
                string currDigits = string.Join("", matchedDigits);
                sumDigits = 0;
                input = Console.ReadLine();
            }

        }
    }
}
