namespace AndiQuiz.Server.Services.Data
{
    using System.Collections.Generic;
    using Server.Data.Models;
    using Contracts;
    using Server.Data.Repositories;
    using System.Linq;
    using System;
    public class AnswerService : IAnswerService
    {
        private readonly IRepository<Answer> answers;
        private readonly IRepository<UserAnswer> userAnswers;

        public AnswerService(IRepository<Answer> answers, IRepository<UserAnswer> userAnswers)
        {
            this.answers = answers;
            this.userAnswers = userAnswers;
        }

        public List<Answer> GetAnswersByIds(int[] answersIds)
        {
            var resultQuestions = this.answers
                    .All()
                    .Where(a => answersIds.Any(i => i == a.Id))
                    .ToList();

            return resultQuestions;
        }

        public void MakeUserAnswers(string userId, List<Answer> answers)
        {
            foreach (var answer in answers)
            {
                var currentUserAnswer = new UserAnswer()
                {
                    UserId = Guid.Parse(userId),
                    QuestionId = answer.QuestionId,
                    AnswerId = answer.Id
                };

                this.userAnswers.Add(currentUserAnswer);
            }

            this.answers.SaveChanges();
        }
    }
}
