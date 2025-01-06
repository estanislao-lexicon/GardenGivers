using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class OfferQueryObject
    {
        public decimal Quantity { get; set; }
        public bool IsFree { get; set; }
        public decimal Price { get; set; }        
    }
}
