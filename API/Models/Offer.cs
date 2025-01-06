using API.Dtos.Transaction;

namespace API.Models
{
    public class Offer
    {        
        public int OfferId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Quantity { get; set; }
        public bool IsFree { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime ExpirationDate { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
