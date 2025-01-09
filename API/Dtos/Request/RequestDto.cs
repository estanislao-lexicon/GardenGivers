using API.Dtos.Transaction;

namespace API.Dtos.Request
{
    public class RequestDto
    {
        public int RequestId { get; set; }
        public int OfferId { get; set; }        
        public decimal Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public List<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();
    }
}
