namespace AndiQuiz.Server.Services.Data.Contracts
{
    using System.Linq;
    using Server.Data.Models;
    using System.Collections.Generic;

    public interface IUserService
    {
        IQueryable<User> GetUserById(string userId);

        IQueryable<UserQuizStatistic> GetAllStatisticsForUser(string userId);

        IQueryable<Quiz> GetAllQuizsForUser(string userId);

        void MakeUserAnswers(string userId, List<Answer> answers);

        UserQuizStatistic MakeUserStatistic(string userId, int quizId, int correctAnswers, int totalAnswersInQuiz);
    }
}
