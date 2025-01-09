using API.Dtos.Transaction;
using API.Dtos.Request;

namespace API.Dtos.Offer
{
    public class OfferDto
    {
        public int OfferId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public bool IsFree { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();
        public List<RequestDto> Requests { get; set; } = new List<RequestDto>();
    }
}
