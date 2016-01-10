namespace AndiQuiz.Server.Services.Data
{
    using System.Linq;
    using Server.Data.Models;
    using Server.Data.Repositories;
    using Contracts;
    using System;
    public class QuizService : IQuizService
    {
        private readonly IRepository<Quiz> quizzes;
        private readonly IRepository<Question> questions;
        private readonly IRepository<Answer> answers;

        public QuizService(IRepository<Quiz> quizzes, IRepository<Question> questions, IRepository<Answer> answers)
        {
            this.quizzes = quizzes;
            this.questions = questions;
            this.answers = answers;
        }

        public IQueryable<Question> GetQuestionsForQuiz(Quiz quiz)
        {
            var questions = this.quizzes
                .All()
                .Where(q => q.Id == quiz.Id)
                .SelectMany(q => q.Questions);

            return questions;
        }

        public IQueryable<Quiz> GetAllQuizzesForUser(User user)
        {
            var quizzes = this.quizzes
                .All()
                .OrderByDescending(q => q.CreatedOn)
                .Where(q => q.UserId == user.Id);

            return quizzes;
        }

        public IQueryable<Quiz> GetAllQuizzesForCategory(int categoryId)
        {
            var quizzes = this.quizzes
                .All()
                .Where(q => q.CategoryId == categoryId);

            return quizzes;
        }

        public IQueryable<Quiz> GetAllQuizzes()
        {
            var quizzes = this.quizzes
                .All()
                .OrderByDescending(q => q.CreatedOn);

            return quizzes;
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

            this.quizzes.Add(quiz);
            this.quizzes.SaveChanges();

            return quiz;
        }
    }
}
