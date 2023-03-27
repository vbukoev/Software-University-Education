using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatcherDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlArray("Trucks")]
        public ImportTruckDto[] Trucks { get; set; }
    }
    [XmlType("Truck")]
    public class ImportTruckDto
    {
        [Required]
        [RegularExpression(@"[A-Z]{2}\d{4}[A-Z]{2}$")]
        [XmlElement("RegistrationNumber")]
        public string RegistrationNumber { get; set; }

        [Required]
        [StringLength(17)]
        [XmlElement("VinNumber")]
        public string VinNumber { get; set; }

        [Range(950,1420)]
        [XmlElement("TankCapacity")]
        public int TankCapacity { get; set; }

        [Range(5000, 29000)]
        [XmlElement("CargoCapacity")]
        public int CargoCapacity { get; set; }

        [Required]
        [Range(0,3)]
        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }

        [Required]
        [Range(0,4)]
        [XmlElement("MakeType")]
        public int MakeType { get; set; }
    }
}