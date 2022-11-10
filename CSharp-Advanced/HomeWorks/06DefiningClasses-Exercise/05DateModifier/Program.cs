using System;

namespace _05DateModifier
{
    public class StartUp
    {
        public static void Main()
        {
            string firstDay = Console.ReadLine();
            string secondDay = Console.ReadLine();
            Console.WriteLine(DateModifier.GetDaysBetweenDates(firstDay, secondDay));
        }
    }
}
