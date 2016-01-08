namespace AndiQuiz.Server.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using AutoMapper.QueryableExtensions;
    using Models.Quiz;
    using AndiQuiz.Server.Services.Data.Contracts;
    using Newtonsoft.Json;
    using Data.Models;
    using System.Collections.Generic;
    using Common.Constants;

    [RoutePrefix("api/Quiz")]
    public class QuizController : ApiController
    {
        private readonly IQuizService quizs;
        private readonly IAnswerService answers;
        private readonly IUserService users;

        public QuizController(IQuizService quizs, IAnswerService answers, IUserService users)
        {
            this.quizs = quizs;
            this.answers = answers;
            this.users = users;
        }

        [HttpPost]
        [Route("Score")]
        public IHttpActionResult GetQuizScore(QuizAnswersBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var answers = this.answers.GetAnswersByIds(model.AnswersIds);
            this.users.MakeUserAnswers(model.UserId, answers);

            var score = 0;
            foreach (var answer in answers)
            {
                if ((int)answer.AnswerIs == 1)
                {
                    score++;
                }
            }

            this.users.MakeUserStatistic(model.UserId, model.QuizId, score, answers.Count);

            return this.Ok(score);
        }

        [HttpGet]
        [Route("{quizId}/Questions")]
        public IHttpActionResult GetQuestionsForQuiz(int quizId)
        {
            var questions = this.quizs
                .GetQuestionsForQuiz(quizId)
                .ProjectTo<QuestionsDetailsResponseModel>()
                .ToList();

            return this.Ok(questions);
        }

        //[HttpGet]
        //[Route("{quizId}")]
        //public IHttpActionResult GetQuizDetails(int quizId)
        //{
        //    var quiz = this.quizs.GetAllRatingsForQuiz(quizId)
        //        .ProjectTo <;
        //}

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAllQuizDetails(int page = 1, int pageSize = GlobalConstants.DefaultPageSize)
        {
            var quizTitles = this.quizs
                .GetAllQuizs()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<QuizTitleDetailsResponseModel>()
                .ToList();

            return this.Ok(quizTitles);
        }
    }
}
