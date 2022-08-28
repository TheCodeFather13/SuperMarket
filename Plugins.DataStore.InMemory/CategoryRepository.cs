using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;

        public CategoryRepository()
        {
            _categories.Add(new Category()
            {
                CategoryId = 1,
                Name = "Books",
                Description = "Books category example"
            });

            _categories.Add(new Category()
            {
                CategoryId = 2,
                Name = "Cars",
                Description = "Cars category example"
            });

            _categories.Add(new Category()
            {
                CategoryId = 3,
                Name = "Sports",
                Description = "Sports category example"
            });
        }

        public void AddCategory(Category category)
        {
           if(_categories != null && _categories.Count > 0)
            {
                var maxCategoryId = _categories.Max(x => x.CategoryId);
                category.CategoryId = maxCategoryId + 1;
            }
            else
            {
                category.CategoryId = 1;
            }          
            _categories.Add(category);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.CategoryId);
                if(categoryToUpdate != null)
            {
                categoryToUpdate = category;
            }
            else
            {
                _categories.Add(category);
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categories?.FirstOrDefault(x => x.CategoryId == categoryId);
        }

        public void DeleteCategory(int categoryId)
        {
            _categories?.Remove(GetCategoryById(categoryId));
        }
    }
}