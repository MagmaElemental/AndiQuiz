namespace AndiQuiz.Server.Services.Data.Contracts
{
    using System.Linq;
    using AndiQuiz.Server.Data.Models;
    using System.Collections.Generic;

    public interface IAnswerService
    {
        IQueryable<Answer> GetAnswersByIds(int[] answersIds);

        void MakeAnswer(Question question, string description, bool answerType);

        void SaveAnswers();
    }
}
