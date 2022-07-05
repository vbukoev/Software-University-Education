using System;
using System.Collections.Generic;

namespace _03_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine()); //n - the num which is going to be read from the console and which is going to point the length of the for loop :)
            for (int i = 0; i < n; i++) cars.Add(new Car(Console.ReadLine().Split()));
            string[] drive = Console.ReadLine().Split();
            while (true)
            {
                if (drive[0] == "End") break;
                cars.Find(car => car.Model == drive[1]).Drive(int.Parse(drive[2]));
                drive = Console.ReadLine().Split();

                foreach (var item in cars) Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.Distance:f2}");
            }
        }
        class Car
        {
            public Car(string[] characteristics)
            {
                Model = characteristics[0];
                FuelAmount = decimal.Parse(characteristics[1]);
                FuelConsumptionPerKm = decimal.Parse(characteristics[2]);
            }
            public void Drive(int disatnce)
            {
                decimal fuelNeeded = disatnce * FuelConsumptionPerKm;
                if (FuelAmount >= fuelNeeded)
                {
                    Distance += disatnce;
                    FuelAmount -= fuelNeeded;
                }
                else Console.WriteLine("Insufficient fuel for the drive");
            }
            public string Model { get; set; }
            public decimal FuelAmount { get; set; }
            public decimal FuelConsumptionPerKm { get; set; }
            public int Distance { get; set; }

        }
    }
}
