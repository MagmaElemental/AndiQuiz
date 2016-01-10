namespace AndiQuiz.Server.Api.Models.Answer
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class AnswerCreateBindingModel
    {
        [Required]
        [MinLength(QuizConstants.AnswerMinLength)]
        [MaxLength(QuizConstants.AnswerMaxLength)]
        public string AnswerContent { get; set; }

        [Required]
        public bool AnswerIs { get; set; }
    }
}