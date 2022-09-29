using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double Distance { get; set; }
        public Car() { }
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double distance) 
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.Distance = distance;
        }
        public void Drive(double km)
        {
            bool canMove = this.FuelAmount >= km * FuelConsumptionPerKilometer;
            if (canMove)
            {
                this.FuelAmount = FuelAmount-  (km * FuelConsumptionPerKilometer);
                this.Distance = Distance+  km;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.Distance}"; 
        }
    }
}
