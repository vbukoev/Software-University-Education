using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportCreatorDto
    {
        [Required]
        [XmlElement("FirstName")]
        [MinLength(2)]
        [MaxLength(7)]
        public string FirstName { get; set; }
        
        [Required]
        [XmlElement("LastName")]
        [MinLength(2)]
        [MaxLength(7)]
        public string LastName { get; set; }

        public List<ImportBoardgameDto> Boardgames { get; set; }
    }
    [XmlType("Boardgame")]
    public class ImportBoardgameDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(10)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [XmlElement("Rating")]
        [Range(1.00,10.00)]
        public double Rating { get; set; }

        [Required]
        [XmlElement("YearPublished")]
        [Range(2018, 2023)]
        public int YearPublished { get; set; }

        [Required]
        [Range(0,4)]
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("Mechanics")]
        public string Mechanics { get; set; }
    }
}
