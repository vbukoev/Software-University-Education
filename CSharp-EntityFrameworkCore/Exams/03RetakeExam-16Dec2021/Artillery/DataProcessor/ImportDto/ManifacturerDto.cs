namespace Artillery.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    [XmlType("Manufacturer")]
    public class ManufacturerDto
    {
        [Required]
        [StringLength(40, MinimumLength = 4)]
        [XmlElement("ManufacturerName")]
        public string ManufacturerName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        [XmlElement("Founded")]
        public string Founded { get; set; }
    }
}
