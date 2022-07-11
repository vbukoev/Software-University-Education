using System;
using System.Linq;

namespace _02.CharacterMultiplirt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(" ").ToArray();
            string firstWord = words[0];
            string secondWord = words[1];
            int total = CharacterMultiplirt(firstWord, secondWord);
            Console.WriteLine(total);
        }

        private static int CharacterMultiplirt(string firstWord, string secondWord)
        {
            int total = 0;
            if (firstWord.Length == secondWord.Length)
            {
                for (int i = 0; i < firstWord.Length; i++)
                {
                    int multiply = firstWord[i] * secondWord[i];
                    total = total + multiply;
                }
            }
            else
            {
                if (firstWord.Length > secondWord.Length)
                {
                    for (int i = 0; i < secondWord.Length; i++)
                    {
                        int multiply = firstWord[i] * secondWord[i];
                        total = total + multiply;
                    }
                    for (int i = secondWord.Length; i < firstWord.Length; i++) total = total + firstWord[i];
                }
                else if (firstWord.Length < secondWord.Length) {
                    for (int i = 0; i < firstWord.Length; i++)
                    {
                        int multiply = firstWord[i] * secondWord[i];
                        total = total + multiply;
                    }
                    for (int i = firstWord.Length; i < secondWord.Length; i++)
                    {
                        total = total + secondWord[i];
                    }
                }
                    
            }
            return total;
        }
    }
}
