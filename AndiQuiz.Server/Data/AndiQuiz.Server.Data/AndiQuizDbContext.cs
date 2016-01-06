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

        public IDbSet<UserAnswer> UserAnswers { get; set; }

        public IDbSet<Question> Questions { get; set; }

        public IDbSet<Answer> Answers { get; set; }

        public IDbSet<Quiz> Quizs { get; set; }
    }
}
