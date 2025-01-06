using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Transaction;

namespace API.Dtos.Request
{
    public class RequestDto
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }
}
