using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.InMemory
{
    public class ProductRepository
    {
        private List<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    CategoryId = 1,
                    Name = "Toys",
                    Quantity = 15,
                    Price = 12.5m
                },

                new Product()
                {
                    ProductId = 2,
                    CategoryId = 2,
                    Name = "Cosmetics",
                    Quantity = 35,
                    Price = 18.3m
                },

                new Product()
                {
                    ProductId = 3,
                    CategoryId = 1,
                    Name = "Batman toys",
                    Quantity = 27,
                    Price = 5.7m
                }
            };
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
    }
}
