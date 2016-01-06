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

    [RoutePrefix("api/Quiz")]
    public class QuizController : ApiController
    {
        private readonly IQuizService quiz;
        private readonly IAnswerService answer;

        public QuizController(IQuizService quiz, IAnswerService answer)
        {
            this.quiz = quiz;
            this.answer = answer;
        }

        [Route("Score")]
        [HttpPost]
        public IHttpActionResult GetQuizScore(QuizAnswersBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var answers = this.answer.GetAnswersByIds(model.AnswersIds);
            this.answer.MakeUserAnswers(model.UserId, answers);

            var score = 0;
            foreach (var answer in answers)
            {
                if ((int)answer.AnswerIs == 1)
                {
                    score++;
                }
            }

            return this.Ok(score);
        }

        [Route("Questions/{quizType}")]
        [HttpGet]
        public IHttpActionResult GetQuestionsByType(int quizId)
        {
                var questionsResult = this.quiz
                .GetQuestionsForQuiz(quizId)
                .ProjectTo<QuestionsDetailsResponseModel>()
                .ToList();

            return this.Ok(questionsResult);
        }

        [Route("Titles")]
        [HttpGet]
        public IHttpActionResult GetQuizTitles()
        {
            var quizTitles = this.quiz
            .GetQuizTitles()
            .ProjectTo<QuizTitleDetailsResponseModel>()
            .ToList();

            return this.Ok(quizTitles);
        }
    }
}
