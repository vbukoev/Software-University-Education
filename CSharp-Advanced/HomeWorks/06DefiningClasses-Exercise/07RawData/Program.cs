namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var model = tokens[0];

                var engineSpeed = int.Parse(tokens[1]);
                var enginePower = int.Parse(tokens[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                var cargoWeight = int.Parse(tokens[3]);
                var cargoType = tokens[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire[] tires = new Tire[4]
                {
                    new Tire(double.Parse(tokens[5]), int.Parse(tokens[6])),
                    new Tire(double.Parse(tokens[7]), int.Parse(tokens[8])),
                    new Tire(double.Parse(tokens[9]), int.Parse(tokens[10])),
                    new Tire(double.Parse(tokens[11]), int.Parse(tokens[12])),
                };
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
            var command = Console.ReadLine();
            switch (command)
            {
                case "fragile":
                    var res = cars.Where(x => x.Cargo.Type == "fragile").Where(x => x.Tires.Any(y => y.Pressure < 1)).ToList();
                    foreach (var item in res) Console.WriteLine(item);
                    break;

                case "flammable":
                    res = cars.Where(x => x.Cargo.Type == "flammable").Where(x => x.Engine.Power > 250).ToList();
                    foreach (var item in res) Console.WriteLine(item);
                    break;
                default:
                    break;
            }
        }
    }
}
