using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Task;
using API.Models;
using API.Dtos.Offer;

namespace API.Mappers
{
    public static class OfferMappers
    {
        public static OfferDto ToOfferDto(this Offer offerModel)
        {
            return new OfferDto
            {
                OfferId = offerModel.UserId,
                UserId = offerModel.UserId,
                ProduceId = offerModel.ProduceId,
                Quantity = offerModel.Quantity,
                IsFree = offerModel.IsFree,
                Price = offerModel.Price,                
                DateCreated = offerModel.DateCreated,
            };
        }

        public static Offer ToOfferFromCreateDTO(this CreateOfferRequestDto offerDto)
        {
            return new Offer
            {
                OfferId = offerDto.UserId,
                UserId = offerDto.UserId,
                ProduceId = offerDto.ProduceId,
                Quantity = offerDto.Quantity,
                IsFree = offerDto.IsFree,
                Price = offerDto.Price,                
                DateCreated = offerDto.DateCreated,             
            };
        }
    }
}
