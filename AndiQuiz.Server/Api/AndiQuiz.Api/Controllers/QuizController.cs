namespace AndiQuiz.Server.Api.Controllers
{
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using System.Web.Http;
    using Common.Constants;
    using Models.Quiz;
    using AndiQuiz.Server.Services.Data.Contracts;

    [RoutePrefix("api/Quiz")]
    public class QuizController : ApiController
    {
        private readonly IQuizService quizzes;
        private readonly IAnswerService answers;
        private readonly IUserService users;
        private readonly IUserAnswerService userAnswers;
        private readonly IUserStatisticService userStatistics;
        private readonly ICategoryService categories;
        private readonly IQuestionService questions;

        public QuizController(IQuizService quizzes,
            IAnswerService answers,
            IUserService users,
            IUserAnswerService userAnswers,
            IUserStatisticService userStatistics,
            ICategoryService categories,
            IQuestionService questions)
        {
            this.quizzes = quizzes;
            this.answers = answers;
            this.users = users;
            this.userAnswers = userAnswers;
            this.userStatistics = userStatistics;
            this.categories = categories;
            this.questions = questions;
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(QuizCreateBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var userName = this.User.Identity.Name;
            var user = this.users
                .GetUserByUserName(userName)
                .FirstOrDefault();

            var category = this.categories
                .GetAllCategories()
                .Where(c => c.Name == model.Category)
                .FirstOrDefault();

            if (category == null)
            {
                category = this.categories.MakeCategory(model.Category);
            }

            // TODO: Check for duplicate entries in db, BadRequest
            // creating quiz
            var quiz = this.quizzes
                .MakeQuiz(user, model.Title, category);

            // creating questions for quiz
            var questionsContent = model.Questions.Select(q => q.QuestionContent).ToList();
            this.questions.MakeQuestions(quiz, questionsContent);
            var questionsAdded = this.quizzes
                .GetQuestionsForQuiz(quiz)
                .ToList();

            // creating answers for questions
            foreach (var addedQuestion in questionsAdded)
            {
                BindingAnswer[] questionAnswers;
                foreach (var question in model.Questions)
                {
                    if (question.QuestionContent == addedQuestion.Content)
                    {
                        questionAnswers = question.Answers;
                        for (int i = 0; i < questionAnswers.Length; i++)
                        {
                            this.answers.MakeAnswer(addedQuestion, questionAnswers[i].AnswerContent, questionAnswers[i].AnswerIs);
                        }

                        break;
                    }
                }
            }

            this.answers.SaveAnswers();

            return this.Ok();
        }

        [HttpPost]
        [Authorize]
        [Route("Score")]
        public IHttpActionResult GetQuizScore(QuizAnswersBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var userName = this.User.Identity.Name;
            var user = this.users
                .GetUserByUserName(userName)
                .FirstOrDefault();

            var answers = this.answers
                .GetAnswersByIds(model.AnswersIds)
                .ToList();

            this.userAnswers.MakeUserAnswers(user, answers);

            var score = 0;
            foreach (var answer in answers)
            {
                if (answer.AnswerIs)
                {
                    score++;
                }
            }

            this.userStatistics.MakeUserStatistic(user, model.QuizId, score, answers.Count);

            return this.Ok(score);  
        }

        [HttpGet]
        [Authorize]
        [Route("{quizId}/Questions")]
        public IHttpActionResult GetQuestionsForQuiz(int quizId)
        {
            var quiz = this.quizzes
                .GetAllQuizzes()
                .Where(q => q.Id == quizId)
                .FirstOrDefault();

            if (quiz == null)
            {
                return this.BadRequest();
            }

            var questions = this.quizzes
                .GetQuestionsForQuiz(quiz)
                .ProjectTo<QuestionDetailsResponseModel>()
                .ToList();

            return this.Ok(questions);
        }

        [HttpGet]
        [Authorize]
        [Route("All")]
        public IHttpActionResult GetAllQuizDetails(int page = 1, int pageSize = GlobalConstants.DefaultPageSize)
        {
            var quizDetails = this.quizzes
                .GetAllQuizzes()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<QuizDetailsResponseModel>()
                .ToList();

            return this.Ok(quizDetails);
        }
    }
}
