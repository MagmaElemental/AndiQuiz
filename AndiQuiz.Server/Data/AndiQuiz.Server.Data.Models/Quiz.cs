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
        private ICollection<QuizRating> ratings;
        private ICollection<UserQuizStatistic> userQuizStatistics;

        public Quiz()
        {
            this.questions = new HashSet<Question>();
            this.ratings = new HashSet<QuizRating>();
            this.userQuizStatistics = new HashSet<UserQuizStatistic>();
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

        public virtual ICollection<QuizRating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<UserQuizStatistic> UserQuizStatistics
        {
            get { return this.userQuizStatistics; }
            set { this.userQuizStatistics = value; }
        }
    }
}
