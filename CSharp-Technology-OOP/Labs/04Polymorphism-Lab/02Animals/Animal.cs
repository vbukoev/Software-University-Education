﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;
        public Animal(string name, string favouriteFood)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
        }
        public virtual string ExplainSelf()
        {
            return $"I am {this.name} and my favourite food is {this.favouriteFood}";
        }
    }
}
