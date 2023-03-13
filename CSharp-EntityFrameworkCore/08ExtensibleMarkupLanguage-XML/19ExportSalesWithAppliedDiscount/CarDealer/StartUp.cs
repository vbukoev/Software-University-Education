using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using CarDealer.Data;
using CarDealer.DTOs.Export;
namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();
                
            string xmlOutput = GetSalesWithAppliedDiscount(context); 
            File.WriteAllText(@"../../../Results/sales-discounts.xml", xmlOutput);
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


        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            SalesWithDiscountDto[] sales = context
                .Sales
                .Select(s => new SalesWithDiscountDto()
                {
                    SingleCar = new SingleCar()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = (int)s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(x => x.Part.Price),
                    PriceWithDiscount =
                        Math.Round((double)(s.Car.PartsCars.Sum(x => x.Part.Price) * (1 - (s.Discount / 100))), 4)
                }).ToArray();

            return Serializer<SalesWithDiscountDto[]>(sales, "sales");
        }
    }
}