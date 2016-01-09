namespace AndiQuiz.Server.Services.Data.Contracts
{
    using System.Linq;
    using Server.Data.Models;

    public interface IQuizService
    {
        IQueryable<Question> GetQuestionsForQuiz(Quiz quiz);

        IQueryable<Quiz> GetAllQuizsForUser(User user);

        IQueryable<Quiz> GetAllQuizs();

        Quiz MakeQuiz(User user, string title, Category category);
    }
}
