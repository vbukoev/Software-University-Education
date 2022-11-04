using System;
using System.Collections.Generic;
using System.Text;

namespace _01ClassBoxData
{
    public class Box
    {
        //Length - double, should not be zero or negative number
        //Width - double, should not be zero or negative number
        //Height - double, should not be zero or negative number
        private double length;
        private double width;
        private double height;  
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public double Length 
        { 
            get=>length;
            private set
            {
                SideValidation(value, nameof(Length));
                length = value;
            }
        }
        public double Width 
        { 
            get=> width;
            private set 
            {
                SideValidation(value, nameof(Width));
                width = value;
            }

        }
        public double Height
        {

            get => height;
            private set
            {
                SideValidation(value, nameof(Height));
                height = value;
            }
        }
        public double SurfaceArea()
        {
            return this.LateralSurfaceArea() + (2 * Length * Width);
        }
        public double LateralSurfaceArea()
        {
            return (2 * Length * Height) + (2 * Width * Height);
        }
        public double Volume()
        {
            return Length * Width * Height;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {this.Volume():f2}");
            return sb.ToString().TrimEnd();
        }

        public static void SideValidation(double value, string sideName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{sideName} cannot be zero or negative.");
            };
        }
    }
}
