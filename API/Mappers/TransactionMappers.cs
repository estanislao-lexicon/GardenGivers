using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Task;
using API.Models;
using API.Dtos.Transaction;

namespace API.Mappers
{
    public static class TransactionMappers
    {
        public static TransactionDto ToTransactionDto(this Transaction transactionModel)
        {
            return new TransactionDto
            {
                TransactionId = transactionModel.TransactionId,
                OfferId = transactionModel.OfferId,
                RequestId = transactionModel.RequestId,
                Quantity = transactionModel.Quantity,
                TransactionDate = transactionModel.TransactionDate
            };
        }

        public static Transaction ToTransactionFromCreate(this CreateTransactionRequestDto transactionDto, int offerId, int requestId)
        {
            return new Transaction
            {
                OfferId = offerId,
                RequestId = requestId,
                Quantity = transactionDto.Quantity,                
            };
        }

        public static Transaction ToTransactionFromUpdate(this UpdateTransactionRequestDto transactionDto)
        {
            return new Transaction
            {
                Quantity = transactionDto.Quantity,                
            };
        }
    }
}
