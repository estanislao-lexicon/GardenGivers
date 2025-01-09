namespace API.Models
{
    public class Request
    {
        public int RequestId { get; set; }        
        public int OfferId { get; set; }
        public string UserId { get; set; } = null!;
        public decimal Quantity { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public required List<Transaction> Transactions { get; set; }         
        public Offer Offer { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
