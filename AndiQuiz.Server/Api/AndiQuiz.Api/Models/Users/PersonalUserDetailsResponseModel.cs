namespace AndiQuiz.Server.Api.Models.Users
{
    using System.Collections.Generic;
    using UserQuizStatistic;

    public class PersonalUserDetailsResponseModel : UserDetailsResponseModel
    {
        public PersonalUserDetailsResponseModel(UserDetailsResponseModel details)
        {
            this.FirstName = details.FirstName;
            this.LastName = details.LastName;
            this.UserName = details.UserName;
            this.CorrectAnswers = details.CorrectAnswers;
            this.TotalAnswers = details.TotalAnswers;
        }

        public IEnumerable<UserQuizStatisticResponseModel> RecentlyPlayed { get; set; }
    }
}