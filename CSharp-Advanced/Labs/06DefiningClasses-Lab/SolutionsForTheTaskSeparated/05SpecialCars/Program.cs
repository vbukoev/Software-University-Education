using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialCars
{
    public class Tire
    {
        private int year;
        private double pressure;
        public int Year { get => year; set => year = value; }
        public double Pressure { get => pressure; set => pressure = value; }
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
    }
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;
        public int HorsePower { get => horsePower; set => horsePower = value; }
        public double CubicCapacity { get => cubicCapacity; set => cubicCapacity = value; }
        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }
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
            if (this.FuelQuantity - ((this.FuelConsumption * distance) / 100) >= 0)
            {
                this.FuelQuantity -= ((distance * this.FuelConsumption) / 100);
            }
        }
        public string GetInfo()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:f2}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var tires = new List<Tire[]>();
            var engines = new List<Engine>();
            var cars = new List<Car>();
            
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "No more tires") break;
                var tiresInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var currTires = new Tire[4]
                {
                    new Tire(int.Parse(tiresInfo[0]), double.Parse(tiresInfo[1])),
                    new Tire(int.Parse(tiresInfo[2]), double.Parse(tiresInfo[3])),
                    new Tire(int.Parse(tiresInfo[4]), double.Parse(tiresInfo[5])),
                    new Tire(int.Parse(tiresInfo[6]), double.Parse(tiresInfo[7])),
                };
                tires.Add(currTires);

            }
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Engines done") break;
                var enginesInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var hp = int.Parse(enginesInfo[0]);
                var cubicCapacity = double.Parse(enginesInfo[1]);
                var engine = new Engine(hp, cubicCapacity);
                engines.Add(engine);
            }
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Show special") break;
                var carsInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var make = carsInfo[0];
                var model = carsInfo[1];
                var year = int.Parse(carsInfo[2]);
                var engineIndex = int.Parse(carsInfo[5]);
                var tiresIndex = int.Parse(carsInfo[6]);
                var fuelQuantity = double.Parse(carsInfo[3]);
                var fuelConsumption = double.Parse(carsInfo[4]);
                var car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);
            }
            string res = GetSpecial(cars);
            Console.WriteLine(res);
        }

        private static string GetSpecial(List<Car> cars)
        {
            var special = cars.Where(x => x.Year >= 2017).Where(x => x.Engine.HorsePower > 300).Where(x => x.Tires.Sum(n => n.Pressure) >= 9 && x.Tires.Sum(n => n.Pressure) <= 10);

            var res = new StringBuilder();
            foreach (var car in special)
            {
                car.Drive(20);
                res.AppendLine($"Make: {car.Make}");
                res.AppendLine($"Model: {car.Model}");
                res.AppendLine($"Year: {car.Year}");
                res.AppendLine($"HorsePowers: {car.Engine.HorsePower}");
                res.AppendLine($"FuelQuantity: {car.FuelQuantity}");
            }
            return res.ToString();
        }
    }
}
