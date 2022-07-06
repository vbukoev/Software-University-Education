using System;
using System.Collections.Generic;

namespace _02.OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Dictionary<string, int> cnt = new Dictionary<string, int>();
            foreach (var item in words)
            {
                string wordInLCase = item.ToLower();
                if (cnt.ContainsKey(wordInLCase)) cnt[wordInLCase]++;
                else cnt.Add(wordInLCase, 1);                
            }
            foreach (var item1 in cnt)  
                if (item1.Value % 2 != 0) Console.Write(item1.Key + " ");
        }
    }
}
