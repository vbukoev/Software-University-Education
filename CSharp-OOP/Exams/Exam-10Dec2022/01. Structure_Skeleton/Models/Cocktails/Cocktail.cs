using System;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                name = value;
            }
        }

        public string Size
        {
            get => size;
            private set => size = value;
        }

        public double Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (this.Size == "Middle")
                {
                    value = 2.00 / 3.00 * value;
                }
                else if (this.Size == "Small")
                {
                    value = 1.00 / 3.00 * value;
                }

                price = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"--{Name} ({Size}) - {Price:f2} lv");
            return sb.ToString().TrimEnd();
        }
    }
}
