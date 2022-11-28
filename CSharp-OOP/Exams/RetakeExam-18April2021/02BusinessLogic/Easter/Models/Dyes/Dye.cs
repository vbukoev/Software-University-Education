using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            this.power = power;
        }

        public int Power
        {
            get => power;
            private set => power = value < 0 ? 0 : value;
        }
        public void Use()
        {
            Power -= 10;
        }

        public bool IsFinished()
            => power == 0;
    }
}
