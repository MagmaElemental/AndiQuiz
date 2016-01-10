namespace AndiQuiz.Server.Common.Constants
{
    public class GlobalConstants
    {
        public const int DefaultPageSize = 10;

        public const string RequestCannotBeEmpty = "Request cannot be empty!";

        public const string WrongRatingErrorMessage = "Wrong Rating, must be a value from 1 to 5!";

        public const string WrongCategoryErrorMessage = "There is no such category!";

        public const string NoCategoriesInDbErrorMessage = "Sorry currently there are no categories, maybe add one.";

        public const string WrongQuizErrorMessage = "There is no such quiz!";

        public const string WrongUserNameErrorMessage = "There is no such user!";

        public const string NoQuizzesInDbErrorMessage = "Sorry currently there are no quizzes, maybe add one.";

        public const string QuizAlreadyExistsErrorMessage = "This Title is already taken!";

        public const string WebApiAssemblyName = "AndiQuiz.Server.Api";
    }
}
