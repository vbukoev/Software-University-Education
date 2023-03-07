using CarDealer.Data;
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
            string output = ImportParts(context, partsJsonInput);
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
    }
}