namespace AndiQuiz.Server.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserScore
    {
        [Key]
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public int TestId { get; set; }

        public virtual Test Test { get; set; }

        public DateTime AnsweredOn { get; set; }
    }
}
