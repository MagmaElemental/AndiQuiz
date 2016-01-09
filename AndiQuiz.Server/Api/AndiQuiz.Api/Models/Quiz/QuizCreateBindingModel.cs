namespace AndiQuiz.Server.Api.Models.Quiz
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class QuizCreateBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public BindingQuestion[] Questions { get; set; }
    }

    public class BindingQuestion
    {
        [Required]
        [MinLength(QuizConstants.QuestionMinLength)]
        [MaxLength(QuizConstants.QuestionMaxLength)]
        public string QuestionContent { get; set; }
        
        [Required]
        public BindingAnswer[] Answers { get; set; }
    }

    public class BindingAnswer
    {
        [Required]
        [MinLength(QuizConstants.MinAnswerLength)]
        [MaxLength(QuizConstants.MaxAnswerLength)]
        public string AnswerContent { get; set; }

        [Required]
        public bool AnswerIs { get; set; }
    }
}