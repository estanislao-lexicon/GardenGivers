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
                OfferId = requestModel.OfferId,
                Quantity = requestModel.Quantity,
                DateCreated = requestModel.DateCreated,
                Transactions = requestModel.Transactions.Select(t => t.ToTransactionDto()).ToList()
            };
        }

        public static Request ToRequestFromCreate(this CreateRequestDto requestDto, int offerId)
        {
            return new Request
            {
                OfferId = offerId,
                Quantity = requestDto.Quantity,
                Transactions = new List<Transaction>()                
            };
        }

        public static Request ToRequestFromUpdate(this UpdateRequestDto requestDto, int offerId)
        {
            return new Request
            {
                OfferId = offerId,
                Quantity = requestDto.Quantity,
                Transactions = new List<Transaction>()
            };
        }
    }
}
