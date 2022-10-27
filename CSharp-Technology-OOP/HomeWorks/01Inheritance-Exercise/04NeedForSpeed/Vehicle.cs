using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;
        public Vehicle(int hp, double fuel)
        {
            Fuel = fuel;
            HorsePower = hp;
        }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public virtual double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;
        public virtual void Drive(double km)
        {
            double fuelLeft = Fuel - FuelConsumption * km;
            if (fuelLeft >= 0) Fuel = fuelLeft;
           // if (fuelLeft >= 0) Fuel -= FuelConsumption * km; <- THIS CAN BE USED LIKE THE PREVIOUS TWO LINES
        }
    }
}
