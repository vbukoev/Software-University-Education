using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.New
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            while (true)
            {
                string[] inputAr = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                if (inputAr[0] == "End") break;
                VehicleType vehicleType;
                bool isSuccessfull = Enum.TryParse(inputAr[0], out vehicleType);
                if (isSuccessfull)
                {
                    string vehicleModel = inputAr[1];
                    string vehicleColor = inputAr[2];
                    int vehicleHP = int.Parse(inputAr[3]);
                    var currVehicle = new Vehicle(vehicleType, vehicleModel, vehicleColor, vehicleHP);
                    vehicles.Add(currVehicle);
                }
                while (true)
                {
                    string cmds = Console.ReadLine();
                    if (cmds == "Close the Catalogue") break;
                    var desiredVehicle = vehicles.FirstOrDefault(vehicle => vehicle.Model == cmds);
                    Console.WriteLine(desiredVehicle);
                }
                var cars = vehicles.Where(vehicle => vehicle.Type == VehicleType.Car).ToList();
                var trucks = vehicles.Where(vehicle => vehicle.Type == VehicleType.Truck).ToList();
                double carsAvgHP = cars.Count > 0 ? cars.Average(car => car.HorsePower):0.00;
                double truckAvgHP = trucks.Count > 0 ? trucks.Average(truck => truck.HorsePower) : 0.00;
                Console.WriteLine($"Cars have average horsepower of: {carsAvgHP:f2}.");
                Console.WriteLine($"Trucks have average horsepower of: {truckAvgHP:f2}.");
            }           
        }
    }
    enum VehicleType { Car, Truck }
    class Vehicle
    {
        public Vehicle(VehicleType type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
        public VehicleType Type { get; set; }
        public override string ToString() 
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Type: {Type}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {HorsePower}");
            return sb.ToString().TrimEnd();
        }
    }
}
