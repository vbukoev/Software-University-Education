using System;

namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string subStringToRemove = Console.ReadLine();
            string wholeString = Console.ReadLine();
            while (wholeString.Contains(subStringToRemove)) wholeString = wholeString.Replace(subStringToRemove, String.Empty);
            Console.WriteLine(wholeString);
        }
    }
}
