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
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IRecordTransactionUseCase _recordTransactionUseCase;

        public SellProductUseCase(IProductRepository productRepository, IRecordTransactionUseCase recordTransactionUseCase)
        {
            _productRepository = productRepository;
            _recordTransactionUseCase = recordTransactionUseCase;
        }

        public void Execute(string cashierName, int productId, int quantityToSell)
        {
           var productToSell = _productRepository.GetProductById(productId);
            if (productToSell == null) return;

            // change product quantity
            productToSell.Quantity -= quantityToSell;

            // then update product
            _productRepository.Update(productToSell);
            _recordTransactionUseCase.Execute(cashierName, productId, quantityToSell);
        }
    }
}
