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

        Category MakeCategory(string name);
    }
}
