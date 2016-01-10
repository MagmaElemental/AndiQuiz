namespace AndiQuiz.Server.Api.Models.Quiz
{
    using AndiQuiz.Server.Api.Infrastructure.Mappings;
    using Data.Models;

    public class QuizTitlesResponseModel : IMapFrom<Quiz>
    {
        public string Title { get; set; }
    }
}