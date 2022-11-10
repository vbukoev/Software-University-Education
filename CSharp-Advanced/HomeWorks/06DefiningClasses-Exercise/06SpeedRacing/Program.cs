namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumptionFor1km = double.Parse(tokens[2]);
                if (!cars.Any(x=>x.Model.Contains(model)))
                {
                    var car = new Car(model, fuelAmount, fuelConsumptionFor1km, 0);
                    cars.Add(car);
                }
            }
            
            while (true)
            {
                var input = Console.ReadLine();
                if (input  == "End")
                {
                    break;
                }
                var command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var action = command[0];
                switch (action)
                {
                    case "Drive":
                        var model = command[1];
                        var km = double.Parse(command[2]);
                        var car = cars.Where(x => x.Model == model).FirstOrDefault();
                        car.Drive(km);
                        break;
                    default:
                        break;
                }
            }
            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }
        }
    }
}
