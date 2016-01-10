namespace AndiQuiz.Server.Services.Data.Contracts
{
    using Server.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        IQueryable<Category> GetAllCategories();

        IQueryable<Category> GetCategoryByName(string categoryName);

        bool CategoryExists(string categoryName);

        Category MakeCategory(string name);
    }
}
