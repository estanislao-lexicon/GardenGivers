using System.Threading.Task;

namespace API.Dtos.Transaction
{
    public class CreateTransactionDto
    {
        public int OfferId { get; set; }
        public int RequestId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
