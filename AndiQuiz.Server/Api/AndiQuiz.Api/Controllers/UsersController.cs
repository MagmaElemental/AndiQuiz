namespace AndiQuiz.Server.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Common.Constants;
    using Models.Users;
    using Models.Quiz;
    using Services.Data.Contracts;
    using System.Collections.Generic;
    using Data.Models;
    using AutoMapper;
    using Models.UserQuizStatistic;
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
        [Route("All")]
        public IHttpActionResult GetAllUserNames(int page = 1, int pageSize = GlobalConstants.DefaultPageSize)
        {
            var userNames = this.users
                .GetAllUsers()
                .OrderBy(u => u.UserName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<UserNamesResponseModel>()
                .ToList();

            return this.Ok(userNames);
        }

        [HttpGet]
        [Authorize]
        [Route("{userName}/Quizzes", Order = 1)]
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
        [Authorize]
        [Route("{userName}", Order = 2)]
        public IHttpActionResult GetUserDetails(string userName)
        {
            var currentUserName = this.User.Identity.Name;
            var user = this.users
                .GetUserByUserName(userName)
                .FirstOrDefault();

            if (user == null)
            {
                return this.BadRequest(GlobalConstants.WrongUserNameErrorMessage);
            }

            var userStatistics = this.userStatistics
                .GetAllStatisticsForUser(user)
                .ToList();

            var uniqueUserStatistics = new Dictionary<int, UserQuizStatistic>();
            ulong answeredCorrectly = 0;
            ulong totalAnswersGiven = 0;
            foreach (var statistic in userStatistics)
            {
                if (!uniqueUserStatistics.ContainsKey(statistic.QuizId))
                {
                    uniqueUserStatistics.Add(statistic.QuizId, statistic);
                }

                answeredCorrectly += (ulong)statistic.CorrectAnswers;
                totalAnswersGiven += (ulong)statistic.TotalQuizAnswers;
            }

            var details = new UserDetailsResponseModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                CorrectAnswers = answeredCorrectly,
                TotalAnswers = totalAnswersGiven
            };

            // checking his own profile
            // shows recently played games
            if (currentUserName == userName)
            {
                var personalDetails = new PersonalUserDetailsResponseModel(details);

                personalDetails.RecentlyPlayed = uniqueUserStatistics
                    .Take(QuizConstants.TakeUserPersonalGamesPlayed)
                    .Select(s => Mapper.Map<UserQuizStatisticResponseModel>(s.Value));

                return this.Ok(personalDetails);
            }


            return this.Ok(details);
        }
    }
}