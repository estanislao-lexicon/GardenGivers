using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Request
{
    public class CreateRequestDto
    {
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int ProduceId { get; set; }
        public decimal Quantity { get; set; }        
    }
}
