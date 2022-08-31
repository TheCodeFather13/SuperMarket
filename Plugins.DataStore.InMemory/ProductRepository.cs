using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>();
        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    CategoryId = 1,
                    Name = "Adventures of Tom Sowyer",
                    Quantity = 15,
                    Price = 12.5m
                },

                new Product()
                {
                    ProductId = 2,
                    CategoryId = 2,
                    Name = "BMW Toy",
                    Quantity = 35,
                    Price = 18.3m
                },

                new Product()
                {
                    ProductId = 3,
                    CategoryId = 1,
                    Name = "Vinni Poof",
                    Quantity = 27,
                    Price = 5.7m
                }
            };
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public void AddProduct(Product product)
        {
            if (_products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;

            if(_products != null && _products.Count > 0)
            {
                var maxProductId = _products.Max(x => x.ProductId);
                product.ProductId = maxProductId + 1;
            }
            else
            {
                product.ProductId = 1;
            }
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var productToUpdate = GetProductById(product.ProductId);
            if(productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.Price = product.Price;
                productToUpdate.Quantity = product.Quantity;
            }           
        }

        public Product GetProductById(int id)
        {
           return _products.Find(x => x.ProductId == id);                      
        }
    }
}
