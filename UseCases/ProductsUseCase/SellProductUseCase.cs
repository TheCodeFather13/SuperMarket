using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductsUseCasesInterfaces;

namespace UseCases.ProductsUseCase
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public SellProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Execute(int productId, int quatityToSell)
        {
           var productToSell = _productRepository.GetProductById(productId);
            if (productToSell == null) return;

            // change product quantity
            productToSell.Quantity -= quatityToSell;

            // then update product
            _productRepository.Update(productToSell);
        }
    }
}
