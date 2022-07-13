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
                text = text.Replace(bannedWord, new string('*', bannedWord.Length));           
            Console.WriteLine(text);
        }
    }
}
