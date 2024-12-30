namespace API.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public int RequestId { get; set; }
        public Request Request { get; set; }
        public decimal Quantity { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}
