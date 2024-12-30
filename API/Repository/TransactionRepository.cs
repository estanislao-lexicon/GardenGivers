using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFramworkCore;
using API.Interfaces;
using API.Models;
using API.Data;
using API.Dtos.Transaction;
using API.Helpers;

namespace API.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDBContext _context;
        public TransactionRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Lis<Transaction>> GetAllAsync(QueryObject query)
        {
            return await _context.Transaction.ToListAsync();
        }
        public async Task<Transaction> GetByIdAsync(int transactionId)
        {
            return await _context.Transaction.Include(t => t.transactionId).FirstOrDefaultAsync(i => i.transactionId == transactionId);
        }
        public async Task<Transaction> CreateAsync(Transaction transactionModel)
        {
            await _context.Transaction.AddAsync(transactionModel);
            await _context.SaveChangesAsync();
            return transactionModel;
        }

        public async Task<Transaction?> DeleteAsync (int transactionId)
        {
            var transactionModel = await _context.Transaction.FirstOrDefaultAsync(t => t.TransactionId = transactionId);
            
            if(transactionModel == null)
            {
                return null;
            }

            _context.Transaction.Remove(transactionModel);
            await _context.SaveChangesAsync();
            return transactionModel;
        }

        public Task<bool> TransactionExists(int transactionId)
        { 
            return _context.Transactions.AnyAsync(t => t.TransactionId == transactionId);
        }
        public async Task<Transaction?> UpdateAsync (int transactionId, UpdateTransactionRequestDto transactionDto)
        {
            var existingTransaction = await _context.Transaction.FirstOrDefaultAsync(t => t.TransactionId == transactionId);

            if(existingTransaction == null)
            {
                return null;
            }

            existingTransaction.Quantity = transactionDto.Quantity;

            await _context.SaveChangesAsync();
            return existingTransaction;
        }
    }
}
