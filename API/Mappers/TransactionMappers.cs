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

        public static Transaction ToTransactionFromCreateDTO(this CreateTransactionRequestDto transactionDto)
        {
            return new Transaction
            {
                OfferId = transactionDto.OfferId,
                RequestId = transactionDto.RequestId,
                Quantity = transactionDto.Quantity,
                TransactionDate = transactionDto.TransactionDate
            };
        }
    }
}
