﻿namespace AndiQuiz.Server.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserScore
    {
        [Key]
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public int QuizId { get; set; }

        public virtual Quiz Quiz { get; set; }

        public DateTime AnsweredOn { get; set; }
    }
}