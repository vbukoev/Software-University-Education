using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double mililitters) : base(name, price)
        {
            Mililitters = mililitters;
        }
        public double Mililitters { get; set; }
    }
}
