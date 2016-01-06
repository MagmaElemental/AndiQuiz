namespace AndiQuiz.Server.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Quiz> quizs;

        public Category()
        {
            this.quizs = new HashSet<Quiz>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Quiz> Quizs
        {
            get { return this.quizs; }
            set { this.quizs = value; }
        }
    }
}
