using API.Dtos.Request;
using API.Dtos.Offer;

namespace API.Dtos.Product
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public List<OfferDto> Offers { get; set; } = new List<OfferDto>();        
    }
}
