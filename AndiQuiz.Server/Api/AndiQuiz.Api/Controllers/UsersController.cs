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

    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private readonly IUserService users;

        public UsersController(IUserService users)
        {
            this.users = users;
        }

        [HttpGet]
        [Route("{userId}")]
        public IHttpActionResult GetUserDetails(string userId)
        {
            var user = this.users.GetUserById(userId).FirstOrDefault();
            if (user == null)
            {
                return this.BadRequest();
            }

            var userStatistics = this.users.GetAllStatisticsForUser(userId);
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

        [HttpGet]
        [Route("{userId}/quizs")]
        public IHttpActionResult GetAllQuizsForUser(string userId)
        {
            var quizs = this.users
                .GetAllQuizsForUser(userId)
                .ToList();

            return this.Ok(quizs);
        }
    }
}