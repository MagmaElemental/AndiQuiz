namespace AndiQuiz.Server.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Common.Constants;
    using Models.Category;
    using Models.Quiz;
    using Services.Data.Contracts;

    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        private ICategoryService categories;
        private IQuizService quizzes;

        public CategoryController(ICategoryService categories, IQuizService quizzes)
        {
            this.categories = categories;
            this.quizzes = quizzes;
        }

        [HttpGet]
        [Route("{categoryName}")]
        public IHttpActionResult GetCategoryDetails(string categoryName)
        {
            var categoryExists = this.categories.CategoryExists(categoryName);
            if (!categoryExists)
            {
                return this.BadRequest(GlobalConstants.WrongCategoryErrorMessage);
            }

            var categoriesDetails = this.categories
                .GetCategoryByName(categoryName)
                .ProjectTo<CategoryDetailsResponseModel>()
                .ToList();

            return this.Ok(categoriesDetails);
        }

        [HttpGet]
        [Authorize]
        [Route("{categoryName}/Quizzes")]
        public IHttpActionResult GetAllQuizzesForCategory(string categoryName, int page = 1, int pageSize = GlobalConstants.DefaultPageSize)
        {
            var category = this.categories
                .GetCategoryByName(categoryName)
                .FirstOrDefault();

            if (category == null)
            {
                return this.BadRequest(GlobalConstants.WrongCategoryErrorMessage);
            }

            var quizzes = this.quizzes
                .GetAllQuizzesForCategory(category)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<QuizDetailsResponseModel>()
                .ToList();

            return this.Ok(quizzes);
        }

        [HttpGet]
        [Route("All")]
        public IHttpActionResult GetAllCategories(int page = 1, int pageSize = GlobalConstants.DefaultPageSize)
        {
            if (this.categories.GetAllCategories().ToList().Count == 0)
            {
                return this.BadRequest(GlobalConstants.NoCategoriesInDbErrorMessage);
            }

            var categoriesDetails = this.categories
                .GetAllCategories()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<CategoryDetailsResponseModel>()
                .ToList();

            return this.Ok(categoriesDetails);
        }
    }
}
