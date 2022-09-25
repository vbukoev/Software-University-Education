using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        private int year;
        private double pressure;
        public int Year { get=>year; set=>year=value; }
        public double Pressure { get=>pressure; set=>pressure=value; }
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
    }
}
