namespace API.Models
{
    public class Offer
    {        
        public int OfferId { get; set; }
        public int UserID { get; set; }
        public int ProduceID { get; set; }
        public decimal Quantity { get; set; }
        public bool IsFree { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime ExpirationDate { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
