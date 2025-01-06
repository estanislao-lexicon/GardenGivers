using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
                Name = productModel.Name,
                Description = productModel.Description,
                Offers = productModel.Offers.Select(o => o.ToOfferDto()).ToList(),
                Requests = productModel.Requests.Select(r => r.ToRequestDto()).ToList(),
            };
        }

        public static Product ToProductFromCreate(this CreateProductDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,                
            };
        }
    }
}
