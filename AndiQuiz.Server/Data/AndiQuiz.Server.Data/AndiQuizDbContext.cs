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

        public IDbSet<Question> QuizQuestions { get; set; }

        public IDbSet<Answer> QuizAnswers { get; set; }

        public IDbSet<Test> QuizTests { get; set; }
    }
}
