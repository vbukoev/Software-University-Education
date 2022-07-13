using System;

namespace _04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] banWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();
            foreach (var bannedWord in banWords)
            {
                string replaced = new string('*', bannedWord.Length);
                text = text.Replace(bannedWord, replaced);
            }
            Console.WriteLine(text);
        }
    }
}
