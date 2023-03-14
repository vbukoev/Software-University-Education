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
                
            string xmlOutput = GetCarsWithDistance(context);
            File.WriteAllText(@"../../../Results/cars.xml", xmlOutput);
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

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            CarsWithDistanceDto[] cars = context.Cars
                .Where(x=>x.TraveledDistance > 2000000)
                .OrderBy(x=>x.Make)
                .ThenBy(x=>x.Model)
                .Take(10)
                .Select(x=>new CarsWithDistanceDto()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TraveledDistance,
                }).ToArray();

            return Serializer<CarsWithDistanceDto[]>(cars, "cars");
        }
    }
}