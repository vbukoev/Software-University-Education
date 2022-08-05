using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            while (true)
            {
                string[] inputAr = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (inputAr[0] == "End") break;
                VehicleType vehicleType;
                bool isSuccessfull =
                if (isSuccessfull)
                {
                }


                while (true)
                {
                    string cmds = Console.ReadLine();
                    if (cmds == "Close the Catalogue") break;
                    var desiredVehicle = vehicles.FirstOrDefault(vehicle => vehicle.Model == cmds);
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
            public vehicleType Type { get; set; }
            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Type: {Type}");
                sb.AppendLine($"Model: {Model}");
                sb.AppendLine($"Color: {Color}");
                sb.AppendLine($"Horsepower: {HorsePower}");

            }
        }
    }
}

