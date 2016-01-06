namespace AndiQuiz.Server.Services.Data
{
    using System.Linq;
    using Contracts;
    using Server.Data.Models;
    using Server.Data.Repositories;

    public class UserService : IUserService
    {
        private readonly IRepository<User> users;

        public UserService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetUserById(string userId)
        {
            var user = this.users
                .All()
                .Where(u => u.Id == userId);

            return user;
        }
    }
}
