using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.Sql.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly SuperMarketDbContext _superMarketDbContext;

        public TransactionRepository(SuperMarketDbContext superMarketDbContext)
        {
            _superMarketDbContext = superMarketDbContext;
        }

        public IEnumerable<Transaction> GetAll(string cashierName)
        {
            if(string.IsNullOrEmpty(cashierName))
            {
                return _superMarketDbContext.Transactions.ToList();
            }
            else
            {
                return _superMarketDbContext.Transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
            }
        }

        public IEnumerable<Transaction> GetByDateRange(string cashierName, DateTime startDate, DateTime endDate)
        {
            if(string.IsNullOrEmpty(cashierName))
            {
                    return _superMarketDbContext.Transactions
                    .Where(x => x.TimeStamp.Date >= startDate 
                    && x.TimeStamp.Date <= endDate).ToList();
            }
            else
            {
                return _superMarketDbContext.Transactions
                    .Where(x => x.TimeStamp.Date >= startDate
                    && x.TimeStamp.Date <= endDate
                    && x.CashierName == cashierName).ToList();
                    // && string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        public IEnumerable<Transaction> GetTransactionsByDay(string cashierName, DateTime day)
        {
            if (string.IsNullOrEmpty(cashierName))
            {
                return _superMarketDbContext.Transactions.Where(x => x.TimeStamp.Date == day.Date);
            }
            else
            {
                return _superMarketDbContext.Transactions.Where(
                    x => x.TimeStamp.Date == day.Date
                    && x.CashierName == cashierName).ToList();
                   // && string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        public void Save(string cashierName, int productId, string productName, decimal price, int beforeQuantity, int soldQuantity)
        {
            _superMarketDbContext.Transactions.Add(new Transaction
            {
                CashierName = cashierName,
                ProductId = productId,
                ProductName = productName,
                Price = price,
                BeforeQuantity = beforeQuantity,
                Quantity = soldQuantity,
                TimeStamp = DateTime.UtcNow
            });          
            _superMarketDbContext.SaveChanges();
        }
    }
}
