namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class ImportPrisonerDto
    {
        [Required]
        [MinLength(GlobalConstants.PrisonerFullNameMinLength)]
        [MaxLength(GlobalConstants.PrisonerFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.PrisonerNicknameRegex)]
        public string Nickname { get; set; }

        [Range(GlobalConstants.PrisonerAgeMinValue, GlobalConstants.PrisonerAgeMaxValue)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        [Range(typeof(decimal), GlobalConstants.PrisonerBailMinValue, GlobalConstants.PrisonerBailMaxValue)]
        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public ImportPrisonerMailDto[] Mails { get; set; }
    }
}
