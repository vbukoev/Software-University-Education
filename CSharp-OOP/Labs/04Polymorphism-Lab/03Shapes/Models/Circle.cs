namespace Shapes.Models
{
    using Shapes.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public double Radius
        {
            get { return radius; }
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidRadiusException();
                }
                radius = value;
            }
        }

        public override double CalculateArea()
        => Math.PI * Math.Pow(this.Radius, 2);

        public override double CalculatePerimeter()
        => 2 * Math.PI * this.Radius;
        public override string Draw()
        => base.Draw() + $" {this.GetType().Name}";
    }
}