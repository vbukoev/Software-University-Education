using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _01BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffee = new Queue<int>();
            Stack<int> milk = new Stack<int>();
            Dictionary<string, int> drinks = new Dictionary<string, int>();
            int[] inputOfTheCoffee = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] inputOfTheMilk = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < inputOfTheCoffee.Length; i++)
            {
                coffee.Enqueue(inputOfTheCoffee[i]);
            }
            for (int i = 0; i < inputOfTheMilk.Length; i++)
            {
                milk.Push(inputOfTheMilk[i]);
            }
            while (true)
            {
                if (!(coffee.Count > 0 && milk.Count > 0)) break;
                var sum = coffee.Peek() + milk.Peek();
                if (sum == 50) // Cortado
                {
                    coffee.Dequeue();
                    milk.Pop();
                    AddingToTheDictionary(drinks, "Cortado");
                }
                else if (sum == 75) // Espresso
                {
                    coffee.Dequeue();
                    milk.Pop();
                    AddingToTheDictionary(drinks, "Espresso");
                }
                else if (sum == 100) // Capuccino
                {
                    coffee.Dequeue();
                    milk.Pop();
                    AddingToTheDictionary(drinks, "Capuccino");
                }
                else if (sum == 150) // Americano
                {
                    coffee.Dequeue();
                    milk.Pop();
                    AddingToTheDictionary(drinks, "Americano");
                }
                else if (sum == 200) // Latte
                {
                    coffee.Dequeue();
                    milk.Pop();
                    AddingToTheDictionary(drinks, "Latte");
                }
                else // default
                {
                    coffee.Dequeue();
                    int decreasedMilk = milk.Pop();
                    milk.Push(decreasedMilk - 5);
                }
            }
            if (coffee.Count > 0 || milk.Count > 0)
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            string coffeeLeft = coffee.Count == 0 ? "none" : String.Join(", ", coffee);
            string milkLeft = milk.Count == 0 ? "none" : String.Join(", ", milk);
            Console.WriteLine($"Coffee left: {coffeeLeft}");
            Console.WriteLine($"Milk left: {milkLeft}");
            var ordered = drinks.OrderBy(x => x.Value).ThenByDescending(x => x.Key);
            foreach (var item in ordered) Console.WriteLine($"{item.Key}: {item.Value}");
        }
        public static void AddingToTheDictionary(Dictionary<string, int> drinks, string input)
        {
            if (drinks.ContainsKey(input)) drinks[input] += 1;
            else drinks.Add(input, 1);
        }
    }
}