using API.Models;

namespace API.Interfaces
{
    public interface ITransactionRepository
    {
        ICollection<Transaction> GetTransactions();
        Transaction GetTransaction(int transactionId);        
        bool TransactionExists(int transactionId);
        bool CreateTransaction(Transaction transaction);
        bool UpdateTransaction(Transaction transaction);
        bool DeleteTransaction(Transaction transaction);
        bool Save();
    }
}
