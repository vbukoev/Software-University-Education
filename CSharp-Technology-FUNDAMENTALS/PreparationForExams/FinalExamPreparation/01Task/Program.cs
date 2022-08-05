using System;
using System.Text.RegularExpressions;

namespace _01Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"([#|])([A-Za-z ]+)\1([\d]{2}\/[\d]{2}\/[\d]{2})\1([0-9]+)\1");
            string cmd = Console.ReadLine();
            MatchCollection matches = pattern.Matches(cmd);
            int total = 0;
            foreach (Match m in matches)
            {
                int value = int.Parse(m.Groups[4].Value);
                total += value;
            }
            Console.WriteLine($"You have food to last you for: {total/2000} days!");
            foreach (Match match in matches) Console.WriteLine($"Item: {match.Groups[2].Value}, Best before: {match.Groups[3].Value}, Nutrition: {match.Groups[4].Value}");
            
        }
    }
}