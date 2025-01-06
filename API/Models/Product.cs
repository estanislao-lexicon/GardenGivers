using API.Dtos.Request;
using API.Dtos.Offer;

namespace API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public List<Offer> Offers { get; set; }
        public List<Request> Requests { get; set; }
    }
}
