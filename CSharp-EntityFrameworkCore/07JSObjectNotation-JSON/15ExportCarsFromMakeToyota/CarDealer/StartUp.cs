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

            string jsonOutput = GetCarsFromMakeToyota(context);
            string path = @"../../../Results/toyota-cars.json";

            
            File.WriteAllText(path, jsonOutput);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var orderedCustomers = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TraveledDistance)
                .Select(x => new
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TraveledDistance,
                }).ToArray();
                
            return JsonConvert.SerializeObject(orderedCustomers, Formatting.Indented);
        }
    }
}