using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boardgames.Data.Models
{
    public class BoardgameSeller
    {
        [Required]
        [ForeignKey(nameof(Boardgame))]
        public int BoardgameId { get; set; }
        public Boardgame Boardgame { get; set; }

        [Required]
        [ForeignKey(nameof(Seller))]
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
