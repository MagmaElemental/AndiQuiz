namespace AndiQuiz.Server.Services.Data.Contracts
{
    using AndiQuiz.Server.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserStatisticService
    {
        IQueryable<UserQuizStatistic> GetAllStatisticsForUser(User user);

        void MakeUserStatistic(User user, int quizId, int correctAnswers, int totalAnswersInQuiz);
    }
}
