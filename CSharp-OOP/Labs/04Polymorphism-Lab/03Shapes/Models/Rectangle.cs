using Shapes.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    public class Rectangle : Shape
    {
        private const string InvalidSideExceptionMessage = "{0} must be a positive number!";
        private double height;
        private double width;
        public Rectangle(double heigth, double width)
        {
            this.Height = heigth;
            this.Width = width;
        }

        public double Height
        {
            get => height;
            private set
            {
                ValidateSide(value, nameof(Height));
                height = value;
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                ValidateSide(value, nameof(Width));
                width = value;
            }
        }

        private void ValidateSide(double value, string v)
        {
            if (value <= 0)
            {
                throw new InvalidSideException(string.Format(InvalidSideExceptionMessage, v));
            }
        }



        public override double CalculateArea()
        => Width * Height;


        public override double CalculatePerimeter()
        => 2 * Width + 2 * Height;
        public override string Draw()
        => base.Draw() + $" {this.GetType().Name}";
    }
}
