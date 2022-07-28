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
            MatchCollection emoji = pattern.Matches(input);
            List<string> coolEmojios = new List<string>();

            foreach (Match match in nums)
            {
                var num = int.Parse(match.Value);
                threshold = threshold * num;
            }           
            foreach (Match item in emoji)
            {
                BigInteger cntOfCoolness = 0;
                var itemGroup = item.Groups["nameOfTheEmoji"].Value;
                for (int i = 0; i < itemGroup.Length; i++)
                    cntOfCoolness = cntOfCoolness + (int)itemGroup[i];
                if (cntOfCoolness >= threshold) coolEmojios.Add(item.Value);
            }
            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{emoji.Count} emojis found in the text. The cool ones are:");
            Console.WriteLine(string.Join("\n", coolEmojios));
        }
    }
}