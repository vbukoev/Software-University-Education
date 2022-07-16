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
            for (int i = 0; i < text.Length; i++)
            {
                char encryptedChar = (char)(text[i] + 3);
                sb.Append(encryptedChar);
            }
            //the same way but with foreach 
            //vvvvvvvvvv
            //foreach (var item in text)
            //{
            //    char encrypted = (char)(item + 3);
            //    sb.Append(encrypted);   
            //}
            Console.WriteLine(sb);
            
        }
    }
}
