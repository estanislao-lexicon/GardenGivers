using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
                Transactions = requestModel.Transactions.Select(t => t.ToTransactionDto()).ToList(),
            };
        }

        public static Request ToRequestFromCreate(this CreateRequestDto requestDto, int userId, int productId)
        {
            return new Request
            {
                UserId = userId,
                ProductId = productId,
                Quantity = requestDto.Quantity,                
                
            };
        }

        public static Request ToRequestFromUpdate(this UpdateRequestDto requestDto)
        {
            return new Request
            {
                Quantity = requestDto.Quantity,                
            };
        }
    }
}
