using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Task;
using API.Models;
using API.Dtos.Produce;

namespace API.Mappers
{
    public static class ProduceMappers
    {
        public static ProduceDto ToProduceDto(this Produce produceModel)
        {
            return new ProduceDto
            {
                ProduceId = produceModel.ProduceId,
                Name = produceModel.Name,
                Description = produceModel.Description,                
            };
        }

        public static Produce ToProduceFromCreateDTO(this CreateProduceRequestDto produceDto)
        {
            return new Produce
            {
                ProduceId = produceDto.ProduceId,
                Name = produceDto.Name,
                Description = produceDto.Description,               
            };
        }
    }
}
