namespace AndiQuiz.Server.Data.Models
{
    using Common.Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Question
    {
        private ICollection<Answer> answers;
        private ICollection<UserAnswer> userAnswers;

        public Question()
        {
            this.answers = new HashSet<Answer>();
            this.userAnswers = new HashSet<UserAnswer>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(QuizConstants.QuestionMaxLength)]
        [MinLength(QuizConstants.QuestionMinLength)]
        public string Content { get; set; }

        public virtual ICollection<Answer> Answers
        {
            get { return this.answers; }
            set { this.answers = value; }
        }

        public virtual ICollection<UserAnswer> UserAnswers
        {
            get { return this.userAnswers; }
            set { this.userAnswers = value; }
        }

        public int TestId { get; set; }

        public virtual Test Test { get; set; }
    }
}
