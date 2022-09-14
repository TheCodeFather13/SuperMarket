using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.Sql.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SuperMarketDbContext _superMarketDbContext;

        public CategoryRepository(SuperMarketDbContext superMarketDbContext)
        {
            _superMarketDbContext = superMarketDbContext;
        }

        public void AddCategory(Category category)
        {
            _superMarketDbContext.Categories.Add(category);
            _superMarketDbContext.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var categoryToDelete = GetCategoryById(categoryId);
            if(categoryToDelete == null)
            {
                return;
            }
           _superMarketDbContext.Categories.Remove(categoryToDelete);
           _superMarketDbContext.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
           return _superMarketDbContext.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {           
            return _superMarketDbContext.Categories.Find(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.CategoryId);
            if (categoryToUpdate == null)
            {
                return;
            }
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Description = category.Description;   
            _superMarketDbContext.SaveChanges();
        }
    }
}
