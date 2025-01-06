using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Transaction;

namespace API.Dtos.Offer
{
    public class OfferDto
    {
        public int OfferId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public bool IsFree { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }
}
