using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required, StringLength(50)]
        public required string ProductName { get; set; }
        [Required, StringLength(500)]
        public required string ProductDescription { get; set; }

        // Navigation properties
        [Required]
        public List<Offer> Offers { get; set; } = new List<Offer>();
    }
}
