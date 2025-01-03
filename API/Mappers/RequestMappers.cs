using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Task;
using API.Models;
using API.Dtos.Request;

namespace API.Mappers
{
    public static class RequestMappers
    {
        public static RequestDto ToRequestDto(this Request requestModel)
        {
            return new RequestDto
            {
                RequestId = requestModel.RequestId,
                UserId = requestModel.UserId,
                ProductId = requestModel.ProductId,
                Quantity = requestModel.Quantity,
                DateCreated = requestModel.DateCreated,
                Transactions = requestModel.Transactions,
            };
        }

        public static Request ToRequestFromCreate(this CreateRequestRequestDto requestDto, int userId, int productId)
        {
            return new Request
            {
                UserId = userId,
                ProductId = productId,
                Quantity = requestDto.Quantity,                
                Transactions = requestDto.Transactions,
            };
        }

        public static Request ToRequestFromUpdate(this UpdateRequestRequestDto requestDto)
        {
            return new Request
            {
                Quantity = requestDto.Quantity,                
                Transactions = requestDto.Transactions,
            };
        }
    }
}
