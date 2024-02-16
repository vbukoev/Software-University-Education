using SoftUniBazar.Data;

namespace SoftUniBazar.Models
{
    public class AdAndCartInfoViewModel
    {
        public AdAndCartInfoViewModel(int id, string name, string description, string category, decimal price, string imageUrl, string owner, DateTime createdOn)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            ImageUrl = imageUrl;
            Owner = owner;
            CreatedOn = createdOn.ToString(DataConstants.DateTimeFormat);
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Owner { get; set; } = null!;
        public string CreatedOn { get; set; } 
    }
}
