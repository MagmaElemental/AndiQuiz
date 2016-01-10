namespace AndiQuiz.Server.Data.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Common.Constants;

    public class User : IdentityUser
    {
        private ICollection<UserQuizStatistic> quizStatistics;
        private ICollection<Quiz> quizzes;
        private ICollection<QuizRating> quizzesRating;
        private ICollection<Question> questions;
        private ICollection<UserAnswer> answers;

        public User()
        {
            this.quizStatistics = new HashSet<UserQuizStatistic>();
            this.quizzes = new HashSet<Quiz>();
            this.quizzesRating = new HashSet<QuizRating>();
            this.questions = new HashSet<Question>();
            this.answers = new HashSet<UserAnswer>();
        }

        [Required]
        [MinLength(QuizConstants.NameMinLength)]
        [MaxLength(QuizConstants.NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(QuizConstants.NameMinLength)]
        [MaxLength(QuizConstants.NameMaxLength)]
        public string LastName { get; set; }

        public virtual ICollection<UserQuizStatistic> QuizStatistics
        {
            get { return this.quizStatistics; }
            set { this.quizStatistics = value; }
        }

        public virtual ICollection<Quiz> Quizzes
        {
            get { return this.quizzes; }
            set { this.quizzes = value; }
        }

        public virtual ICollection<QuizRating> QuizzesRating
        {
            get { return this.quizzesRating; }
            set { this.quizzesRating = value; }
        }

        public virtual ICollection<Question> Questions
        {
            get { return this.questions; }
            set { this.questions = value; }
        }

        public virtual ICollection<UserAnswer> Albums
        {
            get { return this.answers; }
            set { this.answers = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
