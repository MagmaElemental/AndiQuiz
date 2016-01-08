namespace AndiQuiz.Server.Services.Data.Contracts
{
    using System.Linq;
    using System.Collections.Generic;
    using Server.Data.Models;

    public interface IQuizService
    {
        Answer MakeAnswer(AnswerType answerType, string description, int questionId, int typeQuiz);

        Question MakeQuestion(int quizType, string description);

        IQueryable<Question> GetQuestionsForQuiz(int testId);

        IQueryable<Quiz> GetAllQuizs();
    }
}
