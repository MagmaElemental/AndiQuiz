namespace UniversalQuizBackEnd.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserAnswer
    {
        [Key]
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public int? QuizQuestionId { get; set; }

        public virtual QuizQuestion QuizQuestion { get; set; }

        public int QuizAnswerId { get; set; }

        public virtual QuizAnswer QuizAnswer { get; set; }

        public DateTime AnsweredOn { get; set; }
   }
}
