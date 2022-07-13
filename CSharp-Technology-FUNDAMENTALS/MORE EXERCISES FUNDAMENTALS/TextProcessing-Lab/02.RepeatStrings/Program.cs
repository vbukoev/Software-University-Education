using System;

namespace _02.RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            string res = "";
            
            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    res += word;
                }
            }
            Console.WriteLine(res);
        }
    }
}
