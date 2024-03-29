﻿using System;
using System.Linq;

namespace _03CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> check = n => n[0] == n.ToUpper()[0]; // checks the words and gets only   uppercase letter 
            var words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(x=>check(x)).ToArray();// making an array for the upper case letters
            foreach (var word in words) Console.WriteLine(word); 
        }
    }
}
