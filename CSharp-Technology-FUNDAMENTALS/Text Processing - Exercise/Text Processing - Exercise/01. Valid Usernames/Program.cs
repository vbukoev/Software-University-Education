using System;
using System.Linq;

namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(", ").ToArray();
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                bool isValid = false;
                if (word.Length >= 3 && word.Length <= 16)
                {
                    for (int j = 0; j < word.Length; j++)
                    {
                        char currChar = word[j];
                        if (char.IsLetterOrDigit(currChar) || currChar == '-' || currChar == '_') isValid = true;
                        else break;                        
                    }
                }
                if (isValid) Console.WriteLine(word);
            }
        }
    }
}
