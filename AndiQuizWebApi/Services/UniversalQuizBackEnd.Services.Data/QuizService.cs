namespace UniversalQuizBackEnd.Services.Data
{
    using System.Linq;
    using UniversalQuizBackEnd.Data.Models;
    using UniversalQuizBackEnd.Data.Repositories;
    using UniversalQuizBackEnd.Services.Data.Contracts;

    public class QuizService : IQuizService
    {
        private readonly IRepository<QuizQuestion> questions;
        private readonly IRepository<QuizAnswer> answers;
        private readonly IRepository<QuizTest> quizTests;

        public QuizService(IRepository<QuizQuestion> questions, IRepository<QuizAnswer> answers, IRepository<QuizTest> quizTests)
        {
            this.questions = questions;
            this.answers = answers;
            this.quizTests = quizTests;
        }

        public IQueryable<QuizQuestion> GetQuestionByQuizType(int typeQuiz)
        {
            var resultQuestions = this.questions
                .All()
                .Where(q => q.QuizTestId == typeQuiz);

            return resultQuestions;
        }

        public IQueryable<QuizTest> GetQuizTitles()
        {
            var resultTitles = this.quizTests
                .All();

            return resultTitles;
        }

        public QuizAnswer MakeAnswer(AnswerType answerType, string description, int questionId, int typeQuiz)
        {
            var newAnswer = new QuizAnswer
            {
                QuizQuestionId = questionId,
                AnswerIs = answerType,
                Answer = description
            };

            this.answers.Add(newAnswer);
            this.answers.SaveChanges();

            return newAnswer;
        }

        public QuizQuestion MakeQuestion(int quizType, string description)
        {
            var newQuestion = new QuizQuestion
            {
                 QuizTestId = quizType,
                 Question = description
            };

            this.questions.Add(newQuestion);
            this.questions.SaveChanges();

            return newQuestion;
        }
    }
}
