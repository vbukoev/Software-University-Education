using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, int>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "stop") break;
                int quantity = int.Parse(Console.ReadLine());
                if (!dictionary.ContainsKey(input)) dictionary[input] = quantity;
                else dictionary[input] += quantity;
            }
            foreach (var item in dictionary) Console.WriteLine($"{item.Key} -> {item.Value}");
        }
    }
}
