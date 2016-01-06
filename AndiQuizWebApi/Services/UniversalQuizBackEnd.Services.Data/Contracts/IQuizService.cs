namespace UniversalQuizBackEnd.Services.Data.Contracts
{
    using System.Linq;
    using UniversalQuizBackEnd.Data.Models;

    public interface IQuizService
    {
        QuizAnswer MakeAnswer(AnswerType answerType, string description, int questionId, int typeQuiz);

        QuizQuestion MakeQuestion(int quizType, string description);

        IQueryable<QuizQuestion> GetQuestionByQuizType(int typeQuiz);

        IQueryable<QuizTest> GetQuizTitles();
    }
}
