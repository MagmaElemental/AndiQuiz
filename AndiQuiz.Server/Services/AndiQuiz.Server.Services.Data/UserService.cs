namespace AndiQuiz.Server.Services.Data
{
    using System.Linq;
    using Contracts;
    using Server.Data.Models;
    using Server.Data.Repositories;
    using System.Collections.Generic;
    using System;

    public class UserService : IUserService
    {
        private readonly IRepository<User> users;

        public UserService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetUserByUserName(string userName)
        {
            var resultUser = this.users
                .All()
                .Where(u => u.UserName == userName);

            return resultUser;
        }
    }
}
