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
            var output = GetProductsInRange(context);
            File.WriteAllText(@"../../../Results/products-in-range.xml", output);
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
    }
}