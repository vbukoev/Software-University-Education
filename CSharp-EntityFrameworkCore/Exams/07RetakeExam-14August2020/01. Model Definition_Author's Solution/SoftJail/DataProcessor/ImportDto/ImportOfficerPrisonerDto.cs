namespace SoftJail.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class ImportOfficerPrisonerDto
    {
        [XmlAttribute("id")]
        public int PrisonerId { get; set; }
    }
}
