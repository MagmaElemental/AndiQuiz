namespace AndiQuiz.Server.Services.Data
{
    using System.Linq;
    using Server.Data.Models;
    using Server.Data.Repositories;
    using Contracts;
    using System;

    public class CategoryService : ICategoryService
    {
        private IRepository<Category> categories;

        public CategoryService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public bool CategoryExists(string categoryName)
        {
            return this.categories.All().Any(c => c.Name == categoryName);
        }

        public IQueryable<Category> GetAllCategories()
        {
            var categories = this.categories
                .All();

            return categories;
        }

        public IQueryable<Category> GetCategoryByName(string categoryName)
        {
            var category = this.categories
                .All()
                .Where(c => c.Name == categoryName);

            return category;
        }

        public Category MakeCategory(string name)
        {
            var newCategory = new Category()
            {
                Name = name
            };

            this.categories.Add(newCategory);
            this.categories.SaveChanges();

            return newCategory;
        }
    }
}
