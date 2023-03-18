using CarDealer.Data;
using CarDealer.DTOs;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string suppliersJsonInput = File.ReadAllText(@"../../../Datasets/suppliers.json");
            ImportSuppliers(context, suppliersJsonInput);

            string partsJsonInput = File.ReadAllText(@"../../../Datasets/parts.json");
            ImportParts(context, partsJsonInput);

            string carsJsonInput = File.ReadAllText(@"../../../Datasets/cars.json");
            string output = ImportCars(context, carsJsonInput);
            
            Console.WriteLine(output);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(x=>(context.Suppliers.Select(s=>s.Id).ToArray()).Contains(x.SupplierId))
                .ToList();
            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsAndParts = JsonConvert.DeserializeObject<List<CarDTO>>(inputJson);
            List<PartCar> parts = new List<PartCar>();
            List<Car> cars = new List<Car>();

            foreach (var dto in carsAndParts)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TravelledDistance = dto.TraveledDistance
                };
                cars.Add(car);

                foreach (var part in dto.PartsId.Distinct())
                {
                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        PartId = part
                    };
                    parts.Add(partCar);
                }
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {cars.Count}.";
        }
    }
}