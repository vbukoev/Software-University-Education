using System;

namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string subStringToRemove = Console.ReadLine();
            string wholeString = Console.ReadLine();
            while (wholeString.Contains(subStringToRemove))
            {
                int startIndex = wholeString.IndexOf(subStringToRemove);
                wholeString = wholeString.Remove(startIndex, subStringToRemove.Length);
                
            }
            Console.WriteLine(wholeString);
        }
    }
}
