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

            string jsonOutput = GetCarsWithTheirListOfParts(context);
            string path = @"../../../Results/local-suppliers.json";

            
            File.WriteAllText(path, jsonOutput);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsAndParts = context.Cars
                .Select(x => new
                {
                   car= new 
                   {
                       x.Make,
                       x.Model,
                       x.TraveledDistance
                   },
                   parts = x.PartsCars.Select(x=>new
                   {
                       x.Part.Name,
                       Price = $"{x.Part.Price:f2}"
                   })
                }).ToArray();

            return JsonConvert.SerializeObject(carsAndParts, Formatting.Indented);
        }
    }
}