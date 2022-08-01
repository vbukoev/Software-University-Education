using System;
using System.Collections.Generic;

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

                while (true)
                {
                    var cmd = Console.ReadLine();
                    if (cmd == "Stop") break;
                    var tokens = cmd.Split(" : ");
                    var action = tokens[0];
                    switch (action)
                    {
                        case "Drive":

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
            }
        }

         static void Revert(string brand, int km, List<Car> cars)
        {
            
        }
    }
    public class Car
    {
        public string Brand { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
}