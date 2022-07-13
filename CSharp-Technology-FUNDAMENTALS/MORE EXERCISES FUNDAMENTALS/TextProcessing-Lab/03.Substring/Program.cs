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
                int startindex = wholeString.IndexOf(subStringToRemove);
                wholeString = wholeString.Remove(startindex, subStringToRemove.Length);

            }
            Console.WriteLine(wholeString);
        }
    }
}
