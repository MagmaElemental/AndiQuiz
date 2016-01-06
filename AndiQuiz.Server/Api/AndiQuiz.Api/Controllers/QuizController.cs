namespace AndiQuiz.Server.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using AutoMapper.QueryableExtensions;
    using Models.Quiz;
    using Services.Contracts;

    [RoutePrefix("api/Quiz")]
    public class QuizController : ApiController
    {
        private readonly IQuizService quiz;

        public QuizController(IQuizService quiz)
        {
            this.quiz = quiz;
        }

        [Route("Questions/{quizType}")]
        [HttpGet]
        public IHttpActionResult GetQuestionsByType(int quizType)
        {
            //if (this.User.Identity.IsAuthenticated)
            //{
                var questionsResult = this.quiz
                .GetQuestionByQuizType(quizType)
                .ProjectTo<QuestionsDetailsResponseModel>()
                .ToList();

            return this.Ok(questionsResult);
            //}
            //return this.Request.CreateResponse(HttpStatusCode.Unauthorized);

        }

        [Route("Titles")]
        [HttpGet]
        public IHttpActionResult GetQuizTitles()
        {
            //if (this.User.Identity.IsAuthenticated)
            //{
            var quizTitles = this.quiz
            .GetQuizTitles()
            .ProjectTo<QuizTitleDetailsResponseModel>()
            .ToList();

            return this.Ok(quizTitles);
            //}
            //return this.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
    }
}
