using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const int weight = 10000;
        private const int price = 80;
        public Kettlebell() : base(weight, price)
        {
        }
    }
}
