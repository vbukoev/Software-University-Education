namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class ImportDepartmentDto
    {
        [Required]
        [MinLength(GlobalConstants.DepartmentNameMinLength)]
        [MaxLength(GlobalConstants.DepartmentNameMaxLength)]
        public string Name { get; set; }

        public ImportDepartmentCellDto[] Cells { get; set; }
    }
}
