﻿namespace AndiQuiz.Server.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class QuizRating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1,5)]
        public int Rate { get; set; }
        
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int QuizId { get; set; }
        
        public virtual Quiz Quiz { get; set; }
    }
}
