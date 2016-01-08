namespace AndiQuiz.Server.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Server.Data.Models;
    using Server.Data.Repositories;

    public class QuizService : IQuizService
    {
        private readonly IRepository<Question> questions;
        private readonly IRepository<Answer> answers;
        private readonly IRepository<Quiz> quizs;

        public QuizService(IRepository<Question> questions, IRepository<Answer> answers, IRepository<Quiz> quizs)
        {
            this.questions = questions;
            this.answers = answers;
            this.quizs = quizs;
        }

        public IQueryable<Question> GetQuestionsForQuiz(int quizId)
        {
            var questions = this.questions
                .All()
                .Where(q => q.QuizId == quizId);

            return questions;
        }

        public IQueryable<Quiz> GetAllQuizsForCategory(int categoryId)
        {
            var quizs = this.quizs
                .All()
                .Where(q => q.CategoryId == categoryId);

            return quizs;
        }

        public IQueryable<Quiz> GetAllQuizs()
        {
            var quizs = this.quizs
                .All();

            return quizs;
        }

        public Answer MakeAnswer(AnswerType answerType, string description, int questionId, int quizId)
        {
            var newAnswer = new Answer
            {
                QuestionId = questionId,
                AnswerIs = answerType,
                Content = description
            };

            this.answers.Add(newAnswer);
            this.answers.SaveChanges();

            return newAnswer;
        }

        public Question MakeQuestion(int quizType, string description)
        {
            var newQuestion = new Question
            {
                 QuizId = quizType,
                 Content = description
            };

            this.questions.Add(newQuestion);
            this.questions.SaveChanges();

            return newQuestion;
        }
    }
}
