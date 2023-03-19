namespace VaporStore.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    using System.ComponentModel.DataAnnotations;

    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [Required]
        [XmlElement("Type")]
        public string PurchaseType { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.PurchaseKeyRegex)]
        [XmlElement("Key")]
        public string Key { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.CardNumberRegex)]
        [XmlElement("Card")]
        public string CardNumber { get; set; }

        [Required]
        [XmlAttribute("title")]
        public string GameTitle { get; set; }
    }
}
