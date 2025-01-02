using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Helpers;
using API.Dtos.Transaction;

namespace API.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(int transactionId);
        Task<Transaction> CreateAsync(Transaction transactionModel);
        Task<Transaction?> UpdateAsync(int transactionId, UpdateTransactionRequestDto transactionDto);
        Task<Transaction?> DeleteAsync (int transactionId);
        Task<bool> TransactionExists(int transactionId);
    }
}
