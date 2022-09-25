
using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        string make;
        string model;
        int year;
        double fuelQuantity;
        double fuelConsumption;

        public string Make { get => this.make; set => this.make = value; }

        public string Model { get => this.model; set => this.model = value; }

        public int Year { get => this.year; set => this.year = value; }
        public double FuelQuantity { get => this.fuelQuantity; set => this.fuelQuantity = value; }
        public double FuelConsumption { get => this.fuelConsumption; set => this.fuelConsumption = value; }
        public Car()
        {
            this.make = "VW";
            this.model = "Golf";
            this.year = 2025;
            this.fuelQuantity = 200;
            this.fuelConsumption = 10;
        }
        public Car(string make, string model, int year) : this()
        {
            this.make = make;
            this.model = model;
            this.year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }

        public void Drive(double distance)
        {

            var carContinue = FuelQuantity - fuelConsumption * distance >= 0;
            if (carContinue)
            {
                FuelQuantity -= this.FuelConsumption * distance;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string GetInfo()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:f2}L";
        }
    }
}
