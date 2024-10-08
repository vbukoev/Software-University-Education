﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Periodi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var unique = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                var chemicals = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                unique.UnionWith(chemicals);
                //foreach (var item in chemicals) unique.Add(item);
            }
            Console.WriteLine(String.Join(" ", unique));
        }
    }
}
