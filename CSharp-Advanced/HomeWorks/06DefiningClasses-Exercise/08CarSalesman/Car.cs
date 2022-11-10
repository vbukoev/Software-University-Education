using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }
        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }
        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }
        public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
        {
            this.Color = color;
        }


        public override string ToString()
        {
            var res = new StringBuilder();
            res.AppendLine($"{this.Model}:");
            res.AppendLine($"{this.Engine}");
            if (this.Weight ==0)
            {
                res.AppendLine($"  Weight: n/a");
            }
            else
            {
                res.AppendLine($"  Weight: {this.Weight}");
            }
            if (this.Color == null)
            {
                res.Append($"  Color: n/a");
            }
            else
            {
                res.Append($"  Color: {this.Color}");
            }
            return res.ToString();
        }
    }
}
