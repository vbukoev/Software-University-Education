namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class ImportDepartmentCellDto
    {
        [Range(GlobalConstants.CellNumberMinValue, GlobalConstants.CellNumberMaxValue)]
        public int CellNumber { get; set; }

        public bool HasWindow { get; set; }
    }
}
