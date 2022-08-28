using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;

        public CategoryRepository()
        {
            _categories = new List<Category>()
            {
                new Category { CategoryId = 1, Name = "Books", Description = "Original Books"},
                new Category { CategoryId = 2, Name = "NoteBooks", Description = "Original NoteBooks"},
                new Category { CategoryId = 3, Name = "Monitors", Description = "Original Monitors"},
            };
        }

        public void AddCategory(Category category)
        {
            if (_categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
           
            var maxCategoryId=_categories.Max(x => x.CategoryId);
            category.CategoryId = maxCategoryId + 1;
           
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
    }
}