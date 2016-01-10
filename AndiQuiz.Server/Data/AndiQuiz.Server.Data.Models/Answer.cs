namespace AndiQuiz.Server.Data.Models
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool AnswerIs { get; set; }

        [Required]
        [Column("Answer")]
        [MinLength(QuizConstants.AnswerMinLength)]
        [MaxLength(QuizConstants.AnswerMaxLength)]
        public string Content { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}
