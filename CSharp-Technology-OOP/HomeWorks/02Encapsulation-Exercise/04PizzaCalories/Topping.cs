using System;
using System.Collections.Generic;
using System.Text;

namespace _04PizzaCalories
{
    public class Topping
    {
        //Meat - 1.2;
        //Veggies - 0.8;
        //Cheese - 1.1;
        //Sauce - 0.9;
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;
        private string type;
        private double grams;
        private double Grams
        {
            set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                grams = value;
            }
        }        
        private string Type
        {
            set
            {
                if (!new List<string> {"meat", "veggies", "cheese", "sauce"}.Contains(value.ToLower()))
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                type = value;
            }
        }
        public double CaloriesPerGram
        {
            get
            {
                double calories = 2;
                switch (type.ToLower())
                {
                    case "meat": calories *= Meat; break;
                    case "veggies": calories *= Veggies; break;
                    case "cheese": calories *= Cheese; break;
                    case "sauce": calories *= Sauce; break;

                }
                return calories;
            }
        }
        public Topping(string type, double grams)
        {
            Type = type;
            Grams = grams; 
        }
        public double GetCalories()
        {
            return grams * CaloriesPerGram;
        }
    }
}
