﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Request
{
    public class RequestDto
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int ProduceId { get; set; }
        public decimal Quantity { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }
}
