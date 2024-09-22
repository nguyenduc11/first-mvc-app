namespace MyApp.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category() { CategoryId = 1, Name = "Beverage", Description = "Beverage desc" },
            new Category() { CategoryId = 2, Name = "Bakery", Description = "Bakery desc" },
            new Category() { CategoryId = 3, Name = "Meat", Description = "Meat desc" },
        };

        public static void AddCategory(Category category)
        {
            int maxId = _categories.Any() ? _categories.Max(c => c.CategoryId) : 0;
            category.CategoryId = maxId + 1;
            _categories.Add(category);
        }

        public static List<Category> GetCategories()
        {
            return _categories;
        }

        public static Category? GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
            return category != null ? new Category
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description
            } : null;
        }

        public static void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId) return;

            var categoryToUpdate = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public static void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == categoryId);

            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}
