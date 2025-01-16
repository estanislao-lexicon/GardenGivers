using API.Models;
using API.Dtos.Offer;
using API.Dtos.Request;
using API.Dtos.Transaction;

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
                Requests = offerModel.Requests != null
                            ? offerModel.Requests.Select(r => r.ToRequestDto()).ToList()
                            : new List<RequestDto>(),                
                Transactions = offerModel.Transactions != null
                                ?offerModel.Transactions.Select(t => t.ToTransactionDto()).ToList()
                                : new List<TransactionDto>()
            };
        }

        public static Offer ToOfferFromCreate(this CreateOfferDto offerDto, string userId, int productId)
        {
            return new Offer
            {                
                UserId = userId,
                ProductId = productId,
                Quantity = offerDto.Quantity,
                IsFree = offerDto.IsFree,
                Price = offerDto.Price,
                ExpirationDate = offerDto.ExpirationDate,
                Requests = new List<Request>(),
                Transactions = new List<Transaction>()
            };
        }

        public static Offer ToOfferFromUpdate(this UpdateOfferRequestDto offerDto, Offer existingOffer)
        {
            return new Offer
            {                
                Quantity = offerDto.Quantity,
                IsFree = offerDto.IsFree,
                Price = offerDto.Price,
                ExpirationDate = offerDto.ExpirationDate,
                Requests = existingOffer.Requests ?? new List<Request>(),
                Transactions = existingOffer.Transactions ?? new List<Transaction>()
            };
        }
    }
}
