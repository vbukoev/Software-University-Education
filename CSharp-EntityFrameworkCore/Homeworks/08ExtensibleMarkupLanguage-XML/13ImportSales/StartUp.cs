using System.IdentityModel.Tokens.Jwt;
using System.Xml.Serialization;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string suppliersPath = @"../../../Datasets/suppliers.xml";
            string suppliersXml = File.ReadAllText(suppliersPath);
            ImportSuppliers(context, suppliersXml);

            string partsPath = @"../../../Datasets/parts.xml";
            string partsXml = File.ReadAllText(partsPath);
            ImportParts(context, partsXml);

            string carsPath = @"../../../Datasets/cars.xml";
            string carsXml = File.ReadAllText(carsPath);
            ImportCars(context, carsXml);

            string customersPath = @"../../../Datasets/customers.xml";
            string customersXml = File.ReadAllText(customersPath);
            ImportCustomers(context, customersXml);

            string salesPath = @"../../../Datasets/sales.xml";
            string salesXml = File.ReadAllText(salesPath);
            string output = ImportSales(context, salesXml);
            Console.WriteLine(output);
        }
        private static T Deserializer<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            using StringReader reader = new StringReader(inputXml);

            T dtos = (T)serializer.Deserialize(reader);
            return dtos;
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            ImportSuppliersDto[] suppliersDto = Deserializer<ImportSuppliersDto[]>(inputXml, "Suppliers");

            Supplier[] suppliers = suppliersDto
                .Select(x => new Supplier()
                {
                    Name = x.Name,
                    IsImporter = x.IsImporter
                })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            ImportPartsDto[] partsDto = Deserializer<ImportPartsDto[]>(inputXml, "Parts");
            int[] supplierIds = context.Suppliers.Select(x => x.Id).ToArray();

            Part[] parts = partsDto
                .Where(x=>supplierIds.Contains(x.SupplierId))
                .Select(x=>new Part()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId 
                }).ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            ImportCarsDto[] carsDto = Deserializer<ImportCarsDto[]>(inputXml, "Cars");
            List<Car> cars = new List<Car>();
            List<PartCar> partCars = new List<PartCar>();
            
            int[] allPartsIds = context.Parts.Select(x => x.Id).ToArray();  
            int carId = 1;

            foreach (var dto in carsDto)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TravelledDistance = dto.TraveledDistance
                };

                cars.Add(car);

                foreach (var partId in dto.Parts
                             .Where(x=> allPartsIds.Contains(x.PartId))
                             .Select(x=>x.PartId)
                             .Distinct()) //C# Linq Distinct() method removes the duplicate elements from a sequence (list) and returns the distinct elements from a single data source.
                {
                    PartCar partCar = new PartCar()
                    {
                        CarId = carId,
                        PartId = partId
                    };
                    partCars.Add(partCar);
                }
                carId++;
            }   
            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            ImportCustomersDto[] customersDtos = Deserializer<ImportCustomersDto[]>(inputXml, "Customers");
            Customer[] customers = customersDtos.Select(x=>new Customer()
            {
                Name = x.Name,
                BirthDate = x.BirthDate,
                IsYoungDriver = x.IsYoungDriver

            }).ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count()}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            ImportSalesDto[] salesDto = Deserializer<ImportSalesDto[]>(inputXml, "Sales");
            int[] allcarsId = context.Cars.Select(x=>x.Id).ToArray();
            Sale[] sales = salesDto
                .Where(x=>allcarsId.Contains(x.CarId))
                .Select(x =>new Sale()
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                }).ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Count()}";
        }
    }
}