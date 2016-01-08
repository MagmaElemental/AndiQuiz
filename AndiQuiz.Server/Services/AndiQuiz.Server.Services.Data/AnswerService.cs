namespace AndiQuiz.Server.Services.Data
{
    using System.Collections.Generic;
    using Server.Data.Models;
    using Contracts;
    using Server.Data.Repositories;
    using System.Linq;

    public class AnswerService : IAnswerService
    {
        private readonly IRepository<User> users;
        private readonly IRepository<Answer> answers;

        public AnswerService(IRepository<User> users, IRepository<Answer> answers)
        {
            this.users = users;
            this.answers = answers;
    }

        public List<Answer> GetAnswersByIds(int[] answersIds)
        {
            var resultQuestions = this.answers
                    .All()
                    .Where(a => answersIds.Any(i => i == a.Id))
                    .ToList();

            return resultQuestions;
        }
    }
}
