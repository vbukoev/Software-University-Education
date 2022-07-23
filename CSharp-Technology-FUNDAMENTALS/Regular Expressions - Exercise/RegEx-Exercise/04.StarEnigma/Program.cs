using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // num of messages - this is the length of the for loop
            List<string> attackedNames = new List<string>(); 
            List<string> destroyedNames = new List<string>();
            int attacked = 0;
            int destroyed = 0;
            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                Regex regex = new Regex(@"[STARstar]");
                MatchCollection matches = regex.Matches(message);
                StringBuilder decoded = new StringBuilder();
                int sum = 0;
                foreach (Match match in matches) 
                    sum++;
                foreach (var @char in message) 
                    decoded.Append((char)(@char - sum));
                Regex regex1 = new Regex(@"@(?<planet>[A-Za-z]+)[^\@,!:>]*[\-]*:(?<population>\d+)[^\@,!:>]*[\-]*!(?<attakType>[AD])![^\@,!:>]*[\-]*->(?<soldiers>\d+)");
                MatchCollection matches1 = regex1.Matches(decoded.ToString());
                foreach (Match match in matches1)
                {
                    string name = match.Groups["planet"].Value;
                    int popultion = int.Parse(match.Groups["population"].Value);
                    char attackType = char.Parse(match.Groups["attakType"].Value);
                    int soldiers = int.Parse(match.Groups["soldiers"].Value);
                    if (attackType == 'A')
                    {
                        attacked++;
                        attackedNames.Add(name);
                    }
                    if (attackType == 'D')
                    {
                        destroyed++;
                        destroyedNames.Add(name);
                    }
                }                
            }
            Console.WriteLine($"Attacked planets: {attacked}");
            foreach (var kvp in attackedNames.OrderBy(x => x)) 
                Console.WriteLine($"-> {kvp}");
            Console.WriteLine($"Destroyed planets: {destroyed}");
            foreach (var kvp in destroyedNames.OrderBy(x => x)) 
                Console.WriteLine($"-> {kvp}");
        }
    }
}
