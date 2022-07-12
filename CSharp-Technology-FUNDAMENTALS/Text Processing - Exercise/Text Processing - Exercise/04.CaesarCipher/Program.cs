using System;
using System.Text;

namespace _04.CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb  =new StringBuilder();
            foreach (var item in text)
            {
                char encrypted = (char)(item + 3);
                sb.Append(encrypted);   
            }
            Console.WriteLine(sb);
        }
    }
}
