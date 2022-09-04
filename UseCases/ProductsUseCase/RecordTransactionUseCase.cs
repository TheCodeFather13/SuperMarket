using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductsUseCasesInterfaces;
using UseCases.UseCasesInterfaces;

namespace UseCases.ProductsUseCase
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IGetProductByIdUseCase _getProductByIdUseCase;

        public RecordTransactionUseCase(ITransactionRepository transactionRepository, IGetProductByIdUseCase getProductByIdUseCase)
        {
            _transactionRepository = transactionRepository;
            _getProductByIdUseCase = getProductByIdUseCase;
        }

        public void Execute(string cashierName, int productId, int quantity)
        {
            var product = _getProductByIdUseCase.GetProductById(productId);
            _transactionRepository.Save(cashierName, productId, product.Price, quantity);
        }
    }
}
