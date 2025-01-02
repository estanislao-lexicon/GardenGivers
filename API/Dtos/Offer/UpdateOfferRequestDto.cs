using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Offer
{
    public class UpdateOfferRequestDto
    {
        public int OfferId { get; set; }
        public int UserID { get; set; }
        public int ProduceID { get; set; }
        public decimal Quantity { get; set; }
        public bool IsFree { get; set; }
        public decimal Price { get; set; }     
    }
}
