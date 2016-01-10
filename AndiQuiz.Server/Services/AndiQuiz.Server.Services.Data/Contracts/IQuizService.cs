namespace AndiQuiz.Server.Services.Data.Contracts
{
    using System.Linq;
    using Server.Data.Models;

    public interface IQuizService
    {
        IQueryable<Question> GetQuestionsForQuiz(Quiz quiz);

        IQueryable<Quiz> GetAllQuizzesForUser(User user);

        IQueryable<Quiz> GetAllQuizzesForCategory(Category category);

        IQueryable<Quiz> GetAllQuizzes();

        IQueryable<Quiz> GetQuizById(int quizId);

        IQueryable<Quiz> GetQuizByTitle(string title);

        void RateQuiz(Quiz quiz, User user, int Rating);

        Quiz MakeQuiz(User user, string title, Category category);

        bool QuizExists(int quizId);
    }
}
