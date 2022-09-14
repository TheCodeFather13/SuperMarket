using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.Sql.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SuperMarketDbContext _superMarketDbContext;

        public ProductRepository(SuperMarketDbContext superMarketDbContext)
        {
            _superMarketDbContext = superMarketDbContext;
        }

        public void AddProduct(Product product)
        {
            _superMarketDbContext.Products.Add(product);
            _superMarketDbContext.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = GetProductById(productId);
            if(productToDelete == null)
            {
                return;
            }
            _superMarketDbContext.Products.Remove(productToDelete);
            _superMarketDbContext.SaveChanges();
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId)
        {
            return _superMarketDbContext.Products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public Product GetProductById(int id)
        {
            return _superMarketDbContext.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _superMarketDbContext.Products.ToList();
        }

        public void Update(Product product)
        {           
            var productToUpdate = GetProductById(product.ProductId);
            if (productToUpdate == null)
            {
                return;
            }
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Quantity = product.Quantity;
            productToUpdate.CategoryId = product.CategoryId;
            _superMarketDbContext.SaveChanges();         
        }
    }
}
