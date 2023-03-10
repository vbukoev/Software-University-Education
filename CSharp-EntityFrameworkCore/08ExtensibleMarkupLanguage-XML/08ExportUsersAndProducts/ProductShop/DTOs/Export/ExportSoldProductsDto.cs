using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("SoldProducts")]
    public class ExportSoldProductsDto
    {
        [XmlElement("count")] public int Count { get; set; }
        [XmlArray("soldProducts")] public ProductDto[] SoldProducts { get; set; }
    }

    [XmlType("Product")]
    public class ProductDto
    {
        [XmlElement("name")] public string Name { get; set; }
        [XmlElement("price")] public decimal Price { get; set; }
    }
}