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
            var user = this.users.GetUserById(userId);

            var details = this.users
                    .GetUserById(userId)
                    .ProjectTo<UserDetailsResponseModel>()
                    .FirstOrDefault();

            return this.Ok(details);
        }
    }
}