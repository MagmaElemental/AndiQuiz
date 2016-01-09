namespace AndiQuiz.Server.Services.Data
{
    using System.Linq;
    using Server.Data.Models;
    using Server.Data.Repositories;
    using Contracts;

    public class CategoryService : ICategoryService
    {
        private IRepository<Category> categories;

        public CategoryService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Category> GetAllCategories()
        {
            var categories = this.categories
                .All();

            return categories;
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
