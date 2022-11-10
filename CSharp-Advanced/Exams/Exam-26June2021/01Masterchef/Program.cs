using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Masterchef
{
    public class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Dictionary<int, string> meals = new Dictionary<int, string>{
                {150, "Dipping sauce" },
                { 250, "Green salad" },
                { 300, "Chocolate cake" },
                { 400, "Lobster"}
            };
            SortedDictionary<string, int> cookedMeals = new SortedDictionary<string, int>();
            while (true)
            {
                if (!ingredients.Any() || !freshness.Any()) break;

                int currIngridient = ingredients.Dequeue();

                if (currIngridient == 0) continue;
                
                int currFreshness = freshness.Pop();
                int product = currIngridient * currFreshness;

                if (meals.ContainsKey(product))
                {
                    string meal = meals[product];
                    if (!cookedMeals.ContainsKey(meal))
                    {
                        cookedMeals.Add(meal, 0);
                    }
                    cookedMeals[meal]++;
                }
                else  ingredients.Enqueue(currIngridient + 5);
                
            }
            if (cookedMeals.Count>=4) Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            else Console.WriteLine("You were voted off. Better luck next year.");

            if (ingredients.Any()) Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            if (cookedMeals.Count > 0)
            {
                foreach (var item in cookedMeals)
                {
                    Console.WriteLine($" # {item.Key} --> {item.Value}");
                }
            }
        }
    }
}