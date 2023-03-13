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
                
            string xmlOutput = GetLocalSuppliers(context); 
            File.WriteAllText(@"../../../Results/suppliers.xml", xmlOutput);
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
        

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            LocalSuppliersDto[] localSuppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new LocalSuppliersDto()
                {
                    Name = x.Name,
                    Id = x.Id,
                    PartsCount = x.Parts.Count()
                }).ToArray();

            return Serializer<LocalSuppliersDto[]>(localSuppliers, "suppliers");
        }

    }
}