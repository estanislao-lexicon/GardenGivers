using API.Models;
using API.Dtos.Request;
using API.Dtos.Transaction;

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
                OfferId = requestModel.OfferId,
                Quantity = requestModel.Quantity,
                DateCreated = requestModel.DateCreated,
                Transactions = requestModel.Transactions != null
                                ? requestModel.Transactions.Select(t => t.ToTransactionDto()).ToList()
                                : new List<TransactionDto>()
            };
        }

        public static Request ToRequestFromCreate(this CreateRequestDto requestDto, string userId, int offerId)
        {
            return new Request
            {
                UserId = userId,
                OfferId = offerId,
                Quantity = requestDto.Quantity,
                Transactions = new List<Transaction>()                
            };
        }

        public static Request ToRequestFromUpdate(this UpdateRequestDto requestDto, string userId, int offerId, Request existingRequest)
        {
            return new Request
            {
                UserId = userId,
                OfferId = offerId,
                Quantity = requestDto.Quantity,
                Transactions = existingRequest.Transactions ?? new List<Transaction>()
            };
        }
    }
}
