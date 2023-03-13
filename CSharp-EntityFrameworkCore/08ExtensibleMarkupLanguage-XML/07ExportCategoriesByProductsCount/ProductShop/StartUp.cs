using System.Text;
using System.Xml.Serialization;
using ProductShop.Data;
using ProductShop.DTOs;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();
            var output = GetCategoriesByProductsCount(context);
            File.WriteAllText(@"../../../Results/sold-products.xml", output);
        }

        private static string Serializer<T>(T dataTransferObjects, string xmlRootAttributeName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));
            StringBuilder sb = new StringBuilder();
            using var write = new StringWriter(sb);
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            serializer.Serialize(write, dataTransferObjects, xmlNamespaces);

            return sb.ToString(); 
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x=>x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x=>x.Price)
                .Take(10)
                .Select(x=>new ExportProductsInRangeDto()
                {
                    Price = x.Price,
                    Name = x.Name,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                }).ToArray();

            return Serializer<ExportProductsInRangeDto[]>(products, "Products");
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportSoldProductsDto[] sold = context.Users
                .Where(x => x.ProductsSold.Any())
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .Select(x => new ExportSoldProductsDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(p => new ProductDto()
                    {
                        Name = p.Name,
                        Price = p.Price
                    }).ToArray()
                })
                .ToArray();

            return Serializer<ExportSoldProductsDto[]>(sold, "Users");
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportCategoriesByProductsCountDto[] categories = context.Categories
                .Select(x => new ExportCategoriesByProductsCountDto()
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count(),
                    AveragePrice = x.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            return Serializer<ExportCategoriesByProductsCountDto[]>(categories, "Categories");
        }
    }
}