﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductsUseCasesInterfaces;

namespace UseCases.ProductsUseCase
{
   public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductUseCase(IProductRepository productRepository)
        {
           _productRepository = productRepository;
        }

        public void Delete(int productId)
        {
            _productRepository.DeleteProduct(productId);
        }
    }
}
