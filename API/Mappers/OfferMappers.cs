using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
                OfferId = offerModel.OfferId,
                UserId = offerModel.UserId,
                ProductId = offerModel.ProductId,
                Quantity = offerModel.Quantity,
                IsFree = offerModel.IsFree,
                Price = offerModel.Price,
                DateCreated = offerModel.DateCreated,
                ExpirationDate = offerModel.ExpirationDate,
            };
        }

        public static Offer ToOfferFromCreate(this CreateOfferDto offerDto, int userId, int productId)
        {
            return new Offer
            {
                UserId = userId,
                ProductId = productId,
                Quantity = offerDto.Quantity,
                IsFree = offerDto.IsFree,
                Price = offerDto.Price,
                ExpirationDate = offerDto.ExpirationDate,
            };
        }

        public static Offer ToOfferFromUpdate(this UpdateOfferRequestDto offerDto)
        {
            return new Offer
            {                
                Quantity = offerDto.Quantity,
                IsFree = offerDto.IsFree,
                Price = offerDto.Price,
                ExpirationDate = offerDto.ExpirationDate,
            };
        }
    }
}
