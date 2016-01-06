namespace AndiQuiz.Server.Data.Models
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class Answer
    {
        [Key]
        public int Id { get; set; }

        public AnswerType AnswerIs { get; set; }

        [MinLength(QuizConstants.MinAnswerLength)]
        [MaxLength(QuizConstants.MaxAnswerLength)]
        public string Content { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
