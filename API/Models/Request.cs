using API.Dtos.Transaction;

namespace API.Models
{
    public class Request
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Quantity { get; set; }        
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public List<Transaction> Transactions { get; set; } 
    }
}
