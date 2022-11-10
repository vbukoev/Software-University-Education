using System;
using System.Collections.Generic;
namespace _03ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> bag;
        
        public string Name
        {
            get => name;
             set
             {
                ValidateName(value);
                name = value;
             }
        }
        public decimal Money
        {
            get => money;
             set
            {
                ValidateMoney(value);
                money = value;
            }
        }
        public IReadOnlyCollection<Product> Bag { get { return bag.AsReadOnly(); } }
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }
        public void BuyProduct(Product product)
        {
            if (money >= product.Cost)
            {
                Console.WriteLine($"{this.Name} bought {product}");
                money -= product.Cost;
                this.bag.Add(product);
            }
            else Console.WriteLine($"{this.Name} can't afford {product}"); 
        }

        public void ValidateMoney(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
        }

        public void ValidateName(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }
    }
}
