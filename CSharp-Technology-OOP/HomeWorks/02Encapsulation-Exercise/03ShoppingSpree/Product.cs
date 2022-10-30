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
        
        public string Name
        {
            get => this.name;
               set
            {
                this.ValidateName(value);
                    name = value;
            }
        }
        public decimal Cost
        {
            get => this.cost;
             set
            {
                this.ValidateMoney(value);
                cost = value;
            }
        }
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public override string ToString()
        {
            return Name;
        }
        public void ValidateName(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }
        public void ValidateMoney(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
        }
    }
}
