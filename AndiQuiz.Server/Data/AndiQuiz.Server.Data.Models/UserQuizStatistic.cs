namespace AndiQuiz.Server.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserQuizStatistic
    {
        [Key]
        public int Id { get; set; }
        
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int QuizId { get; set; }
        
        public virtual Quiz Quiz { get; set; }

        [Required]
        public int CorrectAnswers { get; set; }

        [Required]
        public int TotalQuizAnswers { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
