using System;

namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int times = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatString(input, times));

        }
        static string RepeatString(string input, int times)
        {
            string result = String.Empty;
            for (int i = 0; i < times; i++)
            {
                result += input; 
            }

            return result;
        }
    }
}
