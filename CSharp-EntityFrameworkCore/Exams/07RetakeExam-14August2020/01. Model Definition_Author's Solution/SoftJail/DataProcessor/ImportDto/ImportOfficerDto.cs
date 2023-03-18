namespace SoftJail.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    using System.ComponentModel.DataAnnotations;

    [XmlType("Officer")]
    public class ImportOfficerDto
    {
        [Required]
        [MinLength(GlobalConstants.OfficerFullNameMinLength)]
        [MaxLength(GlobalConstants.OfficerFullNameMaxLength)]
        [XmlElement("Name")]
        public string FullName { get; set; }

        [Range(typeof(decimal), GlobalConstants.OfficerSalaryMinValue, GlobalConstants.OfficerSalaryMaxValue)]
        [XmlElement("Money")]
        public decimal Salary { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public ImportOfficerPrisonerDto[] Prisoners { get; set; }
    }
}
