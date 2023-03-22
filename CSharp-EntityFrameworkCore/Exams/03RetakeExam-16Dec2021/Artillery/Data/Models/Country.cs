namespace Artillery.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string CountryName { get; set; }

        public int ArmySize { get; set; }
        public virtual ICollection<CountryGun> CountriesGuns { get; set; } = new HashSet<CountryGun>();
    }
}
