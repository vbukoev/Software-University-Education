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
        /// <summary>
        /// Ad And Cart Identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Ad And Cart Name
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Ad And Cart Description
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// Ad And Cart Category
        /// </summary>
        public string Category { get; set; } = null!;
        /// <summary>
        /// Ad And Cart Price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Ad And Cart Image Path
        /// </summary>
        public string ImageUrl { get; set; } = null!;
        /// <summary>
        /// Ad And Cart Owner
        /// </summary>
        public string Owner { get; set; } = null!;
        /// <summary>
        /// Ad And Cart Creation Date
        /// </summary>
        public string CreatedOn { get; set; } 
    }
}
