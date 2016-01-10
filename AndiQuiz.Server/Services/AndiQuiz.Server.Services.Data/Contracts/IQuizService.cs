namespace AndiQuiz.Server.Services.Data.Contracts
{
    using System.Linq;
    using Server.Data.Models;

    public interface IQuizService
    {
        IQueryable<Question> GetQuestionsForQuiz(Quiz quiz);

        IQueryable<Quiz> GetAllQuizzesForUser(User user);

        IQueryable<Quiz> GetAllQuizzes();

        Quiz MakeQuiz(User user, string title, Category category);
    }
}
