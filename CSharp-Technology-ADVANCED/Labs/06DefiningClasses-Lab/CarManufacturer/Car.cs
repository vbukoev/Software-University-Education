
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
        private Engine engine;
        private Tire[] tires;

        public string Make { get => make; set => make = value; }

        public string Model { get => model; set => model = value; }

        public int Year { get => year; set => year = value; }

        public Engine Engine { get { return engine; } set { engine = value; } }
        public Tire[] Tires { get { return tires; } set { tires = value; } }

        public Car()
        {
            this.make = "VW";
            this.model = "Golf";
            this.year = 2025;
            this.fuelQuantity = 200;
            this.fuelConsumption = 10;
        }
        public Car(string make, string model, int year)
        : this()
        {
            this.make = make;
            this.model = model;
            this.year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
           : this(make, model, year)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;

        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) 
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public double FuelQuantity { get => fuelQuantity; set => fuelQuantity = value; }
        public double FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }





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
            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:f2}";
        }
    }
}
