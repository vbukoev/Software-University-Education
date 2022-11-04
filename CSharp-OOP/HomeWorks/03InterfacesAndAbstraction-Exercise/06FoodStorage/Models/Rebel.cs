using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStorage.Models
{
    public class Rebel : Person
    {
        public Rebel(string name, int age, string group) : base(name, age)
        {
            Group = group;
        }
        public string Group { get; private set; }
        public override void BuyFood()
        {
            Food += 5;
        }
    }
}
