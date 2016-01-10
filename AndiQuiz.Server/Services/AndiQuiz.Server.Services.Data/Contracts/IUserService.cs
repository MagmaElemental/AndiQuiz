namespace AndiQuiz.Server.Services.Data.Contracts
{
    using System.Linq;
    using Server.Data.Models;

    public interface IUserService
    {
        IQueryable<User> GetUserByUserName(string userName);

        IQueryable<User> GetAllUsers();
    }
}
