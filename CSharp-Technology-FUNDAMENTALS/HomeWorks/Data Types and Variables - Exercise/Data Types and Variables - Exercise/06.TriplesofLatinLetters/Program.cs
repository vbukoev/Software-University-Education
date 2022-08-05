using System;

namespace _06.TriplesofLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nInteger = int.Parse(Console.ReadLine());

            for (char a = 'a'; a < 'a' + nInteger; a++)
            {
                for (char b = 'a'; b < 'a' + nInteger; b++)
                {
                    for (char c = 'a'; c < 'a' + nInteger; c++)
                    {
                        Console.WriteLine($"{a}{b}{c}");
                    }
                }
            }
        }
    }
}
