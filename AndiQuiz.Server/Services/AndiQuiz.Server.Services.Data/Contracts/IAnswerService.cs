namespace AndiQuiz.Server.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using AndiQuiz.Server.Data.Models;

    public interface IAnswerService
    {
        List<Answer> GetAnswersByIds(int[] answersIds);

        void MakeUserAnswers(string userId, List<Answer> answers);
    }
}
