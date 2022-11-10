using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(string.Join("", Console.ReadLine().Split()).ToCharArray());
            Stack<char> consonants = new Stack<char>(string.Join("", Console.ReadLine().Split()).ToCharArray());
            HashSet<string> words = new HashSet<string>(new string[] { "pear", "flour", "pork", "olive" });
            HashSet<char> letters = new HashSet<char>();
            while (true)
            {
                if (!consonants.Any()) break;
                letters.Add(consonants.Pop());
                letters.Add(vowels.Peek());
                vowels.Enqueue(vowels.Dequeue());
            }
            List<string> wordsList = new List<string>();
            foreach (var item in words) if (string.Join("", item.Intersect(letters)) == item) wordsList.Add(item); 
            Console.WriteLine($"Words found: {wordsList.Count} ");
            Console.WriteLine(string.Join(Environment.NewLine, wordsList));
        }
    }
}