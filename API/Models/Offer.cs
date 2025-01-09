using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Offer
    {        
        public int OfferId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public bool IsFree { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime ExpirationDate { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
        public Product Product { get; set; } = null!;
        [Required]
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        [Required]
        public List<Request> Requests { get; set; } = new List<Request>();
    }
}
