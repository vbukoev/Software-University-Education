using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Newnew
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var vehicleList = new List<Vehicle>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End") break;
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string typeOfCar = tokens[0];
                string model = tokens[1];
                string color = tokens[2];
                int hp = int.Parse(tokens[3]);
                switch (typeOfCar)
                {
                    case "car":
                        vehicleList.Add(new Vehicle("Car", model, color, hp));
                    break;
                    case "truck":
                        vehicleList.Add(new Vehicle("Truck", model, color, hp));
                    break;
                    default:
                        break;
                }
            }
            
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Close the Catalogue") break;
                foreach (var vehicle in vehicleList.Where(x => x.Model == command))
                {
                    Console.WriteLine($"Type: {vehicle.Type}");
                    Console.WriteLine($"Model: {vehicle.Model}");
                    Console.WriteLine($"Color: {vehicle.Color}");
                    Console.WriteLine($"Horsepower: {vehicle.HorsePower}");
                }                
            }
            double totalCarHp = 0;
            double carCnt = 0;
            double totalTruckHp = 0;
            double truckCnt = 0;   
            foreach (var vehicle in vehicleList)
            {
                switch (vehicle.Type)
                {
                    case "Car":
                        totalCarHp += vehicle.HorsePower;
                        carCnt++;
                        break;
                    case "Truck":
                        totalTruckHp += vehicle.HorsePower;
                        truckCnt++;
                        break;
                    default:
                        break;
                }
            }
            if (carCnt > 0) Console.WriteLine($"Cars have average horsepower of: {totalCarHp/carCnt:f2}.");
            else Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            if (truckCnt > 0) Console.WriteLine($"Cars have average horsepower of: {totalTruckHp / truckCnt:f2}.");
            else Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");

        }
    }
    class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
        public string Type { get; set; }
    }
}
