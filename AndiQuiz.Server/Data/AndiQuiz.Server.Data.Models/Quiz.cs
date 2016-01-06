namespace AndiQuiz.Server.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Quiz
    {
        private ICollection<Question> questions;

        public Quiz()
        {
            this.questions = new HashSet<Question>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(QuizConstants.QuestionMinLength)]
        [MaxLength(QuizConstants.QuestionMaxLength)]
        public string Title { get; set; }
        
        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        
        public virtual ICollection<Question> Questions
        {
            get { return this.questions; }
            set { this.questions = value; }
        }
    }
}
