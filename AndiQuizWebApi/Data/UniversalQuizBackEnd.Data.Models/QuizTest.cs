namespace UniversalQuizBackEnd.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using UniversalQuizBackEnd.Common.Constants;

    public class QuizTest
    {
        private ICollection<QuizQuestion> quizQuestion;

        public QuizTest()
        {
            this.quizQuestion = new HashSet<QuizQuestion>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(QuizConstants.QuestionMaxLength)]
        [MinLength(QuizConstants.QuestionMinLength)]
        public string Title { get; set; }

        public virtual ICollection<QuizQuestion> QuizQuestion
        {
            get { return this.quizQuestion; }
            set { this.quizQuestion = value; }
        }
    }
}
