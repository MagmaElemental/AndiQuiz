namespace AndiQuiz.Server.Api.Models.Quiz
{
    using System.ComponentModel.DataAnnotations;

    public class QuizAnswersBindingModel
    {
        [Required]
        public int QuizId { get; set; }

        // answers Ids
        [Required]
        public int[] AnswersIds { get; set; }
    }
}