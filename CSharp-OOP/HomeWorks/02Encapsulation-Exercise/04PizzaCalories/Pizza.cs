using System;
using System.Collections.Generic;
using System.Data;

namespace _04PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string pizzaName, Dough dough)
        {
            this.Name = pizzaName;
            this.dough = dough;
            toppings = new List<Topping>();
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }
        public int Count { get { return toppings.Count; } }
        public double TotalCalories
        {
            get
            {
                double total = dough.GetCalories();
                foreach (var item in toppings)
                {
                    total = total + item.GetCalories();
                }
                return total;
            }
        }
        public void AddTopping(Topping topping)
        {
            if (Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }
        public override string ToString()
        {
            return $"{name} - {TotalCalories:f2} Calories."; 
        }
    }
}