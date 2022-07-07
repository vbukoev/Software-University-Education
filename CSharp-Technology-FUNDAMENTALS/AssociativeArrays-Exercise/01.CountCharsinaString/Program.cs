using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountCharsinaString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> chars = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    if (chars.ContainsKey(input[i])) chars[input[i]]++;
                    else chars.Add(input[i], 1);
                }
                else continue;
            }
            chars.OrderByDescending(@char => @char.Value);
            foreach (var newChar in chars) Console.WriteLine($"{newChar.Key} -> {newChar.Value}");            
        }
    }
}