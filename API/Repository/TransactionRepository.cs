using API.Interfaces;
using API.Models;
using API.Data;

namespace API.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _context;

        public TransactionRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateTransaction(Transaction transaction)
        {
            _context.Add(transaction);
            return Save();
        }

        public bool DeleteTransaction(Transaction transaction)
        {
            _context.Remove(transaction);
            return Save();
        }

        public Transaction GetTransaction(int transactionId)
        {
            return _context.Transactions.Where(t => t.TransactionId == transactionId).FirstOrDefault();
        }

        public ICollection<Transaction> GetTransactions()
        {
            return _context.Transactions.ToList();
        }

        public bool TransactionExists(int transactionId)
        { 
            return _context.Transactions.Any(t => t.TransactionId == transactionId);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }       

        public bool UpdateTransaction(Transaction transaction)
        {
            _context.Update(transaction);
            return Save();
        }
    }
}
