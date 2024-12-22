namespace API.Models
{
    public class Request
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int ProduceId { get; set; }
        public decimal Quantity { get; set; }        
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public ICollection<Transaction> Transactions { get; set; } 
    }
}
