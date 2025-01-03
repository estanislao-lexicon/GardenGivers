using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Offer
{
    public class UpdateOfferRequestDto
    {
        public decimal Quantity { get; set; }
        public bool IsFree { get; set; }
        public decimal Price { get; set; } 
        public DateTime ExpirationDate { get; set; }    
    }
}
