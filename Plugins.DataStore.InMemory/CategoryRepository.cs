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
        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }
    }
}