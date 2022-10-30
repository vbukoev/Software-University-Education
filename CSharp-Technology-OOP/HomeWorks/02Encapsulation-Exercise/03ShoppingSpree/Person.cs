using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace _03ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> bag;
        public Person(string name, decimal money)
        {
            this.name = name;
            this.money = money;
            this.bag = new List<Product>();
        }
        public string Name
        {
            get => name;
            private set
            {
                ValidateName(value);
                name = value;
            }
        }
        public decimal Money
        {
            get => money;
            private set
            {
                ValidateMoney(value);
                money = value;
            }
        }
        public IReadOnlyCollection<Product> Bag { get { return bag.AsReadOnly(); } }
        public void BuyProduct(Product product)
        {
            if (money >= product.Cost)
            {
                Console.WriteLine($"{this.Name} bought {product}");
                money -= product.Cost;
                bag.Add(product);
            }
            else Console.WriteLine($"{this.Name} can't afford {product}"); 
        }

        private void ValidateMoney(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.NegativeMoneyException);
            }
        }

        private void ValidateName(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NullOrEmptyNameException);
            }
        }
    }
}
