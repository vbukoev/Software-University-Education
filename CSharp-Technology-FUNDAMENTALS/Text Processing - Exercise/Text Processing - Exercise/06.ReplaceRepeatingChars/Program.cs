using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            StringSplitOptions 
            for (int i = 0; i < text.Length - 1; i++)
            {
                char curChar = text[i];
                char next = text[i + 1];
                if (curChar != next) sb.Append(curChar);
                if (i == text.Length - 2) sb.Append(next);                    
            }
            Console.WriteLine(sb);
        }
    }
}
