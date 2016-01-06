namespace UniversalQuizBackEnd.Data.Models
{
    using Common.Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class QuizQuestion
    {
        private ICollection<QuizAnswer> quizAnswers;
        private ICollection<UserAnswer> userAnswers;

        public QuizQuestion()
        {
            this.quizAnswers = new HashSet<QuizAnswer>();
            this.userAnswers = new HashSet<UserAnswer>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(QuizConstants.QuestionMaxLength)]
        [MinLength(QuizConstants.QuestionMinLength)]
        public string Question { get; set; }

        public virtual ICollection<QuizAnswer> QuizAnswers
        {
            get { return this.quizAnswers; }
            set { this.quizAnswers = value; }
        }

        public virtual ICollection<UserAnswer> UserAnswers
        {
            get { return this.userAnswers; }
            set { this.userAnswers = value; }
        }

        public int QuizTestId { get; set; }

        public virtual QuizTest QuizTest { get; set; }
    }
}
