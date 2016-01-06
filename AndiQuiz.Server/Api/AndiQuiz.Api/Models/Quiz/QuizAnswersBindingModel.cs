namespace AndiQuiz.Server.Api.Models.Quiz
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class QuizAnswersBindingModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int QuizId { get; set; }

        // answers Ids
        [Required]
        public int[] AnswersIds { get; set; }
    }
}