﻿namespace API.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int OfferId { get; set; }
        public int RequestId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}