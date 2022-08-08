using System;

namespace _01._Day_of_Week
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dayOfWeek = int.Parse(Console.ReadLine());
            string[] weekDays =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            if (dayOfWeek >= 1 && dayOfWeek <= 7)
            {
                Console.WriteLine(weekDays[dayOfWeek-1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }            
        }
    }
}