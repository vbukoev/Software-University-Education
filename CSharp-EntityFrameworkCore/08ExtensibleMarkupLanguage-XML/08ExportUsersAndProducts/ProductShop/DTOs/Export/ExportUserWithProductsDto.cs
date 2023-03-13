using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("User")]
    public class ExportUserWithProductsDto
    {
        [XmlElement("firstName")] public string FirstName { get; set; }
        [XmlElement("lastName")] public string LastName { get; set; }
        [XmlElement("age")] public int? Age { get; set; }
        [XmlElement("SoldProducts")] public ExportSoldProductsDto SoldProducts { get; set; }
    }
}
