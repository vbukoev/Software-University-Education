using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const int weight = 227;
        private const int price = 120;
        public BoxingGloves() : base(weight, price)
        {
        }
    }
}
