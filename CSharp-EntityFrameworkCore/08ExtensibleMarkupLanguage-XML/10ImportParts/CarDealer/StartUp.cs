using System.IdentityModel.Tokens.Jwt;
using System.Xml.Serialization;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;

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
            string output = ImportParts(context, partsXml);

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
    }
}