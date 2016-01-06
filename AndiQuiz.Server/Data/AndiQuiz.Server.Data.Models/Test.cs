namespace AndiQuiz.Server.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using System;
    public class Test
    {
        private ICollection<Question> questions;

        public Test()
        {
            this.questions = new HashSet<Question>();
        }

        [Key]
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        [MaxLength(QuizConstants.QuestionMaxLength)]
        [MinLength(QuizConstants.QuestionMinLength)]
        public string Title { get; set; }

        public virtual ICollection<Question> Question
        {
            get { return this.questions; }
            set { this.questions = value; }
        }
    }
}
