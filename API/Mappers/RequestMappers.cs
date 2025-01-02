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
                ProduceId = requestModel.ProduceId,
                Quantity = requestModel.Quantity,
                DateCreated = requestModel.DateCreated,    
            };
        }

        public static Request ToRequestFromCreateDTO(this CreateRequestRequestDto requestDto)
        {
            return new Request
            {
                RequestId = requestDto.RequestId,
                UserId = requestDto.UserId,
                ProduceId = requestDto.ProduceId,
                Quantity = requestDto.Quantity,
                DateCreated = requestDto.DateCreated,
            };
        }
    }
}
