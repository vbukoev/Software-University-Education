using System;

namespace _05.Digits_LettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string digits = "";
            string letters = "";
            string others = "";
            foreach (var item in text)
            {
                if (char.IsLetter(item)) letters += item;
                else if (char.IsDigit(item)) digits += item;
                else others += item;

            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
