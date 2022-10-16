using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01Cooking
{
    public class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray());
            Dictionary<int, string> foods = new Dictionary<int, string>()
            {
                { 25, "Bread" },
                { 50, "Cake"},
                { 75, "Pastry"},
                { 100, "Fruit Pie"}
            };
            SortedDictionary<string, int> cooked = new SortedDictionary<string, int>();
            foreach (var item in foods) cooked.Add(item.Value, 0);
            while (true)
            {
                if (!liquids.Any() || !ingredients.Any()) break;

                int liquid = liquids.Dequeue();
                int ingredient = ingredients.Pop();
                int sum = liquid + ingredient;
                if (foods.ContainsKey(sum))
                {
                    string food = foods[sum];
                    cooked[food]++;
                }
                else ingredients.Push(ingredient + 3);

            }
            if (cooked.Where(x => x.Value > 0).Count() == 4) Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            else Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");

            if (!liquids.Any()) Console.WriteLine("Liquids left: none");
            else Console.WriteLine($"Liquids left: {string.Join(", ",  liquids)}");
            if (!ingredients.Any()) Console.WriteLine("Ingredients left: none");
            else Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            foreach (var item in cooked) Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}