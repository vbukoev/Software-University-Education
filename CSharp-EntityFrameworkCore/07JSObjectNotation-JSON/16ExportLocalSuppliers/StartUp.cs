using System.Globalization;
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

            string jsonOutput = GetLocalSuppliers(context);
            string path = @"../../../Results/local-suppliers.json";

            
            File.WriteAllText(path, jsonOutput);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                }).ToArray();

            return JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
        }
    }
}