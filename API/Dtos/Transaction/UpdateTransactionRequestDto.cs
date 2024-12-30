using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Transaction
{
    public class UpdateTransactionRequestDto
    {        
        public int OfferId { get; set; }
        public int RequestId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
