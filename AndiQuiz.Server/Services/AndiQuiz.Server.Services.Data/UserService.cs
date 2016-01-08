namespace AndiQuiz.Server.Services.Data
{
    using System.Linq;
    using Contracts;
    using Server.Data.Models;
    using Server.Data.Repositories;
    using System.Collections.Generic;
    using System;

    public class UserService : IUserService
    {
        private readonly IRepository<User> users;
        private readonly IRepository<UserQuizStatistic> statistics;
        private readonly IRepository<UserAnswer> userAnswers;
        private readonly IRepository<Quiz> quizs;

        public UserService(IRepository<User> users,
            IRepository<UserQuizStatistic> statistics,
            IRepository<UserAnswer> userAnswers,
            IRepository<Quiz> quizs)
        {
            this.users = users;
            this.statistics = statistics;
            this.userAnswers = userAnswers;
            this.quizs = quizs;
        }

        public IQueryable<User> GetUserById(string userId)
        {
            var user = this.users
                .All()
                .Where(u => u.Id == userId);

            return user;
        }

        public IQueryable<Quiz> GetAllQuizsForUser(string userId)
        {
            var quizs = this.quizs
                .All()
                .Where(q => q.UserId == userId);

            return quizs;
        }

        public IQueryable<UserQuizStatistic> GetAllStatisticsForUser(string userId)
        {
            var statistics = this.statistics
                .All()
                .Where(s => s.UserId == userId);

            return statistics;
        }

        public void MakeUserAnswers(string userId, List<Answer> answers)
        {
            var user = this.users.GetById(userId);

            foreach (var answer in answers)
            {
                var currentUserAnswer = new UserAnswer()
                {
                    User = user,
                    QuestionId = answer.QuestionId,
                    AnswerId = answer.Id
                };

                this.userAnswers.Add(currentUserAnswer);
            }

            this.userAnswers.SaveChanges();
        }

        public UserQuizStatistic MakeUserStatistic(string userId, int quizId, int correctAnswers, int totalAnswersInQuiz)
        {
            var newStatistic = new UserQuizStatistic()
            {
                UserId = userId,
                QuizId = quizId,
                CorrectAnswers = correctAnswers,
                TotalQuizAnswers = totalAnswersInQuiz
            };

            this.statistics.Add(newStatistic);
            this.statistics.SaveChanges();

            return newStatistic;
        }
    }
}
