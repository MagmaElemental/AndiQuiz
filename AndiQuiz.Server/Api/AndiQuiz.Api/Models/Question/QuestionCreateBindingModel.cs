namespace AndiQuiz.Server.Api.Models.Question
{
    using System.ComponentModel.DataAnnotations;
    using Answer;
    using Common.Constants;

    public class QuestionCreateBindingModel
    {
        private const string MustHaveAtleastOneAnswerErrorMessage = "Sorry Question must have atleast one answer!";

        [Required]
        [MinLength(QuizConstants.QuestionMinLength)]
        [MaxLength(QuizConstants.QuestionMaxLength)]
        public string QuestionContent { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = MustHaveAtleastOneAnswerErrorMessage)]
        public AnswerCreateBindingModel[] Answers { get; set; }
    }
}