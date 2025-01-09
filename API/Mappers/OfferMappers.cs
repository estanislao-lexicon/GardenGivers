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
                ProductId = offerModel.ProductId,
                Quantity = offerModel.Quantity,
                IsFree = offerModel.IsFree,
                Price = offerModel.Price,
                DateCreated = offerModel.DateCreated,
                ExpirationDate = offerModel.ExpirationDate,
                Requests = offerModel.Requests.Select(r => r.ToRequestDto()).ToList(),
                Transactions = offerModel.Transactions.Select(t => t.ToTransactionDto()).ToList()
            };
        }

        public static Offer ToOfferFromCreate(this CreateOfferDto offerDto, int productId)
        {
            return new Offer
            {                
                ProductId = productId,
                Quantity = offerDto.Quantity,
                IsFree = offerDto.IsFree,
                Price = offerDto.Price,
                ExpirationDate = offerDto.ExpirationDate,
                Requests = new List<Request>(),
                Transactions = new List<Transaction>()
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
                Requests = new List<Request>(),
                Transactions = new List<Transaction>()
            };
        }
    }
}
