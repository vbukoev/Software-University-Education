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

            string jsonOutput = GetSalesWithAppliedDiscount(context);
            string path = @"../../../Results/discounts-sales.json";

            
            File.WriteAllText(path, jsonOutput);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new
                    {
                        x.Car.Make,
                        x.Car.Model,
                        x.Car.TraveledDistance
                    },
                    customerName = x.Customer.Name,
                    discount = $"{x.Discount:f2}",
                    price = $"{x.Car.PartsCars.Sum(p => p.Part.Price):f2}",
                    priceWithDiscount = $"{x.Car.PartsCars.Sum(p => p.Part.Price) * (1 - x.Discount / 100):f2}"
                }).ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }
    }
}