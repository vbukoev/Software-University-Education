namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            var enginesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < enginesCount; i++)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var model = tokens[0];
                var power = int.Parse(tokens[1]);
                var length = tokens.Length;
                if (length == 2)
                {
                    engines.Add(new Engine(model, power));
                }
                else if (length == 3)
                {
                    if (int.TryParse(tokens[2], out int displacement))
                    {
                        engines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        engines.Add(new Engine(model, power, tokens[2]));
                    }
                }
                else if (length == 4)
                {
                    int displacement = int.Parse(tokens[2]);
                    var eff = tokens[3];
                    engines.Add(new Engine(model, power, displacement, eff));
                }
            }

            var cnt = int.Parse(Console.ReadLine());
            for (int i = 0; i < cnt; i++)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var model = tokens[0];
                var engineModel = tokens[1];
                Engine engine = GetEngine(engines, engineModel);
                var length = tokens.Length;
                if (length == 2)
                {
                    cars.Add(new Car(model, engine));
                }
                else if (length == 3)
                {
                    if (int.TryParse(tokens[2], out int weight))
                    {
                        cars.Add(new Car(model, engine, weight));
                    }
                    else
                    {
                        cars.Add(new Car(model, engine, tokens[2]));
                    }
                }
                else if (length == 4)
                {
                    int weight = int.Parse(tokens[2]);
                    var color = tokens[3];
                    cars.Add(new Car(model, engine, weight, color));
                }
            }            
            foreach (var item in cars) Console.WriteLine(item);

        }
        public static Engine GetEngine(List<Engine> engines, string engineModel) => engines.Where(x => x.Model == engineModel).FirstOrDefault(); 
    }
}
