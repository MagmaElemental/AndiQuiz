namespace AndiQuiz.Server.Api.Models.Users
{
    public class UserDetailsResponseModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public ulong CorrectAnswers { get; set; }

        public ulong TotalAnswers { get; set; }
    }
}