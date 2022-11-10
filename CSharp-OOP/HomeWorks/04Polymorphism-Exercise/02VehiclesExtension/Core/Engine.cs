namespace Vehicles.Core
{
    using Exceptions;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Vehicles.Contracts;

    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInfo[1]); // creating the car
            double carLitersPerKm = double.Parse(carInfo[2]);
            int carTankCapacity = int.Parse(carInfo[3]);
            Car car = new Car(carFuelQuantity, carLitersPerKm, carTankCapacity);

            double truckFuelQuantity = double.Parse(truckInfo[1]); // creating the truck
            double truckLitersPerKm = double.Parse(truckInfo[2]);
            int truckTankCapacity = int.Parse(truckInfo[3]);
            Truck truck = new Truck(truckFuelQuantity, truckLitersPerKm, truckTankCapacity);

            double busFuelQuantity = double.Parse(busInfo[1]); // creating the bus
            double busLitersPerKm = double.Parse(busInfo[2]);
            int busTankCapacity = int.Parse(busInfo[3]);
            Bus bus = new Bus(busFuelQuantity, busLitersPerKm, busTankCapacity);

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
                        else if (type=="Truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }
                        else if (type == "Bus")
                        {
                            Console.WriteLine(bus.Drive(distance));
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
                        else if (type == "Bus")
                        {
                            bus.Refuel(litters);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        double distance = double.Parse(cmdArgs[2]);
                        if (type == "Bus")
                        {
                            Console.WriteLine(bus.DriveEmpty(distance));
                        }
                    }
                }
                catch (LowFuelException lfe)
                {
                    Console.WriteLine(lfe.Message);
                    continue;
                }
                catch (MoreFuelException mfe)
                {
                    Console.WriteLine(mfe.Message);
                    continue;
                }
                catch (NegativeFuelException nfe)
                {
                    Console.WriteLine(nfe.Message);
                    continue;
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
