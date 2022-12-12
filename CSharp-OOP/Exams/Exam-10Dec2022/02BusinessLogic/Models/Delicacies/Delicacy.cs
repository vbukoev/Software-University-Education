using System;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {
        private string name;
        private double price;

        public Delicacy(string delicacyName, double price)
        {
            Name = delicacyName;
            this.Price = price;
        }

        public string Name
        {
            get=> name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            } 

        }

        public double Price
        {
            get=> price;
            private set
            {
                price = value;
            }
        }

        public override string ToString()
            => $"{Name} - {Price:f2} lv";
    }
}
