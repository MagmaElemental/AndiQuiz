namespace AndiQuiz.Server.Api.Models.Quiz
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class TestAnswersBindingModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int TestId { get; set; }

        // answers Ids
        [Required]
        public int[] AnswersIds { get; set; }
    }
}