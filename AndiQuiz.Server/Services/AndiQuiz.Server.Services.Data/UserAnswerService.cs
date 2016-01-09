namespace AndiQuiz.Server.Services.Data
{
    using System.Collections.Generic;
    using Server.Data.Models;
    using Server.Data.Repositories;
    using Contracts; 

    public class UserAnswerService : IUserAnswerService
    {
        private IRepository<UserAnswer> userAnswers;

        public UserAnswerService(IRepository<UserAnswer> userAnswers)
        {
            this.userAnswers = userAnswers;
        }

        public void MakeUserAnswers(User user, List<Answer> answers)
        {
            foreach (var answer in answers)
            {
                var currentUserAnswer = new UserAnswer()
                {
                    UserId = user.Id,
                    QuestionId = answer.QuestionId,
                    AnswerId = answer.Id
                };

                this.userAnswers.Add(currentUserAnswer);
            }

            this.userAnswers.SaveChanges();
        }
    }
}
