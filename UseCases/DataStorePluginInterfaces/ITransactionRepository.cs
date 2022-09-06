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
        void Save(string cashierName, int productId,string productName, decimal price, int beforeQuantity, int soldQuantity);
        IEnumerable<Transaction> GetTransactionsByDay(string cashierName, DateTime day);
        IEnumerable<Transaction> GetAll(string cashierName);
    }
}
