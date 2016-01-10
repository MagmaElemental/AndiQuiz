namespace AndiQuiz.Server.Api.Models.QuizRate
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class QuizRateBindingModel
    {
        [Required]
        [Range(1,5, ErrorMessage = GlobalConstants.WrongRatingErrorMessage)]
        public int Rating { get; set; }
    }
}