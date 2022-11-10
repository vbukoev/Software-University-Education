namespace Vehicles.Core
{
    using Vehicles.Models;
    using System;
    using System.Linq;
    using Vehicles.Exceptions;

    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInfo[1]); // creating the car
            double carLitersPerKm = double.Parse(carInfo[2]);
            Car car = new Car(carFuelQuantity, carLitersPerKm);

            double truckFuelQuantity = double.Parse(truckInfo[1]); // creating the truck
            double truckLitersPerKm = double.Parse(truckInfo[2]);
            Truck truck = new Truck(truckFuelQuantity, truckLitersPerKm);

            int commandCnt = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCnt; i++)
            {
                try
                {
                    string[] cmdArgs = Console.ReadLine().Split().ToArray();
                    string command = cmdArgs[0];
                    string type = cmdArgs[1];
                    
                    if (command == "Drive")
                    {
                        double distance = double.Parse(cmdArgs[2]);
                        if (type == "Car")
                        {
                            Console.WriteLine(car.Drive(distance));
                        }
                        else if (type == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }
                    }
                    else if (command == "Refuel")
                    {
                        double litters = double.Parse(cmdArgs[2]);
                        if (type == "Car")
                        {
                            car.Refuel(litters);
                        }
                        else if (type == "Truck")
                        {
                            truck.Refuel(litters);
                        }
                    }
                }
                catch (LowFuelException lfe)
                {
                    Console.WriteLine(lfe.Message);
                    continue;
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
