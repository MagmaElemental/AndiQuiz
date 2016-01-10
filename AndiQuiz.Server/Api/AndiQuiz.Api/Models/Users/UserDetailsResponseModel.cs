namespace AndiQuiz.Server.Api.Models.Users
{
    public class UserDetailsResponseModel
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ulong CorrectAnswers { get; set; }

        public ulong TotalAnswers { get; set; }
    }
}