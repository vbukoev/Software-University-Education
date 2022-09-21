using System;
using System.Collections.Generic;
using System.Linq;

namespace _05CountSy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = new Dictionary<char, int>();
            var input = Console.ReadLine();
            foreach (var character in input)
            {
                if (!text.ContainsKey(character))
                {
                    text[character] = 1;
                }
                else
                {
                    text[character]++;
                }
            }
            foreach (var item in text.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
