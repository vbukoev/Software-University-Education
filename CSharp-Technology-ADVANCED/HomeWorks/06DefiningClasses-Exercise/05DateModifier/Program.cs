using System;

namespace _05DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string sec   = Console.ReadLine();
            Console.WriteLine(DateModifier.GetDaysBetweenDates(first, sec));

        }
    }
}
