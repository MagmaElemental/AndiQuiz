namespace AndiQuiz.Server.Services.Data
{
    using System;
    using System.Collections.Generic;
    using Server.Data.Models;
    using Server.Data.Repositories;
    using AndiQuiz.Server.Services.Data.Contracts;

    public class QuestionService : IQuestionService
    {
        private IRepository<Question> questions;
             
        public QuestionService(IRepository<Question> questions)
        {
            this.questions = questions;
        }
        
        public void MakeQuestions(Quiz quiz, ICollection<string> questionsContent)
        {
            foreach (var content in questionsContent)
            {
                var newQuestion = new Question
                {
                    QuizId = quiz.Id,
                    Content = content
                };

                this.questions.Add(newQuestion);
            }

            this.questions.SaveChanges();
        }
    }
}
