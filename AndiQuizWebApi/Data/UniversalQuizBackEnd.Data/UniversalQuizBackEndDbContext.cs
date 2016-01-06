namespace UniversalQuizBackEnd.Data
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class UniversalQuizBackEndDbContext : IdentityDbContext<User>, IUniversalQuizBackEnd
    {
        public UniversalQuizBackEndDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static UniversalQuizBackEndDbContext Create()
        {
            return new UniversalQuizBackEndDbContext();
        }

        public IDbSet<UserAnswer> UserAnswers { get; set; }

        public IDbSet<QuizQuestion> QuizQuestions { get; set; }

        public IDbSet<QuizAnswer> QuizAnswers { get; set; }

        public IDbSet<QuizTest> QuizTests { get; set; }
    }
}
