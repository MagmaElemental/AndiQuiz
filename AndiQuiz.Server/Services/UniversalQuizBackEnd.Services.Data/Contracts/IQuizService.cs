namespace AndiQuiz.Server.Services.Contracts
{
    using System.Linq;
    using Data.Models;

    public interface IQuizService
    {
        QuizAnswer MakeAnswer(AnswerType answerType, string description, int questionId, int typeQuiz);

        QuizQuestion MakeQuestion(int quizType, string description);

        IQueryable<QuizQuestion> GetQuestionByQuizType(int typeQuiz);

        IQueryable<QuizTest> GetQuizTitles();
    }
}
