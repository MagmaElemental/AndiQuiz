namespace AndiQuiz.Server.Services.Data
{
    using System.Linq;
    using Contracts;
    using Server.Data.Models;
    using Server.Data.Repositories;

    public class QuizService : IQuizService
    {
        private readonly IRepository<Question> questions;
        private readonly IRepository<Answer> answers;
        private readonly IRepository<Test> quizTests;

        public QuizService(IRepository<Question> questions, IRepository<Answer> answers, IRepository<Test> quizTests)
        {
            this.questions = questions;
            this.answers = answers;
            this.quizTests = quizTests;
        }

        public IQueryable<Question> GetQuestionsForTest(int testId)
        {
            var resultQuestions = this.questions
                .All()
                .Where(q => q.TestId == testId);

            return resultQuestions;
        }

        //public IQueryable<Test> GetAllTestNamesForCategory(Category category)
        //{

        //}

        public IQueryable<Test> GetQuizTitles()
        {
            var resultTitles = this.quizTests
                .All();

            return resultTitles;
        }

        //public int GetScoreForExamAnswers(string jsonObject)
        //{
        //    var model = JsonConvert.DeserializeObject<TestAnswersBindingModel>
        //}

        public Answer MakeAnswer(AnswerType answerType, string description, int questionId, int testId)
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
                 TestId = quizType,
                 Content = description
            };

            this.questions.Add(newQuestion);
            this.questions.SaveChanges();

            return newQuestion;
        }
    }
}
