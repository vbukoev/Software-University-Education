using System;

namespace _04PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
			try
			{
				string pizzaName = Console.ReadLine().Split()[1];
				string[] input = Console.ReadLine().Split();
				string flour = input[1];
				string baking = input[2];
				double grams = double.Parse(input[3]);
				Dough dough = new Dough(flour, baking, grams);
				Pizza pizza = new Pizza(pizzaName, dough);
				while (true)
				{
					string cmd = Console.ReadLine();
					if (cmd == "END") break;
					string type = cmd.Split()[1];
					double toppingGrams = double.Parse(cmd.Split()[2]);
					Topping top = new Topping(type, toppingGrams);
					pizza.AddTopping(top);
				}
				Console.WriteLine(pizza);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
        }
    }
}
