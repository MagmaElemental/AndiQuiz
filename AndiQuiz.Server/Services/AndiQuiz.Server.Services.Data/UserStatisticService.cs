namespace AndiQuiz.Server.Services.Data
{
    using AndiQuiz.Server.Data.Models;
    using AndiQuiz.Server.Data.Repositories;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserStatisticService : IUserStatisticService
    {
        private IRepository<UserQuizStatistic> statistics;

        public UserStatisticService(IRepository<UserQuizStatistic> statistics)
        {
            this.statistics = statistics;
        }

        public IQueryable<UserQuizStatistic> GetAllStatisticsForUser(User user)
        {
            var statistics = this.statistics
                .All()
                .Where(s => s.UserId == user.Id);

            return statistics;
        }

        public void MakeUserStatistic(User user, int quizId, int correctAnswers, int totalAnswersInQuiz)
        {
            var newStatistic = new UserQuizStatistic()
            {
                UserId = user.Id,
                QuizId = quizId,
                CorrectAnswers = correctAnswers,
                TotalQuizAnswers = totalAnswersInQuiz
            };

            this.statistics.Add(newStatistic);
            this.statistics.SaveChanges();
        }
    }
}
