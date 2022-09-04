using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionRepository : ITransactionRepository
    {
        private List<Transaction> _transactions = new List<Transaction>();
        public TransactionRepository(List<Transaction> transactions)
        {
            _transactions = transactions;
        }
        public IEnumerable<Transaction> GetTransactionsByDay(DateTime day)
        {
            throw new NotImplementedException();
        }

        public void Save(string cashierName, int productId, decimal price, int quantity)
        {
            int transactionId = 1;
            if(_transactions != null && _transactions.Count > 0)
            {
                int maxId = _transactions.Max(x => x.TransactionId);
                transactionId = maxId + 1;
            }

            _transactions.Add(new Transaction
            {
                TransactionId = transactionId,
                ProductId = productId,
                TimeStamp = DateTime.UtcNow,
                Price = price,
                Quantity = quantity,
                CashierName = cashierName
            });
        }
    }
}
