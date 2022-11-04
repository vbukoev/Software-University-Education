using System;
using System.Collections.Generic;
using System.Linq;

namespace _01MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            var cntOfMeals = meals.Count; //constant int which is going to save the count of the meals which are as an input beacuse after that if I use "meals.Count" variable it will no longer have the same value
            Stack<int> target = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            int cnt = 0;
            while (true)
            {
                if (meals.Count <= 0 || target.Sum() <= 0) break;
                int currCalories = target.Peek();
                string currMeal = meals.Peek();
                switch (currMeal)
                {
                    case "salad":
                        currCalories -= 350;
                        break;
                    case "soup":
                        currCalories -= 490;
                        break;
                    case "pasta":
                        currCalories -= 680;
                        break;
                    case "steak":
                        currCalories -= 790;
                        break; 
                }
                if (currCalories > 0)
                {
                    target.Pop();
                    target.Push(currCalories);
                }
                else // if calories are below or equal to 0
                {
                    target.Pop();
                    if (target.Count<1)
                    {
                        cnt++;
                        meals.Dequeue();
                        break;
                    }
                    int previousCalories = Math.Abs(currCalories);
                    int sum = target.Peek() - previousCalories;
                    target.Pop();
                    target.Push(sum);
                }
                meals.Dequeue();
                cnt++;
            }
            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {cntOfMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", target)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {cnt} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
