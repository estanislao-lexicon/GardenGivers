using API.Interfaces;
using API.Models;

namespace API.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        public bool CreateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Transaction GetTransaction(int transactionId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Transaction> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool TransactionExists(int transactionId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
