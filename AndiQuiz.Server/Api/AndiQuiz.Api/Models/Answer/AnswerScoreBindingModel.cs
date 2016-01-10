namespace AndiQuiz.Server.Api.Models.Answer
{
    using System.ComponentModel.DataAnnotations;

    public class AnswerScoreBindingModel
    {
        [Required]
        public int QuizId { get; set; }

        // answers Ids
        [Required]
        public int[] AnswersIds { get; set; }
    }
}