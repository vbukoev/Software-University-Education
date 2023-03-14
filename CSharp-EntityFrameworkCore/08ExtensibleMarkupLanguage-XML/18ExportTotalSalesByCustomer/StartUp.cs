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
                
            string xmlOutput = GetTotalSalesByCustomer(context); 
            File.WriteAllText(@"../../../Results/customers-total-sales.xml", xmlOutput);
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


        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var temp = context.Customers
                .Where(x => x.Sales.Any())
                .Select(x => new
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count(),
                    SalesInfo = x.Sales.Select(s => new
                        {
                            Prices = x.IsYoungDriver
                                ? s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2))
                                : s.Car.PartsCars.Sum(pc => (double)pc.Part.Price)
                        })
                        .ToArray(),
                })
                .ToArray();
            TotalSalesByCustomerDto[] totalSales = temp.OrderByDescending(x => x.SalesInfo.Sum(y => y.Prices))
                .Select(x => new TotalSalesByCustomerDto()
                {
                    FullName = x.FullName,
                    BoughtCars = x.BoughtCars,
                    SpentMoney = x.SalesInfo.Sum(y => y.Prices).ToString("f2")
                })
                .ToArray();

            return Serializer<TotalSalesByCustomerDto[]>(totalSales, "customers");
        }
    }
}