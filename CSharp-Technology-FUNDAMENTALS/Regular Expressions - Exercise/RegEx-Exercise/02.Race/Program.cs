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
            Regex patternNamesOfPeople = new Regex(@"(?<name>[A-Za-z]+)");
            string patternDigits = @"(?<numbers>\d+)";
            int sumDigits = 0;
            var people = new Dictionary<string, int>();
            var names = Console.ReadLine().Split(", ").ToList();
            string input = Console.ReadLine();
            while (input != "end of race")
            {
                MatchCollection matchedNames = patternNamesOfPeople.Matches(input);
                MatchCollection matchedDigits = Regex.Matches(input, patternDigits);
                string currName = string.Join("", matchedNames);
                string currDigits = string.Join("", matchedDigits);
                sumDigits = 0;
                for (int i = 0; i < currDigits.Length; i++) 
                { 
                    sumDigits += int.Parse(currDigits[i].ToString()); 
                }
                if (names.Contains(currName))
                {
                    if (!people.ContainsKey(currName))  
                    {
                        people.Add(currName, sumDigits);
                    }
                    else
                    {
                        //updating the curr km of the run
                        people[currName]+=sumDigits;
                    }
                }                
                input = Console.ReadLine();
            }
            //finding the winners of the run
            var winners = people.OrderByDescending(x => x.Value).Take(3);
            var first = winners.Take(1);
            var second = winners.OrderByDescending(x=>x.Value).Take(2).OrderBy(x=>x.Value).Take(1);
            var third = winners.OrderBy(x => x.Value).Take(1);
            foreach (var firstName in first)
            {
                Console.WriteLine($"1st place: {firstName.Key}"); // 1st place
            }
            foreach (var secondName in second)
            {
                Console.WriteLine($"2nd place: {secondName.Key}"); // 2nd place
            }
            foreach (var thirdName in third)
            {
                Console.WriteLine($"3rd place: {thirdName.Key}"); // 3rd place
            }
        }
    }
}
