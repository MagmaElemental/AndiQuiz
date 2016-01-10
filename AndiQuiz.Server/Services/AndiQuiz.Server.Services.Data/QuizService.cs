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
        private readonly IRepository<QuizRating> ratings;

        public QuizService(IRepository<Quiz> quizzes,
            IRepository<Question> questions,
            IRepository<Answer> answers,
            IRepository<QuizRating> ratings)
        {
            this.quizzes = quizzes;
            this.questions = questions;
            this.answers = answers;
            this.ratings = ratings;
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

        public IQueryable<Quiz> GetAllQuizzesForCategory(Category category)
        {
            var quizzes = this.quizzes
                .All()
                .OrderByDescending(q => q.CreatedOn)
                .Where(q => q.CategoryId == category.Id);

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

        public void RateQuiz(Quiz quiz, User user, int Rate)
        {
            var userRating = this.ratings
                .All()
                .Where(r => r.QuizId == quiz.Id && r.UserId == user.Id)
                .FirstOrDefault();

            if (userRating != null)
            {
                this.ratings.Delete(userRating);
            }

            var ratingToAdd = new QuizRating()
            {
                QuizId = quiz.Id,
                UserId = user.Id,
                Rate = Rate
            };

            this.ratings.Add(ratingToAdd);
            this.ratings.SaveChanges();
        }

        public IQueryable<Quiz> GetQuizById(int quizId)
        {
            var quiz = this.quizzes
                .All()
                .Where(q => q.Id == quizId);

            return quiz;
        }

        public bool QuizExists(int quizId)
        {
            var quiz = this.quizzes.GetById(quizId);
            if (quiz == null)
            {
                return false;
            }

            return true;
        }
    }
}
