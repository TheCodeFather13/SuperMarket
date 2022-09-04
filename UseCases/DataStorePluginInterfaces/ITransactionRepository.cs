using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        void Save(string cashierName, int productId, decimal price, int quantity);
        IEnumerable<Transaction> GetTransactionsByDay(DateTime day);
    }
}
