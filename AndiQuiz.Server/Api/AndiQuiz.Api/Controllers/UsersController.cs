namespace AndiQuiz.Server.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using AutoMapper;
    using System.Net.Http;
    using Infrastructure.Validation;
    using Models.Users;
    using Services.Data.Contracts;
    using Models.Quiz;
    using Common.Constants;
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private readonly IUserService users;
        private readonly IUserStatisticService userStatistics;
        private readonly IQuizService quizzes;

        public UsersController(IUserService users, IUserStatisticService userStatistics, IQuizService quizzes)
        {
            this.users = users;
            this.userStatistics = userStatistics;
            this.quizzes = quizzes;
        }

        [HttpGet]
        [Authorize]
        [Route("{userName}/quizzes", Order = 1)]
        public IHttpActionResult GetAllQuizzesForUser(string userName, int page = 1, int pageSize = GlobalConstants.DefaultPageSize)
        {
            var user = this.users
                .GetUserByUserName(userName)
                .FirstOrDefault();

            if (user == null)
            {
                return this.BadRequest();
            }

            var quizzes = this.quizzes
                .GetAllQuizzesForUser(user)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<QuizDetailsResponseModel>()
                .ToList();

            return this.Ok(quizzes);
        }

        [HttpGet]
        [Route("{userName}", Order = 2)]
        public IHttpActionResult GetUserDetails(string userName)
        {
            var user = this.users
                .GetUserByUserName(userName)
                .FirstOrDefault();

            if (user == null)
            {
                return this.BadRequest();
            }

            var userStatistics = this.userStatistics
                .GetAllStatisticsForUser(user)
                .ToList();

            ulong answeredCorrectly = 0;
            ulong totalAnswersGiven = 0;
            foreach (var statistic in userStatistics)
            {
                answeredCorrectly += (ulong)statistic.CorrectAnswers;
                totalAnswersGiven += (ulong)statistic.TotalQuizAnswers;
            }

            var details = new UserDetailsResponseModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
                CorrectAnswers = answeredCorrectly,
                TotalAnswers = totalAnswersGiven
            };


            return this.Ok(details);
        }
    }
}