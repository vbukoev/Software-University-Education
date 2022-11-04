using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Parking
{
    public class Car
    {
        //•	Manufacturer: string
        //•	Model: string
        //•	Year: int
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public Car(string manufacturer, string model, int year)
        {
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
        }
        public override string ToString()
        {
            return $"{Manufacturer} {Model} ({Year})";
        }
    }
}
