using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();
            var cnt = int.Parse(Console.ReadLine());
            for (int i = 0; i < cnt; i++)
            {
                var carProps = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car
                {
                    Brand = carProps[0],
                    Mileage = int.Parse(carProps[1]),
                    Fuel = int.Parse(carProps[2])
                };
                cars.Add(car);
            }

            while (true)
                {
                    var cmd = Console.ReadLine();
                    if (cmd == "Stop") break;
                    var tokens = cmd.Split(" : ");
                    var action = tokens[0];
                    switch (action)
                    {
                        case "Drive":
                            Drive(tokens[1], int.Parse(tokens[2]),int.Parse(tokens[3]), cars);
                            break;

                        case "Refuel":
                            Refuel(tokens[1], int.Parse(tokens[2]), cars);
                            break;

                        case "Revert":
                            Revert(tokens[1], int.Parse(tokens[2]), cars);
                            break;

                        default: 
                            break;
                    }
                }
                foreach (var car in cars)                
                    Console.WriteLine($"{car.Brand} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");   
        }

        static void Drive(string brand, int distance, int fuel, List<Car> cars)
        {
            Car car = cars.First(x => x.Brand == brand);
            if (car.Fuel < fuel)
            {
                Console.WriteLine("Not enough fuel to make that ride");
                return;
            }
            car.Mileage += distance;
            car.Fuel -= fuel;
            Console.WriteLine($"{car.Brand} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
            if (car.Mileage >= 100000) 
            { 
                cars.Remove(car);
                Console.WriteLine($"Time to sell the {car.Brand}!");
            }
        }

        static void Refuel(string brand, int fuel, List<Car> cars)
        {
            Car car = cars.First(x => x.Brand == brand);
            var currFuel = car.Fuel;
            car.Fuel += fuel;
            if (car.Fuel > 75) car.Fuel = 75;
            Console.WriteLine($"{car.Brand} refueled with {car.Fuel - currFuel} liters");
        }

        static void Revert(string brand, int km, List<Car> cars)
        {
            Car car = cars.First(x => x.Brand == brand);
            car.Mileage -= km;
            Console.WriteLine($"{car.Brand} mileage decreased by {km} kilometers");
            if (km<10000) car.Mileage = 10000;
        }
    }
    public class Car
    {
        public string Brand { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
}