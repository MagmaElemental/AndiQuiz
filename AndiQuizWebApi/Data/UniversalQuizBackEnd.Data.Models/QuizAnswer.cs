namespace UniversalQuizBackEnd.Data.Models
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class QuizAnswer
    {
        [Key]
        public int Id { get; set; }

        public AnswerType AnswerIs { get; set; }

        [MinLength(QuizConstants.MinAnswerLength)]
        [MaxLength(QuizConstants.MaxAnswerLength)]
        public string Answer { get; set; }

        public int QuizQuestionId { get; set; }

        public virtual QuizQuestion QuizQuestion { get; set; }
    }
}
