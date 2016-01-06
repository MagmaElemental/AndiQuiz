﻿namespace AndiQuiz.Server.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserAnswer
    {
        [Key]
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public int? QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public int AnswerId { get; set; }

        public virtual Answer Answer { get; set; }
   }
}
