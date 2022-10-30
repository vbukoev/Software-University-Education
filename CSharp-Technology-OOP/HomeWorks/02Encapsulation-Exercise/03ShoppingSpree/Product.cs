using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _03ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public string Name
        {
            get => this.name;
                private set
            {
                this.ValidateName(value);
                    name = value;
            }
        }
        public decimal Cost
        {
            get => this.cost;
            private set
            {
                this.ValidateMoney(value);
                cost = value;
            }
        }
        public override string ToString()
        {
            return Name;
        }
        private void ValidateName(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NullOrEmptyNameException);
            }
        }
        private void ValidateMoney(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.NegativeMoneyException);
            }
        }
    }
}
