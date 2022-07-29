using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Regex numOfPattern = new Regex(@"\d");
            BigInteger threshold = 1;           
            MatchCollection nums = numOfPattern.Matches(input);
            Regex pattern = new Regex(@"(?<chars>[:]{2}|[*]{2})(?<nameOfTheEmoji>[A-Z]{1}[a-z]{2,})\1");
            MatchCollection allEmojis = pattern.Matches(input);
            List<string> coolEmojis = new List<string>();

            foreach (Match match in nums)
            {
                var num = int.Parse(match.Value);
                threshold = threshold * num;
            }           
            foreach (Match item in allEmojis)
            {
                BigInteger cntOfCoolness = 0;
                var itemGroup = item.Groups["nameOfTheEmoji"].Value;
                for (int i = 0; i < itemGroup.Length; i++)
                    cntOfCoolness = cntOfCoolness + (int)itemGroup[i];
                if (cntOfCoolness >= threshold) coolEmojis.Add(item.Value);
            }
            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{allEmojis.Count} emojis found in the text. The cool ones are:");
            Console.WriteLine(string.Join("\n", coolEmojis));
        }
    }
}