using System;
using System.Collections.Generic;
using System.Linq;

namespace _01BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> guests = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray().Reverse());
            Stack<int> food = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int wastedFoodCounter = 0;
            while (true)
            {
                if (!guests.Any() || !food.Any()) break;
                int currGuest = guests.Pop();
                int currFood = food.Pop();
                currGuest -= currFood;
                if (currGuest <= 0) wastedFoodCounter -= currGuest;
                else guests.Push(currGuest);
            }
            if (food.Any()) Console.WriteLine($"Plates: {string.Join(" ", food)}");
            else Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            Console.WriteLine($"Wasted grams of food: {wastedFoodCounter}");
        }
    }
}