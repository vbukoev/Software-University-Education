using System;

namespace _01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                string text = Console.ReadLine();
                string reversed = "";
                if (text == "end") break;
                for (int i = text.Length - 1; i >=0 ; i--) reversed += text[i];
                Console.WriteLine($"{text} = {reversed}");
            }            
        }
    }
}
