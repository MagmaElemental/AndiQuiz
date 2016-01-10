namespace AndiQuiz.Server.Api.Models.Users
{
    using AndiQuiz.Server.Api.Infrastructure.Mappings;
    using AndiQuiz.Server.Data.Models;

    public class UserNamesResponseModel : IMapFrom<User>
    {
        public string UserName { get; set; }
    }
}