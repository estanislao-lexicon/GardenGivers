using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Task;
using API.Models;
using API.Dtos.Product;

namespace API.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto(this Product ProductModel)
        {
            return new ProductDto
            {
                ProductId = ProductModel.ProductId,
                Name = ProductModel.Name,
                Description = ProductModel.Description,
                Offers = ProductModel.Offers,
                Requests = ProductModel.Requests,              
            };
        }

        public static Product ToProductFromCreateDTO(this CreateProductRequestDto ProductDto)
        {
            return new Product
            {
                ProductId = ProductDto.ProductId,
                Name = ProductDto.Name,
                Description = ProductDto.Description,
                Offers = ProductDto.Offers,
                Requests = ProductDto.Requests,             
            };
        }
    }
}
