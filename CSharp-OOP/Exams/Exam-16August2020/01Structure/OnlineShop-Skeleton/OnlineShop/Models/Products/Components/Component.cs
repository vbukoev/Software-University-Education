using System;
using System.Collections.Generic;
using System.Text;
using OnlineShop.Common.Constants;

namespace OnlineShop.Models.Products.Components
{
    public abstract class Component : Product, IComponent
    {
        private int generation;
        public Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance)
        {
            Generation = generation;
        }

        public int Generation
        {
            get => generation;
            private set=> generation = value;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(SuccessMessages.ComponentToString, generation);
        }
    }
}
