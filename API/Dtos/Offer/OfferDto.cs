﻿namespace API.Dtos.Offer
{
    public class OfferDto
    {
        public int OfferId { get; set; }
        public int UserID { get; set; }
        public int ProduceID { get; set; }
        public decimal Quantity { get; set; }
        public bool IsFree { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }
}
