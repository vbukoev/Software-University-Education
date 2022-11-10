using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Reptile : Animal
    {
        public override string Name { get; set; }
        public Reptile(string name) : base(name)
        {
            Name = name;
        }
    }
}
