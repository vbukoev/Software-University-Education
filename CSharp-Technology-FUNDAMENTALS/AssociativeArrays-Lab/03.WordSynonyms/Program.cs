using System;
using System.Collections.Generic;

namespace _03.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cnt = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();
            for (int i = 0; i < cnt; i++)
            {
                string wrd = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (!synonyms.ContainsKey(wrd)) synonyms.Add(wrd, new List<string>());
                synonyms[wrd].Add(synonym);
            }
            foreach (var item in synonyms) Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}"); 
            
        }
    }
}
