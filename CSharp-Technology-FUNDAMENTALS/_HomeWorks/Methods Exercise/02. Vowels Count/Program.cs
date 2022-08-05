using System;
using System.Linq;

namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            VowelsCount(word);
        }

        static void VowelsCount(string text)
        {
            int cnt = 0;
            //Console.WriteLine(text.Count(vowels=>"aouei".Contains(vowels)));
            foreach (char vowel in text)
            {
                if ("aouei".Contains(vowel))
                {
                    cnt++;
                }
            }
            Console.WriteLine(cnt);
        }
        //static void VowelsCount(string word)
        //{
        //    int totalVowels = 0; 
        //    word = word.ToLower() ;
        //    for (int i = 0; i < word.Length; i++)
        //    {
        //        if (word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u')
        //        {
        //            totalVowels++;
        //        }
        //    }
        //    Console.WriteLine(totalVowels);
        //}
    }
}
