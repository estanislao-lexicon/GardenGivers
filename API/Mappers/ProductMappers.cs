using API.Models;
using API.Dtos.Product;

namespace API.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                ProductId = productModel.ProductId,
                ProductName = productModel.ProductName,
                ProductDescription = productModel.ProductDescription,
                Offers = productModel.Offers.Select(o => o.ToOfferDto()).ToList(),                
            };
        }

        public static Product ToProductFromCreate(this CreateProductDto productDto)
        {
            return new Product
            {
                ProductName = productDto.ProductName,
                ProductDescription = productDto.ProductDescription,
                Offers = new List<Offer>()
            };
        }
    }
}
