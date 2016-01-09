namespace AndiQuiz.Server.Services.Data
{
    using System.Linq;
    using Server.Data.Models;
    using Server.Data.Repositories;
    using Contracts;
    using System;
    public class QuizService : IQuizService
    {
        private readonly IRepository<Quiz> quizs;
        private readonly IRepository<Question> questions;
        private readonly IRepository<Answer> answers;

        public QuizService(IRepository<Quiz> quizs, IRepository<Question> questions, IRepository<Answer> answers)
        {
            this.quizs = quizs;
            this.questions = questions;
            this.answers = answers;
        }

        public IQueryable<Question> GetQuestionsForQuiz(Quiz quiz)
        {
            var questions = this.quizs
                .All()
                .Where(q => q.Id == quiz.Id)
                .SelectMany(q => q.Questions);

            return questions;
        }

        public IQueryable<Quiz> GetAllQuizsForUser(User user)
        {
            var quizs = this.quizs
                .All()
                .Where(q => q.UserId == user.Id);

            return quizs;
        }

        public IQueryable<Quiz> GetAllQuizsForCategory(int categoryId)
        {
            var quizs = this.quizs
                .All()
                .Where(q => q.CategoryId == categoryId);

            return quizs;
        }

        public IQueryable<Quiz> GetAllQuizs()
        {
            var quizs = this.quizs
                .All()
                .OrderByDescending(q => q.CreatedOn);

            return quizs;
        }

        public Quiz MakeQuiz(User user, string title, Category category)
        {
            var quiz = new Quiz()
            {
                UserId = user.Id,
                CategoryId = category.Id,
                Title = title,
                CreatedOn = DateTime.Now
            };

            this.quizs.Add(quiz);
            this.quizs.SaveChanges();

            return quiz;
        }
    }
}
