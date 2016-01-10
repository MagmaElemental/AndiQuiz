namespace AndiQuiz.Server.Api.Models.Quiz
{
    using Question;
    using System.ComponentModel.DataAnnotations;

    public class QuizCreateBindingModel
    {
        private const string MustHaveAtleastOneQuestionErrorMessage = "Sorry Quiz must have atleast one question!";

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = MustHaveAtleastOneQuestionErrorMessage)]
        public QuestionCreateBindingModel[] Questions { get; set; }
    }
}