namespace AndiQuiz.Server.Services.Data
{
    using System.Collections.Generic;
    using Server.Data.Models;
    using Contracts;
    using Server.Data.Repositories;
    using System.Linq;

    public class AnswerService : IAnswerService
    {
        private readonly IRepository<Answer> answers;

        public AnswerService(IRepository<Answer> answers)
        {
            this.answers = answers;
        }

        public IQueryable<Answer> GetAnswersByIds(int[] answersIds)
        {
            var resultQuestions = this.answers
                    .All()
                    .Where(a => answersIds.Any(i => i == a.Id));

            return resultQuestions;
        }
        
        /// <remarks>
        /// instance of AnswerService must call method SaveAnswers(), otherwise they are not saved to the db, just added.
        /// </remarks>
        public void MakeAnswer(Question question, string description, bool answerType)
        {
            var newAnswer = new Answer
            {
                QuestionId = question.Id,
                Content = description,
                AnswerIs = answerType
            };

            this.answers.Add(newAnswer);
        }

        public void SaveAnswers()
        {
            this.answers.SaveChanges();
        }
    }
}
