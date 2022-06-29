using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalogue catalogue = new Catalogue();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end") break;
                string[] tokens = command.Split('/');
                string type = tokens[0];
                switch (type)
                {
                    case "Truck":
                        Truck truck = new Truck()
                        {
                            Brand = tokens[1],
                            Model = tokens[2],
                            Weigth = int.Parse(tokens[3])

                        };
                        catalogue.Truck.Add(truck);
                        break;
                    case "Car":
                        Car car = new Car()
                        {
                            Brand = tokens[1],
                            Model = tokens[2],
                            HorsePower = int.Parse(tokens[3])

                        };
                        catalogue.Cars.Add(car);
                        break;
                    default:
                        break;
                }
            }
            if (catalogue.Cars.Count > 0)
            {
                List<Car> ordered = catalogue.Cars.OrderBy(c => c.Brand).ToList();
                Console.WriteLine("Cars:");
                foreach (var car in ordered)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalogue.Truck.Count > 0)
            {
                List<Truck> orderedTr = catalogue.Truck.OrderBy(c => c.Brand).ToList();
                Console.WriteLine("Trucks:");
                foreach (var truck in orderedTr)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weigth}kg");
                }
            }

        }
        class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }

        }
        class Truck
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weigth { get; set; }

        }
        class Catalogue
        {
            public Catalogue()
            {
                this.Cars = new List<Car>();
                this.Truck = new List<Truck>();
            }
            public List<Car> Cars { get; set; }
            public List<Truck> Truck { get; set; }
        }
    }
}
