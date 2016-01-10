namespace AndiQuiz.Server.Data
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class AndiQuizDbContext : IdentityDbContext<User>, IAndiQuiz
    {
        public AndiQuizDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static AndiQuizDbContext Create()
        {
            return new AndiQuizDbContext();
        }

        public IDbSet<Answer> Answers { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Question> Questions { get; set; }

        public IDbSet<Quiz> Quizzes { get; set; }

        public IDbSet<QuizRating> QuizRatings { get; set; }

        public IDbSet<UserAnswer> UserAnswers { get; set; }

        public IDbSet<UserQuizStatistic> UserQuizStatistics { get; set; }
    }
}
